using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using yourscope_api.entities;
using yourscope_api.Models.DbModels;

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

        public async Task<ApiResponse> DeleteCourseFromSchoolByIdMethod(int schoolId, int courseId)
        {
            SchoolCourse? link = await GetCourseLinkById(schoolId, courseId);

            if (link is null)
                return new ApiResponse(StatusCodes.Status404NotFound, $"School with ID {schoolId} does not have a course with ID {courseId}.");

            bool result = await DeleteCourseFromSchool(link);

            return new ApiResponse(StatusCodes.Status200OK, data: result, success: result);
        }

        #region helpers
        private static List<School> GetAllSchools()
        {
            using var context = new YourScopeContext();

            return context.Schools.ToList();
        }

        private static async Task<SchoolCourse?> GetCourseLinkById(int schoolId, int courseId)
        {
            using var context = new YourScopeContext();

            SchoolCourse? link = await context.SchoolCourse
                .Where(entry => entry.SchoolId == schoolId && entry.CourseId == courseId)
                .FirstOrDefaultAsync();

            return link;
        }

        private static async Task<bool> DeleteCourseFromSchool(SchoolCourse link)
        {
            using var context = new YourScopeContext();

            context.SchoolCourse.Remove(link);
            await context.SaveChangesAsync();

            return true;
        }
        #endregion
    }
}

