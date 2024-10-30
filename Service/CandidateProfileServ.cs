using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DAO;
using Repository;

namespace Service
{
    public interface ICandidateProfileServ
    {
        List<CandidateProfile> GetAllCandidate();
        void CreateCandidate(CandidateProfile candidate);
        void UpdateCandidate(CandidateProfile candidate);
        void DeleteCandidate(CandidateProfile candidate);
        CandidateProfile? GetCandidateProfileById(string id);
        List<CandidateProfile> FilterCandidate(string? inputString, DateOnly? date);
    }
    public class CandidateProfileServ : ICandidateProfileServ
    {
        private readonly ICandidateProfileRepo _candidateProfileRepo;

        public CandidateProfileServ(ICandidateProfileRepo candidateProfileRepo)
        {
            _candidateProfileRepo = candidateProfileRepo;
        }
        public List<CandidateProfile> GetAllCandidate()
        {
            return _candidateProfileRepo.GetAllCandidate();
        }
        public void CreateCandidate(CandidateProfile candidate)
        {
            _candidateProfileRepo.CreateCandidate(candidate);
        }

        public void DeleteCandidate(CandidateProfile candidate)
        {
            _candidateProfileRepo.DeleteCandidate(candidate);
        }
        public void UpdateCandidate(CandidateProfile candidate)
        {
            _candidateProfileRepo.UpdateCandidate(candidate);
        }

        public CandidateProfile? GetCandidateProfileById(string id)
        {
            return _candidateProfileRepo.GetCandidateProfileById(id);
        }
        public List<CandidateProfile> FilterCandidate(string? inputString, DateOnly? date)
        {
            return _candidateProfileRepo.FilterCandidate(inputString, date);
        }
    }
}
