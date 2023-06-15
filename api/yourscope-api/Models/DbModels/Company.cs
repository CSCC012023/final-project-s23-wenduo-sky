using System.ComponentModel.DataAnnotations;

/*public enum CompanyType
{
    Accomodation,
    FoodServices,
    AdminAndSupport
    WasteManagement,
    Remediation,
    Agriculture,
    Forestry,
    Fishing,
    Hunting,
    Arts,
    Entertainment,
    Recreation,
    Construction,
    Education,
    FinanceAndInsurance,
    HealthCare,
    SocialAssistance,
    Information,
    CulturalIndustries,
    Management,
    Manufacturing,
    Mining,
    OilAndGasExtraction,
    Other,
    Professional,
    Technical,
    Scientific,
    PublicAdmin,
    RealEstate,
    Retail,
    Transportation,
    Warehousing,
    Utilities,
    Wholesale
}*/

namespace yourscope_api.Models.DbModels
{
    public class Company
    {
        [Key]
        public required string CompanyName { get; set; }
        public required string Country { get; set; }
        public required string City { get; set; }
        public required string Address { get; set; }
        public required int? UnitNumber { get; set; }
        public required string? Phone { get; set; }
        public required string? Fax { get; set; }
        public required string Email { get; set; }
        public required string? Type { get; set; }
    }
}
