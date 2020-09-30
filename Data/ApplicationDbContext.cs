using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;
using SeniorProject.Models;

namespace SeniorProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser,IdentityRole<int>,int>
  

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {



        }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetForeignKeys())
         .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Assesment>(g =>            {                g.HasOne(g => g.Student).WithMany(b => b.AssesmentStudents).OnDelete(DeleteBehavior.Restrict);
                g.HasOne(g => g.Trainee).WithMany(b => b.AssesmentTrainees).OnDelete(DeleteBehavior.Restrict);            });

            modelBuilder.Entity<LabDay>(u =>            {                u.Property<DateTime>("date")                       .HasColumnType("date");

            });

            modelBuilder.Entity<Accident>(u =>            {                u.Property<DateTime>("Date")                       .HasColumnType("date");

            });

            modelBuilder.Entity<Assesment>(u =>            {                u.Property<DateTime>("date")                       .HasColumnType("date");

            });

            /*modelBuilder.Entity<Bacteria>()            .HasIndex(p => new { p.x, p.y })            .IsUnique(true);*/



        }





        public DbSet<SeniorProject.Models.Accident> Accident { get; set; }

        
        

        public DbSet<SeniorProject.Models.Assesment> Assesment { get; set; }

        
        

        public DbSet<SeniorProject.Models.Attendance> Attendance { get; set; }

        
        

        public DbSet<SeniorProject.Models.Bacteria> Bacteria { get; set; }

        
        

        public DbSet<SeniorProject.Models.Biowaste> Biowaste { get; set; }

        
        

        public DbSet<SeniorProject.Models.Box> Box { get; set; }

        
        

        public DbSet<SeniorProject.Models.Collaboration> Collaboration { get; set; }

        
        

        public DbSet<SeniorProject.Models.Company> Company { get; set; }

        
        

        public DbSet<SeniorProject.Models.Equipment> Equipment { get; set; }

        
        

        public DbSet<SeniorProject.Models.Experiment> Experiment { get; set; }

        
        

        public DbSet<SeniorProject.Models.Form> Form { get; set; }

        
        

        public DbSet<SeniorProject.Models.Freezer> Freezer { get; set; }

        
        

        public DbSet<SeniorProject.Models.LabDay> LabDay { get; set; }

        
        

        public DbSet<SeniorProject.Models.Machine> Machine { get; set; }

        
        

        public DbSet<SeniorProject.Models.MeetingPresence> MeetingPresence { get; set; }

        
        

        public DbSet<SeniorProject.Models.MeetingRoomReservation> MeetingRoomReservation { get; set; }

        
        

        public DbSet<SeniorProject.Models.Order> Order { get; set; }

        
        

        public DbSet<SeniorProject.Models.Permission> Permission { get; set; }

        
        

        public DbSet<SeniorProject.Models.Project> Project { get; set; }

        
        

        public DbSet<SeniorProject.Models.ProjectCollaboration> ProjectCollaboration { get; set; }

        
        

        public DbSet<SeniorProject.Models.ProjectResearcher> ProjectResearcher { get; set; }

        
        

        public DbSet<SeniorProject.Models.Researcher> Researcher { get; set; }

        
        

        public DbSet<SeniorProject.Models.Rotation> Rotation { get; set; }

        
        

        public DbSet<SeniorProject.Models.TestingAndCalibration> TestingAndCalibration { get; set; }



    }
}
