using Microsoft.AspNetCore.Mvc;
using yourscope_api;
using yourscope_api.entities;
using yourscope_api.Models.DbModels;
using User = yourscope_api.Models.DbModels.User;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;

namespace yourscope_api.service
{
    public class AccountsService : IAccountsService
    {
        #region class fields and constructors
        private readonly IConfiguration configuration;
        private readonly FirebaseAuthClient firebase;
        private readonly string FirebaseWebAPIKey;
        private readonly string FirebaseAuthDomain;

        public AccountsService(IConfiguration configuration)
        {
            this.configuration = configuration;

            // Setting configuration values.
            string? apiKey = this.configuration.GetValue<string>("FirebaseAuth:APIKey");
            string? authDomain = this.configuration.GetValue<string>("FirebaseAuth:AuthDomain");

            // Null checks.
            if (string.IsNullOrEmpty(apiKey))
                throw new ArgumentNullException(nameof(apiKey), "Missing FirebaseWebAPIKey configuration field in appsettings.json");
            if (string.IsNullOrEmpty(authDomain))
                throw new ArgumentNullException(nameof(authDomain), "Missing FirebaseAuth:AuthDomain configuration field in appsettings.json");

            FirebaseWebAPIKey = apiKey;
            FirebaseAuthDomain = authDomain;

            #region setup firebase
            var config = new FirebaseAuthConfig {
                ApiKey = FirebaseWebAPIKey,
                AuthDomain = FirebaseAuthDomain,
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            };
            firebase = new(config);
            #endregion
        }
        #endregion

        public bool CheckEmailRegistered(string email)
        {
            using var context = new YourScopeContext();

            List<User> users = context.Users.Where(user => user.Email == email).ToList();
            return users.Count > 0;
        }

        public IActionResult RegisterStudentMethod(UserRegistrationDto userInfo)
        {
            if (CheckEmailRegistered(userInfo.Email))
                return new BadRequestObjectResult($"{userInfo.Email} has already been registered!");

            userInfo.Role = UserRole.Student;

            FirebaseRegister(userInfo);

            InsertUserIntoDb(userInfo);

            return new CreatedResult("User successfully registered.", true);
        }

        private async void FirebaseRegister(UserRegistrationDto userInfo)
        {
            var nameList = new List<string>
            {
                userInfo.FirstName.Trim(),
                userInfo.MiddleName?.Trim()[0]+".",
                userInfo.LastName.Trim()
            };
            string displayName = string.Join(" ", nameList);

            await firebase.CreateUserWithEmailAndPasswordAsync(userInfo.Email, userInfo.Password, displayName);
        }

        private static async void InsertUserIntoDb(User user)
        {
            using var context = new YourScopeContext();

            context.Users.Add(user);
            await context.SaveChangesAsync();
        }

        public async Task<IActionResult> LoginMethod(UserLoginDto loginInfo)
        {
            UserCredential userLogin;
            
            try
            {
                userLogin = await firebase.SignInWithEmailAndPasswordAsync(loginInfo.Email, loginInfo.Password);
            }
            catch (FirebaseAuthException)
            {
                return new UnauthorizedObjectResult("Incorrect email or password.");
            }

            return new OkObjectResult(userLogin.User.Credential.IdToken);
        }
    }
}
