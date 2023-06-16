using Microsoft.AspNetCore.Mvc;
using yourscope_api.Models.DbModels;

namespace yourscope_api.service
{
    public class CompanyService : ICompanyService
    {
        #region constructors and class fields
        public readonly string name;
        public CompanyService(string name)
        {
            this.name = name;
        }
        #endregion
        public bool CheckCompanyExists(string company)
        {
            using var context = new YourScopeContext();

            List<Company> exist = context.Company.Where(comp => comp.CompanyName == company).ToList();
            return exist.Count > 0;
        }

        public async Task<IActionResult> RegisterCompanyMethod()
        {
            return new CreatedResult("User successfully registered.", true);
        }
    }
}
