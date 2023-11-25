using Marketplace.Model;
using Marketplace.Models.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Marketplace.Data
{
    public class MarketPlaceDBContext : DbContext
    {
        public MarketPlaceDBContext(DbContextOptions<MarketPlaceDBContext> options) : base(options)
        {
        }
        //implemente outros models
        public DbSet<ClienteModel> Cliente { get; set; }
        public DbSet<EnderecoModel> Endereco { get; set; }
        public DbSet<CategoriaModel> Categoria { get; set; }
        public DbSet<ProdutoModel> Produto { get; set; }
        public DbSet<VendedorModel> Vendedor { get; set; }
        public DbSet<CarrinhoModel> Carrinho { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteModel>()
                .Property(c => c.Endereco)
                .HasConversion(
                    e => JsonConvert.SerializeObject(e),
                    e => JsonConvert.DeserializeObject<EnderecoModel>(e)
                );
            //implemente outros maps
            base.OnModelCreating(modelBuilder);
        }
    }
}
