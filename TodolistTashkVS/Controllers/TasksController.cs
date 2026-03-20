using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodolistTashkVS.Data;
using TodolistTashkVS.Models;
using TodolistTashkVS.ViewModels;

namespace TodolistTashkVS.Controllers
{
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // GET: Tasks/Create?todoListId=1
        [HttpGet]
        public IActionResult Create(int todoListId)
        {
            var vm = new CreateTasksViewModel
            {
                TodoListId = todoListId,
                DueDate = DateTimeOffset.Now
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTasksViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var todoExists = await _context.TodoLists.AnyAsync(x => x.Id == vm.TodoListId);

            if (!todoExists)
            {
                ModelState.AddModelError("", "Invalid TodoListId. Parent TodoList not found.");
                return View(vm);
            }

            var model = new Tasks
            {
                Title = vm.Title,
                Description = vm.Description ?? string.Empty,
                Status = vm.Status,
                Priority = vm.Priority,
                DueDate = vm.DueDate.DateTime,
                TodoListId = vm.TodoListId
            };

            await _context.Tasks.AddAsync(model);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { todoListId = vm.TodoListId });
        }

        [HttpGet]
        public async Task<IActionResult> Details(int todoListId)
        {
            var taskList = await _context.Tasks
                .Where(x => x.TodoListId == todoListId)
                .ToListAsync();

            var vm = taskList.Select(task => new TaskListViewModel
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status,
                Priority = task.Priority,
                DueDate = task.DueDate ?? DateTime.Now
            }).ToList();

            ViewBag.TodoListId = todoListId;
            return View(vm);
        }


    }
}