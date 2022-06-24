using final_project.Server.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_project.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyUser> CompanyUsers { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Company>(c =>
            {
                c.HasKey(e => e.IdCompany);
                c.Property(e => e.Ticker).IsRequired().HasMaxLength(10);
                c.Property(e => e.Name).IsRequired().HasMaxLength(100);
                c.Property(e => e.Description).IsRequired().HasMaxLength(100);
                c.Property(e => e.Country).IsRequired().HasMaxLength(50);
                c.Property(e => e.Logo_url).IsRequired().HasMaxLength(256);
            });

            modelBuilder.Entity<CompanyUser>(c =>
            {
                c.HasKey(e => new { e.IdCompany, e.IdUser });

                c.HasOne(e => e.Company).WithMany(e => e.CompanyUsers).HasForeignKey(e => e.IdCompany);
                c.HasOne(e => e.User).WithMany(e => e.CompanyUsers).HasForeignKey(e => e.IdUser);
            });



        }
    }
}
