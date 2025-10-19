using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agendamento.Dominio.Entidades;
using Agendamento.Repositorio.Interfaces;

namespace Agendamento.Repositorio.Implementacao
{
    public class RepAula : IRepAula
    {
        private readonly List<Aula> _aulas= new();
        public void Adicionar(Aula aula) => _aulas.Add(aula);
        public Aula? RecuperarPorId(Guid id) => _aulas.FirstOrDefault(a => a.Id == id);
        public IEnumerable<Aula> ListarTodas() => _aulas;
    }
}
