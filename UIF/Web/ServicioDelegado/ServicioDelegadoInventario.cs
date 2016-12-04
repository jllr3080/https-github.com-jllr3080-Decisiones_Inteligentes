#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using Web.DTOs.Individuo;
using Web.Models.Inventario.Parametrizacion;

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
        /// Obtiene el precio de los productos por la talla y el codigo del producto
        /// </summary>
        /// <param name="productoId"></param>
        /// <param name="productoTallaId"></param>
        /// <returns></returns>

        public List<ProductoPrecioVistaModelo> ObtenerProductoPrecioPorProductoIdYProductoTallaId(int productoId,
            int productoTallaId)
        {
            try
            {
                var clienteWeb = new WebClient();
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerProductoPrecioPorProductoIdYProductoTallaId?productoId=" + productoId+ "&productoTallaId="+ productoTallaId);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<ProductoPrecioVistaModelo>>(json);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion

        #region PRODUCTO TALLA

        /// <summary>
        /// Obtiene las tallas  de los productos por el codigo del producto
        /// </summary>
        /// <param name="productoId"></param>
        /// <returns></returns>
        public List<ProductoTallaVistaModelo> ObtenProductoTallaPorProductoId(int productoId)
        {
            try
            {
                var clienteWeb = new WebClient();
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenProductoTallaPorProductoId?productoId=" + productoId );
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<ProductoTallaVistaModelo>>(json);

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