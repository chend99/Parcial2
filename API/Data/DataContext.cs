using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Modelo.Entidades;



namespace API.Data
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=tareas.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Crear tabla de usuarios
            modelBuilder.Entity<Usuario>(eu => {
                eu.ToTable("Usuario");
                eu.Property(p => p.Nombre).IsRequired();
                eu.Property(p => p.Clave).IsRequired();
            });
            // Crear tabla de recursos
            modelBuilder.Entity<Recurso>(er => {
                er.ToTable("Recurso");
                er.Property(p => p.Nombre).IsRequired();
            });
            // Crear tabla de tareas
            modelBuilder.Entity<Tarea>(et => {
                et.ToTable("Tarea");
                et.Property(p => p.Titulo).HasMaxLength(100).IsRequired();
                et.Property(p => p.Vencimiento).IsRequired();
                et.Property(p => p.Estimacion).IsRequired();
                et.Property(p => p.Estado).IsRequired();
            });
            // Crear tabla de Detalle
            modelBuilder.Entity<Detalle>(ed => {
                ed.ToTable("Detalle");
                ed.Property(p => p.Fecha).IsRequired();
                ed.Property(p => p.Tiempo).IsRequired();
            });

        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Recurso> Recursos { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Detalle> Detalles { get; set; }
    }
}
