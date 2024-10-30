using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class HraccountDAO
    {
        private readonly CandidateManagementContext _context;
        private static HraccountDAO instance = null;

        public static HraccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HraccountDAO();
                }
                return instance;
            }
        }

        public HraccountDAO()
        {
            _context = new CandidateManagementContext();
        }

        public Hraccount? GetHraccountByEmailAndPassword(string Email, string Password)
        {
            return _context.Hraccounts.FirstOrDefault(h => h.Email == Email && h.Password == Password);
        }
    }
}
