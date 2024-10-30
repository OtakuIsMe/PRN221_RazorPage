using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using CandidateManagement_DuyNMSE173649.Data;
using Service;

namespace CandidateManagement_DuyNMSE173649.Pages.CandidatePage
{
    public class DetailsModel : PageModel
    {
        private readonly ICandidateProfileServ _candidateProfileServ;

        public DetailsModel(ICandidateProfileServ candidateProfileServ)
        {
            _candidateProfileServ = candidateProfileServ;
        }

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
            else
            {
                CandidateProfile = candidateprofile;
            }
            return Page();
        }
    }
}
