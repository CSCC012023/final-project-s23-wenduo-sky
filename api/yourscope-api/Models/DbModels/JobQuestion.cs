using System.ComponentModel.DataAnnotations;

namespace yourscope_api.Models.DbModels
{
    public class JobQuestion
    {
        [Key]
        public int JobQuestionId { get; set; }
        public required JobPosting JobPosting { get; set; } = null!;
        public required string Question { get; set; }
        public int MaxWords { get; set; }
    }
}
