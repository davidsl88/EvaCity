using EvaCity.Models.Entidades;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace EvaCity.Models.Infraestructura
{
	public class EvaCityContext : IdentityDbContext<ApplicationUser>
    {
        private readonly static string connectionString = ConfigurationManager.ConnectionStrings["EvaCityConexion"].ConnectionString;
        public EvaCityContext()
            : base(connectionString, throwIfV1Schema: false)
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public static EvaCityContext Create()
        {
            return new EvaCityContext();
        }

        public virtual DbSet<Ciudad> Ciudad { get; set; }
        public virtual DbSet<Proyecto> Proyecto { get; set; }
        public virtual DbSet<Seccion> Seccion { get; set; }
        public virtual DbSet<Valoracion> Valoracion { get; set; }
        public virtual DbSet<Ubicacion> Ubicacion { get; set; }
        public virtual DbSet<TipoUbicacion> TipoUbicacion { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Relacion uno a muchos
            modelBuilder.Entity<Proyecto>().HasRequired(t => t.Seccion).WithMany(m => m.Proyectos).HasForeignKey(t => t.SeccionId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Proyecto>().HasRequired(t => t.Usuario).WithMany(m => m.Proyectos).HasForeignKey(t => t.UsuarioId).WillCascadeOnDelete(true);
            modelBuilder.Entity<Proyecto>().HasRequired(t => t.Ciudad).WithMany(m => m.Proyectos).HasForeignKey(t => t.CiudadId).WillCascadeOnDelete(false);

            modelBuilder.Entity<Valoracion>().HasRequired(t => t.Proyecto).WithMany(m => m.Valoraciones).HasForeignKey(t => t.ProyectoId).WillCascadeOnDelete(true);
            modelBuilder.Entity<Ubicacion>().HasRequired(t => t.Ciudad).WithMany(m => m.Ubicaciones).HasForeignKey(t => t.CiudadId).WillCascadeOnDelete(true);
            modelBuilder.Entity<Ubicacion>().HasRequired(t => t.TipoUbicacion).WithMany(m => m.Ubicaciones).HasForeignKey(t => t.TipoUbicacionId).WillCascadeOnDelete(true);

            //Renombrar tablas Identity
            modelBuilder.Entity<ApplicationUser>().ToTable("Usuario");
            modelBuilder.Entity<IdentityRole>().ToTable("Perfil");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UsuarioPerfil");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UsuarioLogin");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("Elementos");

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}