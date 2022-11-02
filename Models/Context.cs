using Microsoft.EntityFrameworkCore;

namespace CredexAPI.Models
{
    public class Context : DbContext
    {
        public DbSet<AllowancesOfEmployees> AllowancesOfEmployees { get; set; }
        public DbSet<AllowanceTypes> AllowanceTypes { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Genders> Genders { get; set; }
        public DbSet<Jobs> Jobs { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Statuses> Statuses { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<ValueStreams> ValueStreams { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //AllowanceOfEmployees tábla
            modelBuilder.Entity<AllowancesOfEmployees>()
                .HasKey(x => x.Id);
            //AllowanceTypes tábla
            modelBuilder.Entity<AllowanceTypes>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<AllowanceTypes>()
                .HasMany(x => x.AllowancesOfEmployees)
                .WithOne(x => x.AllowanceTypes)
                .HasForeignKey(x => x.AllowanceTypeId);
            //Employees tábla
            modelBuilder.Entity<Employees>()
                .HasKey(x => x.EmployeeId);
            modelBuilder.Entity<Employees>()
                .HasMany(x => x.AllowancesOfEmployees)
                .WithOne(x => x.Employees)
                .HasForeignKey(x => x.EmployeeId);
            //Genders tábla
            modelBuilder.Entity<Genders>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Genders>()
                .HasMany(x => x.Employees)
                .WithOne(x => x.Genders)
                .HasForeignKey(x => x.GenderId);
            //Jobs tábla
            modelBuilder.Entity<Jobs>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Jobs>()
                .HasMany(x => x.Employees)
                .WithOne(x => x.Jobs)
                .HasForeignKey(x => x.JobId);
            //Roles tábla
            modelBuilder.Entity<Roles>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Roles>()
                .HasMany(x => x.Users)
                .WithOne(x => x.Roles)
                .HasForeignKey(x => x.RoleId);
            //Statuses tábla
            modelBuilder.Entity<Statuses>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Statuses>()
                .HasMany(x => x.Employees)
                .WithOne(x => x.Statuses)
                .HasForeignKey(x => x.StatusId);
            //Users tábla
            modelBuilder.Entity<Users>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Users>()
                .HasOne(x => x.Employees)
                .WithOne(x => x.Users)
                .HasForeignKey<Users>(x => x.EmployeeId);
            //ValueStreams tábla
            modelBuilder.Entity<ValueStreams>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<ValueStreams>()
                .HasMany(x => x.Employees)
                .WithOne(x => x.ValueStreams)
                .HasForeignKey(x => x.ValueStreamId);
            modelBuilder.Entity<ValueStreams>()
                .HasMany(x => x.Jobs)
                .WithOne(x => x.ValueStreams)
                .HasForeignKey(x => x.ValueStreamId);
        }


    }
}
