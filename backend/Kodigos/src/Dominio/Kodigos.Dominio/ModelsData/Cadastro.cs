using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodigos.Dominio.ModelsData
{
    public class Cadastro: BaseDTO<long>
    {
        public string nome { get; set; }
    }
}
