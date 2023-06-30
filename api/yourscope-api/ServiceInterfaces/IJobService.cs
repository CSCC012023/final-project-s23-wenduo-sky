using yourscope_api.Models.DbModels;
using yourscope_api.Models.Reponse;
using yourscope_api.Models.Request;

namespace yourscope_api.ServiceInterfaces
{
    public interface IJobService
    {
        public void CreateJobPosting(JobPostingCreation posting);
        public int CountJobPostings(JobFilter filters);
        public List<JobPostingDetails> GetJobPostings(JobFilter filters);
        public void DeleteJobPosting(int postingId);

    }
}
