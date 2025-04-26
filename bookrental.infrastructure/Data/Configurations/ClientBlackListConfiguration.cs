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
    class ClientBlackListConfiguration : IEntityTypeConfiguration<ClientBlackList>
    {
        public void Configure(EntityTypeBuilder<ClientBlackList> builder)
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
                .Property(x => x.Reason)
                .HasColumnName("motivo")
                .HasMaxLength(255)
                .IsRequired();

            builder
                .HasOne(b => b.Client)
                .WithMany(c => c.ClientBlackLists)
                .HasForeignKey(b => b.ClientId);

            builder
                .ToTable("lista_negra_cliente");
        }
    }
}
