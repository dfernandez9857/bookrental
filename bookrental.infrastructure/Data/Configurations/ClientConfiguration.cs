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
    class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .UseIdentityColumn();

            builder
                .Property(x => x.FirstName)
                .HasColumnName("nombres")
                .IsRequired();

            builder
                .Property(x => x.LastName)
                .HasColumnName("apellidos")
                .IsRequired();

            builder
                .Property(x => x.IdentityDocument)
                .HasColumnName("documento_identidad")
                .IsRequired();

            builder
                .ToTable("cliente");
        }
    }
}
