using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using CandidateManagement_DuyNMSE173649.Data;
using Service;

namespace CandidateManagement_DuyNMSE173649.Pages.CandidatePage
{
    public class EditModel : PageModel
    {
        private readonly ICandidateProfileServ _candidateProfileServ;
        private readonly IJobPostingServ _jobPostingServ;

        public EditModel(ICandidateProfileServ candidateProfileServ, IJobPostingServ jobPostingServ)
        {
            _candidateProfileServ = candidateProfileServ;
            _jobPostingServ = jobPostingServ;
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidateprofile = _candidateProfileServ.GetCandidateProfileById(id);

            if (candidateprofile == null)
            {
                return NotFound();
            }
            CandidateProfile = candidateprofile;
            ViewData["PostingId"] = _jobPostingServ.GetAllJobPosting()
         .Select(jp => new SelectListItem
         {
             Value = jp.PostingId.ToString(),
             Text = jp.JobPostingTitle
         }).ToList();
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public void OnPost()
        {
            _candidateProfileServ.UpdateCandidate(CandidateProfile);
            Response.Redirect("./List");
        }
    }
}
