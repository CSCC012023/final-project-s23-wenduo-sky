using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using yourscope_api.entities;
using yourscope_api.Models.DbModels;
using yourscope_api.Models.Reponse;
using yourscope_api.Models.Request;

namespace yourscope_api.service
{
    public class SchoolService : ISchoolService
    {
        #region fields and constructor
        private readonly IConfiguration configuration;

        public SchoolService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        #endregion

        public ApiResponse GetSchoolsMethod()
        {
            List<School> schools = GetAllSchools();

            return new ApiResponse(StatusCodes.Status200OK, data: schools);
        }

        public void PopulateCourseData(List<Course> courses, int schoolId)
        {
            using var context = new YourScopeContext();

            var courseData = context.Courses.Select(q => q.CourseCode).ToHashSet();
            var currCourses = context.SchoolCourse.Where(q => q.SchoolId == schoolId).Include(q => q.Course).Select(q => q.Course.CourseCode).ToHashSet();

            int courseId;
            foreach (Course course in courses)
            {
                if (courseData.Contains(course.CourseCode))
                {
                    if (currCourses.Contains(course.CourseCode))
                    {
                        throw new BadHttpRequestException($"Course with code {course.CourseCode} already belongs to the school");
                    }
                    // Get id of existing course in 
                    courseId = context.Courses.First(q => q.CourseCode == course.CourseCode).CourseId;
                }
                else
                {
                    //Create new course
                    context.Courses.Add(course);
                    context.SaveChanges();
                    courseId = course.CourseId;
                }

                context.SchoolCourse.Add(new SchoolCourse { CourseId = courseId , SchoolId = schoolId});
            }
            context.SaveChanges();
        }

        public async Task<ApiResponse> GetCoursesMethod(CourseFilter filters)
        {
            List<int> courseIDs = await GetCourseIDList(filters.SchoolID);
            filters.CourseIDs = courseIDs;

            List<CourseDetails> courses = await GetFilteredCourses(filters);

            return new ApiResponse(StatusCodes.Status200OK, data: courses, success: true);
        }
        #region helpers
        private static List<School> GetAllSchools()
        {
            using var context = new YourScopeContext();

            return context.Schools.ToList();
        }

        private static async Task<List<int>> GetCourseIDList(int? schoolID)
        {
            using var context = new YourScopeContext();

            List<int> courseIDs = await context.SchoolCourse
                .Where(entry => schoolID == null || entry.SchoolId == schoolID)
                .Select(entry => entry.CourseId)
                .Distinct()
                .ToListAsync();

            return courseIDs;
        }

        private static List<string>? ParseDisciplineString(string? disciplines)
        {
            if (disciplines is null) return null;

            List<string> disciplineList = disciplines
                .Split(',')
                .ToList()
                .ConvertAll(entry => entry.Trim().ToLower());

            return disciplineList;
        }

        private static async Task<List<CourseDetails>> GetFilteredCourses(CourseFilter filters)
        {
            List<string>? disciplines = ParseDisciplineString(filters.Disciplines);

            using var context = new YourScopeContext();

            List<Course> courses = await context.Courses
                .Where(course => filters.CourseIDs == null || filters.CourseIDs.Contains(course.CourseId))
                .Where(course =>
                (filters.SearchQuery == null || course.Name.ToLower().Contains(filters.SearchQuery) || course.CourseCode.ToLower().Contains(filters.SearchQuery)) // Name and course code filter.
                && (filters.Grade == null || course.Grade == filters.Grade) // Grade filter.
                && (disciplines == null || disciplines.Any(d => d == course.Discipline.ToLower()))) // Disciplines filter.
                .Skip(filters.Offset)
                .Take(filters.Count)
                .ToListAsync();

            List<CourseDetails> courseDetails = courses.ConvertAll(course => new CourseDetails(course));

            return courseDetails;
        }

        #endregion
    }
}

