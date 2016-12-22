#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using entidad = JLLR.Core.Base.Proveedor.Entidades;
using modelo = JLLR.Core.Logistica.Servicio.Modelo;
#endregion

namespace JLLR.Core.Logistica.Servicio.Ensamblador
{

    /// <summary>
    /// Ingresa una entidad y devuleve un modelo
    /// </summary>
    public class EnsambladorModelo
    {

        #region  ENTREGA ORDEN DE TRABAJO
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.EntregaOrdenTrabajoModelo CrearEntregaOrdenTrabajo(entidad.ENTREGA_ORDEN_TRABAJO e)
        {

            return new modelo.EntregaOrdenTrabajoModelo
            {
               OrdenTrabajoId = e.ORDEN_TRABAJO_ID,
               FechaEntrega = e.FECHA_ENTREGA,
               UsuarioEntregaId = e.USUARIO_ENTREGA_ID,
               EntregaOrdenTrabajoId = e.ENTREGA_ORDEN_TRABAJO_ID,
               UsuarioRecibeId = e.USUARIO_RECIBE_ID
            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.EntregaOrdenTrabajoModelo> CrearEntregaOrdenesTrabajo(IQueryable<entidad.ENTREGA_ORDEN_TRABAJO> listadoEntidad)
        {
            List<modelo.EntregaOrdenTrabajoModelo> listaModelo = new List<modelo.EntregaOrdenTrabajoModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearEntregaOrdenTrabajo(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region DETALLE ENTREGA ORDEN DE TRABAJO
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.DetalleEntregaOrdenTrabajoModelo CrearDetalleEntregaOrdenTrabajo(entidad.DETALLE_ENTREGA_ORDEN_TRABAJO e)
        {

            return new modelo.DetalleEntregaOrdenTrabajoModelo
            {
               DetalleOrdenTrabajoId = e.DETALLE_ORDEN_TRABAJO_ID,
               DetalleEntregaOrdenTrabajoId = e.DETALLE_ENTREGA_ORDEN_TRABAJO_ID,
               EntregaTrabajoId = e.ENTREGA_ORDEN_TRABAJO_ID
            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.DetalleEntregaOrdenTrabajoModelo> CrearDetallesEntregaOrdenTrabajo(IQueryable<entidad.DETALLE_ENTREGA_ORDEN_TRABAJO> listadoEntidad)
        {
            List<modelo.DetalleEntregaOrdenTrabajoModelo> listaModelo = new List<modelo.DetalleEntregaOrdenTrabajoModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearDetalleEntregaOrdenTrabajo(entidad));
            }
            return listaModelo;

        }

        #endregion
    }
}