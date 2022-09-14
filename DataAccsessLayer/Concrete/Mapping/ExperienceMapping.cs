using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsessLayer.Mapping
{
    public class ExperienceMapping : IEntityTypeConfiguration<Experience>
    {
        public void Configure(EntityTypeBuilder<Experience> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(100);

            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(100);

            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.Date).HasMaxLength(50);

            builder.Property(x => x.ImageUrl).IsRequired(false);
            builder.Property(x => x.ImageUrl).HasMaxLength(500);

            builder.Property(x => x.Description).IsRequired(false);
            builder.Property(x => x.Description).HasMaxLength(2000);
        }
    }
}