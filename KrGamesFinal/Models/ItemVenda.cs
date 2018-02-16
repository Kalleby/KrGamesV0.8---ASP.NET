using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KrGamesFinal.Models
{
    [Table("ItensVenda")]
    public class ItemVenda
    {
        [Key]
        public int ItemVendaId { get; set; }
        public virtual Jogo Jogo { get; set; }
        public int JogoId { get; set; }
        public DateTime ItemVendaData { get; set; }
        public int ItemVendaQuantidade { get; set; }
        public string CarrinhoId { get; set; }
    }
}