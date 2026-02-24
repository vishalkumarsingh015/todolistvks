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
    public class SubTaskConfiguration : IEntityTypeConfiguration<SubTask>
    {
        public void Configure(EntityTypeBuilder<SubTask> builder)
        {
            builder.HasKey(X => X.Id); //pri

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(225);

            builder.HasOne(x => x.Tasks)
                   .WithMany(t => t.SubTasks)
                   .HasForeignKey(x => x.TasksId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.IsCompleted)
                  .HasDefaultValue(false);

        }
    }
}
