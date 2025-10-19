using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agendamento.Repositorio.Interfaces;

namespace Agendamento.Repositorio.Implementacao
{
    public class RepAgendamento : IRepAgendamento
    {
        private readonly List<(Guid IdAluno, Guid IdAula, DateTime DataHora)> _agendamentos = new();

        public void SalvarAgendamento(Guid idAluno, Guid idAula, DateTime dataHora)
        {
            _agendamentos.Add((idAluno, idAula, dataHora));
        }
        public IEnumerable<(Guid IdAluno, Guid IdAula, DateTime DataHora)> ListarPorAluno(Guid idAluno)
        {
            return _agendamentos.Where(a => a.IdAluno == idAluno);
        }
        public int ContarAgendamentoMensal(Guid idAluno, int ano, int mes)
        {
            return _agendamentos.Count(a =>
                 a.IdAluno == idAluno &&
                 a.DataHora.Year == ano &&
                 a.DataHora.Month == mes);
        }
    }
}
