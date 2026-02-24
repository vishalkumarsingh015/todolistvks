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
    public class TagConfiguration : IEntityTypeConfiguration<Tag>


    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                 .IsRequired()
                 .HasMaxLength(50);

            builder.Property(t => t.Color)
                  .IsRequired()
                  .HasMaxLength(20);

            builder.HasIndex(t => t.Name)
                .IsUnique();

            //->Same naam ka tag dobara add nahi ho sakta
        }
    }
}


//Agar case-insensitive chahiye (Urgent = urgent):

//builder.Property(t => t.Name)
//       .UseCollation("SQL_Latin1_General_CP1_CI_AS");