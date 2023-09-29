using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelo.application.Interfaces;

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
            try
            {
                var aluno = _alunoApplication.BuscarAluno(id);
                return Ok(aluno);
            }
            catch
            {
                return BadRequest("Erro");
            }
        }
    }
}
