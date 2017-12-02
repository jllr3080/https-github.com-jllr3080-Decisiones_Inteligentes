#region using
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using JLLR.Core.ServicioDelegado.Proveedor.VistaModelo.General;

#endregion
namespace JLLR.Core.ServicioDelegado.Proveedor.ServicioDelegado
{
    public class ServicioDelegadoGeneral
    {
        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private static string direccionUrl = "http://localhost/Decisiones_Inteligentes_General/ServicioGeneral.svc/";

        #region MES
        /// <summary>
        /// Obtiene los meses de  cierre
        /// </summary>
        /// <returns></returns>
        public List<MesVistaModelo> ObtenerMeses()
        {
            try
            {
                try
                {
                    var clienteWeb = new WebClient();
                    clienteWeb.Headers["content-type"] = "application/json";
                    clienteWeb.Encoding = Encoding.UTF8;
                    var json = clienteWeb.DownloadString(direccionUrl + "ObtenerMeses");
                    var js = new JavaScriptSerializer();
                    return js.Deserialize<List<MesVistaModelo>>(json);
                }
                catch (Exception ex)
                {

                    throw;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region PUNTO VENTA
        /// <summary>
        /// Obtiene los puntos de  venta por sucursal Id
        /// </summary>
        /// <param name="sucursalId"></param>
        /// <returns></returns>
        public List<PuntoVentaVistaModelo> ObtenerPuntosVentaPorSucursalId(int sucursalId)
        {
            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerPuntosVentaPorSucursalId?sucursalId=" + sucursalId);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<PuntoVentaVistaModelo>>(json);


            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion


        #region PARAMETRO
        /// <summary>
        /// Obtiene los  parametros por descripcion
        /// </summary>
        /// <param name="descripcion"></param>
        /// <returns></returns>
        public ParametroVistaModelo ObtenerParametroPorDescripcion(string descripcion)
        {
            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerParametroPorDescripcion?descripcion=" + descripcion);
                var js = new JavaScriptSerializer();
                return js.Deserialize<ParametroVistaModelo>(json);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// Actualiza  los parametros
        /// </summary>
        /// <param name="parametro"></param>
        public void ActualizarParametro(ParametroVistaModelo parametro)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ParametroVistaModelo));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, parametro);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "ActualizarParametro ", "POST", datos);


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion
    }
}
