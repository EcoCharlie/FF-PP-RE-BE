using System;
using Microsoft.EntityFrameworkCore;
using PiensaPeruAPIWeb.Domain.Models.Contents;
using PiensaPeruAPIWeb.Domain.Models.Users;
using PiensaPeruAPIWeb.Extensions;

namespace PiensaPeruAPIWeb.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {  
        //sets - Contents
        public DbSet<PoliticalParty> PoliticalParties  { get; set; }
        public DbSet<MilitantType> MilitantTypes  { get; set; }
        public DbSet<Period> Periods  { get; set; }
        
        //sets - Users
        public DbSet<User> Users  { get; set; }
        public DbSet<Plan> Plans  { get; set; }
        public DbSet<UserPlan> UserPlans  { get; set; }
        
        public AppDbContext(DbContextOptions options) : base(options) { }
        
      

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //Constraints of Content Bounded
            
           //Constraints-MilitantType
            builder.Entity<MilitantType>().ToTable("MilitantTypes");
            builder.Entity<MilitantType>().HasKey(p => p.MilitantTypeId);
            builder.Entity<MilitantType>().Property(p => p.MilitantTypeId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<MilitantType>().Property(p => p.Type).IsRequired();
            //RelationShips-MilitantType
            builder.Entity<MilitantType>()
                .HasMany(p => p.Militants)
                .WithOne(p => p.MilitantType)
                .HasForeignKey(p => p.MilitantTypeId);
            //InitialData-MilitantType
            builder.Entity<MilitantType>().HasData
            (
                new MilitantType { MilitantTypeId = 101, Type = "Good" },
                new MilitantType { MilitantTypeId = 102, Type = "Nice" }
            );
            //Constraints-Period
            builder.Entity<Period>().ToTable("Periods");
            builder.Entity<Period>().HasKey(p => p.PeriodId);
            builder.Entity<Period>().Property(p => p.PeriodId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Period>().Property(p => p.StartDate).IsRequired();
            builder.Entity<Period>().Property(p => p.EndDate).IsRequired();
            builder.Entity<Period>().Property(p => p.OriginOfChange).IsRequired().HasMaxLength(50);
            //RelationShips-Period
            builder.Entity<Period>()
                .HasMany(p => p.MilitantContents)
                .WithOne(p => p.Period)
                .HasForeignKey(p => p.PeriodId);
            //InitialData-Period}
            builder.Entity<Period>().HasData
            (
                new Period
                {
                    PeriodId = 101,
                    StartDate = new DateTime(2018, 8, 6),
                    EndDate = new DateTime(2019, 8, 6),
                    OriginOfChange = "Problems"
                },
                new Period
                {
                    PeriodId = 102,
                    StartDate = new DateTime(2016,8,6), 
                    EndDate = new DateTime(2017,8,6),
                    OriginOfChange = "Others"
                }
            );
            //Constraints - PoliticalParty
            builder.Entity<PoliticalParty>().ToTable("PoliticalParties");
            builder.Entity<PoliticalParty>().HasKey(p => p.PoliticalPartyId);
            builder.Entity<PoliticalParty>().Property(p => p.PoliticalPartyId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<PoliticalParty>().Property(p => p.PoliticalPartyName).IsRequired().HasMaxLength(50);
            builder.Entity<PoliticalParty>().Property(p => p.PresidentName).IsRequired().HasMaxLength(50);
            builder.Entity<PoliticalParty>().Property(p => p.FoundationDate).IsRequired();
            builder.Entity<PoliticalParty>().Property(p => p.Ideology).IsRequired().HasMaxLength(50);
            builder.Entity<PoliticalParty>().Property(p => p.Position).IsRequired().HasMaxLength(50);
            builder.Entity<PoliticalParty>().Property(p => p.PictureLink).IsRequired().HasMaxLength(50);
            //RelationShips-PoliticalParty
            builder.Entity<PoliticalParty>()
                .HasMany(p => p.Militants)
                .WithOne(p => p.PoliticalParty)
                .HasForeignKey(p => p.PoliticalPartyId);
            //InitialData - PoliticalParty
            builder.Entity<PoliticalParty>().HasData
            (
                new PoliticalParty
                {
                    PoliticalPartyId = 101,
                    PoliticalPartyName = "Perú Nación",
                    PresidentName = "Francisco Diez Canseco Távara",
                    FoundationDate = new DateTime(2015, 11, 28),
                    Ideology = "Conservadurismo social Democracia cristiana",
                    Position = "Centroderecha a derecha",
                    PictureLink = "https://www.proetica.org.pe/wp-content/uploads/2018/07/PERU-NACION@300x-100.jpg",
                },
                new PoliticalParty
                {
                    PoliticalPartyId = 102,
                    PoliticalPartyName = "Accion Popular",
                    PresidentName = "Mesías Guevara",
                    FoundationDate = new DateTime(1956, 7, 7),
                    Ideology = "Partido atrapalotodo",
                    Position = "Centroderecha a derecha",
                    PictureLink = "https://upload.wikimedia.org/wikipedia/commons/e/ed/Acci%C3%B3n_Popular.png",
                }
            );
            
            
            //Constraints of User Bounded
            
            //Constraints - Plan
            builder.Entity<Plan>().ToTable("Plans");
            builder.Entity<Plan>().HasKey(p => p.Id);
            builder.Entity<Plan>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Plan>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Plan>().Property(p => p.Description).IsRequired().HasMaxLength(50);
            builder.Entity<Plan>().Property(p => p.Price).IsRequired();
            //InitialData - Plan
            builder.Entity<Plan>().HasData
            (
                new Plan { Id = 101, Name = "Plan1" , Description = "Plan regular 1 año" , Price = 350 },
                new Plan { Id = 102, Name = "Plan2" , Description = "Plan especial 1/2 año", Price = 120 }
            );
            
            //Constraints - User
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(50);
            builder.Entity<User>().Property(p => p.Password).IsRequired().HasMaxLength(30);
            //InitialData - User
            builder.Entity<User>().HasData
            (
                new User { Id = 101, Email = "usuario1@email.com", Password = "123456" },
                new User { Id = 102, Email = "usuario2@email.com", Password = "987654"}
            );
            
            //Constraints - UserPlan
            builder.Entity<UserPlan>().ToTable("UserPlans");
            builder.Entity<UserPlan>().HasKey(p => new { p.UserId, p.PlanId });
            builder.Entity<UserPlan>().Property(p => p.UserId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<UserPlan>().Property(p => p.PlanId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<UserPlan>().Property(p => p.ActivatedDate).IsRequired();
            //RelationShips - UserPlan
            builder.Entity<UserPlan>() //<-RelationManyToMany
                .HasOne(p => p.User)
                .WithMany(u => u.UserPlans)
                .HasForeignKey(p => p.UserId);
            builder.Entity<UserPlan>()
                .HasOne(p => p.Plan)
                .WithMany(p => p.UserPlans)
                .HasForeignKey(p => p.PlanId);
            //InitialData - UserPlan
            builder.Entity<UserPlan>().HasData
            (
                new UserPlan { UserId = 101, PlanId = 101, ActivatedDate = new DateTime(2015, 12, 25) },
                new UserPlan { UserId = 102, PlanId = 102, ActivatedDate = new DateTime(2015, 11, 20) }
            );
            
            
            //ChangeTableNameToLower
            builder.UseSnakeCaseNamingConvention();
        }
    }
}