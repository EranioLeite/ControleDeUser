using Kodigos.Dominio.ModelsData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodigos.Infra.Data.Configuration
{
    public class CadastroConfiguration
    {
        public CadastroConfiguration(EntityTypeBuilder<Cadastro> entity)
        {
            if (entity != null)
            {
                entity.ToTable("Cadastro").HasKey(t => t.Id);
                entity.Property(t => t.nome);
            }
        }
    }
}
