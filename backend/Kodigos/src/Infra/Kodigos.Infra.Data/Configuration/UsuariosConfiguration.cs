using Kodigos.Dominio.ModelsData;
using Kodigos.Dominio.ModelsData.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodigos.Infra.Data.Configuration
{
    public class UsuariosConfiguration
    {
        public UsuariosConfiguration(EntityTypeBuilder<UsuariosDTO> entity)
        {
            if (entity != null)
            {
                entity.ToTable("Usuarios").HasKey(t => t.Id);
                entity.Property(t => t.nome);
                entity.Property(t => t.sobrenome);
                entity.Property(t => t.email);
                entity.Property(t => t.senha);
                entity.Property(t => t.nivelAcesso);
            }
        }
    }
}
