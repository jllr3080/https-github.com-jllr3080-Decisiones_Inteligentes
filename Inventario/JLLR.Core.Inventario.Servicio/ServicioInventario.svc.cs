#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using JLLR.Core.Inventario.Servicio.Transformador;
using modeloParametrizacion = JLLR.Core.Inventario.Servicio.Modelo.Parametrizacion;
#endregion
namespace JLLR.Core.Inventario.Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioInventario : IServicioInventario
    {
        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private readonly  InventarioTransformadorParametrizacion _inventarioTransformadorParametrizacion= new InventarioTransformadorParametrizacion();

        #region PARAMETRIZACION
      

        #region   PRODUCTO
        /// <summary>
        /// Obtener producto por  tipo de  producto servicio o produccion etc
        /// </summary>
        /// <param name="tipoProductoId"></param>
        /// <returns></returns>
        public List<modeloParametrizacion.ProductoModelo> ObtenerProductoPorTipoProductoId(int tipoProductoId)
        {
            try
            {
                return _inventarioTransformadorParametrizacion.ObtenerProductoPorTipoProductoId(tipoProductoId);


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

        public List<modeloParametrizacion.ProductoPrecioModelo> ObtenerProductoPrecioPorProductoIdYProductoTallaId(int productoId,
            int productoTallaId)
        {
            try
            {
                return
                    _inventarioTransformadorParametrizacion.ObtenerProductoPrecioPorProductoIdYProductoTallaId(
                        productoId, productoTallaId);

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
        public List<modeloParametrizacion.ProductoTallaModelo> ObtenProductoTallaPorProductoId(int productoId)
        {
            try
            {
                return
                    _inventarioTransformadorParametrizacion.ObtenProductoTallaPorProductoId(productoId);

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
