using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KrGamesFinal.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(5, ErrorMessage = "No mínimo 5 caracteres!")]
        [MaxLength(50, ErrorMessage = "No máximo 50 caracteres!")]
        [Display(Name = "Nome do Usuário*")]
        public string UsuarioNome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "E-mail do Usuário*")]
        [EmailAddress(ErrorMessage = "E-mail inválido!")]
        public string UsuarioEmail { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(5, ErrorMessage = "No mínimo 5 caracteres!")]
        [MaxLength(20, ErrorMessage = "No máximo 20 caracteres!")]
        [Display(Name = "Login do Usuário*")]
        public string UsuarioLogin { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Senha do Usuário*")]
        public string UsuarioSenha { get; set; }

        [Display(Name = "Confirmação de senha do Usuário*")]
        [Compare("UsuarioSenha", ErrorMessage = "Os campos não coincidem!")]
        [NotMapped]
        public string UsuarioConfirmacaoSenha { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Endereço*")]
        public string Endereco { get; set; }
    }
}