using System;
using Microsoft.EntityFrameworkCore;
using yourscope_api.entities;
using yourscope_api.Models.DbModels;
using yourscope_api.Models.Reponse;

namespace yourscope_api.service
{
    public class StudentService : IStudentService
    {
        #region class fields and constructor
        private readonly IConfiguration configuration;

        public StudentService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        #endregion

        public async Task<ApiResponse> GetStudentScheduleMethod(int studentID)
        {
            Schedule? schedule = await GetScheduleFromDB(studentID);

            if (schedule is null)
                return new ApiResponse(StatusCodes.Status404NotFound, $"Student with ID {studentID} does not have a schedule. Please call the schedule creation endpoint to create one.");

            ScheduleDetails result = new(schedule);

            return new ApiResponse(StatusCodes.Status200OK, data: result, success: true);
        }

        #region helpers
        private static async Task<Schedule?> GetScheduleFromDB(int studentID)
        {
            using var context = new YourScopeContext();

            Schedule? schedule = await context.Schedules
                .Where(s => s.StudentId == studentID)
                .Include(s => s.Years)
                .ThenInclude(year => year.CourseYears)
                .ThenInclude(cy => cy.Course)
                .FirstOrDefaultAsync();

            return schedule;
        }
        #endregion
    }
}

