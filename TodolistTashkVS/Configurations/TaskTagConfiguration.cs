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
    public class TaskTagConfiguration : IEntityTypeConfiguration<TaskTag>
    {
        public void Configure(EntityTypeBuilder<TaskTag> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Tasks)
                   .WithMany(t => t.TaskTags)
                   .HasForeignKey(x => x.TasksId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Tag)
                   .WithMany(t => t.TaskTags)
                   .HasForeignKey(x => x.TagId)
                   .OnDelete(DeleteBehavior.Cascade);


            builder.HasIndex(x => new { x.TasksId, x.TagId })
                 .IsUnique();





            //Unique composite index ensure karta hai ki ek task par same tag repeat na ho.”








        }
    }
}
