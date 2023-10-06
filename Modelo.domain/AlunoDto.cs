using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.domain
{
    public class AlunoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Matrícula { get; set; }
        public double Nota { get; set; }
        public string Cep { get; set; }
    }
}
