using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;
using TodolistTashkVS.Data;
using TodolistTashkVS.Extensions;
using TodolistTashkVS.ViewModels;


namespace TodolistTashkVS.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    [Authorize]
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
        [ValidateAntiForgeryToken]  // security
        public async Task<IActionResult> Create(CreateViewModels vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                return RedirectToAction("Login", "Account");
            }

            int userId = Convert.ToInt32(userIdClaim.Value);

            var model = vm.MapToModel(userId);

            await _context.TodoLists.AddAsync(model); // in-memory
            await _context.SaveChangesAsync(); // Write SQL Query Change Tracker

            return RedirectToAction(nameof(Index));
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

        public IActionResult Open(int Id)
        {
            var todo = _context.TodoLists.Find(Id);
            var vm = todo.MapToViewModel();
            if (vm == null)
                return NotFound();
            //return View(vm);

            return RedirectToAction("Details", "Tasks", new {todolistId = Id });

        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TodoListViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                return RedirectToAction("Login", "Account");
            }

            int userId = Convert.ToInt32(userIdClaim.Value);

            var model = vm.MapToModel(userId);

            _context.TodoLists.Update(model);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                return RedirectToAction("Login", "Account");
            }

            int userId = Convert.ToInt32(userIdClaim.Value);

            var todo = await _context.TodoLists
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);

            if (todo == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var vm = todo.MapToViewModel();
            return View(vm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                return RedirectToAction("Login", "Account");
            }

            int userId = Convert.ToInt32(userIdClaim.Value);

            var todo = await _context.TodoLists
                .FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);

            if (todo == null)
            {
                return RedirectToAction(nameof(Index));
            }

            _context.TodoLists.Remove(todo);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}


//1️⃣ AsNoTracking()

//Read - only data ke liye use hota hai → performance fast karta hai.