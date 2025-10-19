using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agendamento.Dominio.Entidades;
using Agendamento.Infra.Contextos;
using Agendamento.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Agendamento.Repositorio.ImplementacaoEF
{
    public class RepAulaEF : IRepAula
    {
        private readonly AgendamentoContext _context;

        public RepAulaEF(AgendamentoContext context)
        {
            _context = context;
        }

        public void Adicionar(Aula aula)
        {
            _context.Aulas.Add(aula);
            _context.SaveChanges();
        }

        public Aula? RecuperarPorId(Guid id)
        {
            return _context.Aulas.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Aula> ListarTodas()
        {
            return _context.Aulas.AsNoTracking().ToList();
        }
    }
}
