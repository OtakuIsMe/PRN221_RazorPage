using BusinessObject;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ICandidateProfileRepo
    {
        List<CandidateProfile> GetAllCandidate();
        void CreateCandidate(CandidateProfile candidate);
        void UpdateCandidate(CandidateProfile candidate);
        void DeleteCandidate(CandidateProfile candidate);
        CandidateProfile? GetCandidateProfileById(string id);
        List<CandidateProfile> FilterCandidate(string? inputString, DateOnly? date);
    }
    public class CandidateProfileRepo : ICandidateProfileRepo
    {
        public void CreateCandidate(CandidateProfile candidate)
        {
            CandidateProfileDAO.Instance.CreateCandidate(candidate);
        }

        public void DeleteCandidate(CandidateProfile candidate)
        {
            CandidateProfileDAO.Instance.DeleteCandidate(candidate);
        }

        public List<CandidateProfile> GetAllCandidate()
        {
            return CandidateProfileDAO.Instance.GetAllCandidate();
        }

        public CandidateProfile? GetCandidateProfileById(string id)
        {
            return CandidateProfileDAO.Instance.GetCandidateProfileById(id);
        }

        public void UpdateCandidate(CandidateProfile candidate)
        {
            CandidateProfileDAO.Instance.UpdateCandidate(candidate);
        }

        public List<CandidateProfile> FilterCandidate(string? inputString, DateOnly? date)
        {
            return CandidateProfileDAO.Instance.FilterCandidate(inputString, date);
        }

    }
}
