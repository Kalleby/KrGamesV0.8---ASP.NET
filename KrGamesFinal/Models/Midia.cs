using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KrGamesFinal.Models
{
    [Table("Midias")]
    public class Midia
    {
        [Key]
        public int MidiaId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Midia")]
        public string MidiaJogo { get; set; }
    }
}