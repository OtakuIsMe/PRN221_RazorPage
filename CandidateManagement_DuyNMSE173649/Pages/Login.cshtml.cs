using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;

namespace CandidateManagement_DuyNMSE173649.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IHraccountServ _hraccountServ;

        public LoginModel(IHraccountServ hraccountServ)
        {
            _hraccountServ = hraccountServ;
        }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            string username = Request.Form["username"];
            string password = Request.Form["password"];

            Hraccount? hraccount = _hraccountServ.Login(username, password);
            if (hraccount == null)
            {
                Response.Redirect("/LoginFail");
            }
            else
            {
                Response.Redirect("/CandidatePage/List");
            }
        }
    }
}
