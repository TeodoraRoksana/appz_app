using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using System.Reflection.Metadata;
using MedApp.DataAccessLayer.Models;

namespace DataAccessLayer.Implementation.EntityFramework
{
    public class MedAppDbContext : DbContext
    {
        public MedAppDbContext(DbContextOptions<MedAppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnalysisType>().Property("_fieldsData");
            modelBuilder.Entity<AnalysisResult>().Property("_analysisData");
        }

        public DbSet<UserData> UserData { get; set; }
        public DbSet<AnalysisResult> AnalysisResults { get; set; }
        public DbSet<AnalysisType> AnalysisTypes { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
