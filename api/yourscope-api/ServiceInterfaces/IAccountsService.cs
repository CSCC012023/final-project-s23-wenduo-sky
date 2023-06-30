﻿using Microsoft.AspNetCore.Mvc;
using yourscope_api.entities;

namespace yourscope_api.service
{
    public interface IAccountsService
    {
        public bool CheckEmailRegistered(string email);
        public Task<ApiResponse> RegisterStudentMethod(UserRegistrationDto userInfo);
        public Task<IActionResult> RegisterEmployerMethod(UserRegistrationDto userInfo);
        public Task<ApiResponse> LoginMethod(UserLoginDto loginInfo);
        public Task<ApiResponse> SendPasswordResetEmailMethod(string email);
    }
}
