using Agendamento.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento.Dominio.Entidades
{
    public class Aluno
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Nome { get; private set; }
        public TipoPlano Plano { get; private set; }

        private Aluno() 
        {

        }

        public Aluno(string nome, TipoPlano plano) 
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome do aluno é obrigatório!");

            Nome = nome.Trim();
            Plano = plano;
        }
    }
}
