using Agendamento.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento.Repositorio.Interfaces
{
    public interface IRepAluno
    {
        void Adicionar(Aluno aluno);
        Aluno? RecuperarPorId(Guid id);
        IEnumerable<Aluno> ListarTodos();
    }
}
