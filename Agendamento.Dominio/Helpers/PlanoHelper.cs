using Agendamento.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento.Dominio.Helpers
{
    public static class PlanoHelper
    {
        public static int LimiteMensal(TipoPlano plano)
        {
            return plano switch
            {
                TipoPlano.Mensal => 12,
                TipoPlano.Trimestral => 20,
                TipoPlano.Anual => 30,
                _ => 0
            };
        }
    }
}
