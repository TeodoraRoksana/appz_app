using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace DataAccessLayer.Implementation.EntityFramework
{
    public class MedAppDbContext : DbContext
    {
        public MedAppDbContext(DbContextOptions<MedAppDbContext> options) : base(options)
        {

        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<AnalysisResult> AnalysisResults { get; set; }
        public DbSet<AnalysisType> AnalysisTypes { get; set; }
    }
}
