using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recinia.Entities;
using Recinia.Models;


namespace Recinia.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileApiController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public ProfileApiController(ApplicationDbContext _context)
        {
            context = _context;
        }
        // GET: api/Rest
        [HttpGet]
        public IEnumerable<Individual> Get()
        {
            return context.Individuals.ToList();
        }
        public async Task<IActionResult> CreateIndividual(Individual model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Add(model);
                    await context.SaveChangesAsync();
                    return RedirectToAction("index", "LoggedIn");
                }
            }
            catch (DbException ex)
            {
                ModelState.AddModelError(ex.ToString(), "Unable to save changes. Please contact a system admin");
            }
            return RedirectToAction("index", "LoggedIn", model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateHobby(Hobbies model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Add(model);
                    await context.SaveChangesAsync();
                    return RedirectToAction("index", "LoggedIn");
                }
            }
            catch(DbException ex)
            {
                ModelState.AddModelError(ex.ToString(), "Unable to save changes. Please contact a system admin");   
            }
            return RedirectToAction("index", "LoggedIn",model);
        }
        public async Task<IActionResult> CreateOrganization(Organization model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Add(model);
                    await context.SaveChangesAsync();
                    return RedirectToAction("index", "LoggedIn");
                }
            }
            catch (DbException ex)
            {
                ModelState.AddModelError(ex.ToString(), "Unable to save changes. Please contact a system admin");
            }
            return RedirectToAction("index", "LoggedIn", model);
        }

        //edit Hobbies
        [HttpPost]
        public async Task<IActionResult>EditHobby(Guid id,Hobbies model)
        {
            if (id != model.HobbieID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(model);
                    await context.SaveChangesAsync();
                    return RedirectToAction("Index", "LoggedIn");
                }
                catch(DbUpdateException ex)
                {
                    ModelState.AddModelError(ex.ToString(), "Unable to edit changes. Please contact a system admin");
                }
            }
            return RedirectToAction("Index", "LoggedIn",model);
        }
        //edit Individual
        [HttpPost]
        public async Task<IActionResult> EditIndividual(Guid id, Individual model)
        {
            if (id != model.IndividualID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(model);
                    await context.SaveChangesAsync();
                    return RedirectToAction("Index", "LoggedIn");
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError(ex.ToString(), "Unable to edit changes. Please contact a system admin");
                }
            }
            return RedirectToAction("Index", "LoggedIn", model);
        }
        //edit Organization
        [HttpPost]
        public async Task<IActionResult> EditOrganization(Guid id, Organization model)
        {
            if (id != model.OrganizationID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(model);
                    await context.SaveChangesAsync();
                    return RedirectToAction("Index", "LoggedIn");
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError(ex.ToString(), "Unable to edit changes. Please contact a system admin");
                }
            }
            return RedirectToAction("Index", "LoggedIn", model);
        }

        //Delete Hobbies
        [HttpPost]
        public async Task<IActionResult> DeleteHobby(Guid id)
        {
            var model = await context.Hobby.SingleOrDefaultAsync(x => x.HobbieID == id);
            if (model == null)
            {
                return RedirectToAction("Index", "LoggedIn");
            }
            try
            {
                context.Hobby.Remove(model);
                await context.SaveChangesAsync();
                return RedirectToAction("Index", "LoggedIn");
            }
            catch(DbUpdateException ex)
            {
                ModelState.AddModelError(ex.ToString(), "Error");
                return RedirectToAction("Index", "LoggedIn");
            }
        }
        //Delete Individual
        [HttpPost]
        public async Task<IActionResult> DeleteIndividual(Guid id)
        {
            var model = await context.Individuals.SingleOrDefaultAsync(x => x.IndividualID == id);
            if (model == null)
            {
                return RedirectToAction("Index", "LoggedIn");
            }
            try
            {
                context.Individuals.Remove(model);
                await context.SaveChangesAsync();
                return RedirectToAction("Index", "LoggedIn");
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError(ex.ToString(), "Error");
                return RedirectToAction("Index", "LoggedIn");
            }
        }
        //Delete Organization
        [HttpPost]
        public async Task<IActionResult> DeleteOrganization(Guid id)
        {
            var model = await context.Organizations.SingleOrDefaultAsync(x => x.OrganizationID == id);
            if (model == null)
            {
                return RedirectToAction("Index", "LoggedIn");
            }
            try
            {
                context.Organizations.Remove(model);
                await context.SaveChangesAsync();
                return RedirectToAction("Index", "LoggedIn");
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError(ex.ToString(), "Error");
                return RedirectToAction("Index", "LoggedIn");
            }
        }

        ////detail Hobby
        //[HttpGet]
        //public async Task<IActionResult>DetailHobby(Guid id)
        //{
        //    if(id ==null)
        //    {
        //        return NotFound();
        //    }
        //    var model = await context.Hobby.SingleOrDefaultAsync(x => x.HobbieID == id);
        //    if(model==null)
        //    {
        //        return NotFound();
        //    }
        //    return PartialView(model);
        //}
        ////detail Hobby
        //[HttpGet]
        //public async Task<IActionResult> DetailOrganization(Guid id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var model = await context.Organizations.SingleOrDefaultAsync(x => x.OrganizationID == id);
        //    if (model == null)
        //    {
        //        return NotFound();
        //    }
        //    return PartialView(model);
        //}
        ////detail Hobby
        //[HttpGet]
        //public async Task<IActionResult> DetailIndividual(Guid id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var model = await context.Individuals.SingleOrDefaultAsync(x => x.IndividualID == id);
        //    if (model == null)
        //    {
        //        return NotFound();
        //    }
        //    return PartialView(model);
        //}


        //// GET: api/Rest/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Rest
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Rest/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
