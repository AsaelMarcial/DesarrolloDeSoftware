﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistemaGestionMusical
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Database : DbContext
    {
        public Database()
            : base("name=Database")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Album> Album { get; set; }
        public virtual DbSet<Artista> Artista { get; set; }
        public virtual DbSet<Cancion> Cancion { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Elemento> Elemento { get; set; }
        public virtual DbSet<Genero> Genero { get; set; }
        public virtual DbSet<Jingle> Jingle { get; set; }
        public virtual DbSet<Patron> Patron { get; set; }
        public virtual DbSet<Programa> Programa { get; set; }
        public virtual DbSet<CancionPlaylist> CancionPlaylist { get; set; }
        public virtual DbSet<Playlist> Playlist { get; set; }
    }
}
