using BusinessObject;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IHraccountServ
    {
        Hraccount? Login(string Email, string Password);
    }
    public class HraccountServ : IHraccountServ
    {
        public IHraccountRepo _HraccountRepo;
        public HraccountServ(IHraccountRepo HraccountRepo)
        {
            _HraccountRepo = HraccountRepo;
        }
        public Hraccount? Login(string Email, string Password)
        {
            return _HraccountRepo.Login(Email, Password);
        }
    }
}
