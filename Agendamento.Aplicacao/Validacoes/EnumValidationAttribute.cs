using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

    namespace Agendamento.Aplicacao.Validacoes
    {
        public class EnumValidationAttribute : ValidationAttribute
        {
            private readonly Type _enumType;

            public EnumValidationAttribute(Type enumType)
            {
                _enumType = enumType;
            }

            public override bool IsValid(object? value)
            {
                if (value == null) return false;
                return Enum.IsDefined(_enumType, value);
            }
        }
    }


