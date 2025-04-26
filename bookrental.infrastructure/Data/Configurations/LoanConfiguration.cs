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
    class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .UseIdentityColumn();

            builder
                .Property(x => x.ClientId)
                .HasColumnName("cliente_id")
                .IsRequired();

            builder
                .Property(x => x.LoanChannel)
                .HasColumnName("canal_prestamo")
                .IsRequired();

            builder
                .Property(x => x.LoanDate)
                .HasColumnName("fecha_prestamo")
                .IsRequired();

            builder
                .Property(x => x.ReturnDate)
                .HasColumnName("fecha_devolucion")
                .IsRequired();

            builder
                .Property(x => x.LoanStatusId)
                .HasColumnName("estado_prestamo_id")
                .IsRequired();

            builder
                .Property(x => x.RegisteredByUserId)
                .HasColumnName("usuario_registra_prestamo")
                .IsRequired();

            builder
                .Property(x => x.DueDate)
                .HasColumnName("fecha_devolver")
                .IsRequired();


            builder
                .ToTable("prestamo");
        }
    }
}
