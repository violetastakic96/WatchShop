using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(r => r.Name).IsRequired();
            builder.Property(r => r.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.HasData(
                new Role() { Id = 1, Name = "Administrator", IsDeleted = false },
                new Role() { Id = 2, Name = "User", IsDeleted = false }
                ); 
        }
    }
}
