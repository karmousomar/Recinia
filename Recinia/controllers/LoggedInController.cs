using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Recinia.Entities;
using Recinia.Repository;
using Recinia.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recinia.controllers
{

    public class LoggedInController : Controller
    {
        // GET: /<controller>/
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IProfileRepository profileRepository;
        public LoggedInController(UserManager<ApplicationUser> _userManager, IProfileRepository _profileRepository)
        {
            userManager = _userManager;
            profileRepository = _profileRepository;
        }
        public IActionResult Index()
        {
            var userId = userManager.GetUserId(HttpContext.User);
            //var hobbies = context.Hobby.Where(x => x.AspNetUserId == userId).ToList();
            var hobbies = profileRepository.GetHobbyList(userId);
            var individual = profileRepository.GetIndividualList(userId);
            var organization = profileRepository.GetOrganizationList(userId);
            var model = new DashboardViewModel
            {
                Individuals = individual,
                Organization = organization,
                Hobby = hobbies
            };
            return View(model);
        }
    }
}
