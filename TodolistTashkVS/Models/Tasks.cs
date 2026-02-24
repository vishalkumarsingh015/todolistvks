using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodolistTashkVS.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        public int TodoListId { get; set; } //FK
        public TodoList TodoList { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }

        public required string Status { get; set; }
        public int Priority { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }


        public ICollection<SubTask> SubTasks { get; set; } = new HashSet<SubTask>();
        public ICollection<Note> Notes { get; set; } = new HashSet<Note>();
        public ICollection<Remainder> Remainders { get; set; } = new HashSet<Remainder>();
        public ICollection<TaskTag> TaskTags { get; set; } = new HashSet<TaskTag>();



    }
}
