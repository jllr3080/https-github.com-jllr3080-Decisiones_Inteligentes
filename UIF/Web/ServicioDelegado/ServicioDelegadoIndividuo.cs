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
        /// Obtiene el cliente completo por  numero  de documento
        /// </summary>
        /// <param name="primerApellido"></param>
        /// <param name="segundoApellido"></param>
        /// <returns></returns>
        public List<ClienteGeneralVistaDTOs> ObtenerClientePorApellidos(string primerApellido, string segundoApellido)
        {
            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerClientePorApellidos?primerApellido=" + primerApellido + "&segundoApellido=" + segundoApellido);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<ClienteGeneralVistaDTOs>>(json);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
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
        /// Obtiene   la informacion del cliente
        /// </summary>
        /// <param name="apellidoPaterno"></param>
        /// <param name="apellidoMaterno"></param>
        public List<ClienteVistaDTOs> ObtenerDatosClientePorApellidos (string apellidoPaterno, string apellidoMaterno)
        {
            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerDatosClientePorApellidos?apellidoPaterno=" + apellidoPaterno+ "&apellidoMaterno="+ apellidoMaterno);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<ClienteVistaDTOs>>(json);

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

        #region PROVEEDOR
        /// <summary>
        /// Grabar Proveedor
        /// </summary>
        /// <param name="proveedorDtOs"></param>
        /// <returns></returns>
        public ProveedorVistaModelo GrabarProveedor(ProveedorVistaDTOs proveedorDtOs)
        {

            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ProveedorVistaDTOs));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, proveedorDtOs);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "GrabarProveedor", "POST", datos);
                var js = new JavaScriptSerializer();
                return js.Deserialize<ProveedorVistaModelo>(json);

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
        public void ActualizarProveedor(ProveedorVistaDTOs proveedorDtOs)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ProveedorVistaDTOs));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, proveedorDtOs);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "ActualizarProveedor", "POST", datos);
                //var js = new JavaScriptSerializer();
                //return js.Deserialize<ProveedorVistaModelo>(json);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        /// <summary>
        /// Obtiene el proveedor completo por  numero  de documento
        /// </summary>
        /// <param name="numeroIdentificacion"></param>
        /// <returns></returns>
        public ProveedorVistaDTOs ObtenerProveedorPorNumeroIdentificacion(string numeroIdentificacion)
        {
            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerProveedorPorNumeroIdentificacion?numeroIdentificacion=" + numeroIdentificacion);
                var js = new JavaScriptSerializer();
                return js.Deserialize<ProveedorVistaDTOs>(json);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
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