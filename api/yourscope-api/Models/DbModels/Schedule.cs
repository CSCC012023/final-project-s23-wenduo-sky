using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace yourscope_api.Models.DbModels
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }
        public required int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public required User Student { get; set; }
        public List<Year>? Years { get; set; } = new List<Year>();
    }
}
