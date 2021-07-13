using MentoriaDevSTi3.data.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MentoriaDevSTi3.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome).HasColumnType("varchar(250)").IsRequired();
            builder.Property(p => p.Cep).HasColumnType("varchar(8)").IsRequired();
            builder.Property(p => p.Endereco).HasColumnType("varchar(250)").IsRequired();
            builder.Property(p => p.Cidade).HasColumnType("varchar(100)").IsRequired();
        }
    }
}
