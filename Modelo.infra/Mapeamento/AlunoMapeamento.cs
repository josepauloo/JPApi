using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Modelo.domain;

namespace Modelo.infra.Mapeamento
{
    public class AlunoMapeamento : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("Aluno");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Nome).HasColumnType("varchar(100)");

            builder.Property(t => t.Idade).HasColumnType("int");

            builder.Property(t => t.Matrícula).HasColumnType("varchar(100)");

            builder.Property(t => t.Nota).HasColumnType("decimal");

            builder.Property(t => t.Cep).HasColumnType("varchar(100)");

        }
    }
}
