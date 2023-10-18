using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modelo.domain;
using Modelo.infra.Repositorio.Interfaces;

namespace Modelo.infra.Repositorio
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly BancoContexto _bancoContexto;

        public AlunoRepositorio(BancoContexto bancoContexto)
        {
            _bancoContexto = bancoContexto;
        }

        public Aluno BuscarId(int id)
        {
            return _bancoContexto.Aluno.FirstOrDefault(x => x.Id == id);
        }

        public void Inserir(Aluno aluno)
        {
            _bancoContexto.Aluno.Add(aluno);
            _bancoContexto.SaveChanges();
        }
         
        public void DeletarPorId(int id)
        {
            var alunoParaExcluir = _bancoContexto.Aluno.FirstOrDefault(x => x.Id == id);
                _bancoContexto.Aluno.Remove(alunoParaExcluir);
                _bancoContexto.SaveChanges();
 
        }

        public void EditarAluno(Aluno aluno)
        {
            _bancoContexto.Aluno.Update(aluno);
            _bancoContexto.SaveChanges();
        }
    }
}
