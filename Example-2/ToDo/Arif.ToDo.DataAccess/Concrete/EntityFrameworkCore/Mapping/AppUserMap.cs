using System;
using System.Collections.Generic;
using System.Text;
using Arif.ToDo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arif.ToDo.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(I => I.Name).HasMaxLength(100);
            builder.Property(I => I.SurName).HasMaxLength(150);

            builder.HasMany(I => I.Tasks)
                .WithOne(I => I.AppUser)
                .HasForeignKey(I => I.AppUserId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
