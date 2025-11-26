using Microsoft.EntityFrameworkCore;
using UrbanFarming.Domain.Classes;

namespace UrbanFarming.Data.Mapping
{
    public class ProdutosMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produtos>()
                .ToTable("PRODUTO");

            modelBuilder.Entity<Produtos>()
                .HasKey(p => p.Codigo);

            modelBuilder.Entity<Produtos>()
                .Property(p => p.Codigo)
                .HasColumnName("CODIGO")
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Entity<Produtos>()
                .Property(p => p.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Produtos>()
                .Property(p => p.Valor)
                .HasColumnName("VALOR")
                .HasColumnType("decimal(18, 2)")
                .IsRequired();

            modelBuilder.Entity<Produtos>()
                .Property(p => p.Descricao)
                .HasColumnName("DESCRICAO")
                .HasMaxLength(500)
                .IsRequired(false);

            modelBuilder.Entity<Produtos>()
                .Property(p => p.LinkImagem)
                .HasColumnName("LINKIMAGEM")
                .HasMaxLength(255) 
                .IsRequired(false);
        }
    }
}
