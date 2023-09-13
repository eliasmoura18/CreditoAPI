using Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Map
{
    public class ClienteMap : IEntityTypeConfiguration<ClienteEntity>
    {
        public void Configure(EntityTypeBuilder<ClienteEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).IsRequired().HasMaxLength(250);
            builder.Property(x => x.CPF).IsRequired().HasMaxLength(11);
            builder.Property(x => x.UF).IsRequired().HasMaxLength(2);
            builder.Property(x => x.DDD).IsRequired().HasMaxLength(2);
            builder.Property(x => x.Celular).IsRequired().HasMaxLength(9);

            builder.HasData(
                new ClienteEntity[] {
                    new ClienteEntity()
                    {
                        Id = 1,
                        DataInsercao = new DateTime(2023, 08, 15, 16, 30, 12),
                        Nome = "Elias de Moura",
                        CPF = "58672118006",
                        UF = "GO",
                        DDD = "62",
                        Celular = "912345678"
                    },
                    new ClienteEntity()
                    {
                        Id = 2,
                        DataInsercao = new DateTime(2023, 09, 01, 15, 45, 33),
                        Nome = "João da silva",
                        CPF = "76249229086",
                        UF = "SP",
                        DDD = "11",
                        Celular = "943218765"
                    },
                    new ClienteEntity()
                    {
                        Id = 3,
                        DataInsercao = new DateTime(2023, 09, 11, 9, 11, 26),
                        Nome = "Fulano de Tal",
                        CPF = "16162984052",
                        UF = "MG",
                        DDD = "31",
                        Celular = "911223344"
                    },
                }
            );
        }
    }
}
