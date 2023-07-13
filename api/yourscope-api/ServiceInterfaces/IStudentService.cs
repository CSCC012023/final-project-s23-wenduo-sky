using System;
using yourscope_api.entities;

namespace yourscope_api.service
{
    public interface IStudentService
    {
        public Task<ApiResponse> GetStudentScheduleMethod(int studentID);
    }
}

