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
    
    public partial class Jingle
    {
        public int idJingle { get; set; }
        public string descripcion { get; set; }
        public int programa_id { get; set; }
    
        public virtual Programa Programa { get; set; }
    }
}
