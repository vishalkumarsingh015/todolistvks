using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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
                vmList.Add(new TodoListViewModel { Id = todo.Id, Title = todo.Title, Description = todo.Description, CreatedAt = todo.CreatedAt });
            }
            return vmList;
        }

        public static TodoList MapToModel(this CreateViewModels vm)
        {

            return new TodoList { Title = vm.Title, Description = vm.Description ,UserId=8};
        }
    }
}
