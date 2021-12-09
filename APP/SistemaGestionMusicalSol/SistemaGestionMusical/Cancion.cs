//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Cancion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cancion()
        {
            this.CancionPlaylist = new HashSet<CancionPlaylist>();
        }
    
        public int idCancion { get; set; }
        public bool activa { get; set; }
        public int artista_id { get; set; }
        public Nullable<int> album_id { get; set; }
        public int categoria_id { get; set; }
        public string clave { get; set; }
        public int genero_id { get; set; }
        public string nombre { get; set; }
        public string observacion { get; set; }
        public int prioridad { get; set; }
        public string radio { get; set; }
        public string tiempo { get; set; }
        public string tiempoIntro { get; set; }
    
        public virtual Album Album { get; set; }
        public virtual Artista Artista { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual Genero Genero { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CancionPlaylist> CancionPlaylist { get; set; }

        public override string ToString()
        {
            return nombre;
        }
    }
}
