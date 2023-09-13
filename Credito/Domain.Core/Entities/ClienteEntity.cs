using Domain.Core.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Core.Entities
{
    [Table("cliente")]
    public class ClienteEntity : BaseEntity
    {
        [Column("nome")]
        public string Nome { get; set; }

        [Column("cpf")]
        public string CPF { get; set; }

        [Column("uf")]
        public string UF { get; set; }

        [Column("ddd")]
        public string DDD { get; set; }
        
        [Column("celular")]
        public string Celular { get; set; }

        //public virtual ICollection<FinanciamentoEntity>? Financiamento { get; set; }
    }
}
