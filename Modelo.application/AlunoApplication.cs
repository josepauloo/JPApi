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

        public Retorno InserirAluno(Aluno aluno)
        {
            Retorno retorno = new();

            if (aluno != null)
            {
                var mensagem = ValidaAluno(aluno);

                if (mensagem != null)
                {
                    retorno.CarregaRetorno(false, mensagem, 200);
                    return retorno;
                }

                _alunoRepositorio.Inserir(aluno);

                retorno.CarregaRetorno(true, "Aluno adicionado com sucesso", 200);
            }
            else
            {
                retorno.CarregaRetorno(true, "Nenhum dado foi informado", 200);
            }
            return retorno;
       
        }

        public void DeletarAluno(int id)
        {
             _alunoRepositorio.DeletarPorId(id);

        }

        public void EditaAluno(AlunoDto alunoDto)
        {
            Aluno aluno = new Aluno();

            aluno.Id = alunoDto.Id;
            aluno.Nome = alunoDto.Nome;
            aluno.Idade = alunoDto.Idade;
            aluno.Matrícula = alunoDto.Matrícula;
            aluno.Nota = alunoDto.Nota;
            aluno.Cep = alunoDto.Cep;

            _alunoRepositorio.EditarAluno(aluno);

        }


        private string ValidaAluno(Aluno aluno)
        {
            string mensagem = "";

            if (!aluno.Matrícula.Any())
                mensagem = "Não é possivel inserir um aluno sem matrícula";
            

            if (aluno.Cep.Length > 9)
                mensagem = $"O cep {aluno.Cep} ultrapassa os limites de tamanho";
            

            return mensagem;
        }

    }
}
// VALIDAÇÃO INSERIR ALUNO ===>       verificar se os campos tão preenchidos, tamanho máximo dos campos, se  

// VALIDAÇÃO DELERTAR ALUNO ===>        verificar se o id existe no banco

// VALIDAÇÃO EDItar ALUNO ===>          se os campos estão todos preenchidos, tamanho máximo dos campos, se o cep está corretamente escrito, verificar se existe no banco



