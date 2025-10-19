using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agendamento.Dominio.Entidades;
using Agendamento.Repositorio.Interfaces;

namespace Agendamento.Repositorio.Implementacao
{
    public class RepAluno : IRepAluno
    {
        private readonly List<Aluno> _alunos = new();
        public void Adicionar(Aluno aluno) => _alunos.Add(aluno);
        public Aluno? RecuperarPorId(Guid id) => _alunos.FirstOrDefault(a => a.Id == id);
        public IEnumerable<Aluno> ListarTodos() => _alunos;
    }
}
