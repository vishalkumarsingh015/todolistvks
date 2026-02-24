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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
           // Primary Key
        builder.HasKey(u => u.Id);

     
            builder.Property(u => u.Name)
                   .IsRequired()
                   .HasMaxLength(100);

         
            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(150);

     
            builder.HasIndex(u => u.Email)
                   .IsUnique();

      
            builder.Property(u => u.PasswordHash)
                   .IsRequired();

       
            builder.Property(u => u.CreatedAt)
                   .HasDefaultValueSql("GETDATE()");

        
            builder.HasMany(u => u.TodoLists)
                   .WithOne(t => t.User)
                   .HasForeignKey(t => t.UserId)
                   .OnDelete(DeleteBehavior.Cascade);



        }
    }
}


// Name
// Email
// Email unique
// PasswordHash
// CreatedAt default value
// Relationship: User -> TodoLists (One-to-Many)