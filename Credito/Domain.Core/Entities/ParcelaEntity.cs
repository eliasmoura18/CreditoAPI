using Domain.Core.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Core.Entities
{
    [Table("parcela")]
    public class ParcelaEntity : BaseEntity
    {
        [ForeignKey("idfinanciamento")]
        public FinanciamentoEntity Financiamento { get; set; }

        [Column("numeroparcela")]
        public int NumeroParcela { get; set; }

        [Column("valorparcela")]
        public decimal ValorParcela { get; set; }

        [Column("datavencimento")]
        public DateTime DataVencimento { get; set; }

        [Column("datapagamento")]
        public DateTime? DataPagamento { get; set; }
    }
}
