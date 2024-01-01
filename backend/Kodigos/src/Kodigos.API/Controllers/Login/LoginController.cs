using System;
using System.Linq;
using Kodigos.Dominio.ModelsData;
using Kodigos.Dominio.ModelsData.Usuarios;
using Kodigos.Infra.Core;
using Kodigos.Infra.Data.Contexto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace Kodigos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly KodigosContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger<LoginController> _logger;

        public LoginController(KodigosContext context, IConfiguration configuration, ILogger<LoginController> logger)
        {
            _configuration = configuration;
            _context = context;
            _logger = logger;

        }

        [HttpPost]
        public async Task<KRetorno<UsuariosDTO>> AcessarSistema(LoginDTO dados)
        {

            var result = new KRetorno<UsuariosDTO>();
            var user = new UsuariosDTO();

            try
            {
                user = _context.Usuarios.SingleOrDefault(t => t.email == dados.usuario && t.senha == dados.senha);
                _context.SaveChanges();

                result.Sucesso = true;
                result.TRetorno = user;
                result.Message = "login realizado com sucesso.";

            }
            catch (Exception e)
            {
                result.Sucesso = false;
                result.Message = "Não foi possível acessar o sistema. Erro: " + e.Message;
            }

            return result;
        }

    }
}
