using Microsoft.AspNetCore.Mvc;
using yourscope_api.entities;

namespace yourscope_api.service
{
    public interface IAccountsService
    {
        public bool CheckEmailRegistered(string email);
        public IActionResult RegisterStudentMethod(UserRegistration userInfo);
    }
}
