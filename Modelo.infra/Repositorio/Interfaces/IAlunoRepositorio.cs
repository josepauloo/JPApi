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

        Aluno Inserir(Aluno aluno);

        Aluno DeletarPorId(int id);

        void AtualizarDados(Aluno aluno);
    }
}
