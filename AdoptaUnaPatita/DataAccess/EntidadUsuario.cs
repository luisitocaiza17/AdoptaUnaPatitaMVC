//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdoptaUnaPatita.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class EntidadUsuario
    {
        public int Id { get; set; }
        public int IdEntidad { get; set; }
        public int IdUsuario { get; set; }
    
        public virtual Entidad Entidad { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
