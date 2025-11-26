using Microsoft.EntityFrameworkCore;
using UrbanFarming.Domain.Classes;

namespace UrbanFarming.Data.Mapping
{
    public class ItensPedidoMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItensPedido>()
                .ToTable("ItensPedido");

            modelBuilder.Entity<ItensPedido>()
                .HasKey(i => i.CodigoPedido);


            modelBuilder.Entity<ItensPedido>()
                .Property(i => i.CodigoPedido)
                .HasColumnName("CodigoPedido")
                .IsRequired();

            modelBuilder.Entity<ItensPedido>()
                .Property(i => i.NomeProduto)
                .HasColumnName("NomeProduto")
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<ItensPedido>()
                .Property(i => i.CodigoProduto)
                .HasColumnName("CodigoProduto")
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<ItensPedido>()
                .Property(i => i.Quantidade)
                .HasColumnName("Quantidade")
                .IsRequired();

            modelBuilder.Entity<ItensPedido>()
                .Property(i => i.ValorUnitario)
                .HasColumnName("ValorUnitario")
                .IsRequired()
                .HasColumnType("decimal(10, 2)");
        }
    }
}
