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
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(n => n.Id);

            builder.HasOne(n => n.Tasks)
                   .WithMany(t => t.Notes)
                   .HasForeignKey(n => n.TasksId)
                   .OnDelete(DeleteBehavior.Cascade);


            builder.Property(n => n.Content)
                .HasMaxLength(400);

            builder.Property(n => n.CreatedAt)
                   .HasDefaultValueSql("GETDATE()");

        }
    }
}
