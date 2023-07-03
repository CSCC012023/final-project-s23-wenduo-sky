using Firebase.Auth.Providers;
using Firebase.Auth;
using FirebaseAdmin;
using yourscope_api.entities;
using yourscope_api.Models.DbModels;
using User = yourscope_api.Models.DbModels.User;
using yourscope_api.Models.Request;
using Microsoft.EntityFrameworkCore;

namespace yourscope_api.service
{
    public class EventsService : IEventsService
    {
        #region class fields and constructors
        private readonly IConfiguration configuration;

        public EventsService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        #endregion

        public async Task<ApiResponse> CreateEventMethod(EventCreationDto eventDetails)
        {
            using var context = new YourScopeContext();
            // Retrieve the user object.
            User? user = context.Users.Where(user => user.UserId == eventDetails.UserId).FirstOrDefault();
            if (user is null)
                return new ApiResponse(StatusCodes.Status404NotFound, $"User with id {eventDetails.UserId} does not exist.", success: false);


            // Convert dto to Event object.
            Event createdEvent = new()
            {
                Title = eventDetails.Title,
                Description = eventDetails.Description,
                Date = eventDetails.Date,
                Location = eventDetails.Location,
                User = user
            };

            // Insert into db.
            context.Events.Add(createdEvent);
            await context.SaveChangesAsync();
            

            return new ApiResponse(StatusCodes.Status201Created, "Event successfully created!", true);
        }

        public async Task<ApiResponse> DeleteEventMethod(int id)
        {
            using var context = new YourScopeContext();

            // Ensure the event exists.
            Event? toDelete = GetEventById(id);
            if (toDelete is null)
                return new ApiResponse(StatusCodes.Status404NotFound, $"Event with id {id} does not exist.", success: false);

            // Removing the event from the db.
            context.Events.Remove(toDelete);
            await context.SaveChangesAsync();

            return new ApiResponse(StatusCodes.Status200OK, "Event sucessfully deleted.", data: true, success: true);
        }

        private bool FilterEvent(Event e, EventFilter filter)
        {
            return (filter.SchoolId is null || e.SchoolId is null || e.SchoolId == filter.SchoolId)
                && (filter.UserId is null || e.UserId is null || e.UserId == filter.UserId);
        }

        public async Task<ApiResponse> GetEventsMethod(EventFilter filter)
        {
            using var context = new YourScopeContext();

            List<Event> events = await context.Events.Where(e =>
                (filter.SchoolId == null || (e.SchoolId != null && e.SchoolId == filter.SchoolId)) // SchoolId filter.
                && (filter.UserId == null || (e.UserId != null && e.UserId == filter.UserId)) // UserId filter.
            )
            .Include(e => e.User)
            .Include(e => e.School)
            .Skip(filter.Offset)
            .Take(filter.Count)
            .ToListAsync();

            return new ApiResponse(StatusCodes.Status200OK, data: events, success: true);
        }

        #region helper methods
        private Event? GetEventById(int id)
        {
            using var context = new YourScopeContext();

            Event? result = context.Events.Where(e => e.EventId == id).FirstOrDefault();

            return result;
        }
        #endregion
    }
}
