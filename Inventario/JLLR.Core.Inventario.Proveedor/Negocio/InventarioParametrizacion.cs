#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.Entidades;
using JLLR.Core.Inventario.Proveedor.DAOs;

#endregion
namespace JLLR.Core.Inventario.Proveedor.Negocio
{

    /// <summary>
    /// Todos los  metodos  de parametrizacion de la pantalla
    /// </summary>
    public class InventarioParametrizacion
    {

        #region DECLARACION E INSTANCIAS
        
        private readonly  ProductoDAOs _productoDaOs= new ProductoDAOs();
        private  readonly  ProductoPrecioDAOs _productoPrecioDaOs= new ProductoPrecioDAOs();
        
        #endregion
        
        #region   PRODUCTO
        /// <summary>
        /// Obtener producto por  tipo de  producto servicio o produccion etc
        /// </summary>
        /// <param name="tipoProductoId"></param>
        /// <returns></returns>
        public IQueryable<PRODUCTO> ObtenerProductoPorTipoProductoId(int tipoProductoId)
        {
            try
            {
                return _productoDaOs.ObtenerProductoPorTipoProductoId(tipoProductoId);

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
        public void GrabarProducto(PRODUCTO producto)
        {
            try
            {
                 _productoDaOs.GrabarProducto(producto);
             
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
        public void ActualizarProducto(PRODUCTO producto)
        {
            try
            {
               _productoDaOs.ActualizarProducto(producto);
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

        public IQueryable<PRODUCTO_PRECIO> ObtenerProductoPrecioPorProductoId(int productoId)
        {
            try
            {
                return _productoPrecioDaOs.ObtenerProductoPrecioPorProductoId(productoId);

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
        public void GrabarProductoPrecio(PRODUCTO_PRECIO productoPrecio)
        {
            try
            {
               _productoPrecioDaOs.GrabarProductoPrecio(productoPrecio);

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
        public void ActualizarProductoPrecio(PRODUCTO_PRECIO productoPrecio)
        {
            try
            {
                _productoPrecioDaOs.ActualizarProductoPrecio(productoPrecio);
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

        public IQueryable<PRODUCTO_PRECIO> ObtenerProductoPrecioPorEstadoYProductoId(int productoId)
        {
            try
            {
                return _productoPrecioDaOs.ObtenerProductoPrecioPorEstadoYProductoId(productoId);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion


    }
}
