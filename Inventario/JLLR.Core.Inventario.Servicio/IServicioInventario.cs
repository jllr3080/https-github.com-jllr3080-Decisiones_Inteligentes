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

        #endregion

        #region PRODUCTO PRECIO

        /// <summary>
        /// Obtiene el precio de los productos por la talla y el codigo del producto
        /// </summary>
        /// <param name="productoId"></param>
        /// <param name="productoTallaId"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerProductoPrecioPorProductoIdYProductoTallaId?productoId={productoId}&productoTallaId={productoTallaId}", ResponseFormat = WebMessageFormat.Json)]
        List<modeloParametrizacion.ProductoPrecioModelo> ObtenerProductoPrecioPorProductoIdYProductoTallaId(
            int productoId,
            int productoTallaId);


        #endregion

        #region PRODUCTO TALLA

        /// <summary>
        /// Obtiene las tallas  de los productos por el codigo del producto
        /// </summary>
        /// <param name="productoId"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenProductoTallaPorProductoId?productoId={productoId}", ResponseFormat = WebMessageFormat.Json)]
        List<modeloParametrizacion.ProductoTallaModelo> ObtenProductoTallaPorProductoId(int productoId);

        #endregion

        #endregion



    }



}
