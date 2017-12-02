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
        /// Obtiene el producto  
        /// </summary>
        /// <param name="productoId"></param>
        /// <returns></returns>
        public modeloParametrizacion.ProductoModelo ObtenerProductoPorId(int productoId)
        {
            try
            {
                return _inventarioTransformadorParametrizacion.ObtenerProductoPorId(productoId);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


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

        /// <summary>
        /// Grabar  producto
        /// </summary>
        /// <param name="producto"></param>
        public void GrabarProducto(modeloParametrizacion.ProductoModelo producto)
        {
            try
            {
              _inventarioTransformadorParametrizacion.GrabarProducto(producto);

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
        public void ActualizarProducto(modeloParametrizacion.ProductoModelo producto)
        {
            try
            {
                _inventarioTransformadorParametrizacion.ActualizarProducto(producto);
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

        public List<modeloParametrizacion.ProductoPrecioModelo> ObtenerProductoPrecioPorProductoId(int productoId)
        {
            try
            {
                return
                    _inventarioTransformadorParametrizacion.ObtenerProductoPrecioPorProductoId(productoId);

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
        public void GrabarProductoPrecio(modeloParametrizacion.ProductoPrecioModelo productoPrecio)
        {
            try
            {
              _inventarioTransformadorParametrizacion.GrabarProductoPrecio(productoPrecio);

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
        public void ActualizarProductoPrecio(modeloParametrizacion.ProductoPrecioModelo productoPrecio)
        {
            try
            {
               _inventarioTransformadorParametrizacion.ActualizarProductoPrecio(productoPrecio);
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

        public List<modeloParametrizacion.ProductoPrecioModelo> ObtenerProductoPrecioPorEstadoYProductoId(int productoId)
        {
            try
            {
                return _inventarioTransformadorParametrizacion.ObtenerProductoPrecioPorEstadoYProductoId(productoId);

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
