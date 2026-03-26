using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodolistTashkVS.ViewModels
{
    public class createNoteViewModel
    {
        public int Id { get; set; }
        public int TasksId { get; set; }
        //public Tasks Tasks { get; set; }
        public string Content { get; set; } = "This is content ";
        public DateTimeOffset CreatedAt { get; set; }
    }
}
