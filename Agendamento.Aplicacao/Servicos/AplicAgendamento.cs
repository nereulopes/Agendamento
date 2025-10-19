using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agendamento.Aplicacao.Dtos;
using Agendamento.Dominio.Entidades;
using Agendamento.Dominio.Helpers;
using Agendamento.Repositorio.Interfaces;

namespace Agendamento.Aplicacao.Servicos
{
    public class AplicAgendamento
    {
        private readonly IRepAluno _repAluno;
        private readonly IRepAula _repAula;
        private readonly IRepAgendamento _repAgendamento;

        public AplicAgendamento(IRepAluno repAluno,
                                IRepAula repAula,
                                IRepAgendamento repAgendamento)
        {
            _repAluno = repAluno;
            _repAula = repAula;
            _repAgendamento = repAgendamento;
        }

        public Guid CadastrarAluno(AlunoDto dto)
        {
            var aluno = new Aluno(dto.Nome, dto.Plano);
            _repAluno.Adicionar(aluno);
            return aluno.Id;
        }

        public Guid CadastrarAula(AulaDto dto)
        {
            var aula = new Aula(dto.Tipo, dto.DataHora, dto.Capacidade);
            _repAula.Adicionar(aula);
            return aula.Id;
        }

        public string Agendar(AgendamentoDto dto)
        {
            var aluno = _repAluno.RecuperarPorId(dto.IdAluno)
                ?? throw new Exception("Não existe aluno com esse código!");

            var aula = _repAula.RecuperarPorId(dto.IdAula)
                ?? throw new Exception("Não existe aula com esse código!");

            var qtdAgendamentoMensal = _repAgendamento.ContarAgendamentoMensal(aluno.Id, aula.DataHora.Year, aula.DataHora.Month);

            var limiteMensalPlano = PlanoHelper.LimiteMensal(aluno.Plano);

            if (qtdAgendamentoMensal >= limiteMensalPlano)
                throw new Exception("O plano do aluno não permite mais aulas!");

            aula.AgendarAluno(aluno.Id);
            _repAgendamento.SalvarAgendamento(aluno.Id, aula.Id, aula.DataHora);

            return $"O agendamento de {aluno.Nome} foi efetuado para o dia {aula.DataHora:dd/MM HH:mm}";
        }

        public object RelatorioPorALuno(Guid idAluno, int ano, int mes)
        {
            var agendamentos = _repAgendamento.ListarPorAluno(idAluno)
                .Where(a => a.DataHora.Year == ano && a.DataHora.Month == mes)
                .ToList();

            return new
            {
                TotalMensal = agendamentos.Count,
                TipoFrequente = agendamentos.
                GroupBy(a => _repAula.RecuperarPorId(a.IdAula)?.Tipo)
                .Where(g => g.Key != null)
                .Select(g => new { Tipo = g.Key, Quantidade = g.Count()})
                .OrderByDescending(g => g.Quantidade)
                .ToList()
            };
        }

    }
}

