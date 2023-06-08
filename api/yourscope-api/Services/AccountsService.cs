using yourscope_api;
using yourscope_api.Models.DbModels;

namespace yourscope_api.service
{
    public class AccountsService : IAccountsService
    {
        public bool CheckEmailRegistered(string email)
        {
            using var context = new YourScopeContext();

            List<User> users = context.Users.Where(user => user.Email == email).ToList();
            return users.Count > 0;
        }
    }
}
