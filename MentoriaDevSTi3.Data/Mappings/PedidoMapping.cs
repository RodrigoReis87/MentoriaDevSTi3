using MentoriaDevSTi3.data.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data.Entity.ModelConfiguration;

namespace MentoriaDevSTi3.Data.Mappings
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.FormaPagamento).HasColumnType("varchar(100").IsRequired();
            builder.Property(p => p.Valor).HasColumnType("varchar(250").IsRequired();

            builder.HasMany(f => f.ItensPedido).WithOne(p => p.Pedido).HasForeignKey(p => p.PedidoId);
        }
    }
}
