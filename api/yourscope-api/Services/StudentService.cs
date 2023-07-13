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

        public async Task<ApiResponse> CreateStudentScheduleMethod(int studentID)
        {
            Schedule? schedule = await GetScheduleFromDB(studentID);

            if (schedule is not null)
                return new ApiResponse(StatusCodes.Status400BadRequest, $"Student with ID {studentID} already has a schedule created!");

            User? student = await GetStudentUserFromDB(studentID);

            if (student is null)
                return new ApiResponse(StatusCodes.Status404NotFound, $"User with ID {studentID} does not exist.");
            if (student.Role != UserRole.Student)
                return new ApiResponse(StatusCodes.Status400BadRequest, $"User with ID {studentID} is not a student.");

            bool result = await CreateStudentSchedule(student);

            return new ApiResponse(StatusCodes.Status200OK, data: result, success: result);
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

        private static async Task<User?> GetStudentUserFromDB(int studentID)
        {
            using var context = new YourScopeContext();

            User? student = await context.Users
                .Where(user => user.UserId == studentID)
                .FirstOrDefaultAsync();

            return student;
        }

        private static async Task<bool> CreateStudentSchedule(User student)
        {
            using var context = new YourScopeContext();

            // Creating the schedule.
            Schedule schedule = new() { StudentId = student.UserId };

            context.Schedules.Add(schedule);
            await context.SaveChangesAsync();

            // Creating the years.
            for (int i = 1; i <= 4; i++)
            {
                Year year = new() { YearNumber = i, ScheduleId = schedule.ScheduleId };
                context.Years.Add(year);
            }

            await context.SaveChangesAsync();

            return true;
        }
        #endregion
    }
}

