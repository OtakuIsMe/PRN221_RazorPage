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
    public class ListModel : PageModel
    {
        private readonly ICandidateProfileServ _candidateProfileServ;

        public ListModel(ICandidateProfileServ candidateProfileServ)
        {
            _candidateProfileServ = candidateProfileServ;
        }

        public List<CandidateProfile> CandidateProfile { get; set; } = default!;

        public void OnGet()
        {
            CandidateProfile = _candidateProfileServ.GetAllCandidate();
        }

        public void OnPost()
        {
            string fullname = Request.Form["fullname"];
            DateOnly? birthday = string.IsNullOrEmpty(Request.Form["birthday"])
            ? (DateOnly?)null
            : DateOnly.Parse(Request.Form["birthday"]);

            CandidateProfile = _candidateProfileServ.FilterCandidate(fullname, birthday);
        }
    }
}
