using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Recinia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recinia.Entities
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public ApplicationDbContext()
        {

        }
        //public DbSet<Login> Logins { get; set; }
        //public DbSet<Register> Registration { get; set; }
        public DbSet<Publication> Publications { get; set; }
        //public DbSet<Person> Persons { get; set; }
        //public DbSet<Adress> Adresses { get; set; }
        //public DbSet<Login> Logins { get; set; }
        //public DbSet<Registre> Registration { get; set; }
        public DbSet<Individual> Individuals { get; set; }
        public DbSet<Hobbies> Hobby { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Individual>().ToTable("Individual");
            modelBuilder.Entity<Organization>().ToTable("Organization");
            modelBuilder.Entity<Hobbies>().ToTable("Hobby");

            modelBuilder.Entity<Person>().HasData(new Person { ID = 1, FirstName = "Omar", LastName = "Karmous", Numéro = "123654", Display = "", TimeStamp = BitConverter.GetBytes(DateTime.UtcNow.ToBinary()) });
            modelBuilder.Entity<Person>().HasData(new Person { ID = 2, FirstName = "Mario", LastName = "brutti", Numéro = "789654", Display = "", TimeStamp = BitConverter.GetBytes(DateTime.UtcNow.ToBinary()) });
            modelBuilder.Entity<Publication>();
            modelBuilder.Entity<Publication>().HasData(new Publication { PubID = Guid.NewGuid(), contenu = "Préparation", Image = "qqsdfghbjnkjnkj", AspNetUserId = "9c879b33-b99d-4456-ad2b-c362f6fc858a" });
            modelBuilder.Entity<Publication>().HasData(new Publication { PubID = Guid.NewGuid(), contenu = "Fiche Technique", Image = "Pomme", AspNetUserId = "9c879b33-b99d-4456-ad2b-c362f6fc858a" });
            modelBuilder.Entity<Publication>().HasData(new Publication { PubID = Guid.NewGuid(), contenu = "Védio", Image = "azertyuicvb", AspNetUserId = "9c879b33-b99d-4456-ad2b-c362f6fc858a" });
            modelBuilder.Entity<Publication>().HasData(new Publication { PubID = Guid.NewGuid(), contenu = "Image", Image = "5222222222222", AspNetUserId = "9c879b33-b99d-4456-ad2b-c362f6fc858a" });

            //all of this here is a Fluent API
            //modelBuilder.Ignore<Adress>();
            //Single Primary Key
            modelBuilder.Entity<Adress>().HasKey(x => x.AddId);
            //Composite Primary Key
            modelBuilder.Entity<Person>().HasKey(x => new { x.ID, x.Numéro });
            //Required et MaxLength
            modelBuilder.Entity<Adress>().Property(z => z.ZipCode).IsRequired();
            //***************
            modelBuilder.Entity<Adress>().Property(z => z.StreetName).HasMaxLength(20);



            //Generated Properties
            // Never Generated Value
            //modelBuilder.Entity<Publication>().Property(x => x.PubID).ValueGeneratedNever();
            // Value on Generated Value
            modelBuilder.Entity<Publication>().Property(x => x.TimePost).ValueGeneratedOnAdd();
            // Value on Generated Value or update
            modelBuilder.Entity<Publication>().Property(x => x.TimePost).ValueGeneratedOnAddOrUpdate();
            //Concurrency Tokens 2 ligne
            modelBuilder.Entity<Person>().Property(x => x.LastName).IsConcurrencyToken();
            modelBuilder.Entity<Person>().Property(x => x.TimeStamp).ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
            //Indexes
            //modelBuilder.Entity<Person>().HasIndex(x => x.FirstName);
            modelBuilder.Entity<Person>().HasIndex(x => x.ID).IsUnique();
            //modelBuilder.Entity<Person>().HasIndex(x=> new { x.ID,x.FirstName});
            //Mapping table
            modelBuilder.Entity<Adress>().ToTable("Adr");
            //modelBuilder.Entity<Adress>().ToTable("Adr",schema:"Adress");
            //Computed Columns
            modelBuilder.Entity<Person>().Property(x => x.Display).HasComputedColumnSql("[FirstName]+'  '+[LastName]");


        }
    }
}
