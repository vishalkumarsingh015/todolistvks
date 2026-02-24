using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodolistTashkVS.Models;

namespace TodolistTashkVS.Configurations
{
    public class RemainderConfiguration : IEntityTypeConfiguration<Remainder>
    {
        public void Configure(EntityTypeBuilder<Remainder> builder)
        {
            builder.HasKey(r => r.Id);

            builder.HasOne(r => r.Tasks)
                   .WithMany(t => t.Remainders)
                   .HasForeignKey(r => r.TasksId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(r => r.RemindAt)
                .IsRequired();



            // builder.HasIndex(r => new { r.TasksId, r.RemindAt });

            //Without index
            //    Database poori table scan karega

            //    With index
            //    Direct relevant reminders mil jayenge(fast)
        }
    }
}
