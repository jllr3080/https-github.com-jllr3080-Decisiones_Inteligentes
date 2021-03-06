﻿#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using entidad = JLLR.Core.Base.Proveedor.Entidades;
using modelo = JLLR.Core.FlujoProceso.Servicio.Modelo;
#endregion
namespace JLLR.Core.FlujoProceso.Servicio.Ensamblador
{

    /// <summary>
    /// Ingresa un modelo y devuleve una entidad
    /// </summary>
    public class EnsambladorEntidad
    {

        #region HISTORIAL PROCESO
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.HISTORIAL_PROCESO CrearHistorialProceso(modelo.HistorialProcesoModelo m)
        {
            return new entidad.HISTORIAL_PROCESO()
            {
               HISTORIAL_PROCESO_ID = m.HistorialProcesoId,
               NUMERO_ORDEN = m.NumeroOrden,
               ORDEN_TRABAJO_ID = m.OrdenTrabajoId,
               ETAPA_PROCESO_ID = m.EtapaProceso.EtapaProcesoId,
               FECHA_FIN = m.FechaFin,
               FECHA_INICIO = m.FechaInicio,
               FECHA_REGISTRO = m.FechaRegistro,
               TEXTO = m.Texto,
               SUCURSAL_ID = m.SucursalId,
               PUNTO_VENTA_ID = m.PuntoVentaId,
               USUARIO_ENTREGA_ID = m.UsuarioEntregaId,
               USUARIO_RECIBE_ID = m.UsuarioRecibeId,
               PERFIL_ID = m.PerfilId,
               DETALLE_ORDEN_TRABAJO_ID = m.DetalleOrdenTrabajoId,
               PASO_ESTA_ETAPA = m.PasoPorEstaEtapa,
               SE_ENVIO = m.SeEnvio
            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.HISTORIAL_PROCESO> CrearHistorialProcesos(List<Modelo.HistorialProcesoModelo> listadoModelo)
        {
            List<entidad.HISTORIAL_PROCESO> listaEntidad = new List<entidad.HISTORIAL_PROCESO>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearHistorialProceso(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region HISTORIAL RECLAMO REPROCESO PRENDA
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.HISTORIAL_RECLAMO_REPROCESO_PRENDA CrearHistorialReclamoReprocesoPrenda(modelo.HistorialReclamoReprocesoPrendaModelo m)
        {
            return new entidad.HISTORIAL_RECLAMO_REPROCESO_PRENDA()
            {
               USUARIO_ID = m.UsuarioId,
               DETALLE_PRENDA_ORDEN_TRABAJO_ID = m.DetallePrendaOrdenTrabajoId,
               FECHA = m.Fecha,
               FECHA_ENTREGA = m.FechaEntrega,
               HISTORIAL_RECLAMO_REPROCESO_PRENDA_ID = m.HistorialReclamoReprocesoPrendaId,
               PORQUE_REPROCESO = m.PorqueReproceso
            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.HISTORIAL_RECLAMO_REPROCESO_PRENDA> CrearHistorialReclamoReprocesoPrendas(List<Modelo.HistorialReclamoReprocesoPrendaModelo> listadoModelo)
        {
            List<entidad.HISTORIAL_RECLAMO_REPROCESO_PRENDA> listaEntidad = new List<entidad.HISTORIAL_RECLAMO_REPROCESO_PRENDA>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearHistorialReclamoReprocesoPrenda(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region HISTORIAL REPROCESO
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.HISTORIAL_REPROCESO CrearHistorialReproceso(modelo.HistorialReprocesoModelo m)
        {
            return new entidad.HISTORIAL_REPROCESO()
            {
                HISTORIAL_REPROCESO_ID = m.HistorialReprocesoId,
                HISTORIAL_PROCESO_ID = m.HistorialProceso.HistorialProcesoId,
                DETALLE_PRENDA_ORDEN_TRABAJO_ID = m.DetallePrendaOrdenTrabajoId,
                FECHA_ESTIMADA_ENTREGA = m.FechaEstimadaEntrega
                
            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.HISTORIAL_REPROCESO> CrearHistorialReprocesos(List<Modelo.HistorialReprocesoModelo> listadoModelo)
        {
            List<entidad.HISTORIAL_REPROCESO> listaEntidad = new List<entidad.HISTORIAL_REPROCESO>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearHistorialReproceso(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region DETALLE HISTORIAL REPROCESO
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.DETALLE_HISTORIAL_REPROCESO CrearDetalleHistorialReproceso(modelo.DetalleHistorialReprocesoModelo m)
        {
            return new entidad.DETALLE_HISTORIAL_REPROCESO()
            {
               DETALLE_HISTORIAL_REPROCESO_ID = m.DetalleHistorialReprocesoId,
               HISTORIAL_REPROCESO_ID = m.HistorialReproceso.HistorialReprocesoId,
               TIPO_REPROCESO_ID = m.TipoReproceso.TipoReprocesoId,
               MOTIVO =  m.Motivo

            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.DETALLE_HISTORIAL_REPROCESO> CrearDetalleHistorialReprocesos(List<Modelo.DetalleHistorialReprocesoModelo> listadoModelo)
        {
            List<entidad.DETALLE_HISTORIAL_REPROCESO> listaEntidad = new List<entidad.DETALLE_HISTORIAL_REPROCESO>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearDetalleHistorialReproceso(modelo));
            }
            return listaEntidad;

        }
        #endregion
    }
}