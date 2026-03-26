using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodolistTashkVS.Data;
using TodolistTashkVS.Extensions;
using TodolistTashkVS.Models;
using TodolistTashkVS.ViewModels;

namespace TodolistTashkVS.Controllers
{
    public class AddTagController : Controller
    {

        private readonly ApplicationDbContext _context;

        public AddTagController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tag
        public async Task<IActionResult> AddTagView(int todoListId)
        {
            //if (todoListId <= 0)
            //{
            //    return BadRequest("Invalid TodoListId");
            //}

            ViewBag.TodoListId = todoListId;   

            var tags = await _context.Tags
                .Where(x => x.TodoListId == todoListId) // optional but best
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .ToListAsync();

            var vm = tags.MapToViewModel();
            return View(vm);
        }

        // GET: Tag/Create

        [HttpGet]
     
        public IActionResult Create(int todoListId)
        {
            return View(new AddTagViewModel
            {
                TodoListId = todoListId
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddTagViewModel vm)
        {
            vm.Name = vm.Name?.Trim();

            if (!ModelState.IsValid)
                return View(vm);

            var isExist = await _context.Tags
                .AnyAsync(x => x.Name == vm.Name && x.TodoListId == vm.TodoListId);

            if (isExist)
            {
                ModelState.AddModelError("Name", "This tag already exists for this todo list.");
                return View(vm);
            }

            var tag = vm.MapToModel();

            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(AddTagView), new { todoListId = vm.TodoListId });
        }

        // GET: Tag/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var tag = await _context.Tags.FirstOrDefaultAsync(x => x.Id == id);

            if (tag == null)
                return NotFound();

            return View(tag.MapToViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AddTagViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var tag = await _context.Tags.FirstOrDefaultAsync(x => x.Id == vm.Id);

            if (tag == null)
                return NotFound();

            tag.Name = vm.Name;
            tag.Color = vm.Color;

            await _context.SaveChangesAsync();

            TempData["success"] = "Tag updated successfully.";
            return RedirectToAction(nameof(AddTagView), new { todoListId = tag.TodoListId });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var tag = await _context.Tags
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (tag == null)
                return NotFound();

            return View(tag.MapToViewModel());
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tag = await _context.Tags.FirstOrDefaultAsync(x => x.Id == id);

            if (tag == null)
                return NotFound();

            var todoListId = tag.TodoListId;

            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();

            TempData["success"] = "Tag deleted successfully.";
            return RedirectToAction(nameof(AddTagView), new { todoListId = todoListId });
        }
    }
}

