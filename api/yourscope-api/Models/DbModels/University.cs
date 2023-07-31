using Microsoft.Extensions.Hosting;

namespace yourscope_api.Models.DbModels
{
    public class University
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<UniProgram> UniPrograms { get; } = new List<UniProgram>();

    }
}
