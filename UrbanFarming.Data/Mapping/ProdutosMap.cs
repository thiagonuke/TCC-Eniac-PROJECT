using Microsoft.EntityFrameworkCore;
using UrbanFarming.Domain.Classes;

namespace UrbanFarming.Data.Mapping
{
    public class ProdutosMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produtos>()
                .ToTable("Produtos");

            modelBuilder.Entity<Produtos>()
                .HasKey(p => p.Codigo);

            modelBuilder.Entity<Produtos>()
                .Property(p => p.Codigo)
                .HasColumnName("Codigo")
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Entity<Produtos>()
                .Property(p => p.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Produtos>()
                .Property(p => p.Valor)
                .HasColumnName("Valor")
                .HasColumnType("decimal(18, 2)")
                .IsRequired();

            modelBuilder.Entity<Produtos>()
                .Property(p => p.Descricao)
                .HasColumnName("Descricao")
                .HasMaxLength(500)
                .IsRequired(false);

            modelBuilder.Entity<Produtos>()
                .Property(p => p.LinkImagem)
                .HasColumnName("LinkImagem")
                .HasMaxLength(255) 
                .IsRequired(false);
        }
    }
}
