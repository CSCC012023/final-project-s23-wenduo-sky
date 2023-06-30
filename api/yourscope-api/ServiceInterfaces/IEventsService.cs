using yourscope_api.entities;

namespace yourscope_api.service
{
    public interface IEventsService
    {
        public Task<ApiResponse> CreateEventMethod(EventCreationDto eventDetails);
        public Task<ApiResponse> DeleteEventMethod(int id);
    }
}
