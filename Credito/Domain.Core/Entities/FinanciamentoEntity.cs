using Domain.Core.Entities.Base;
using Domain.Core.Entities.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Core.Entities
{
    [Table("financiamento")]
    public class FinanciamentoEntity : BaseEntity
    {
        [ForeignKey("idcliente")]
        public ClienteEntity Cliente { get; set; }

        [Column("cpf")]
        public string CPF { get; set; }

        [Column("tipofinanciamento")]
        public TipoFinanciamentoEnum? TipoFinanciamento { get; set; }

        [Column("valortotal")]
        public decimal ValorTotal { get; set; }

        [Column("dataultimovencimento")]
        public DateTime DataUltimoVencimento { get; set; }

        //public virtual ICollection<ParcelaEntity> Parcela { get; set; }
    }
}
