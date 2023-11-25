using Marketplace.Models.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marketplace.Map
{
    public class CarrinhoMap : IEntityTypeConfiguration<CarrinhoModel>
    {
        public void Configure(EntityTypeBuilder<CarrinhoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DataPedido).IsRequired();
            builder.Property(x => x.ValorTotal).IsRequired();
            builder.Property(x => x.StatusPedido).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Cliente).IsRequired();
            builder.Property(x => x.Produto).IsRequired();
        }
    }
}
