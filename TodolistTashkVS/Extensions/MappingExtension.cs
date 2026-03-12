using TodolistTashkVS.Models;
using TodolistTashkVS.ViewModels;

namespace TodolistTashkVS.Extensions
{
    public static class MappingExtension
    {
        public static List<TodoListViewModel> MapToViewModel(this List<TodoList> list)
        {
            var vmList = new List<TodoListViewModel>();

            foreach (var todo in list)
            {
                vmList.Add(new TodoListViewModel
                {
                    Id = todo.Id,
                    UserId = todo.UserId,
                    Title = todo.Title,
                    Description = todo.Description,
                    CreatedAt = todo.CreatedAt
                });
            }

            return vmList;
        }

        public static TodoListViewModel MapToViewModel(this TodoList todoList)
        {
            return new TodoListViewModel
            {
                Id = todoList.Id,
                UserId = todoList.UserId,
                Title = todoList.Title,
                Description = todoList.Description,
                CreatedAt = todoList.CreatedAt
            };
        }

        public static TodoList MapToModel(this CreateViewModels vm, int userId)
        {
            return new TodoList
            {
                Title = vm.Title,
                Description = vm.Description,
                UserId = userId,
                CreatedAt = DateTime.UtcNow
            };
        }

        public static TodoList MapToModel(this TodoListViewModel vm, int userId)
        {
            return new TodoList
            {
                Id = vm.Id,
                UserId = userId,
                Title = vm.Title,
                Description = vm.Description,
                CreatedAt = vm.CreatedAt
            };
        }

        public static User MapToUser(this RegisterViewModel vm)
        {
            return new User
            {
                Name = vm.Name,
                Email = vm.Email,
                PasswordHash = vm.Password
            };
        }

        public static User MapToUser(this LoginViewModel vm)
        {
            return new User
            {
                Name = string.Empty,
                Email = vm.Email,
                PasswordHash = vm.Password
            };
        }
    }
}