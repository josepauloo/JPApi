using Modelo.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.infra.Repositorio.Interfaces
{
    public interface IAlunoRepositorio
    {
        Aluno BuscarId(int id);

        List<Aluno> BuscarTodos();

        void Inserir(Aluno aluno);

        void DeletarPorId(int id);

        void EditarAluno(Aluno aluno);
    }
}
