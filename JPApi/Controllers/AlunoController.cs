using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelo.application.Interfaces;
using Modelo.domain;

namespace JPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoApplication _alunoApplication;
        public AlunoController(IAlunoApplication alunoApplication)
        {
            _alunoApplication = alunoApplication;
        }
        [HttpGet("BuscarDadosAluno/{id}")]
        public async Task<IActionResult> BuscarDadosAluno(int id)
        {
            Retorno<Aluno> retorno = new(null);

            try
            {
                var aluno = _alunoApplication.BuscaAluno(id);
                retorno.CarregaRetorno(aluno, true, "Consulta realizada com sucesso", 200);

                return Ok(retorno);
            }
            catch(Exception)
            {
                return BadRequest("Erro");
            }
        }

        [HttpPost("InserirDadosAluno")]
        public async Task<IActionResult> InserirDadosAluno([FromBody] Aluno aluno)
        {
            try
            {
                bool InsercaoSucesso = _alunoApplication.InserirAluno(aluno);
                if(InsercaoSucesso)
                {
                    return Ok("Aluno inserido com sucesso");
                }
                else
                {
                    return BadRequest("Erro ao inserir aluno");
                }
            }
            catch
            {
                return BadRequest("Erro");
            }
        }

        //[HttpPut("EditarDadosAluno")]
        //public async Task<IActionResult> EditarDadosAluno([FromBody] AlunoDto aluno)
        //{
        //    try
        //    {
        //        var aluno = _alunoApplication.InserirAluno(aluno);


        //        return Ok("Aluno inserido com sucesso");
              
        //    }
        //    catch
        //    {
        //        return BadRequest("Erro");
        //    }
        //}
    }
}
