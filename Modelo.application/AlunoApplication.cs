using Modelo.application.Interfaces;
using Modelo.domain;
using Modelo.infra.Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Modelo.application
{
    public class AlunoApplication : IAlunoApplication
    {
        private readonly IAlunoRepositorio _alunoRepositorio;
        public AlunoApplication(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }

        public Aluno BuscaAluno(int id)
        {
            var aluno = _alunoRepositorio.BuscarId(id);
            return aluno;
        }
        public bool InserirAluno(Aluno aluno)
        {
            try
            {
                _alunoRepositorio.Inserir(aluno);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
