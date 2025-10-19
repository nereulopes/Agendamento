using Agendamento.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento.Dominio.Entidades
{
    public class Aula
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public TipoAula Tipo { get; private set; }
        public DateTime DataHora { get; private set; }
        public int Capacidade { get; private set; }

        private readonly List<Guid> _participantes = new();
        public IReadOnlyCollection<Guid> Participantes => _participantes.AsReadOnly();

        private Aula()
        {

        }

        public Aula(TipoAula tipo, DateTime dataHora, int capacidade)
        {
            if (capacidade <= 0)
                throw new ArgumentException("Capacidade deve ser maior que zero!");
            Tipo = tipo;
            DataHora = dataHora;
            Capacidade = capacidade;
        }

        public bool TemVaga => _participantes.Count < Capacidade;

        public void AgendarAluno(Guid alunoId)
        {
            if (!TemVaga)
                throw new InvalidOperationException("Essa aula não possui vagas!");

            if (_participantes.Contains(alunoId))
                throw new InvalidOperationException("Aluno já possui agendamento nessa aula!");

            _participantes.Add(alunoId);
        }
    }
}
