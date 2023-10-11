using Modelo.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.application.Interfaces
{
    public interface IAlunoApplication
    {
        Aluno BuscaAluno(int id);
        Aluno InserirAluno(Aluno aluno);
        Aluno DeletarAluno(int id);
        void AtualizarDadosAluno(Aluno aluno);
    }
}
