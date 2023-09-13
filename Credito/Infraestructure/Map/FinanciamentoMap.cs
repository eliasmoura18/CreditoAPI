using Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Map
{
    public class FinanciamentoMap : IEntityTypeConfiguration<FinanciamentoEntity>
    {
        public void Configure(EntityTypeBuilder<FinanciamentoEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CPF).IsRequired().HasMaxLength(11);
            builder.Property(x => x.TipoFinanciamento).IsRequired();
            builder.Property(x => x.ValorTotal).IsRequired();
            builder.Property(x => x.DataUltimoVencimento).IsRequired();
        }
    }
}
