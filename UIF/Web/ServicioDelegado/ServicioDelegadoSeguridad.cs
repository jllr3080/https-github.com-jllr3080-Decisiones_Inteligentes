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
using Web.DTOs.Seguridad;
using Web.DTOs.Venta;
using Web.Models.Seguridad.Negocio;

#endregion 

namespace Web.ServicioDelegado
{
    /// <summary>
    /// Servicio delegado de seguridad  que contiene todos los metodos del servicio de  seguridad como tal
    /// </summary>
    public class ServicioDelegadoSeguridad
    {

        // <summary>
        /// Declaraciones e instancias
        /// </summary>
        private static string  direccionUrl = "http://localhost/Decisiones_Inteligentes_Seguridad/ServicioSeguridad.svc/";

        #region TRANSACCIONAL
        /// <summary>
        /// Ingresa al sistema 
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="contrasena"></param>
        /// <param name="puntoVentaId"></param>
        /// <param name="sucursalId"></param>
        public UsuarioVistaDTOs IngresoSistema(string nombreusuario, string claveUsuario, int puntoVentaId, int sucursalId)
        {
            try
            {
                var clienteWeb = new WebClient();
                var json = clienteWeb.DownloadString(direccionUrl + "IngresoSistema?nombreusuario=" + nombreusuario + "&claveUsuario=" + claveUsuario + "&puntoVentaId=" + puntoVentaId+ "&sucursalId="+ sucursalId);
                var js = new JavaScriptSerializer();
                return js.Deserialize<UsuarioVistaDTOs>(json);
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Genera el menu  de acuerdo al usuario  revisa  el perfil
        /// </summary>
        /// <param name="usuarioId"></param>
        public List<AccesoVistaDTOs> GenerarMenu(int usuarioId)
        {

            try
            {
                var clienteWeb = new WebClient();
                var json = clienteWeb.DownloadString(direccionUrl + "GenerarMenu?usuarioId=" + usuarioId);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<AccesoVistaDTOs>>(json);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region USUARIO
        /// <summary>
        /// Graba el usuario
        /// </summary>
        /// <param name="usuario"></param>
        public UsuarioVistaModelo GrabarUsuario(UsuarioVistaModelo usuario)
        {

            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(UsuarioVistaModelo));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, usuario);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "GrabarUsuario", "POST", datos);
                var js = new JavaScriptSerializer();
                return js.Deserialize<UsuarioVistaModelo>(json);
            }
            catch (Exception ex)
            {

                throw;
            }


        }
        #endregion

        #region USUARIO PERFIL
        /// <summary>
        /// Graba  Usuario Perfil
        /// </summary>
        /// <param name="usuarioPerfil"></param>
        public void GrabarUsuarioPerfil(UsuarioPerfilVistaModelo usuarioPerfil)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(UsuarioPerfilVistaModelo));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, usuarioPerfil);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "GrabarUsuarioPerfil", "POST", datos);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}