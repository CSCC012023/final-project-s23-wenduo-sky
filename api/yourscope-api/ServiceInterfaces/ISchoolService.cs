using System;
using yourscope_api.entities;
using yourscope_api.Models.DbModels;

namespace yourscope_api.service
{
    public interface ISchoolService
    {
        public ApiResponse GetSchoolsMethod();
        public void PopulateCourseData(List<Course> courses, int schoolId);
    }
}

