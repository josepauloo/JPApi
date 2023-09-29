using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        //public List<Aluno> BuscarAlunos()
        //{
        //    return _bancoContexto.Aluno.ToList();
        //}

        //public void EditarAluno(Aluno aluno)
        //{
        //    _bancoContexto.Aluno.Update(aluno);
        //    _bancoContexto.SaveChanges();
        //}

        //public void InserirAluno(Aluno aluno)
        //{
        //    _bancoContexto.Aluno.Add(aluno);
        //    _bancoContexto.SaveChanges();
        //}
        //public void ExcluirAluno(int Id)
        //{
        //    var alunoParaExcluir = _bancoContexto.Aluno.FirstOrDefault(a => a.Id == Id);
        //    if (alunoParaExcluir != null)
        //    {
        //        _bancoContexto.Aluno.Remove(alunoParaExcluir);
        //        _bancoContexto.SaveChanges();
        //    }
        //}

        //public Aluno BuscarId(int Id)
        //{
        //    return _bancoContexto.Aluno.FirstOrDefault(a => a.Id == Id);
        //}
    }
}
