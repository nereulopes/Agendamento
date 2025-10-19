using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agendamento.Dominio.Enums;
using System.ComponentModel.DataAnnotations;
using Agendamento.Aplicacao.Validacoes;

namespace Agendamento.Aplicacao.Dtos
{
    public record AlunoDto(
        string Nome,
        [EnumValidation(typeof(TipoPlano), ErrorMessage = "Tipo de plano inválido!")]
        TipoPlano Plano
    );
}
