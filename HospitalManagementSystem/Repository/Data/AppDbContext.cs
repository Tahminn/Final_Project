using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Repository.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        #region DbSetClasses

        public DbSet<Bed> Bed { get; set; }
        public DbSet<PatientTriage> PatientTriage { get; set; }
        public DbSet<Birth> Birth { get; set; }
        public DbSet<Medicine> Medicine { get; set; }
        public DbSet<Operation> Operation { get; set; }
        public DbSet<Setting> Setting { get; set; }
        public DbSet<GetPatientsCount> GetPatientsCounts { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

            //get view
            modelBuilder.Entity<GetPatientsCount>(opt =>
            {
                opt.HasNoKey();
                opt.ToView("GetPatientsCount");
            });


            //Change Table Name
            modelBuilder.Entity<User>(b =>
            {
                b.ToTable("Users");
            });

            modelBuilder.Entity<IdentityUserClaim<string>>(b =>
            {
                b.ToTable("UserClaims");
            });

            modelBuilder.Entity<IdentityUserLogin<string>>(b =>
            {
                b.ToTable("UserLogins");
            });

            modelBuilder.Entity<IdentityUserToken<string>>(b =>
            {
                b.ToTable("UserTokens");
            });

            modelBuilder.Entity<IdentityRole>(b =>
            {
                b.ToTable("Roles");
            });

            modelBuilder.Entity<IdentityRoleClaim<string>>(b =>
            {
                b.ToTable("RoleClaims");
            });

            modelBuilder.Entity<IdentityUserRole<string>>(b =>
            {
                b.ToTable("UserRoles");
            });

            //Auto Include for Users
            modelBuilder.Entity<User>().Navigation(e => e.Gender).AutoInclude();
            modelBuilder.Entity<User>().Navigation(e => e.Occupation).AutoInclude();
            modelBuilder.Entity<User>().Navigation(e => e.Department).AutoInclude();

            //Create History Tables          
            modelBuilder
               .Entity<User>()
               .ToTable("Users", b => b.IsTemporal());
            modelBuilder
              .Entity<IdentityRoleClaim<string>>()
               .ToTable("RoleClaims", b => b.IsTemporal());
            modelBuilder
               .Entity<IdentityUserClaim<string>>()
               .ToTable("UserClaims", b => b.IsTemporal());
            modelBuilder
               .Entity<IdentityUserLogin<string>>()
               .ToTable("UserLogins", b => b.IsTemporal());
            modelBuilder
                .Entity<IdentityUserRole<string>>()
                .ToTable("UserRoles", b => b.IsTemporal());
            modelBuilder
                .Entity<IdentityUserToken<string>>()
                .ToTable("UserTokens", b => b.IsTemporal());
            modelBuilder
                .Entity<IdentityRole>()
               .ToTable("Roles", b => b.IsTemporal());
            modelBuilder
                .Entity<Patient>()
                .ToTable("Patients", b => b.IsTemporal());
            modelBuilder
                .Entity<Operation>()
                .ToTable("Operations", b => b.IsTemporal());
            modelBuilder
                .Entity<Birth>()
                .ToTable("Births", b => b.IsTemporal());
            modelBuilder
                .Entity<Department>()
                .ToTable("Departments", b => b.IsTemporal());
            modelBuilder
                .Entity<Gender>()
                .ToTable("Genders", b => b.IsTemporal());
            modelBuilder
                .Entity<Occupation>()
                .ToTable("Occupations", b => b.IsTemporal());
            modelBuilder
                 .Entity<PatientBill>()
                 .ToTable("PatientBills", b => b.IsTemporal());
            modelBuilder
                .Entity<PatientTest>()
                .ToTable("PatientTests", b => b.IsTemporal());
            modelBuilder
                .Entity<PatientTriage>()
                .ToTable("PatientTriages", b => b.IsTemporal());
            modelBuilder
                .Entity<Triage>()
                .ToTable("Triages", b => b.IsTemporal());
            modelBuilder
                .Entity<Setting>()
                .ToTable("Settings", b => b.IsTemporal());
            modelBuilder
                .Entity<UserPatient>()
                .ToTable("UserPatients", b => b.IsTemporal());
            modelBuilder
                .Entity<Payment>()
                .ToTable("Payments", b => b.IsTemporal());
            modelBuilder
                .Entity<Bed>()
                .ToTable("Beds", b => b.IsTemporal());
            modelBuilder
                .Entity<Medicine>()
                .ToTable("Medicine", b => b.IsTemporal());
        }
    }
}
