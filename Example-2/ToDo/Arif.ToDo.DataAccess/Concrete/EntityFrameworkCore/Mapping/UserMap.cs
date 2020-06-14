using System;
using System.Collections.Generic;
using System.Text;
using Arif.ToDo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arif.ToDo.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Name).HasMaxLength(100).IsRequired();

            builder.Property(I => I.Surname).HasMaxLength(100).IsRequired();

            builder.Property(I => I.Phone).HasMaxLength(15).IsRequired();

            builder.Property(I => I.EMail).HasMaxLength(100).IsRequired();

            builder.HasMany(I => I.Works).WithOne(I => I.User).HasForeignKey(I => I.UserId);
        }
    }
}
