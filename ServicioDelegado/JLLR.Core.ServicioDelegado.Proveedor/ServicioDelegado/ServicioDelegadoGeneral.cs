#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    }
}
