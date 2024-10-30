using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject;
using CandidateManagement_DuyNMSE173649.Data;
using Service;

namespace CandidateManagement_DuyNMSE173649.Pages.CandidatePage
{
    public class CreateModel : PageModel
    {
        private readonly ICandidateProfileServ _candidateProfileServ;
        private readonly IJobPostingServ _jobPostingServ;

        public CreateModel(ICandidateProfileServ candidateProfileServ, IJobPostingServ jobPostingServ)
        {
            _candidateProfileServ = candidateProfileServ;
            _jobPostingServ = jobPostingServ;
        }

        public void OnGet()
        {
            ViewData["PostingId"] = _jobPostingServ.GetAllJobPosting()
        .Select(jp => new SelectListItem
        {
            Value = jp.PostingId.ToString(),
            Text = jp.JobPostingTitle
        }).ToList();
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public void OnPost()
        {

            _candidateProfileServ.CreateCandidate(CandidateProfile);

            Response.Redirect("./List");
        }
    }
}
