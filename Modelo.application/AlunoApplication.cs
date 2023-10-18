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

        public Retorno DeletarAluno(int id)
        {
            Retorno retorno = new();

            if (id <= 0)
            {
                retorno.CarregaRetorno(false, $"O id {id} informado não é válido", 200);
                return retorno;
            }

            _alunoRepositorio.DeletarPorId(id);

            retorno.CarregaRetorno(true, "Aluno excluído com sucesso", 200);
            return retorno;
        }


        //public Retorno DeletarAluno(int id)
        //{
        //    Retorno retorno = new();

        //    if (id > 0)
        //    {
        //        var mensagem = ValidaId(id);

        //        if (mensagem != null)
        //        {
        //            retorno.CarregaRetorno(false, mensagem, 200);
        //            return retorno;

        //        }

        //         _alunoRepositorio.DeletarPorId(id);

        //         retorno.CarregaRetorno(true, "Aluno excluído com sucesso", 200);

        //    }
        //    else
        //    {
        //        retorno.CarregaRetorno(false, $"O id {id} informado não é válido", 200);
        //    }
        //    return retorno;
        //}




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

            if (!aluno.Nome.Any())
                mensagem = "Não é possivel inserir um aluno sem nome";

            if (!aluno.Matrícula.Any())
                mensagem = "Não é possivel inserir um aluno sem matrícula";

            if (!aluno.Cep.Any())
                mensagem = "Não é possivel inserir um aluno sem cep";

            if (aluno.Cep.Length > 9)
                mensagem = $"O cep {aluno.Cep} ultrapassa os limites de tamanho";


            //VALIDAR SE A IDADE É INT E SE TEM ALGO NO CAMPO
            int idade;
            bool idadeValida = int.TryParse(aluno.Idade.ToString(), out idade);
            if (!idadeValida)
                mensagem = "Não é possivel inserir um aluno sem idade ou uma válida";


            //VALIDAR SE A NOTA É DECIMAL E SE TEM ALGO NO CAMPO
            decimal nota;
            bool notaValida = decimal.TryParse(aluno.Nota.ToString(), out nota);
            if (!notaValida || aluno.Nota == null)
                mensagem = "Não é possivel inserir um aluno sem nota ou uma válida";

            return mensagem;
        }


        private string ValidaId(int id)
        {
            string mensagem = "";

            //if (id < 1)
            //    mensagem = $"O id {id} informado não é válido";



            //VALIDAR SE O ID É INT
            int result;
            bool success = int.TryParse(id.ToString(), out result);
            if (!success)
                mensagem = $"O id {id} informado está no formato decimal, tente colocar um inteiro";

            return mensagem;
        }

    }
}
// VALIDAÇÃO INSERIR ALUNO ===>       verificar se os campos tão preenchidos, tamanho máximo dos campos, se estão no tipo certo

// VALIDAÇÃO DELERTAR ALUNO ===>        verificar se o id existe no banco, se é menor que 1, 

// VALIDAÇÃO EDItar ALUNO ===>          se os campos estão todos preenchidos, tamanho máximo dos campos, se o cep está corretamente escrito, verificar se existe no banco



