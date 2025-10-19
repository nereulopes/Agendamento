using Agendamento.Aplicacao.Validacoes;
using Agendamento.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento.Aplicacao.Dtos
{
    public record AulaDto (
        [EnumValidation(typeof(TipoAula), ErrorMessage = "Tipo de aula inválido!")]
        TipoAula Tipo, 
        DateTime DataHora, 
        int Capacidade
    );
}
