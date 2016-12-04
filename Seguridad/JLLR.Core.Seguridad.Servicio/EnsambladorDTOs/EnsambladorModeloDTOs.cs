#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using  entidadDTOs=JLLR.Core.Seguridad.Proveedor.DTOs;
using  modeloDTOs=JLLR.Core.Seguridad.Servicio.DTOs;
#endregion

namespace JLLR.Core.Seguridad.Servicio.EnsambladorDTOs
{
    /// <summary>
    /// Ingresa una  entidad y lo transforma en un modelo
    /// </summary>
    public class EnsambladorModeloDTOs
    {
        #region  USUARIODTOs
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modeloDTOs.UsuarioDTOs CrearUsuarioDTOs(entidadDTOs.UsuarioDTOs e)
        {
            return new modeloDTOs.UsuarioDTOs
            {
                UsuarioId = e.UsuarioId,
                HoraInicioPuntoVenta = e.HoraInicioPuntoVenta,
                NombreUsuario = e.NombreUsuario,
                SucursalId = e.SucursalId,
                NombrePuntoVenta = e.NombrePuntoVenta,
                NombreSucursal = e.NombreSucursal,
                PuntoVentaId = e.PuntoVentaId,
                HoraFinPuntoVenta = e.HoraFinPuntoVenta
            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modeloDTOs.UsuarioDTOs> CrearUsuariosDTOs(IQueryable<entidadDTOs.UsuarioDTOs> listadoEntidad)
        {
            List<modeloDTOs.UsuarioDTOs> listaModelo = new List<modeloDTOs.UsuarioDTOs>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearUsuarioDTOs(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  AccesoDTOs
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modeloDTOs.AccesoDTOs CrearAccesoDTOs(entidadDTOs.AccesoDTOs e)
        {
            return new modeloDTOs.AccesoDTOs
            {
                Acceso = e.Acceso,
                AccesoId = e.AccesoId,
                ModuloId = e.ModuloId,
                SubModulo = e.SubModulo,
                SubmoduloId = e.SubmoduloId,
                Url = e.Url,
                Modulo = e.Modulo
            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modeloDTOs.AccesoDTOs> CrearAccesosDTOs(IQueryable<entidadDTOs.AccesoDTOs> listadoEntidad)
        {
            List<modeloDTOs.AccesoDTOs> listaModelo = new List<modeloDTOs.AccesoDTOs>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearAccesoDTOs(entidad));
            }
            return listaModelo;

        }

        #endregion
    }
}