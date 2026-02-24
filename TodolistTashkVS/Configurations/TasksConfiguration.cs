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
    public class TasksConfiguration : IEntityTypeConfiguration<Tasks>
    {
        public void Configure(EntityTypeBuilder<Tasks> builder)
        {
            //primary key
            builder.HasKey(t => t.Id);

            //Title required
            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(100);

            //Description required

            builder.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(300);

            //status required

            builder.Property(t => t.Status)
                .IsRequired()

                .HasMaxLength(20)
             .HasDefaultValue("Pending");



            //priority

            builder.Property(t => t.Priority)

                 .IsRequired();

            //DueDate
            builder.Property(t => t.DueDate);

            //CreatedAt
            builder.Property(t => t.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            //updatedAT
            builder.Property(t => t.UpdatedAt);

            //realtaion todolist-task one to many

            builder.HasOne(t => t.TodoList)
       .WithMany(tl => tl.Tasks)
       .HasForeignKey(t => t.TodoListId)
       .OnDelete(DeleteBehavior.Cascade);





        }
    }
}
