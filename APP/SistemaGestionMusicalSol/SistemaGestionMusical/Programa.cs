//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistemaGestionMusical
{
    using System;
    using System.Collections.Generic;
    
    public partial class Programa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Programa()
        {
            this.Jingles = new HashSet<Jingle>();
        }
    
        public int idPrograma { get; set; }
        public string dia { get; set; }
        public string horaFinal { get; set; }
        public string horaInicio { get; set; }
        public int patron_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Jingle> Jingles { get; set; }
        public virtual Patron Patron { get; set; }
    }
}