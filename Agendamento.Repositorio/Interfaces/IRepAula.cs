using Agendamento.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento.Repositorio.Interfaces
{
    public interface IRepAula
    {
        void Adicionar(Aula aula);
        Aula? RecuperarPorId(Guid id);
        IEnumerable<Aula> ListarTodas();
    }
}
