    #region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using Web.DTOs.Individuo;
using JLLR.Core.ServicioDelegado.Proveedor.VistaModelo.Inventario;

#endregion
namespace Web.ServicioDelegado
{
    /// <summary>
    /// Metodos de  Inventario
    /// </summary>
    public class ServicioDelegadoInventario
    {
        // <summary>
        /// Declaraciones e instancias
        /// </summary>
        private static string direccionUrl = "http://localhost/Decisiones_Inteligentes_Inventario/ServicioInventario.svc/";

        #region PARAMETRIZACION
           

        #region   PRODUCTO
        /// <summary>
        /// Obtener producto por  tipo de  producto servicio o produccion etc
        /// </summary>
        /// <param name="tipoProductoId"></param>
        /// <returns></returns>
        public List<ProductoVistaModelo> ObtenerProductoPorTipoProductoId(int tipoProductoId)
        {
            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerProductoPorTipoProductoId?tipoProductoId="+ tipoProductoId);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<ProductoVistaModelo>>(json);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region PRODUCTO PRECIO

        /// <summary>
        /// Obtiene  los precios de las prendas  que tengan el ultimo precio habilitado
        /// </summary>
        /// <param name="productoId"></param>
        /// <returns></returns>

        public List<ProductoPrecioVistaModelo> ObtenerProductoPrecioPorProductoId(int productoId)
        {
            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerProductoPrecioPorProductoId?productoId=" + productoId);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<ProductoPrecioVistaModelo>>(json);

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