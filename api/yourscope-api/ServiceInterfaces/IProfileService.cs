using System;
using yourscope_api.entities;
using yourscope_api.Models.DbModels;
using yourscope_api.Models.Request;

namespace yourscope_api.service
{
    public interface IProfileService
    {
        public Profile? GetProfile(int UserId);
        public int CreateProfile(ProfileCreation details);
        public void ModifyProfile(ProfileDetails details);
        public int CreateExperience(Experience experience);
        public void DeleteExperience(int experienceId);
        public int CreateCoverLetter(CoverLetter coverLetter);
    }
}

