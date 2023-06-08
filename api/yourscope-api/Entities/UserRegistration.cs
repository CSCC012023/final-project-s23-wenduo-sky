using yourscope_api.Models.DbModels;

namespace yourscope_api.entities
{
    public class UserRegistration : User
    {
        public required string Password { get; set; }
    }
}
