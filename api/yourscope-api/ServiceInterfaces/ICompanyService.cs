using Microsoft.AspNetCore.Mvc;
using yourscope_api.Models.DbModels;

namespace yourscope_api.service
{
    public interface ICompanyService
    {
        public bool CheckCompanyExists(string company);
        public List<Company> GetCompanyList();
        public Task<IActionResult> RegisterCompanyMethod(Company companyInfo);
    }
}
