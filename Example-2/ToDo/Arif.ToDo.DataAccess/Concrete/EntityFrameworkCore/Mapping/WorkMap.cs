using System;
using System.Collections.Generic;
using System.Text;
using Arif.ToDo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arif.ToDo.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class WorkMap : IEntityTypeConfiguration<Work>
    {
        public void Configure(EntityTypeBuilder<Work> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Name).HasMaxLength(150);

            builder.Property(I => I.Description).HasColumnType("ntext");
        }
    }
}
