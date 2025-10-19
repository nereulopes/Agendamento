using Microsoft.AspNetCore.Mvc;
using Agendamento.Aplicacao.Dtos;
using Agendamento.Aplicacao.Servicos;
using Microsoft.VisualBasic;
using System.Reflection.Metadata.Ecma335;
using System.Linq.Expressions;

namespace Agendamento.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "Agendamentos")]
    public class AgendamentoController : ControllerBase
    {
        private readonly AplicAgendamento _aplicAgendamento;

        public AgendamentoController(AplicAgendamento aplicAgendamento)
        {
            _aplicAgendamento = aplicAgendamento;
        }

        /// <summary>
        /// Cadastro de alunos.
        /// </summary>
        /// <param name="dto">Dados do aluno: nome e o tipo de plano (1 - Mensal, 2 - Trimestral ou 3 - Anual) do aluno.</param>
        /// <remarks>
        /// Exemplo:
        ///         
        ///     POST /api/agendamento/aluno
        ///     {
        ///        "nome": "Nereu Lopes",
        ///        "plano": "1"
        ///     }
        /// </remarks>
        [HttpPost("aluno")]
        public IActionResult CadastrarAluno([FromBody] AlunoDto dto)
        {
            var id = _aplicAgendamento.CadastrarAluno(dto);
            return Ok(new { Mensagem = "Cadastro de aluno efetuado com sucesso!", Id = id });
        }

        /// <summary>
        /// Cadastro de aulas.
        /// </summary>
        /// <param name="dto">Dados da aula: Tipo da aula (Cross = 1, Funcional = 2 ou Pilates = 3, Data/hora e capacidade máxima de participantes.</param>
        /// <remarks>
        /// Exemplo:
        /// 
        ///     POST /api/agendamento/aula
        ///     {
        ///        "tipo": "1",
        ///        "dataHora": "2025-10-20T08:00:00",
        ///        "capacidade": 10
        ///     }
        /// </remarks>
        [HttpPost("aula")]
        public IActionResult CadastrarAula([FromBody] AulaDto dto)
        {
            var id = _aplicAgendamento.CadastrarAula(dto);
            return Ok(new { Mensagem = "Cadastro de aula efetuado com sucesso!", Id = id });
        }

        /// <summary>
        /// Agendamento de aluno em uma aula, respeitando a capacidade máxima e limite de agendamento mensal.
        /// </summary>
        /// <param name="dto">Objeto com os Guids do aluno e da aula.</param>
        /// <response code="200">O agendamento de (nome do aluno) foi efetuado para o dia (data/hora do agendamento)</response>
        /// <response code="400">Erro de regra de negócio (ex: O plano do aluno não permite mais aulas!).</response>
        [HttpPost]
        public IActionResult Agendar([FromBody] AgendamentoDto dto)
        {
            try
            {
                var msg = _aplicAgendamento.Agendar(dto);
                return Ok(new {Mensagem = msg });
            }
            catch (Exception ex)
            {
                return BadRequest (new{ Erro = ex.Message});
            }
        }


        /// <summary>
        /// Relatório mensal de aulas frequentadas por um aluno.
        /// </summary>
        /// <param name="idAluno">Guid do aluno.</param>
        /// <param name="ano">Ano desejado.</param>
        /// <param name="mes">Mês desejado.</param>
        /// <returns>Lista dos tipos de aula que ele frequenta mais.</returns>
        [HttpGet("relatorio/{idAluno}")]
        public IActionResult Relatorio(Guid idAluno, int ano, int mes)
        {
            var relatorio = _aplicAgendamento.RelatorioPorALuno(idAluno, ano, mes);
            return Ok(relatorio);
        }
    }
}
