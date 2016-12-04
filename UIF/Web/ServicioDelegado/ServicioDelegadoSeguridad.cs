#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using Web.DTOs.Seguridad;


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
    }
}