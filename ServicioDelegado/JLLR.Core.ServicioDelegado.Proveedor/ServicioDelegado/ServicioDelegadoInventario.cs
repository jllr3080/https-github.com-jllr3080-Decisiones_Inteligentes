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
using JLLR.Core.ServicioDelegado.Proveedor.VistaModelo.Inventario;

#endregion
namespace JLLR.Core.ServicioDelegado.Proveedor.ServicioDelegado
{
    /// <summary>
    /// Servicio de legado de Inventario
    /// </summary>
    public class ServicioDelegadoInventario
    {
        /// <summary>
        /// Declaraciones  e Instancias
        /// </summary>
        private  string direccionUrl= "http://localhost/Decisiones_Inteligentes_Inventario/ServicioInventario.svc/";

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
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerProductoPorTipoProductoId?tipoProductoId=" + tipoProductoId);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<ProductoVistaModelo>>(json);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Grabar  producto
        /// </summary>
        /// <param name="producto"></param>
        public void GrabarProducto(ProductoVistaModelo producto)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ProductoVistaModelo));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, producto);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "GrabarProducto", "POST", datos);

            }
            catch (Exception ex)
            {

                throw;
            }
        }


        /// <summary>
        /// Actualiza  el producto
        /// </summary>
        /// <param name="producto"></param>
        public void ActualizarProducto(ProductoVistaModelo producto)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ProductoVistaModelo));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, producto);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "ActualizarProducto", "POST", datos);
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


        /// <summary>
        /// Graba el precio  de la prenda
        /// </summary>
        /// <param name="productoPrecio"></param>
        public void GrabarProductoPrecio(ProductoPrecioVistaModelo productoPrecio)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ProductoPrecioVistaModelo));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, productoPrecio);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "GrabarProductoPrecio", "POST", datos);

            }
            catch (Exception ex)
            {

                throw;
            }
        }


        /// <summary>
        /// Actualiza los precios  de las prendas
        /// </summary>
        /// <param name="productoPrecio"></param>
        public void ActualizarProductoPrecio(ProductoPrecioVistaModelo productoPrecio)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ProductoPrecioVistaModelo));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, productoPrecio);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "ActualizarProductoPrecio", "POST", datos);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtiene  todos los precios de las prendas 
        /// </summary>
        /// <param name="productoId"></param>
        /// <returns></returns>

        public List<ProductoPrecioVistaModelo> ObtenerProductoPrecioPorEstadoYProductoId(int productoId)
        {
            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerProductoPrecioPorEstadoYProductoId?productoId=" + productoId);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<ProductoPrecioVistaModelo>>(json);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion
    }
}
