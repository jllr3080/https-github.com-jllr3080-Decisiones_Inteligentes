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
    /// Ingresa un modelo y devuleve una entidad
    /// </summary>
    public class EnsambladorEntidad
    {

        #region ENTREGA ORDEN DE TRABAJO
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.ENTREGA_ORDEN_TRABAJO CrearEntregaOrdenTrabajo(modelo.EntregaOrdenTrabajoModelo m)
        {
            return new entidad.ENTREGA_ORDEN_TRABAJO()
            {
               ENTREGA_ORDEN_TRABAJO_ID = m.EntregaOrdenTrabajoId,
               ORDEN_TRABAJO_ID = m.OrdenTrabajoId,
               FECHA_ENTREGA = m.FechaEntrega,
               USUARIO_ENTREGA_ID = m.UsuarioEntregaId,
               USUARIO_RECIBE_ID = m.UsuarioRecibeId

            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.ENTREGA_ORDEN_TRABAJO> CrearEntregaOrdenesTrabajo(List<Modelo.EntregaOrdenTrabajoModelo> listadoModelo)
        {
            List<entidad.ENTREGA_ORDEN_TRABAJO> listaEntidad = new List<entidad.ENTREGA_ORDEN_TRABAJO>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearEntregaOrdenTrabajo(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region DETALLE ENTREGA ORDEN DE TRABAJO
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.DETALLE_ENTREGA_ORDEN_TRABAJO CrearDetalleEntregaOrdenTrabajo(modelo.DetalleEntregaOrdenTrabajoModelo m)
        {
            return new entidad.DETALLE_ENTREGA_ORDEN_TRABAJO()
            {
              DETALLE_ENTREGA_ORDEN_TRABAJO_ID = m.DetalleEntregaOrdenTrabajoId,
              DETALLE_ORDEN_TRABAJO_ID = m.DetalleOrdenTrabajoId,
              ENTREGA_ORDEN_TRABAJO_ID = m.EntregaTrabajoId

            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.DETALLE_ENTREGA_ORDEN_TRABAJO> CrearDetallesEntregaOrdenTrabajo(List<Modelo.DetalleEntregaOrdenTrabajoModelo> listadoModelo)
        {
            List<entidad.DETALLE_ENTREGA_ORDEN_TRABAJO> listaEntidad = new List<entidad.DETALLE_ENTREGA_ORDEN_TRABAJO>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearDetalleEntregaOrdenTrabajo(modelo));
            }
            return listaEntidad;

        }
        #endregion
    }
}