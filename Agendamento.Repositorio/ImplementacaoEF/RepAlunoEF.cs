using Agendamento.Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agendamento.Dominio.Entidades;
using Agendamento.Infra.Contextos;
using Microsoft.EntityFrameworkCore;

namespace Agendamento.Repositorio.ImplementacaoEF
{
    public class RepAlunoEF : IRepAluno
    {
        private readonly AgendamentoContext _context;

        public RepAlunoEF( AgendamentoContext context )
        {
            _context = context;
        }

        public void Adicionar(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            _context.SaveChanges();
        }

        public Aluno? RecuperarPorId(Guid id)
        {
            return _context.Alunos.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Aluno> ListarTodos()
        {
            return _context.Alunos.AsNoTracking().ToList();
        }
    }
}
