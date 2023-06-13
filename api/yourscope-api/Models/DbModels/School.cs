namespace yourscope_api.Models.DbModels
{
    public class School
    {
        public required string Name { get; set; }
        public string Address { get; set; } // Might be online school, so not required
    }
}
