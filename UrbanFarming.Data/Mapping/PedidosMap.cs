using Microsoft.EntityFrameworkCore;
using UrbanFarming.Domain.Classes;

namespace UrbanFarming.Data.Mapping
{
    public class PedidosMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>()
                .ToTable("Pedidos");

            modelBuilder.Entity<Pedido>()
                .HasKey(p => p.CodigoPedido);

            modelBuilder.Entity<Pedido>()
                .Property(p => p.CodigoPedido)
                .HasColumnName("CodigoPedido")
                .IsRequired();

            modelBuilder.Entity<Pedido>()
                .Property(p => p.ValorTotal)
                .HasColumnName("ValorTotal")
                .IsRequired()
                .HasColumnType("decimal(10, 2)");

            modelBuilder.Entity<Pedido>()
                .Property(p => p.Usuario)
                .HasColumnName("Usuario")
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Pedido>()
                .Property(p => p.Data)
                .HasColumnName("Data")
                .IsRequired();

            modelBuilder.Entity<Pedido>()
                .HasMany(p => p.Itens);
        }
    }
}
