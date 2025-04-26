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
    class BookCopyConfiguration : IEntityTypeConfiguration<BookCopy>
    {
        public void Configure(EntityTypeBuilder<BookCopy> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .UseIdentityColumn();

            builder
                .Property(x => x.IsLoanable)
                .HasColumnName("habilitado_prestamo")
                .IsRequired();

            builder
                .Property(x => x.LoanStatusId)
                .HasColumnName("estado_ejemplar_id")
                .IsRequired();            

            builder
                .ToTable("ejemplar");
        }
    }
}
