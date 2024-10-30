using BusinessObject;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IJobPostingRepo
    {
        List<JobPosting> GetAllJobPosting();
    }
    public class JobPostingRepo : IJobPostingRepo
    {
        public List<JobPosting> GetAllJobPosting()
        {
            return JobPostingDAO.Instance.GetAll();
        }
    }
}
