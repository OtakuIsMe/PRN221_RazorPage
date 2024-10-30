using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BusinessObject;

namespace CandidateManagement_DuyNMSE173649.Data
{
    public class CandidateManagement_DuyNMSE173649Context : DbContext
    {
        public CandidateManagement_DuyNMSE173649Context (DbContextOptions<CandidateManagement_DuyNMSE173649Context> options)
            : base(options)
        {
        }

        public DbSet<BusinessObject.CandidateProfile> CandidateProfile { get; set; } = default!;
    }
}
