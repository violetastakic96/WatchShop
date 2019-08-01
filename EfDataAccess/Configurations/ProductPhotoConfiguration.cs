using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class ProductPhotoConfiguration : IEntityTypeConfiguration<ProductPhoto>
    {
        public void Configure(EntityTypeBuilder<ProductPhoto> builder)
        {
            builder.Property(pp => pp.Alt).IsRequired();
            builder.Property(pp => pp.Path).IsRequired();

            builder.Property(pp => pp.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
