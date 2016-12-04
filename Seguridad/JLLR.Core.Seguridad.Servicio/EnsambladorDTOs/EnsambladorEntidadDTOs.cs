#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using entidadDTOs = JLLR.Core.Seguridad.Proveedor.DTOs;
using modeloDTOs = JLLR.Core.Seguridad.Servicio.DTOs;
#endregion
namespace JLLR.Core.Seguridad.Servicio.EnsambladorDTOs
{
    /// <summary>
    /// Ingresa un modelo y devuleve una entidad
    /// </summary>
    public class EnsambladorEntidadDTOs
    {

        #region UsuarioDTOs
        /// <summary>
        /// Convierte el modelo DTO en una entidad DTO
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidadDTOs.UsuarioDTOs CrearUsuarioDTOS(modeloDTOs.UsuarioDTOs m)
        {
            return new entidadDTOs.UsuarioDTOs()
            {
                HoraFinPuntoVenta = m.HoraFinPuntoVenta,
                NombrePuntoVenta = m.NombrePuntoVenta,
                NombreSucursal = m.NombreSucursal,
                PuntoVentaId = m.PuntoVentaId,
                SucursalId = m.SucursalId,
                HoraInicioPuntoVenta = m.HoraInicioPuntoVenta,
                NombreUsuario = m.NombreUsuario,
                UsuarioId = m.UsuarioId
            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidadDTOs.UsuarioDTOs> CrearUsuariosDTOS(List<modeloDTOs.UsuarioDTOs> listadoModelo)
        {
            List<entidadDTOs.UsuarioDTOs> listaEntidad = new List<entidadDTOs.UsuarioDTOs>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearUsuarioDTOS(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region AccesoDTOs
        /// <summary>
        /// Convierte el modelo DTO en una entidad DTO
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidadDTOs.AccesoDTOs CrearAccesoDTOs(modeloDTOs.AccesoDTOs m)
        {
            return new entidadDTOs.AccesoDTOs()
            {
                Modulo = m.Modulo,
                ModuloId = m.ModuloId,
                SubmoduloId = m.SubmoduloId,
                SubModulo = m.SubModulo,
                Acceso = m.Acceso,
                Url = m.Url,
                AccesoId = m.AccesoId
            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidadDTOs.AccesoDTOs> CrearAccesosDTOs(List<modeloDTOs.AccesoDTOs> listadoModelo)
        {
            List<entidadDTOs.AccesoDTOs> listaEntidad = new List<entidadDTOs.AccesoDTOs>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearAccesoDTOs(modelo));
            }
            return listaEntidad;

        }
        #endregion
    }
}