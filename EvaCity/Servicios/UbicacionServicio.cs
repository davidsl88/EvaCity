using EvaCity.Models.Entidades;
using EvaCity.Models.Infraestructura.Repositorios;
using EvaCity.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace EvaCity.Servicios
{
    public class UbicacionServicio
    {
        private UbicacionRepositorio ubicacionRepositorio = new UbicacionRepositorio();
        private CiudadRepositorio ciudadRepositorio = new CiudadRepositorio();
        private UsuarioServicio usuarioServicio = new UsuarioServicio();
        private TipoUbicacionServicio tipoUbicacionServicio = new TipoUbicacionServicio();
        private CiudadServicio ciudadServicio = new CiudadServicio();

        public List<Ubicacion> ObtenerTodasUbicaciones()
        {
            return ubicacionRepositorio.ObtenerTodasUbicaciones();
        }

        public IList<Ubicacion> ObtenerUbicacionesPorCiudad(string nombreCiudad)
        {
            Ciudad ciudad = ciudadRepositorio.ObtenerCiudadPorNombre(nombreCiudad);
            return ubicacionRepositorio.ObtenerUbicacionesPorCiudad(ciudad.CiudadId);
        }

        public IList<Ubicacion> ObtenerEmpresas(string nombreCiudad)
        {
            Ciudad ciudad = ciudadRepositorio.ObtenerCiudadPorNombre(nombreCiudad);
            return ubicacionRepositorio.ObtenerEmpresas(ciudad.CiudadId);
        }

        public IList<Ubicacion> ObtenerTodasEmpresas()
        {
            return ubicacionRepositorio.ObtenerTodasEmpresas();
        }

        public IList<Ubicacion> ObtenerUbicacionesPorUsuario(string idUsuario)
        {
            return ubicacionRepositorio.ObtenerUbicacionesPorUsuario(idUsuario);
        }

        public void CrearUbicacion(Ubicacion ubicacion)
        {
            try
            {
                ubicacionRepositorio.Insertar(ubicacion);
                ubicacionRepositorio.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
        }

        public void EliminarUbicacion(int idUbicacion)
        {
            ubicacionRepositorio.Eliminar(idUbicacion);
            ubicacionRepositorio.SaveChanges();
        }

        public void UbicacionViewModelToModel(Ubicacion ubicacion, UbicacionViewModel ubicacionVM)
        {
            ubicacion.TipoUbicacionId = Int32.Parse(ubicacionVM.TipoUbicacionSeleccionada);
            ubicacion.Latitud = ubicacionVM.Latitud;
            ubicacion.Longitud = ubicacionVM.Longitud;
            ubicacion.Direccion = ubicacionVM.Direccion;
            if (ubicacionVM.TipoUbicacionSeleccionada == "2" || ubicacionVM.TipoUbicacionSeleccionada == "3")
            {
                ubicacion.Url = ubicacionVM.Url;
                ubicacion.NombreEmpresa = ubicacionVM.NombreEmpresa;
            }
            ubicacion.UbicacionId = ubicacionVM.UbicacionId;
            ubicacion.CiudadId = ciudadServicio.ObtenerCiudadPorNombre(ubicacionVM.NombreCiudad).CiudadId;
            ubicacion.UsuarioId = usuarioServicio.ObtenerUsuarioPorNombre(ubicacionVM.NombreUsuario).Id;
        }

        public void UbicacionModelToViewModel(UbicacionViewModel ubicacionVM, Ubicacion ubicacion)
        {
            ubicacionVM.NombreCiudad = ciudadServicio.ObtenerCiudadPorId(ubicacion.CiudadId).Nombre;
            ubicacionVM.Direccion = ubicacion.Direccion;
            ubicacionVM.Latitud = ubicacion.Latitud;
            ubicacionVM.Longitud = ubicacion.Longitud;
            ubicacionVM.Url = ubicacion.Url;
            ubicacionVM.NombreEmpresa = ubicacion.NombreEmpresa;
            ubicacionVM.UbicacionId = ubicacion.UbicacionId;
            ubicacionVM.NombreUsuario = usuarioServicio.ObtenerUsuarioPorId(ubicacion.UsuarioId).UserName;
            ubicacionVM.TipoUbicacion = tipoUbicacionServicio.ObtenerTipoUbicacionPorId(ubicacion.TipoUbicacionId).Nombre;
        }
    }
}