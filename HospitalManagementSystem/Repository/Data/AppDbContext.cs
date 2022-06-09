using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Repository.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        #region DbSetClasses
        public DbSet<Bed> Beds { get; set; }
        public DbSet<Birth> Births { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<PatientBill> PatientBills { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientTest> PatientTests { get; set; }
        public DbSet<PatientTriage> PatientTriages { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Triage> Triages { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
