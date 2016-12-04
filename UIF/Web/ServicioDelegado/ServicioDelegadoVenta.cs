﻿#region using
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using Web.DTOs.Individuo;
using Web.DTOs.Venta;
using Web.Models.Individuo;
using Web.Models.Venta.Negocio;

#endregion
namespace Web.ServicioDelegado
{

    /// <summary>
    /// Metodos  de  venta 
    /// </summary>
    public class ServicioDelegadoVenta
    {

        private static string direccionUrl = "http://localhost/Decisiones_Inteligentes_Venta/ServicioVenta.svc/";

        #region NEGOCIO
        #region TRANSACCIONAL

        /// <summary>
        /// Graba la orden  de trabajo de forma completa
        /// </summary>
        /// <param name="ordenTrabajoDtOs"></param>
        /// <returns></returns>
        public OrdenTrabajoVistaModelo GrabarOrdenTrabajoCompleta(OrdenTrabajoVistaDTOs ordenTrabajoDtOs)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(OrdenTrabajoVistaDTOs));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, ordenTrabajoDtOs);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "GrabarOrdenTrabajoCompleta", "POST", datos);
                var js = new JavaScriptSerializer();
                return js.Deserialize<OrdenTrabajoVistaModelo>(json);
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
        public List<ConsultaOrdenTrabajoVistaDTOs> ObtenerOrdenTrabajoPorFechaIngresoYPorSucursal(string fechaDesde, int sucursalId)
        {
            try
            {
                var clienteWeb = new WebClient();
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerOrdenTrabajoPorFechaIngresoYPorSucursal?fechaDesde=" + fechaDesde+ "&sucursalId="+ sucursalId);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<ConsultaOrdenTrabajoVistaDTOs>>(json);

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