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
        Retorno InserirAluno(Aluno aluno);

        void DeletarAluno(int id);

        void EditaAluno(AlunoDto alunoDto);
    }
}
