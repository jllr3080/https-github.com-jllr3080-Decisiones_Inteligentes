#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using modeloParametrizacion = JLLR.Core.Inventario.Servicio.Modelo.Parametrizacion;
#endregion
namespace JLLR.Core.Inventario.Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioInventario
    {
        #region PARAMETRIZACION
        

        #region   PRODUCTO

        /// <summary>
        /// Obtener producto por  tipo de  producto servicio o produccion etc
        /// </summary>
        /// <param name="tipoProductoId"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerProductoPorTipoProductoId?tipoProductoId={tipoProductoId}", ResponseFormat = WebMessageFormat.Json)]
        List<modeloParametrizacion.ProductoModelo> ObtenerProductoPorTipoProductoId(int tipoProductoId);

        /// <summary>
        /// Grabar  producto
        /// </summary>
        /// <param name="producto"></param>
        [OperationContract]
        [WebInvoke(UriTemplate = "GrabarProducto/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        void GrabarProducto(modeloParametrizacion.ProductoModelo producto);


        /// <summary>
        /// Actualiza  el producto
        /// </summary>
        /// <param name="producto"></param>
        [OperationContract]
        [WebInvoke(UriTemplate = "ActualizarProducto/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        void ActualizarProducto(modeloParametrizacion.ProductoModelo producto);
      

        #endregion

        #region PRODUCTO PRECIO

        /// <summary>
        /// Obtiene  los precios de las prendas  que tengan el ultimo precio habilitado
        /// </summary>
        /// <param name="productoId"></param>
        /// <returns></returns>

        [OperationContract]
        [WebGet(
            UriTemplate =
                "ObtenerProductoPrecioPorProductoId?productoId={productoId}",
            ResponseFormat = WebMessageFormat.Json)]
        List<modeloParametrizacion.ProductoPrecioModelo> ObtenerProductoPrecioPorProductoId(int productoId);



        /// <summary>
        /// Graba el precio  de la prenda
        /// </summary>
        /// <param name="productoPrecio"></param>
        [OperationContract]
        [WebInvoke(UriTemplate = "GrabarProductoPrecio/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        void GrabarProductoPrecio(modeloParametrizacion.ProductoPrecioModelo productoPrecio);



        /// <summary>
        /// Actualiza los precios  de las prendas
        /// </summary>
        /// <param name="productoPrecio"></param>
        [OperationContract]
        [WebInvoke(UriTemplate = "ActualizarProductoPrecio/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        void ActualizarProductoPrecio(modeloParametrizacion.ProductoPrecioModelo productoPrecio);


        /// <summary>
        /// Obtiene  todos los precios de las prendas 
        /// </summary>
        /// <param name="productoId"></param>
        /// <returns></returns>

        [OperationContract]
        [WebGet(
          UriTemplate =
              "ObtenerProductoPrecioPorEstadoYProductoId?productoId={productoId}",
          ResponseFormat = WebMessageFormat.Json)]
        List<modeloParametrizacion.ProductoPrecioModelo> ObtenerProductoPrecioPorEstadoYProductoId(int productoId);


        #endregion



        #endregion



    }



}
