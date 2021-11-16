using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PiensaPeruAPIWeb.Domain.Models.Users;
using PiensaPeruAPIWeb.Extensions;

namespace PiensaPeruAPIWeb.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {

        //sets - Users
        public DbSet<User> Users  { get; set; }
        public DbSet<Plan> Plans  { get; set; }
        public DbSet<UserPlan> UserPlans  { get; set; }
        
        public AppDbContext(DbContextOptions options) : base(options) { }
        
      
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
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
            builder.Entity<User>().HasKey(u => u.Id);
            builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(u => u.Email).IsRequired().HasMaxLength(50);
            builder.Entity<User>().Property(u => u.Password).IsRequired().HasMaxLength(30);
            //InitialData - User
            builder.Entity<User>().HasData
            (
                new User { Id = 101, Email = "usuario1@email.com", Password = "123456" },
                new User { Id = 102, Email = "usuario2@email.com", Password = "987654"}
            );
            
            //Constraints - UserPlan
            builder.Entity<UserPlan>().ToTable("UserPlans");
            builder.Entity<UserPlan>().HasKey(up => new { up.UserId, up.PlanId });
            builder.Entity<UserPlan>().Property(up => up.UserId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<UserPlan>().Property(up => up.PlanId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<UserPlan>().Property(up => up.ActivatedDate).IsRequired();
            //RelationShips - UserPlan
            builder.Entity<UserPlan>() //<-RelationManyToMany
                .HasOne(up => up.User)
                .WithMany(u => u.UserPlans)
                .HasForeignKey(up => up.UserId);
            builder.Entity<UserPlan>()
                .HasOne(up => up.Plan)
                .WithMany(p => p.UserPlans)
                .HasForeignKey(up => up.PlanId);
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