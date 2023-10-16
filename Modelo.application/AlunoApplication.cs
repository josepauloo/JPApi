﻿using Modelo.application.Interfaces;
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

        public Aluno InserirAluno(Aluno aluno)
        {
       
                _alunoRepositorio.Inserir(aluno);
                return aluno;
        }

        public Aluno DeletarAluno(int id)
        {
            var alunoParaExcluir = _alunoRepositorio.DeletarPorId(id);
            if (alunoParaExcluir != null)
            {
                return alunoParaExcluir;
            }
            else
            {
                return null;
            }
        }

        //public void AtualizarDadosAluno(Aluno aluno)
        //{
        //    _alunoRepositorio.AtualizarDados(aluno);
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
    }
}
