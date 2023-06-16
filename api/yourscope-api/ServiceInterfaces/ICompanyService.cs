using Microsoft.AspNetCore.Mvc;
using yourscope_api.Models.DbModels;
using yourscope_api.entities;

namespace yourscope_api.service
{
    public interface ICompanyService
    {
        public bool CheckCompanyExists(string company);

        public Task<IActionResult> RegisterCompanyMethod(Company companyInfo);
    }
}
