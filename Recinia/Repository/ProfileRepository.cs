using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recinia.Entities;
using Recinia.Models;

namespace Recinia.Repository
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly ApplicationDbContext context;
        public ProfileRepository(ApplicationDbContext _context)
        {
            context = _context;
        }
        public List<Hobbies> GetHobbyList(string id)
        {
            return context.Hobby.Where(x => x.AspNetUserId == id).ToList();
        }

        public List<Individual> GetIndividualList(string id)
        {
            return context.Individuals.Where(x => x.AspNetUserId == id).ToList();
        }

        public List<Organization> GetOrganizationList(string id)
        {
            return context.Organizations.Where(x => x.AspNetUserId == id).ToList();
        }
    }
}
