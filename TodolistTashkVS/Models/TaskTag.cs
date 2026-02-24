using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodolistTashkVS.Models
{
    public class TaskTag
    {
        public int Id { get; set; }
        public int TasksId { get; set; }
        public Tasks Tasks { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
