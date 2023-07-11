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

        #region helpers
        private static List<School> GetAllSchools()
        {
            using var context = new YourScopeContext();

            return context.Schools.ToList();
        }

        #endregion
    }
}

