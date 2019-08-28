using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuy.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Repositorio.Config
{
    class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(u => u.Senha)
                .IsRequired()
                .HasMaxLength(800);

            builder.Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(50);
            
            builder.Property(u => u.Sobrenome)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(u => u.Pedidos)
                .WithOne(p => p.Usuario);
        }
    }
}
