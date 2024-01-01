using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodigos.Dominio.ModelsData.Usuarios
{
    public class UsuariosDTO: BaseDTO<long>
    {
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public int nivelAcesso { get; set; }
    }
}
