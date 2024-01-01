
using Kodigos.Dominio.ModelsData;
using Kodigos.Dominio.ModelsData.Usuarios;
using Kodigos.Infra.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodigos.Infra.Data.Contexto
{
    public class KodigosContext : DbContext
    {
       public DbSet<Cadastro> Cadastro { get; set; }
        public DbSet<UsuariosDTO> Usuarios {  get; set; }

    

        public KodigosContext(DbContextOptions<KodigosContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder != null)
            {
                _ = new UsuariosConfiguration(modelBuilder.Entity<UsuariosDTO>());
                _ = new CadastroConfiguration(modelBuilder.Entity<Cadastro>());

            }
        }
    }
}
