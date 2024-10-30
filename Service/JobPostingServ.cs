using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using Repository;

namespace Service
{
    public interface IJobPostingServ
    {
        List<JobPosting> GetAllJobPosting();
    }
    public class JobPostingServ : IJobPostingServ
    {
        private readonly IJobPostingRepo _JobPostingRepo;

        public JobPostingServ(IJobPostingRepo JobPostingRepo)
        {
            _JobPostingRepo = JobPostingRepo;
        }
        public List<JobPosting> GetAllJobPosting()
        {
            return _JobPostingRepo.GetAllJobPosting();
        }
    }
}
