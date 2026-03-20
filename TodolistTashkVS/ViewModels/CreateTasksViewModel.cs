using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodolistTashkVS.Models;

namespace TodolistTashkVS.ViewModels
{
    public class CreateTasksViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public int TodoListId { get; set; }
    }
}
