using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;
using TodolistTashkVS.Data;
using TodolistTashkVS.Extensions;
using TodolistTashkVS.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TodolistTashkVS.Controllers
{
    public class TodolistController : Controller
    {
        private ApplicationDbContext _context;

        public TodolistController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]

        public async Task<IActionResult> Index()
        {

            var todolist = await _context.TodoLists.AsNoTracking().ToListAsync().ConfigureAwait(false);
            var vm = todolist.MapToViewModel();
            return View(vm);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var vm = new CreateViewModels();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  //security////
        public async Task<IActionResult> Create(CreateViewModels vm)
        {

            if (ModelState.IsValid)
            {
                var model = vm.MapToModel();

                await _context.TodoLists.AddAsync(model); //in-momory
                await _context.SaveChangesAsync();  //Write Sql Query Change Tracker
                return RedirectToAction(nameof(Index));
            }
            return View(new CreateViewModels());
        }

        [HttpGet]  // get request
        public async Task<IActionResult> Edit(int id)
        {
            var todo = await _context.TodoLists
                .FirstOrDefaultAsync(x => x.Id == id);

            if (todo == null)
            {
                return RedirectToAction("Index");
            }

            var vm = todo.MapToViewModel();

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TodoListViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var model = vm.MapToModel();
                _context.TodoLists.Update(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }


    }
}


//1️⃣ AsNoTracking()

//Read - only data ke liye use hota hai → performance fast karta hai.