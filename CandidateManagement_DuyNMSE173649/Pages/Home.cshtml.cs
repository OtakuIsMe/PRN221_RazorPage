using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;

namespace CandidateManagement_DuyNMSE173649.Pages
{
    public class HomeModel : PageModel
    {
        private readonly ICandidateProfileServ _candidateProfileServ;
        [BindProperty]
        public List<CandidateProfile> Candidates { get; set; }
        public HomeModel(ICandidateProfileServ candidateProfileServ)
        {
            _candidateProfileServ = candidateProfileServ;
        }
        public void OnGet()
        {
            Candidates = _candidateProfileServ.GetAllCandidate();
        }
    }
}
