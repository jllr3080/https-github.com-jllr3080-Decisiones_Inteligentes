#region using
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using Web.DTOs.Individuo;
using Web.DTOs.Seguridad;
using Web.Models.Individuo;
using System.Runtime.Serialization.Json;
#endregion
namespace Web.ServicioDelegado
{
    /// <summary>
    /// Servicio delegado del individuo  
    /// </summary>
    public class ServicioDelegadoIndividuo
    {

        // <summary>
        /// Declaraciones e instancias
        /// </summary>
        private static string direccionUrl = "http://localhost/Decisiones_Inteligentes_Individuo/ServicioIndividuo.svc/";


        #region TRANSACCIONAL
        /// <summary>
        /// Obtiene   la informacion del cliente
        /// </summary>
        /// <param name="numeroIdentificacion"></param>
        /// <returns></returns>
        public ClienteVistaDTOs ObtenerDatosClientePorNumeroIdentificacion(string numeroIdentificacion)
        {
            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerDatosClientePorNumeroIdentificacion?numeroIdentificacion=" + numeroIdentificacion);
                var js = new JavaScriptSerializer();
                return js.Deserialize<ClienteVistaDTOs>(json);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Grabar cliente
        /// </summary>
        /// <param name="clienteGeneralDtOs"></param>
        /// <returns></returns>
        public ClienteVistaModelo GrabarCliente(ClienteGeneralVistaDTOs clienteGeneralDtOs)
        {
           
                try
                {
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ClienteGeneralVistaDTOs));
                    MemoryStream memoria = new MemoryStream();
                    serializer.WriteObject(memoria, clienteGeneralDtOs);
                    string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                    WebClient clienteWeb = new WebClient();
                    clienteWeb.Headers["content-type"] = "application/json";
                    clienteWeb.Encoding = Encoding.UTF8;
                    var json = clienteWeb.UploadString(direccionUrl + "GrabarCliente", "POST", datos);
                    var js = new JavaScriptSerializer();
                    return js.Deserialize<ClienteVistaModelo>(json);
                }
                catch (Exception ex)
                {

                    throw;
                }
            
        }

        /// <summary>
        /// Actualza  el  cliente
        /// </summary>
        /// <param name="clienteGeneralDtOs"></param>
        /// <returns></returns>
        public void ActualizarCliente(ClienteGeneralVistaDTOs clienteGeneralDtOs)
        {

            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ClienteGeneralVistaDTOs));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, clienteGeneralDtOs);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "ActualizarCliente", "POST", datos);
                var js = new JavaScriptSerializer();
                
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        /// <summary>
        /// Obtiene el cliente completo por  numero  de documento
        /// </summary>
        /// <param name="numeroIdentificacion"></param>
        /// <returns></returns>
        public ClienteGeneralVistaDTOs ObtenerClientePorNumeroIdentificacion(string numeroIdentificacion)
        {
            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerClientePorNumeroIdentificacion?numeroIdentificacion=" + numeroIdentificacion);
                var js = new JavaScriptSerializer();
                return js.Deserialize<ClienteGeneralVistaDTOs>(json);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region VALIDACIONES
        #region CLIENTE
        /// <summary>
        /// Validar si el cliente ya existe  
        /// </summary>
        /// <returns></returns>
        public bool ValidarExistenciaClientePorNumeroIdentificacion(string numeroIdentificacion)
        {
            try
            {
                try
                {
                    var clienteWeb = new WebClient();
                    var json = clienteWeb.DownloadString(direccionUrl + "ValidarExistenciaClientePorNumeroIdentificacion?numeroIdentificacion=" + numeroIdentificacion);
                    var js = new JavaScriptSerializer();
                    return js.Deserialize<bool>(json);
                }
                catch (Exception ex)
                {

                    throw;
                }
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