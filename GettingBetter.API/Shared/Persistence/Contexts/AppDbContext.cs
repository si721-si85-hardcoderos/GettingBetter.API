using GettingBetter.API.GettingBetter_System.Domain.Models;
using GettingBetter.API.Shared.Extensions;
using GettingBetter.API.Tournament_System.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GettingBetter.API.Shared.Persistence.Contexts
{

    public class AppDbContext : DbContext
    {
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<Cyber> Cybers { get; set; }

        public DbSet<Tournament> Tournaments { get; set; }
        // public DbSet<Advisory> Advisories { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Coach>().ToTable("Coaches");
            builder.Entity<Coach>().HasKey(p => p.Id);
            builder.Entity<Coach>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Coach>().Property(p => p.FirstName).IsRequired().HasMaxLength(30);
            builder.Entity<Coach>().Property(p => p.LastName).IsRequired().HasMaxLength(30);
            builder.Entity<Coach>().Property(p => p.SelectedGame).IsRequired().HasMaxLength(30);
            builder.Entity<Coach>().Property(p => p.NickName).IsRequired().HasMaxLength(30);
            builder.Entity<Coach>().Property(p => p.Email).IsRequired().HasMaxLength(30);
            builder.Entity<Coach>().Property(p => p.Password).IsRequired().HasMaxLength(30);
            // Relationships
/*            builder.Entity<Coach>()
                .HasMany(p => p.Students)
                .WithOne(p => p.Coach)
                .HasForeignKey(p => p.CoachId);*/
            builder.Entity<Student>().ToTable("Students");
            builder.Entity<Student>().HasKey(p => p.Id);
            builder.Entity<Student>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Student>().Property(p => p.FirstName).IsRequired().HasMaxLength(30);
            builder.Entity<Student>().Property(p => p.LastName).IsRequired().HasMaxLength(30);
            builder.Entity<Student>().Property(p => p.NickName).IsRequired().HasMaxLength(30);
            builder.Entity<Student>().Property(p => p.Email).IsRequired().HasMaxLength(30);
            builder.Entity<Student>().Property(p => p.Password).IsRequired().HasMaxLength(30);

            builder.Entity<Cyber>().ToTable("Cybers");
            builder.Entity<Cyber>().HasKey(p => p.Id);
            builder.Entity<Cyber>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Cyber>().Property(p => p.FirstName).IsRequired().HasMaxLength(30);
            builder.Entity<Cyber>().Property(p => p.LastName).IsRequired().HasMaxLength(30);
            builder.Entity<Cyber>().Property(p => p.CyberName).IsRequired().HasMaxLength(30);
            builder.Entity<Cyber>().Property(p => p.Bibliography).IsRequired().HasMaxLength(30);
            builder.Entity<Cyber>().Property(p => p.Address).IsRequired().HasMaxLength(30);
            builder.Entity<Cyber>().Property(p => p.Email).IsRequired().HasMaxLength(30);
            builder.Entity<Cyber>().Property(p => p.Password).IsRequired().HasMaxLength(30);

            // Relationships
           builder.Entity<Cyber>()
                .HasMany(p => p.Tournaments)
                .WithOne(p => p.Cyber)
                .HasForeignKey(p => p.CyberId);

            builder.Entity<Tournament>().ToTable("Tournaments");
             builder.Entity<Tournament>().HasKey(p => p.Id);
             builder.Entity<Tournament>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
             builder.Entity<Tournament>().Property(p => p.Title).IsRequired().HasMaxLength(30);
             builder.Entity<Tournament>().Property(p => p.Description).IsRequired().HasMaxLength(30);
             builder.Entity<Tournament>().Property(p => p.StudentId).IsRequired(); 
             builder.Entity<Tournament>().Property(p => p.CyberId).IsRequired();
             builder.Entity<Tournament>().Property(p => p.Date).IsRequired().HasMaxLength(30); 
            
            
             /*
             builder.Entity<Advisory>().ToTable("Tournaments");
             builder.Entity<Advisory>().HasKey(p => p.Id);
             builder.Entity<Advisory>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
             builder.Entity<Advisory>().Property(p => p.StudentId).IsRequired();
             builder.Entity<Advisory>().Property(p => p.CoachId).IsRequired();
             builder.Entity<Advisory>().Property(p => p.Date).IsRequired(); 
             
             */
            // Apply Snake Case Naming Convention

            builder.UseSnakeCaseNamingConvention();
        }
    }
}