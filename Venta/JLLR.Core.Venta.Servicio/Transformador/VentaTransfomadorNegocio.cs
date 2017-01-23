﻿#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JLLR.Core.Venta.Proveedor.Negocio;
using JLLR.Core.Venta.Servicio.DTOs;
using JLLR.Core.Venta.Servicio.Modelo;
using JLLR.Core.Venta.Servicio.EnsambladorDTOs;
using JLLR.Core.Venta.Servicio.Ensamblador;
using  ensambladorLogistica=JLLR.Core.Logistica.Servicio.Ensamblador;
#endregion
namespace JLLR.Core.Venta.Servicio.Transformador
{

    /// <summary>
    /// Metodos  generales
    /// </summary>
    public class VentaTransfomadorNegocio
    {

        #region DECLARACIONES  E INSTANCIAS
        private readonly VentaNegocio _ventaNegocio = new VentaNegocio();
        private readonly EnsambladorEntidadDTOs _ensambladorEntidadDTOs = new EnsambladorEntidadDTOs();
        private readonly EnsambladorModeloDTOs _ensambladorModeloDTOs = new EnsambladorModeloDTOs();
        private readonly EnsambladorEntidad _ensambladorEntidad = new EnsambladorEntidad();
        private readonly EnsambladorModelo _ensambladorModelo = new EnsambladorModelo();
        private readonly  ensambladorLogistica.EnsambladorModelo _ensambladorModeloLogistica= new ensambladorLogistica.EnsambladorModelo();
        private  readonly ensambladorLogistica.EnsambladorEntidad _ensambladorEntidadLogistica= new ensambladorLogistica.EnsambladorEntidad();

        #endregion
        #region NEGOCIO 
        #region TRANSACCIONAL
        /// <summary>
        /// Graba la orden  de trabajo de forma completa
        /// </summary>
        /// <param name="ordenTrabajoDtOs"></param>
        /// <returns></returns>
        public OrdenTrabajoModelo GrabarOrdenTrabajoCompleta(OrdenTrabajoDTOs ordenTrabajoDtOs)
        {
            try
            {
                return _ensambladorModelo.CrearOrdenTrabajo(_ventaNegocio.GrabarOrdenTrabajoCompleta(_ensambladorEntidadDTOs.CrearOrdenTrabajotOs(ordenTrabajoDtOs)));
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtiene todas las  ordenes  que estan lista para enviarse  a matriz
        /// </summary>
        /// <returns></returns>
        public List<OrdenTrabajoDTOs> ObtenerOrdenTrabajoPorEnvioMatriz(int puntoVentaId, int sucursalId)
        {
            try
            {
                return _ensambladorModeloDTOs.CrearOrdenesTrabajotOs(_ventaNegocio.ObtenerOrdenTrabajoPorEnvioMatriz(puntoVentaId,sucursalId));

            }
            catch (Exception ex)
            {

                throw;
            }

        }

       
        #endregion

        #region ORDEN TRABAJO

        /// <summary>
        /// Actualiza la orden de trabajo
        /// </summary>
        /// <param name=""></param>
        public void ActualizarOrdenTrabajo(OrdenTrabajoModelo ordenTrabajo)
        {
            try
            {
                _ventaNegocio.ActualizarOrdenTrabajo(_ensambladorEntidad.CrearOrdenTrabajo(ordenTrabajo));
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtiene  por  id de la orden de trabajo
        /// </summary>
        /// <param name="ordenTrabajoId"></param>
        /// <returns></returns>
        public OrdenTrabajoDTOs ObtenerOrdenTrabajoPorOrdenTrabajoId(int ordenTrabajoId)
        {
            try
            {
                return
                    _ensambladorModeloDTOs.CrearOrdenTrabajotOs(
                        _ventaNegocio.ObtenerOrdenTrabajoPorOrdenTrabajoId(ordenTrabajoId));
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion

        #region DETALLE DE  ORDEN DE TRABAJO OBSERVACIONES
        /// <summary>
        /// Graba todas las observaciones de  los detalles de la orden de trabajo
        /// </summary>
        /// <param name="detalleOrdenTrabajoObservacion"></param>
        public void GrabarDetalleOrdenTrabajoObservacion(DetalleOrdenTrabajoObservacionModelo detalleOrdenTrabajoObservacion)
        {
            try
            {
                _ventaNegocio.GrabarDetalleOrdenTrabajoObservacion(_ensambladorEntidad.CrearDetalleOrdenTrabajoObservacion(detalleOrdenTrabajoObservacion));
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtiene las observaciones 
        /// </summary>
        /// <param name="detalleOrdenTrabajoId"></param>
        /// <returns></returns>
        public List<DetalleOrdenTrabajoObservacionModelo> ObtenerDetalleOrdenTrabajoObservaciones(
            int detalleOrdenTrabajoId)
        {
            try
            {
                return
                    _ensambladorModelo.CrearDetalleOrdenTrabajosObservacion(
                        _ventaNegocio.ObtenerDetalleOrdenTrabajoObservaciones(detalleOrdenTrabajoId));
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion


        #region  REPORTES

        /// <summary>
        /// Obtiene  la orden de  trabajo por  numero de  orden
        /// </summary>
        /// <param name="numeroOrden"></param>
        /// <param name="puntoVentaId"></param>
        /// <returns></returns>
        public List<ConsultaOrdenTrabajoDTOs> ObtenerOrdenTrabajoPorNumeroOrdenYPuntoVenta(string numeroOrden, int puntoVentaId)
        {
            try
            {

                return _ensambladorModeloDTOs.CrearConsultaOrdenesTrabajoDtOs(_ventaNegocio.ObtenerOrdenTrabajoPorNumeroOrdenYPuntoVenta(numeroOrden, puntoVentaId));

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtiene  
        /// </summary>
        /// <param name="fechaDesde"></param>
        /// <param name="sucursalId"></param>
        /// <returns></returns>
        public List<ConsultaOrdenTrabajoDTOs> ObtenerOrdenTrabajoPorFechaIngresoYPorSucursal(DateTime fechaDesde, int sucursalId)
        {
            try
            {
                return _ensambladorModeloDTOs.CrearConsultaOrdenesTrabajoDtOs(_ventaNegocio.ObtenerOrdenTrabajoPorFechaIngresoYPorSucursal(fechaDesde,sucursalId));

            }
            catch (Exception ex)
            {

                throw;
            }
        }


        #endregion


        #endregion

    }
}