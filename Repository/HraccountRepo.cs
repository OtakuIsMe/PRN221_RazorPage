using BusinessObject;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IHraccountRepo
    {
        Hraccount? Login(string Email, string Password);
    }
    public class HraccountRepo : IHraccountRepo
    {
        public Hraccount? Login(string Email, string Password)
        {
            return HraccountDAO.Instance.GetHraccountByEmailAndPassword(Email, Password);
        }
    }
}
