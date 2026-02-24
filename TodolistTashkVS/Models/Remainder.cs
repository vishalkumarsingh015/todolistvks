using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodolistTashkVS.Models
{
    public class Remainder
    {
        public int Id { get; set; }
        public int TasksId { get; set; }
        public Tasks Tasks { get; set; }
        public DateTime RemindAt { get; set; }


    }
}
