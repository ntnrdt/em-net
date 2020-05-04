using System;
using MeetApp.Data.Entities;
using MeetApp.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MeetApp.Controllers
{
    public class EventController : Controller
    {
        private IEventService _eventService;

        public EventController(IEventService eventService) => _eventService = eventService;

        // GET: Event
        public IActionResult Index() => View(_eventService.Get());

        // GET: Event/Details/5
        public IActionResult Details(int? id)
        {
            var model = _eventService.Get(id.Value);

            if (model == null) return NotFound();

            return View(model);
        }

        // GET: Event/Create
        public IActionResult Create() => View();

        // POST: Event/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Event model)
        {
            if (ModelState.IsValid)
            {
                _eventService.Create(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Event/Edit/5
        public IActionResult Edit(int? id)
        {
            var model = _eventService.Get(id.Value);

            if (model == null) return NotFound();

            return View(model);
        }

        // POST: Event/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, [FromForm] Event model)
        {
            if (ModelState.IsValid)
            {
                _eventService.Update(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Event/Delete/5
        public IActionResult Delete(int? id)
        {
            var model = _eventService.Get(id.Value);

            if (model == null) return NotFound();

            return View(model);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _eventService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
