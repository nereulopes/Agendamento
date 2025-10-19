using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento.Repositorio.Interfaces
{
    public interface IRepAgendamento
    {
        void SalvarAgendamento(Guid idAluno, Guid idAula, DateTime dataHora);
        IEnumerable<(Guid IdAluno, Guid IdAula, DateTime DataHora)> ListarPorAluno(Guid idAluno);
        int ContarAgendamentoMensal(Guid idAluno, int ano, int mes);
    }
}
