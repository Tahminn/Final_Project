using Domain.Entities;
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

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
