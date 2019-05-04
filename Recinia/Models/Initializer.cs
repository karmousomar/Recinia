using Recinia.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recinia.Models
{
    public static class Initializer
    {
        public static void InitializeContext(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Individuals.Any())
            {
                return;
            }

            // Individuals
            var individual = new Individual
            {
                FullName = "Carson",
                DateOfBirth = DateTime.Now,
                Address = "4437 Texas Street",
                AspNetUserId = "9c879b33-b99d-4456-ad2b-c362f6fc858a",
                State = "TX",
                City = "Allen",
                ZipCode = "75254"
            };

            context.Individuals.Add(individual);
            context.SaveChanges();
            // Individuals
            var individual1 = new Individual
            {
                FullName = "karmous",
                DateOfBirth = DateTime.Now,
                Address = "12 mai 1964",
                AspNetUserId = "9c879b33-b99d-4456-ad2b-c362f6fc858a",
                State = "TX",
                City = "Allen",
                ZipCode = "4070"
            };

            context.Individuals.Add(individual1);
            context.SaveChanges();

            // Organizations
            var organization = new Organization
            {
                BusinessName = "IT Group",
                HireDate = DateTime.Now,
                Address = "205 Joiner Street",
                AspNetUserId = "9c879b33-b99d-4456-ad2b-c362f6fc858a",
                State = "TX",
                Profession = "Developer",
                City = "Allen",
                ZipCode = "75254"
            };
            context.Organizations.Add(organization);
            context.SaveChanges();

            // Hobbies
            var hobby = new Hobbies
            {
                HobbieID = Guid.NewGuid(),
                Name = "Exercise",
                Rating = 5,
                AspNetUserId = "9c879b33-b99d-4456-ad2b-c362f6fc858a",
            };
            context.Hobby.Add(hobby);
            context.SaveChanges();



        }
    }
}
