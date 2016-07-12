using DbOps.DtoModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace DbOps
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("DataContext") //Specifying the conn string as defined in web.config
        {

        }

        public DbSet<Employees> Employees { get; set; }
        public DbSet<AddedBonus> AddedBonus { get; set; }
        public DbSet<Perks> Perks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Employees");
            modelBuilder.Entity<Employees>().HasKey(t => t.EmployeeId);
            modelBuilder.Entity<Employees>()
                .Property(x => x.EmployeeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Employees>()
                .Property(x => x.Firstname)
                .IsRequired();

            modelBuilder.Entity<Employees>()
               .HasMany(c => c.Perks);

            modelBuilder.Entity<Perks>()
               .HasRequired(c => c.AddedBonus);

            modelBuilder.Entity<Employees>().ToTable("EmployeesInfo");
            modelBuilder.Entity<Perks>().ToTable("PerkInfo", "Perk");
            modelBuilder.Entity<AddedBonus>().ToTable("AddedBonus");

            //modelBuilder.Entity<Employees>().MapToStoredProcedures();
        }
    }
}
