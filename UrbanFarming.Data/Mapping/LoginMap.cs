using Microsoft.EntityFrameworkCore;
using UrbanFarming.Domain.Classes;

namespace UrbanFarming.Data.Mapping
{
    public class LoginMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>()
                .ToTable("Login");

            modelBuilder.Entity<Login>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Login>()
                .Property(x => x.Email)
                .HasColumnName("Email");

            modelBuilder.Entity<Login>()
                .Property(x => x.Senha)
                .HasColumnName("Senha");

            modelBuilder.Entity<Login>()
                .Property(x => x.Nome)
                .HasColumnName("Nome");
            
            modelBuilder.Entity<Login>()
                .Property(x => x.Administrador)
                .HasColumnName("Administrador");
        }
    }
}
