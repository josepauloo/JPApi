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

                if(aluno != null)
                {
                    retorno.CarregaRetorno(aluno, true, "Consulta realizada com sucesso", 200);
                }
                else
                {
                    retorno.CarregaRetorno(aluno, true, $"Aluno com o id {id} não foi encontrado", 204);
                }

                return Ok(retorno);
            }
            catch(Exception e)
            {
                retorno.CarregaRetorno(false, e.Message, 400);

                return BadRequest(retorno);
            }
        }


        [HttpPost("InserirDadosAluno")]
        public async Task<IActionResult> InserirDadosAluno([FromBody] Aluno aluno)
        {
            Retorno retorno = new();

            try
            {
                retorno = _alunoApplication.InserirAluno(aluno);

                return Ok(retorno);
            
            }
            catch(Exception e)
            {
                retorno.CarregaRetorno(false, e.Message, 400);

                return BadRequest(retorno);
            }
        }


        [HttpDelete("DeletarAluno/{id}")]
        public async Task<IActionResult> DeletarAluno(int id)
        {
            Retorno retorno = new();

            try
            {
                retorno = _alunoApplication.DeletarAluno(id);

                return Ok(retorno);

            }
            catch (Exception e)
            {
                retorno.CarregaRetorno(false, e.Message, 400);

                return BadRequest(retorno);
            }
        }


        [HttpPut("EditarDadosAluno")]
        public async Task<IActionResult> EditarDadosAluno([FromBody] AlunoDto alunoDto)
        {
            Retorno<Aluno> retorno = new(null);

            try
            {
                _alunoApplication.EditaAluno(alunoDto);

                retorno.CarregaRetorno(true, "Dados atualizados com sucesso", 200);

                return Ok(retorno);
            }
            catch (Exception e)
            {

                retorno.CarregaRetorno(false, e.Message, 400);

                return BadRequest(retorno);
            }
        } 
    }
}
