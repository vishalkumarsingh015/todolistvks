using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodolistTashkVS.Models;

namespace TodolistTashkVS.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<SubTask> SubTasks { get; set; }

        public DbSet<Note> Notes { get; set; }

        public DbSet<Remainder> Remainders { get; set; }

        public DbSet<TaskTag> TaskTags { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)                                            // Ye EF Core ka special method hai ; jub migration run hoti hai tab ye method execute hota hai
        {
            base.OnModelCreating(modelBuilder);                                                                              //Ye parent class ka default behavior call karta hai.

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);                           //"Jitni bhi configuration classes hain (jo IEntityTypeConfiguration implement karti hain), sabko automatically apply kr do
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<TodoList>().ToTable("TodoList"); //cofig.. 
        //    base.OnModelCreating(modelBuilder);
        //}

    }
}
