using Kodigos.Dominio.ModelsData.Usuarios;
using Kodigos.Infra.Core;
using Kodigos.Infra.Data.Contexto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kodigos.API.Controllers.Usuarios
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly KodigosContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger<UsuariosController> _logger;

        public UsuariosController(KodigosContext context, IConfiguration configuration, ILogger<UsuariosController> logger)
        {
            _configuration = configuration;
            _context = context;
            _logger = logger;

        }
       
        [HttpGet]
        /// <summary>
        /// Lista contendo todos os Usuários
        /// </summary>
        /// <returns></returns>
        public async Task<KRetorno<List<UsuariosDTO>>> GetUsuarios()
        {
            List<UsuariosDTO> listUser = new List<UsuariosDTO>();
            var result = new KRetorno<List<UsuariosDTO>>();
            try
            {
                listUser = _context.Usuarios.ToList();


                result.Sucesso = true;
                result.TRetorno = new List<UsuariosDTO>();
                result.TRetorno = listUser;

            }
            catch (Exception e)
            {
                result.Sucesso = false;
                result.Message = "Não foi possível retornar os dados da listagem de usuários. Erro: " + e.Message;
            }

            return result;
            
        }
        [HttpGet("{id}")]
        public async Task<KRetorno<UsuariosDTO>> GetUsuario(long id)
        {

           
            var result = new KRetorno<UsuariosDTO>();

            try
            {
                UsuariosDTO usuario = _context
                                            .Usuarios
                                            .FirstOrDefault(t => t.Id == id);

                result.Sucesso = true;
                result.TRetorno = usuario;

            }
            catch (Exception e)
            {
                result.Sucesso = false;
                result.Message = "Não foi possível retornar os dados do usuário. Erro: " + e.Message;
            }

            return result;
        }


        [HttpPost]
        public async Task<KRetorno<UsuariosDTO>> PostUsuario(UsuariosDTO usuario)
        {

            var result = new KRetorno<UsuariosDTO>();

            try
            {
                    _context.Usuarios.Add(usuario);
                    _context.SaveChanges();

                    result.Sucesso = true;
                    result.TRetorno = usuario;
                    result.Message = "Usuário cadastrado com sucesso."; 

            }
            catch (Exception e)
            {
                result.Sucesso = false;
                result.Message = "Não foi possível cadastrar usuário. Erro: " + e.Message;
            }

            return result;
        }


        [HttpPut("{id}")]
        public async Task<KRetorno<UsuariosDTO>> PutUsuario(long id, UsuariosDTO usuario)
        {

            var result = new KRetorno<UsuariosDTO>();

            try
            {
                if (UsuarioIdExists(id))
                {
                    _context.Update(usuario);
                    _context.SaveChanges();

                    result.Sucesso = true;
                    result.TRetorno = usuario;
                    result.Message = "Dados do usuário alterado com sucesso.";

                }
                else
                {
                    result.Sucesso = false;
                    result.Message = "Usuário não encontrado.";
                }

            }
            catch (Exception e)
            {
                result.Sucesso = false;
                result.Message = "Não foi possível atualizar os dados do usuário. Erro: " + e.Message;
            }

            return result;
        }

        [HttpDelete("{id}")]
        public async Task<KRetorno<UsuariosDTO>> DeleteUsuario(long id)
        {

            var result = new KRetorno<UsuariosDTO>();

            try
            {
                if (UsuarioIdExists(id))
                {
                    UsuariosDTO usuario = _context.Usuarios.FirstOrDefault(t => t.Id == id);
                    if (usuario != null)
                    {
                    
                        _context.Remove(usuario);
                        _context.SaveChanges();

                        result.Sucesso = true;
                        result.TRetorno = usuario;
                        result.Message = "Usuario excluido com sucesso.";
                    }
                    else
                    {
                        result.Sucesso = false;
                        result.Message = "Registro não localizado.";
                    }

                }
                else
                {
                    result.Sucesso = false;
                    result.Message = "Registro não localizado.";
                }

            }
            catch (Exception e)
            {
                result.Sucesso = false;
                result.Message = "Não foi possível excluir o usuário . Erro: " + e.Message;
            }

            return result;
        }
        private bool UsuarioIdExists(long id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
