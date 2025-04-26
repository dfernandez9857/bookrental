using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using bookrental.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookrental.infrastructure.Data.Configurations
{
    class LoanDetailConfiguration : IEntityTypeConfiguration<LoanDetail>
    {
        public void Configure(EntityTypeBuilder<LoanDetail> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("id")
                .UseIdentityColumn();

            builder
                .Property(x => x.LoanId)
                .HasColumnName("prestamo_id")
                .IsRequired();

            builder
                .Property(x => x.BookCopyId)
                .HasColumnName("ejemplar_id")
                .IsRequired();

            builder.HasOne(ld => ld.Loan)
                .WithMany(l => l.LoanDetails)
                .HasForeignKey(ld => ld.LoanId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ld => ld.BookCopy)
                .WithMany()
                .HasForeignKey(ld => ld.BookCopyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .ToTable("detalle_prestamo");
        }
    }
}
