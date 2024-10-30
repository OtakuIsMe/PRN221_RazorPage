using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace DAO
{
    public class CandidateProfileDAO
    {
        private readonly CandidateManagementContext _context;
        private static CandidateProfileDAO instance = null;

        public static CandidateProfileDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CandidateProfileDAO();
                }
                return instance;
            }
        }

        public CandidateProfileDAO()
        {
            _context = new CandidateManagementContext();
        }

        public List<CandidateProfile> GetAllCandidate()
        {
            return _context.CandidateProfiles.ToList();
        }

        public void CreateCandidate(CandidateProfile candidate)
        {
            _context.CandidateProfiles.Add(candidate);
            _context.SaveChanges();
        }

        public void UpdateCandidate(CandidateProfile candidate)
        {
            _context.CandidateProfiles.Update(candidate);
            _context.SaveChanges();
        }

        public void DeleteCandidate(CandidateProfile candidate)
        {
            _context.CandidateProfiles.Remove(candidate);
            _context.SaveChanges();
        }

        public CandidateProfile? GetCandidateProfileById(string id)
        {
            var trackedEntity = _context.CandidateProfiles.Local
        .FirstOrDefault(e => e.CandidateId == id);

            if (trackedEntity != null)
            {
                _context.Entry(trackedEntity).State = EntityState.Detached;
            }
            return _context.CandidateProfiles.AsNoTracking().FirstOrDefault(c => c.CandidateId == id);
        }
        public List<CandidateProfile> FilterCandidate(string? inputString, DateOnly? date)
        {
            if (inputString.IsNullOrEmpty() && date != null)
            {
                return _context.CandidateProfiles
                .Where(c => c.Birthday.HasValue && DateOnly.FromDateTime(c.Birthday.Value) == date)
                .ToList();
            }
            else if (date == null && !inputString.IsNullOrEmpty())
            {
                return _context.CandidateProfiles.Where(c => c.Fullname.ToLower().Contains(inputString.ToLower())).ToList();
            }
            else if (date == null && inputString.IsNullOrEmpty())
            {
                return _context.CandidateProfiles.ToList();
            }
            else
            {
                return _context.CandidateProfiles.Where(c => c.Birthday.HasValue && DateOnly.FromDateTime(c.Birthday.Value) == date &&
                                                        c.Fullname.ToLower().Contains(inputString.ToLower())).ToList();
            }
        }
    }
}
