using System;
using System.Collections.Generic;
using System.Text;
using Arif.ToDo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arif.ToDo.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class ReportMap : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Definition).HasMaxLength(100).IsRequired();
            builder.Property(I => I.Description).HasColumnType("ntext");

            builder.HasOne(I => I.Task)
                .WithMany(I => I.Report)
                .HasForeignKey(I => I.TaskId);
        }
    }
}
