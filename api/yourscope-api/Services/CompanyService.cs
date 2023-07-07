using Microsoft.AspNetCore.Mvc;
using yourscope_api.entities;
using yourscope_api.Models.DbModels;

namespace yourscope_api.service
{
    public class CompanyService : ICompanyService
    {
        #region constructors and class fields

        public CompanyService() { }


        #endregion

        public ApiResponse CheckCompanyExistsMethod(string company)
        {

            return new ApiResponse(StatusCodes.Status200OK, data: CheckCompanyExists(company), success: true);
        }

        public async Task<IActionResult> RegisterCompanyMethod(Company companyInfo)
        {
            if (CheckCompanyExists(companyInfo.CompanyName))
                return new BadRequestObjectResult($"{companyInfo.CompanyName} already exists!");

            await InsertCompanyIntoDb(companyInfo);

            return new CreatedResult("Company successfully registered.", true);
        }

        private static async Task<bool> InsertCompanyIntoDb(Company company)
        {
            using var context = new YourScopeContext();

            context.Company.Add(company);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public List<Company> GetCompanyList()
        {
            using var context = new YourScopeContext();
            return context.Company.ToList();
        }

        public ApiResponse GetCompaniesMethod()
        {
            return new ApiResponse(StatusCodes.Status200OK, data: GetCompanyList(), success: true);
        }

        private static bool CheckCompanyExists(string company)
        {
            using var context = new YourScopeContext();

            List<Company> exist = context.Company.Where(comp => comp.CompanyName == company).ToList();
            return exist.Count > 0;
        }
    }
}
