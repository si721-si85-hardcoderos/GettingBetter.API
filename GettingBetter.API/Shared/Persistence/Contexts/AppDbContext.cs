using GettingBetter.API.Advisory_System.Domain.Models;
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
        public DbSet<Advisory> Advisories { get; set; }
        
        
        public DbSet<RegisterTournament> RegisterTournaments { get; set; } 
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
            builder.Entity<Coach>().Property(p => p.Bibliography);
            builder.Entity<Coach>().Property(p => p.UserImage);
           
            builder.Entity<Coach>().HasData(
                new Coach { 
                    Id = 1,
                    FirstName = "Jose",
                    LastName = "Rodrigues", 
                    SelectedGame = "Dota 2",
                    NickName = "Tupac Amaru",
                    Email = "jose@gmail.com",
                    Password = "password",
                    UserImage = "https://e.rpp-noticias.io/normal/2016/10/29/023202_277176.png",
                    Bibliography = "Soy uno de los mejores Jugadores en Dota 2 y gane en varios torneos"
                } 
            );
            builder.Entity<Coach>().HasData(
                new Coach { 
                    Id = 2,
                    FirstName = "Eduardo",
                    LastName = "Flores", 
                    SelectedGame = "Mobile Legends",
                    NickName = "Seven",
                    Email = "eduardo@gmail.com",
                    Password = "password",
                    UserImage = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQM1QDTGY4XAju-jLpJnhADF4QzVjgvV_G5yjfAwiois5O0RKran-exjPaGWgRafp3zXAE&usqp=CAU",
                    Bibliography = "Soy uno de los mejores Jugadores en Mobile legends y gane en varios torneos"
                } 
            );
            
            builder.Entity<Coach>().HasData(
                new Coach { 
                    Id = 3,
                    FirstName = "Omar",
                    LastName = "Alvarado", 
                    SelectedGame = "League of Legends",
                    NickName = "Estoico",
                    Email = "omar@gmail.com",
                    Password = "password",
                    UserImage = "https://i0.wp.com/hipertextual.com/wp-content/uploads/2015/11/gamer-2.jpg?fit=810%2C501&quality=50&strip=all&ssl=1",
                    Bibliography = "Soy uno de los mejores Jugadores en League of Leguends y gane en varios torneos"
                } 
            );
            builder.Entity<Student>().ToTable("Students");
            builder.Entity<Student>().HasKey(p => p.Id);
            builder.Entity<Student>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Student>().Property(p => p.FirstName).IsRequired().HasMaxLength(30);
            builder.Entity<Student>().Property(p => p.LastName).IsRequired().HasMaxLength(30);
            builder.Entity<Student>().Property(p => p.NickName).IsRequired().HasMaxLength(30);
            builder.Entity<Student>().Property(p => p.Email).IsRequired().HasMaxLength(30);
            builder.Entity<Student>().Property(p => p.Password).IsRequired().HasMaxLength(30);
            builder.Entity<Student>().Property(p => p.UserImage);
            
            builder.Entity<Student>().HasData(
                new Student { 
                    Id = 1,
                    FirstName = "Jorge",
                    LastName = "Tupia",
                    NickName = "Tapia",
                    Email = "jorge@gmail.com",
                    Password = "password",
                    UserImage = "https://esports.eldesmarque.com/wp-content/uploads/2016/10/17431372369_b85998e8a6_k.jpg"
                } 
            );
            
            builder.Entity<Student>().HasData(
                new Student { 
                    Id = 2,
                    FirstName = "Frederick",
                    LastName = "Torres",
                    NickName = "Dracker",
                    Email = "frederick@gmail.com",
                    Password = "password",
                    UserImage = "https://i.pinimg.com/280x280_RS/70/eb/51/70eb515308d099ee37f86cc8cd923a74.jpg"
                } 
            );
            
            builder.Entity<Student>().HasData(
                new Student { 
                    Id = 3,
                    FirstName = "Manuel",
                    LastName = "Lopez",
                    NickName = "Manueh",
                    Email = "manuel@gmail.com",
                    Password = "password",
                    UserImage = "https://i.pinimg.com/200x150/4a/3b/7c/4a3b7c9d322b1d6854499bb2966dda72.jpg"
                } 
            );
            
            builder.Entity<Cyber>().ToTable("Cybers");
            builder.Entity<Cyber>().HasKey(p => p.Id);
            builder.Entity<Cyber>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Cyber>().Property(p => p.FirstName).IsRequired().HasMaxLength(30);
            builder.Entity<Cyber>().Property(p => p.LastName).IsRequired().HasMaxLength(30);
            builder.Entity<Cyber>().Property(p => p.CyberName).IsRequired().HasMaxLength(30);
            builder.Entity<Cyber>().Property(p => p.Bibliography).HasMaxLength(300);
            builder.Entity<Cyber>().Property(p => p.Address).IsRequired().HasMaxLength(120);
            builder.Entity<Cyber>().Property(p => p.Email).IsRequired().HasMaxLength(30);
            builder.Entity<Cyber>().Property(p => p.Password).IsRequired().HasMaxLength(30);
            builder.Entity<Cyber>().Property(p => p.CyberImage);
            builder.Entity<Cyber>().HasData(
                new Cyber { 
                    Id = 1,
                    FirstName = "Erick",
                    LastName = "Brocka",
                    CyberName = "Cuates",
                    Bibliography = "Tenemos mas de 20 máquinas con todos los juegos online posibles y disponibles para todos ustedes y también tenemos muchas botanas",
                    Address = "AV. Javier Prado Lt2 Manzada D4",
                    Email = "erick@gmail.com",
                    Password = "password",
                    CyberImage = "https://esports.eldesmarque.com/wp-content/uploads/2016/10/17431372369_b85998e8a6_k.jpg"
                } 
            );
            builder.Entity<Cyber>().HasData(
                new Cyber { 
                    Id = 2,
                    FirstName = "Bruno",
                    LastName = "Diaz",
                    CyberName = "CyberCueva",
                    Bibliography = "Tenemos mas de 20 máquinas con todos los juegos online posibles y disponibles para todos ustedes y también tenemos muchas botanas",
                    Address = "Centro Comercial Arenales Puesto 115 2do piso",
                    Email = "bruno@gmail.com",
                    Password = "password",
                    CyberImage = "https://media-cdn.tripadvisor.com/media/photo-s/1a/29/1a/05/legend-cyber-cafe-burwood.jpg"
                } 
            );
            builder.Entity<Cyber>().HasData(
                new Cyber { 
                    Id = 3,
                    FirstName = "Nicolas",
                    LastName = "Gonzales",
                    CyberName = "El peruanaso gaming",
                    Bibliography = "Tenemos mas de 20 máquinas con todos los juegos online posibles y disponibles para todos ustedes y también tenemos muchas botanas", 
                    Address = "Centro comercial Moterrico Rico puesto 20, al frente de la UPC",
                    Email = "nicolas@gmail.com",
                    Password = "password",
                    CyberImage = "http://sislander.com/wp-content/uploads/2015/04/cyber_cafe_gaming.jpg"
                } 
            );
            
           builder.Entity<Cyber>()
                .HasMany(p => p.Tournaments)
                .WithOne(p => p.Cyber)
                .HasForeignKey(p => p.CyberId);

             builder.Entity<Tournament>().ToTable("Tournaments");
             builder.Entity<Tournament>().HasKey(p => p.Id);
             builder.Entity<Tournament>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
             builder.Entity<Tournament>().Property(p => p.Title).IsRequired().HasMaxLength(30);
             builder.Entity<Tournament>().Property(p => p.Description).IsRequired().HasMaxLength(900);
             builder.Entity<Tournament>().Property(p => p.CyberId).IsRequired();
             builder.Entity<Tournament>().Property(p => p.Date).IsRequired().HasMaxLength(30); 
             builder.Entity<Tournament>().Property(p => p.Addres).IsRequired().HasMaxLength(120);  
             builder.Entity<Tournament>().HasData(
                 new Tournament { 
                     Id = 1,
                     Title = "¡Torneo de Dota 2 para 16 jugadores incribete!",
                     Description = "El torneo se realizará a partir de las 4pm, el premio sera de s/100, los concursantes" +
                                   "deberan combatir 1 vs 1 en linea media sin la posibilidad de hacer jungla ",
                     CyberId = 1,
                     Date = "30/06/2022",
                     Addres = "AV. Javier Prado Lt2 Manzada D4"
                 } 
             );
             builder.Entity<RegisterTournament>().ToTable("Register_Tournaments");
             builder.Entity<RegisterTournament>().HasKey(p => p.Id);
             builder.Entity<RegisterTournament>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
             builder.Entity<RegisterTournament>().Property(p => p.StudentId).IsRequired();
             builder.Entity<RegisterTournament>().Property(p => p.TournamentId).IsRequired();
             
             builder.Entity<Tournament>()
                 .HasMany(p => p.RegisterTournaments)
                 .WithOne(p => p.Tournament)
                 .HasForeignKey(p => p.TournamentId);
             
             builder.Entity<Student>()
                 .HasMany(p =>p.RegisterTournaments)
                 .WithOne(p => p.Student)
                 .HasForeignKey(p => p.StudentId);
             builder.UseSnakeCaseNamingConvention();
             
             
             builder.Entity<Advisory>().ToTable("Advisories");
             builder.Entity<Advisory>().HasKey(p => p.Id);
             builder.Entity<Advisory>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
             builder.Entity<Advisory>().Property(p => p.AdvisoryImage).IsRequired().HasMaxLength(200);
             builder.Entity<Advisory>().Property(p => p.DiscorServer).IsRequired().HasMaxLength(150);
             builder.Entity<Advisory>().Property(p => p.Title).IsRequired().HasMaxLength(100);
             builder.Entity<Advisory>().Property(p => p.Description).IsRequired().HasMaxLength(300); 
             builder.Entity<Advisory>().Property(p => p.Hour).IsRequired().HasMaxLength(10);  
             builder.Entity<Advisory>().Property(p => p.Date).IsRequired().HasMaxLength(10);
             builder.Entity<Advisory>().Property(p => p.StudentId).IsRequired();
             builder.Entity<Advisory>().Property(p => p.CoachId).IsRequired();
             builder.Entity<Advisory>().HasData(
                 new Advisory
                 {
                    Id = 1,
                    AdvisoryImage = "https://staticg.sportskeeda.com/editor/2021/04/45716-16195438439457-800.jpg",
                    DiscorServer = "Quasimodo",
                    Title = "(DOTA 2) Learn from the pros",
                    Description = "Meet a pro-gamer to improve your skills",
                    Hour = "9:30pm",
                    Date = "21-07-2022",
                    StudentId = 2,
                    CoachId = 1
                 }
             );
             
             builder.Entity<Advisory>().HasData(
                 new Advisory
                 {
                     Id = 2,
                     AdvisoryImage = "https://dota2freaks.com/wp-content/uploads/sites/10/2020/02/dota-2-recommended-items.jpg",
                     DiscorServer = "AS - WILD",
                     Title = "(DOTA 2) Support Itemization",
                     Description = "How to build to help your team",
                     Hour = "10:30pm",
                     Date = "29-08-2022",
                     StudentId = 1,
                     CoachId = 2
                 }
             );

             builder.Entity<Student>()
                 .HasMany(p => p.Advisories)
                 .WithOne(p => p.Student)
                 .HasForeignKey(p => p.StudentId);

             builder.Entity<Coach>()
                 .HasMany(p =>p.Advisories)
                 .WithOne(p => p.Coach)
                 .HasForeignKey(p => p.CoachId);
             builder.UseSnakeCaseNamingConvention();




        }
    }
}