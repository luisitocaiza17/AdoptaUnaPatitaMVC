﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AdoptaUnaPatitaEntities : DbContext
    {
        public AdoptaUnaPatitaEntities()
            : base("name=AdoptaUnaPatitaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Entidad> Entidad { get; set; }
        public virtual DbSet<Mascota> Mascota { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Sexo> Sexo { get; set; }
        public virtual DbSet<Solicitud> Solicitud { get; set; }
        public virtual DbSet<Tamanio> Tamanio { get; set; }
        public virtual DbSet<TipoAnimal> TipoAnimal { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<EntidadUsuario> EntidadUsuario { get; set; }
        public virtual DbSet<MascotaSolicitud> MascotaSolicitud { get; set; }
        public virtual DbSet<MascotaUsuario> MascotaUsuario { get; set; }
    }
}
