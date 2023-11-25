using Marketplace.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marketplace.Map
{
    public class VendedorMap : IEntityTypeConfiguration<VendedorModel>
    {
        public void Configure(EntityTypeBuilder<VendedorModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.RazaoSocial).IsRequired().HasMaxLength(255);
            builder.Property(x => x.NomeFantasia).IsRequired().HasMaxLength(11);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Senha).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Cnpj).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Comissao).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Endereco).IsRequired();
        }
    }
}
