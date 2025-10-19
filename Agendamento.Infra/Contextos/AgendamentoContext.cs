using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agendamento.Dominio.Entidades;

namespace Agendamento.Infra.Contextos
{
    public class AgendamentoContext : DbContext
    {
        public AgendamentoContext(DbContextOptions<AgendamentoContext> options) : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Aula> Aulas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Aluno>().ToTable("Alunos");
            modelBuilder.Entity<Aula>().ToTable("Aulas");
        }
    }
}
