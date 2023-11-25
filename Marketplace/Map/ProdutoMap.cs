using Marketplace.Models.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marketplace.Map
{
    public class ProdutoMap : IEntityTypeConfiguration<ProdutoModel>
    {
        public void Configure(EntityTypeBuilder<ProdutoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Preco).IsRequired();
            builder.Property(x => x.Imagem).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Vendedor).IsRequired();
            builder.Property(x => x.Categoria).IsRequired();
        }
    }
}
