#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JLLR.Core.FlujoProceso.Servicio.Ensamblador;
using entidadDTOs = JLLR.Core.FlujoProceso.Proveedor.DTOs;
using modeloDTOs = JLLR.Core.FlujoProceso.Servicio.DTOs;
#endregion
namespace JLLR.Core.FlujoProceso.Servicio.EnsambladorDTOs
{

    /// <summary>
    /// Ingresa una  entidad y lo transforma en un modelo
    /// </summary>
    public class EnsambladorModeloDTOs
    {

        private  readonly  EnsambladorModelo _ensambladorModelo= new EnsambladorModelo();

        #region HISTORIAL PROCESO  DTO
        /// <summary>
        /// Convierte el modelo DTO en una entidad DTO
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public modeloDTOs.HistorialProcesoDTOs CrearConsultaHistorialProcesoDtOs(entidadDTOs.HistorialProcesoDTOs m)
        {
            return new modeloDTOs.HistorialProcesoDTOs()
            {
                NumeroOrden = m.NumeroOrden,
                OrdenTrabajoId = m.OrdenTrabajoId,
                NombrePuntoVenta = m.NombrePuntoVenta,
                UsuarioEntrega = m.UsuarioEntrega,
                UsuarioRecibe = m.UsuarioRecibe,
                NumeroPrendas = m.NumeroPrendas,
                FechaRegistro = m.FechaRegistro

            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<modeloDTOs.HistorialProcesoDTOs> CrearConsultaHistorialProcesosDtOs(List<entidadDTOs.HistorialProcesoDTOs> listadoModelo)
        {
            List<modeloDTOs.HistorialProcesoDTOs> listaEntidad = new List<modeloDTOs.HistorialProcesoDTOs>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearConsultaHistorialProcesoDtOs(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region HISTORIAL REPROCESO  DTO
        /// <summary>
        /// Convierte el modelo DTO en una entidad DTO
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public modeloDTOs.HistorialReprocesoDTOs CrearHistorialReprocesoDtOs(entidadDTOs.HistorialReprocesoDTOs m)
        {
            return new modeloDTOs.HistorialReprocesoDTOs()
            {
               HistorialProceso = _ensambladorModelo.CrearHistorialProceso(m.HistorialProceso),
               HistorialReprocesos = _ensambladorModelo.CrearListaHistorialReprocesos(m.HistorialReprocesos)

            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<modeloDTOs.HistorialReprocesoDTOs> CrearHistorialReprocesosDtOs(List<entidadDTOs.HistorialReprocesoDTOs> listadoModelo)
        {
            List<modeloDTOs.HistorialReprocesoDTOs> listaEntidad = new List<modeloDTOs.HistorialReprocesoDTOs>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearHistorialReprocesoDtOs(modelo));
            }
            return listaEntidad;

        }
        #endregion
    }
}