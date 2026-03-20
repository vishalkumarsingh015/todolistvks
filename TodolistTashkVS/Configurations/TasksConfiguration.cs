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
            // Primary Key
            builder.HasKey(t => t.Id);

            // Title
            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(100);

            // Description
            builder.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(300);

            // ✅ Status (ENUM → STRING)
            builder.Property(t => t.Status)
                .HasConversion<string>()
                .IsRequired()
                .HasDefaultValue(Status.Pending);

            // ✅ Priority (ENUM → STRING)
            builder.Property(t => t.Priority)
                .HasConversion<string>()
                .IsRequired()
                .HasDefaultValue(Priority.Medium);

            // DueDate
            builder.Property(t => t.DueDate);

            // CreatedAt
            builder.Property(t => t.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            // UpdatedAt
            builder.Property(t => t.UpdatedAt);

            // Relation (TodoList → Tasks)
            builder.HasOne(t => t.TodoList)
                .WithMany(tl => tl.Tasks)
                .HasForeignKey(t => t.TodoListId)
                .OnDelete(DeleteBehavior.Cascade);





        }
    }
}
