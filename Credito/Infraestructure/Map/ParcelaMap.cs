using Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Map
{
    public class ParcelaMap : IEntityTypeConfiguration<ParcelaEntity>
    {
        public void Configure(EntityTypeBuilder<ParcelaEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.NumeroParcela).IsRequired();
            builder.Property(x => x.ValorParcela).IsRequired().HasMaxLength(11);
            builder.Property(x => x.DataVencimento).IsRequired();
        }
    }
}
