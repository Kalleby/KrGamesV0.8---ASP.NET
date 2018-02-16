using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KrGamesFinal.Models
{
    [Table("Jogos")]
    public class Jogo
    {
        [Key]
        public int JogoId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Nome do Jogo")]
        public string JogoNome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string JogoDescricao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public double JogoPreco { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public int JogoQuantidade { get; set; }

        [Display(Name = "Imagem")]
        public string JogoImagem { get; set; }

        public virtual Genero GeneroJogo { get; set; }

        public int GeneroId { get; set; }

        public virtual Midia MidiaJogo { get; set; }

        public int MidiaId { get; set; }
    }
}