﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ScrumAdmin.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<CRITERIOS_ACEPTACION> CRITERIOS_ACEPTACION { get; set; }
        public DbSet<EQUIPO> EQUIPO { get; set; }
        public DbSet<ESTADO> ESTADO { get; set; }
        public DbSet<ESTRATEGIA> ESTRATEGIA { get; set; }
        public DbSet<INTERES> INTERES { get; set; }
        public DbSet<PLAN_ACCION> PLAN_ACCION { get; set; }
        public DbSet<PODER> PODER { get; set; }
        public DbSet<PRIORIDAD> PRIORIDAD { get; set; }
        public DbSet<PROYECTO> PROYECTO { get; set; }
        public DbSet<PUNTOS_ESTIMACION> PUNTOS_ESTIMACION { get; set; }
        public DbSet<RELEASE> RELEASE { get; set; }
        public DbSet<RIESGO> RIESGO { get; set; }
        public DbSet<ROL> ROL { get; set; }
        public DbSet<SPRINT> SPRINT { get; set; }
        public DbSet<SPRINT_RETROSPECTIVE> SPRINT_RETROSPECTIVE { get; set; }
        public DbSet<SPRINT_REVIEW> SPRINT_REVIEW { get; set; }
        public DbSet<STAKEHOLDER> STAKEHOLDER { get; set; }
        public DbSet<TAREA> TAREA { get; set; }
        public DbSet<TIPO> TIPO { get; set; }
        public DbSet<USER_STORY> USER_STORY { get; set; }
        public DbSet<USUARIO> USUARIO { get; set; }
    }
}