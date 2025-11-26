using Microsoft.EntityFrameworkCore;
using UrbanFarming.Data.Mapping;
using UrbanFarming.Domain.Classes;

namespace UrbanFarming.Data.Context
{
    public class UrbanContext : DbContext
    {
        public UrbanContext(DbContextOptions<UrbanContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            LoginMap.Map(modelBuilder);
            ProdutosMap.Map(modelBuilder);
            FornecedoresMap.Map(modelBuilder);
            //PedidosMap.Map(modelBuilder);
            modelBuilder.Entity<Pedido>()
            .HasKey(t => t.CodigoPedido);  

            modelBuilder.Entity<ItensPedido>().HasNoKey();

            //modelBuilder.Entity<Pedido>()
            //    .HasMany(p => p.Itens); 

            //ItensPedidoMap.Map(modelBuilder);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Login> Login { get; set; }
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<Fornecedores> Fornecedores { get; set; }
        public DbSet<Pedido> PedidoLst { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<ItensPedido> ItensPedido { get; set; } 
    }
}
