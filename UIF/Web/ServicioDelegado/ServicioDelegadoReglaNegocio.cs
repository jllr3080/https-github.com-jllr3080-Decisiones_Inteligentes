#region using
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using Web.DTOs.ReglaNegocio;
using Web.DTOs.Venta;
using Web.Models.Inventario.Parametrizacion;
using Web.Models.ReglaNegocio;
using Web.Models.Venta.Negocio;

#endregion

namespace Web.ServicioDelegado
{
    public class ServicioDelegadoReglaNegocio
    {
        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private static string direccionUrl = "http://localhost/Decisiones_Inteligentes_Regla_Negocio/ServicioReglaNegocio.svc/";


        #region TRANSACCIONAL
        /// <summary>
        /// Obtiene  las  promociones  vigentes 
        /// </summary>
        /// <param name="puntoVentaId"></param>
        /// <param name="sucursalId"></param>
        /// <returns></returns>

        public List<ReglaVistaModelo> ObtenerPromocionesVigentes(int puntoVentaId, int sucursalId)
        {
            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerPromocionesVigentes?puntoVentaId=" + puntoVentaId + "&sucursalId=" + sucursalId);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<ReglaVistaModelo>>(json);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtener las reglas para aplicar     
        /// </summary>
        /// <param name="puntoVentaId"></param>
        /// <param name="sucursalId"></param>
        /// <returns></returns>
        public List<ReglaVistaDTOs> ObtenerReglasPorPuntoVentaIdYSucursalId(int puntoVentaId, int sucursalId)
        {
            try
            {

                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerReglasPorPuntoVentaIdYSucursalId?puntoVentaId=" + puntoVentaId + "&sucursalId="+ sucursalId);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<ReglaVistaDTOs>>(json);


            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region REGLA NEGOCIO

        /// <summary>
        /// Ejeuta las  reglas  de  negocio
        /// </summary>
        /// <param name="parametroEntradaReglaNegocio"></param>
        /// <returns></returns>
        public ParametroSalidaReglaNegocioVistaDTOs EjecucionReglaNegocio(ParametroEntradaReglaNegocioVistaDTOs parametroEntradaReglaNegocio)
        {

            try
            {

                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ParametroEntradaReglaNegocioVistaDTOs));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, parametroEntradaReglaNegocio);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "EjecucionReglaNegocio", "POST", datos);
                var js = new JavaScriptSerializer();
                return js.Deserialize<ParametroSalidaReglaNegocioVistaDTOs>(json);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion           

        #region REGLA

        /// <summary>
        /// Obtiene la promocion por  Id
        /// </summary>
        /// <param name="reglaId"></param>
        /// <returns></returns>
        public ReglaVistaModelo ObtenerReglaPorId(int reglaId)
        {
            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerReglaPorId?reglaId=" + reglaId);
                var js = new JavaScriptSerializer();
                return js.Deserialize< ReglaVistaModelo > (json);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
        #region ADMINISTRACION PROMOCIONES

        /// <summary>
        /// Grabar promociones
        /// </summary>
        /// <param name="reglaCompletaDtOs"></param>
        public void GrabarPromocionesCompleta(ReglaCompletaVistaDTOs reglaCompletaDtOs)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ReglaCompletaVistaDTOs));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, reglaCompletaDtOs);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "GrabarPromocionesCompleta ", "POST", datos);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        /// <summary>
        /// Actualizar promociones
        /// </summary>
        /// <param name="reglaCompletaDtOs"></param>
        public void ActualizarPromocionesCompleta(ReglaCompletaVistaDTOs reglaCompletaDtOs)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ReglaCompletaVistaDTOs));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, reglaCompletaDtOs);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "ActualizarPromocionesCompleta ", "POST", datos);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        /// <summary>
        /// Obtiene las promociones
        /// </summary>
        /// <param name="puntoVentaId"></param>
        /// <returns></returns>

        public List<ReglaCompletaVistaDTOs> ObtenerPromociones(int puntoVentaId)
        {
            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerPromociones?puntoVentaId=" + puntoVentaId );
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<ReglaCompletaVistaDTOs>>(json);
            
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        #endregion

    }
}