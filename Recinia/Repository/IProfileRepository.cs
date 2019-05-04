using Recinia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recinia.Repository
{
    public interface IProfileRepository
    {
        List<Hobbies> GetHobbyList(string id);
        List<Individual> GetIndividualList(string id);
        List<Organization> GetOrganizationList(string id);
    }
}
