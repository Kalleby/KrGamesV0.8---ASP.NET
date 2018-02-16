using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KrGamesFinal.Models
{
    [Table("Generos")]
    public class Genero
    {
        [Key]
        public int GeneroId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Genero")]
        public string GeneroJogo { get; set; }
    }
}