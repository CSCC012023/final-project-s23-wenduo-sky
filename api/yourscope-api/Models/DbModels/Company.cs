namespace yourscope_api.Models.DbModels
{
    public enum CompanyType
    {
        Accomodation = "Accomodation Services",
        FoodServices = "Food Services",
        AdminAndSupport = "Adminsitrative and Support Services",
        WasteManagement = "Waste Management Services",
        Remediation = "Remediation Services",
        Agriculture = "Agriculture",
        Forestry = "Forestry",
        Fishing = "Fishing",
        Hunting = "Hunting",
        Arts = "Arts",
        Entertainment = "Entertainment",
        Recreation = "Recreation",
        Construction = "Construction",
        Education = "Education Services",
        FinanceAndInsurance = "Finance and Insurance",
        HealthCare = "Health Care",
        SocialAssistance = "Social Assistance",
        Information = "Information Serices",
        CulturalIndustries = "Cultueral Industries",
        Management = "Management of Companies and Enterprises",
        Manufacturing = "Manufacturing",
        Mining = "Mining",
        OilAndGasExtraction = "Oil and Gas Extraction",
        Other = "Other Services",
        Professional = "Professional Services",
        Technical = "Technical Services",
        Scientific = "Scientific Services",
        PublicAdmin = "Public Adminsitration",
        RealEstate = "Real Estate",
        Retail = "Retail Trade",
        Transportation = "Transportation",
        Warehousing = "Warehousing",
        Utilities = "Utilities",
        Wholesale = "Wholesale Trade"
    }
  
    public class Company
    {
        public required string CompanyName { get; set; }
        public required string Country { get; set; }
        public required string City { get; set; }
        public required string Address { get; set; }
        public required int? UnitNumber { get; set; }
        public required string? Phone { get; set; }
        public required string? Fax { get; set; }
        public required string Email { get; set; }
        public required List<CompanyType>? Type { get; set; }
    }
}
