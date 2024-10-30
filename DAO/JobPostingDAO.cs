using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DAO
{
    public class JobPostingDAO
    {
        private readonly CandidateManagementContext _context;
        private static JobPostingDAO instance = null;

        public static JobPostingDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JobPostingDAO();
                }
                return instance;
            }
        }

        public JobPostingDAO()
        {
            _context = new CandidateManagementContext();
        }

        public List<JobPosting> GetAll()
        {
            return _context.JobPostings.ToList();
        }
    }
}
