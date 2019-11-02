using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcBoilerPlate.AspNetCore.Contracts;
using MvcBoilerPlate.AspNetCore.Domains.Entity;
using MvcBoilerPlate.AspNetCore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvcBoilerPlate.AspNetCore.Controllers
{
    public class PersonController : Controller
    {

        private readonly ILogger<PersonController> _logger;
        private readonly IPersonManager _personManager;
        private readonly IMapper _mapper;
        public PersonController(IPersonManager personManager, IMapper mapper, ILogger<PersonController> logger) {
            _personManager = personManager;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IActionResult> List()
        {
            var persons = await _personManager.GetAllAsync();
            var dto = _mapper.Map<IEnumerable<PersonViewModel>>(persons);
            return View(dto);
        }

        public async Task<IActionResult> Details(long id) {
            var person = await _personManager.GetByIdAsync(id);
            var dto = _mapper.Map<PersonViewModel>(person);
            return View(dto);
        }

        public  IActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,DateOfBirth")] PersonViewModel dto) {
            try
            {
                if (ModelState.IsValid)
                {
                    var person = _mapper.Map<Person>(dto);
                    await _personManager.CreateAsync(person);

                    return RedirectToAction(nameof(List));
                }
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "Error when trying to insert new record in database.");
                ModelState.AddModelError("", "Unable to save changes.");
            }

            return View(dto);
        }

        public async Task<IActionResult> Edit(long? id) {
            var person = await _personManager.GetByIdAsync(id);
            var dto = _mapper.Map<PersonViewModel>(person);

            return View(dto);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(long? id) {

            if (id == null)
                return NotFound();

            var personToUpdate = await _personManager.GetByIdAsync(id);

            if (await TryUpdateModelAsync(personToUpdate, "", p => p.FirstName, p => p.LastName, p => p.DateOfBirth))
            {
                try
                {
                    await _personManager.UpdateAsync(personToUpdate);
                    return RedirectToAction(nameof(List));
                }
                catch (Exception ex)
                {
                    _logger.Log(LogLevel.Error, ex, "Error when trying to update record in database.");
                    ModelState.AddModelError("", "Unable to save changes.");
                }
            }

            var dto = _mapper.Map<PersonViewModel>(personToUpdate);

            return View(dto);
        }

        public async Task<IActionResult> Delete(long? id, bool? saveChangesError = false) {
            if (id == null)
                return NotFound();

            var personToDelete = await _personManager.GetByIdAsync(id);

            if (personToDelete == null)
                return NotFound();

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }

            var dto = _mapper.Map<PersonViewModel>(personToDelete);

            return View(dto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id) {
            var found = await _personManager.ExistAsync(id);
            if (!found)
                return RedirectToAction(nameof(List));

            try
            {
                await _personManager.DeleteAsync(id);
                return RedirectToAction(nameof(List));
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "Error when trying to delete record in database.");
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }


    }
}