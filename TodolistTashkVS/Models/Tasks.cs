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

        // FK
        public int TodoListId { get; set; }
        public TodoList? TodoList { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // ✅ enum use
        public Status Status { get; set; } = Status.Pending;
        public Priority Priority { get; set; } = Priority.Medium;

        public DateTime? DueDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }


        // navigation collections
        public ICollection<SubTask> SubTasks { get; set; } = new HashSet<SubTask>();
        public ICollection<Note> Notes { get; set; } = new HashSet<Note>();
        public ICollection<Remainder> Remainders { get; set; } = new HashSet<Remainder>();
        public ICollection<TaskTag> TaskTags { get; set; } = new HashSet<TaskTag>();
    }

    public enum Priority
    {
        Low,
        Medium,
        High,
        Urgent
    }
    public enum Status
    {
        Pending,
        InProgress,
        Completed,
        Cancelled
    }
}
