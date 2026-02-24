using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodolistTashkVS.Models
{
    public class SubTask
    {
        public int Id { get; set; }
        public int TasksId { get; set; }
        public Tasks Tasks { get; set; }

        public required string Title { get; set; }

        public bool IsCompleted { get; set; }



    }
}
