using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodolistTashkVS.Models;

namespace TodolistTashkVS.Configurations
{
    public class TodoListConfiguration : IEntityTypeConfiguration<TodoList>
    {
        public void Configure(EntityTypeBuilder<TodoList> builder)
        {
          
            builder.HasKey(t => t.Id);


   

            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(100);

      

            builder.Property(t => t.Description)
                   .HasMaxLength(200);

       

            builder.Property(t => t.CreatedAt)
                 .HasDefaultValueSql("GETDATE()");

    

            builder.HasOne(t => t.User)
                 .WithMany(u => u.TodoLists)
                 .HasForeignKey(t => t.UserId)
                 .OnDelete(DeleteBehavior.Cascade);


        }
    }
}







//primary keyyy
//Titel(Required)
//Description (Optional)
//CreatedAt (Default value)
//Relation:user Todolist(one to many)