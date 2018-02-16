using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KrGamesFinal.Models
{
    public class Context : DbContext
    {
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ItemVenda> ItensVenda { get; set; }
        public DbSet<Midia> Midias { get; set; }
    }
}