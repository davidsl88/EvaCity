using EvaCity.Models.Entidades;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace EvaCity.Models.Infraestructura
{
    public class EvaCityInitializer : CreateDatabaseIfNotExists<EvaCityContext>
    {
        protected override void Seed(EvaCityContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            #region Roles
            if (!roleManager.RoleExists("Administrador"))
            {
                var role = new IdentityRole();
                role.Name = "Administrador";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Administracion Publica"))
            {
                var role = new IdentityRole();
                role.Name = "Administracion Publica";
                roleManager.Create(role);

            }

            if (!roleManager.RoleExists("Ciudadano"))
            {
                var role = new IdentityRole();
                role.Name = "Ciudadano";
                roleManager.Create(role);
            }
            #endregion

            #region Usuarios
            if (!userManager.Users.Any(u => u.UserName == "admin"))
            {
                var user1 = new ApplicationUser()
                {
                    UserName = "admin",
                    Email = "admin@gmail.com",
                    EmailConfirmed = true,
                    FechaNacimiento = DateTime.Now.ToString("yyyy-MM-dd"),
                    CiudadId = 1,
                    Perfil = "Administrador"
                };
                string password = "pass123";
                IdentityResult userResult = userManager.Create(user1, password);
                if (userResult.Succeeded)
                {
                    var result = userManager.AddToRole(user1.Id, "Administrador");
                }
            }
            if (!userManager.Users.Any(u => u.UserName == "bruceWayne"))
            {
                var user2 = new ApplicationUser()
                {
                    UserName = "bruceWayne",
                    Email = "bruceW@waynegroup.com",
                    EmailConfirmed = true,
                    FechaNacimiento = DateTime.Now.ToString("yyyy-MM-dd"),
                    CiudadId = 2,
                    Perfil = "Ciudadano"
                };
                string password = "pass123";
                IdentityResult userResult = userManager.Create(user2, password);
                if (userResult.Succeeded)
                {
                    var result = userManager.AddToRole(user2.Id, "Ciudadano");
                }
            }
            if (!userManager.Users.Any(u => u.UserName == "harveyDent"))
            {
                var user3 = new ApplicationUser()
                {
                    UserName = "harveyDent",
                    Email = "harveyDent@gotham.com",
                    EmailConfirmed = true,
                    FechaNacimiento = DateTime.Now.ToString("yyyy-MM-dd"),
                    CiudadId = 3,
                    Perfil = "Administracion Publica"
                };
                string password = "pass123";
                IdentityResult userResult = userManager.Create(user3, password);
                if (userResult.Succeeded)
                {
                    var result = userManager.AddToRole(user3.Id, "Administracion Publica");
                }
            }
            #endregion

            #region TiposUbicaciones
            var tiposUbicaciones = new List<TipoUbicacion> {

                 new TipoUbicacion {
                     Nombre = "Punto de Reciclaje"
                 },
                 new TipoUbicacion {
                     Nombre = "Empresa Sostenible"
                 },
                 new TipoUbicacion {
                     Nombre = "Alquiler de Vehículos Sostenibles"
                 }
            };
            #endregion

            #region Ciudades
            var ciudades = new List<Ciudad> {

                 new Ciudad {
                     CiudadId = 1,
                     Nombre = "Madrid",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 2,
                     Nombre = "Barcelona",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 3,
                     Nombre = "Valencia",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 4,
                     Nombre = "Sevilla",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 5,
                     Nombre = "Zaragoza",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 6,
                     Nombre = "Málaga",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 7,
                     Nombre = "Murcia",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 8,
                     Nombre = "Palma de Mallorca",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 9,
                     Nombre = "Las Palmas de Gran Canaria",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 10,
                     Nombre = "Bilbao",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 11,
                     Nombre = "Alicante",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 12,
                     Nombre = "Córdoba",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 13,
                     Nombre = "Valladolid",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 14,
                     Nombre = "La Coruña",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 15,
                     Nombre = "Vitoria",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 16,
                     Nombre = "Granada",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 17,
                     Nombre = "Oviedo",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 18,
                     Nombre = "Santa Cruz de Tenerife",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 19,
                     Nombre = "Pamplona",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 20,
                     Nombre = "Almería",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 21,
                     Nombre = "San Sebastián",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 22,
                     Nombre = "Burgos",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 23,
                     Nombre = "Santander",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 24,
                     Nombre = "Castellón",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 25,
                     Nombre = "Albacete",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 26,
                     Nombre = "Logroño",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 27,
                     Nombre = "Badajoz",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 28,
                     Nombre = "Salamanca",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 29,
                     Nombre = "Huelva",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 30,
                     Nombre = "Lérida",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 31,
                     Nombre = "Tarragona",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 32,
                     Nombre = "León",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 33,
                     Nombre = "Cádiz",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 34,
                     Nombre = "Jaén",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 35,
                     Nombre = "Orense",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 36,
                     Nombre = "Lugo",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 37,
                     Nombre = "Gerona",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 38,
                     Nombre = "Cáceres",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 39,
                     Nombre = "Santiago de Compostela",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 40,
                     Nombre = "Ceuta",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 41,
                     Nombre = "Melilla",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 42,
                     Nombre = "Guadalajara",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 43,
                     Nombre = "Toledo",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 44,
                     Nombre = "Pontevedra",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 45,
                     Nombre = "Palencia",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 46,
                     Nombre = "Ciudad Real",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 47,
                     Nombre = "Zamora",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 48,
                     Nombre = "Mérida",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 49,
                     Nombre = "Ávila",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 50,
                     Nombre = "Cuenca",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 51,
                     Nombre = "Segovia",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 52,
                     Nombre = "Huesca",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 53,
                     Nombre = "Soria",
                     Pais = "España"
                 },
                 new Ciudad {
                     CiudadId = 54,
                     Nombre = "Teruel",
                     Pais = "España"
                 }
            };
            #endregion


            #region Secciones
            var secciones = new List<Seccion> {

                 new Seccion {
                     SeccionId = 1,
                     Nombre = "Contaminación",
                     Descripcion = "Seccion Contaminación"
                 },
                 new Seccion {
                     SeccionId = 2,
                     Nombre = "Energías Renovables",
                     Descripcion = "Seccion Energías Renovables"
                 },
                 new Seccion {
                     SeccionId = 3,
                     Nombre = "Reciclaje",
                     Descripcion = "Seccion Reciclaje"
                 },
                 new Seccion {
                     SeccionId = 4,
                     Nombre = "Movilidad Sostenible",
                     Descripcion = "Seccion Movilidad Sostenible"
                 },
                 new Seccion {
                     SeccionId = 5,
                     Nombre = "Negocios Sostenibles",
                     Descripcion = "Seccion Negocios Sostenibles"
                 }
            };
            #endregion

            #region Proyectos
            var proyectos = new List<Proyecto> {

                 new Proyecto {
                     ProyectoId = 1,
                     Nombre = "Creacion de una zona de cero emisiones",
                     Descripcion = "Se solicita la creacion de una zona de cero emisiones en el centro de la ciudad libres de vehiculos contaminantes. Solo podran acceder vehiculos de cero emisiones y personas residentes.",
                     FechaCreacion = DateTime.Now,
                     FechaModificacion = DateTime.Now,
                     Seccion = secciones.FirstOrDefault(d => d.SeccionId == 1),
                     Usuario = userManager.FindByName("bruceWayne"),
                     Ciudad = ciudades.FirstOrDefault(c => c.CiudadId == 2),
                 },
                 new Proyecto {
                     ProyectoId = 1,
                     Nombre = "Creacion de un impuesto especial para combustibles fosiles",
                     Descripcion = "Se va a crear un impuesto especial para aquellos combustibles fosiles que mas contaminen.",
                     FechaCreacion = DateTime.Now,
                     FechaModificacion = DateTime.Now,
                     Seccion = secciones.FirstOrDefault(d => d.SeccionId == 1),
                     Usuario = userManager.FindByName("harveyDent"),
                     Ciudad = ciudades.FirstOrDefault(c => c.CiudadId == 1),
                 },
                 new Proyecto {
                     ProyectoId = 2,
                     Nombre = "Uso obligado de energias renovables en edificios publicos",
                     Descripcion = "Se solicita que al menos el 50% de la energia consumida en edificios publicos provenga de energias renovables.",
                     FechaCreacion = DateTime.Now,
                     FechaModificacion = DateTime.Now,
                     Seccion = secciones.FirstOrDefault(d => d.SeccionId == 2),
                     Usuario = userManager.FindByName("bruceWayne"),
                     Ciudad = ciudades.FirstOrDefault(c => c.CiudadId == 3),
                 },
                 new Proyecto {
                     ProyectoId = 3,
                     Nombre = "Aumento del numero de contenedores de reciclaje",
                     Descripcion = "Dado el escaso numero de contenedores de reciclaje, seria conveniente aumentar el numero de contenedores disponibles",
                     FechaCreacion = DateTime.Now,
                     FechaModificacion = DateTime.Now,
                     Seccion = secciones.FirstOrDefault(d => d.SeccionId == 3),
                     Usuario = userManager.FindByName("harveyDent"),
                     Ciudad = ciudades.FirstOrDefault(c => c.CiudadId == 2),
                 },
                 new Proyecto {
                     ProyectoId = 4,
                     Nombre = "Aumento del numero de puntos de recarga de coches electricos",
                     Descripcion = "Dado el aumento del numero de coches electricos, se solicita aumentar considerablemente el numero de puntos de recarga rapida disponibles en toda la ciudad.",
                     FechaCreacion = DateTime.Now,
                     FechaModificacion = DateTime.Now,
                     Seccion = secciones.FirstOrDefault(d => d.SeccionId == 4),
                     Usuario = userManager.FindByName("harveyDent"),
                     Ciudad = ciudades.FirstOrDefault(c => c.CiudadId == 1),
                 },
                 new Proyecto {
                     ProyectoId = 5,
                     Nombre = "Ventajas fiscales para negocios sostenibles",
                     Descripcion = "Dada la naturaleza de los negocios sostenibles, seria factible ofrecerles ventajas fiscales por su contribucion al medio ambiente.",
                     FechaCreacion = DateTime.Now,
                     FechaModificacion = DateTime.Now,
                     Seccion = secciones.FirstOrDefault(d => d.SeccionId == 5),
                     Usuario = userManager.FindByName("bruceWayne"),
                     Ciudad = ciudades.FirstOrDefault(c => c.CiudadId == 1),
                 }
            };
            #endregion

            ciudades.ForEach(d => context.Ciudad.Add(d));
            proyectos.ForEach(d => context.Proyecto.Add(d));
            secciones.ForEach(d => context.Seccion.Add(d));
            tiposUbicaciones.ForEach(d => context.TipoUbicacion.Add(d));
            context.SaveChanges();
        }
    }
}