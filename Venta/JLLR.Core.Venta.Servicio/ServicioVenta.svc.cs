﻿#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using JLLR.Core.Venta.Servicio.DTOs;
using JLLR.Core.Venta.Servicio.Modelo;
using JLLR.Core.Venta.Servicio.Transformador;
#endregion

namespace JLLR.Core.Venta.Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioVenta : IServicioVenta
    {
        #region  DECLARACIONES  E INSTANCIAS
        private readonly VentaTransfomadorNegocio _ventaTransformadorNegocio = new VentaTransfomadorNegocio();
        #endregion

        #region TRANSACCIONAL
        #region NEGOCIO
        /// <summary>
        /// Graba la orden  de trabajo de forma completa
        /// </summary>
        /// <param name="ordenTrabajoDtOs"></param>
        /// <returns></returns>
        public OrdenTrabajoModelo GrabarOrdenTrabajoCompleta(OrdenTrabajoDTOs ordenTrabajoDtOs)
        {
            try
            {
                return _ventaTransformadorNegocio.GrabarOrdenTrabajoCompleta(ordenTrabajoDtOs);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region REPORTES
        /// <summary>
        /// Obtiene  
        /// </summary>
        /// <param name="fechaDesde"></param>
        /// <param name="sucursalId"></param>
        /// <returns></returns>
        public List<ConsultaOrdenTrabajoDTOs> ObtenerOrdenTrabajoPorFechaIngresoYPorSucursal(string fechaDesde, int sucursalId)
        {
            try
            {
                return _ventaTransformadorNegocio.ObtenerOrdenTrabajoPorFechaIngresoYPorSucursal(Convert.ToDateTime(fechaDesde), sucursalId);

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