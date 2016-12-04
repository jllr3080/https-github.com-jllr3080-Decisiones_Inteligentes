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
        private  readonly  ProductoTallaDAOs _productoTallaDaOs=new ProductoTallaDAOs();
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
        #endregion

        #region PRODUCTO PRECIO

        /// <summary>
        /// Obtiene el precio de los productos por la talla y el codigo del producto
        /// </summary>
        /// <param name="productoId"></param>
        /// <param name="productoTallaId"></param>
        /// <returns></returns>

        public IQueryable<PRODUCTO_PRECIO> ObtenerProductoPrecioPorProductoIdYProductoTallaId(int productoId,
            int productoTallaId)
        {
            try
            {
                return _productoPrecioDaOs.ObtenerProductoPrecioPorProductoIdYProductoTallaId(productoId,
                    productoTallaId);

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
        public IQueryable<PRODUCTO_TALLA> ObtenProductoTallaPorProductoId(int productoId)
        {
            try
            {
                return _productoTallaDaOs.ObtenProductoTallaPorProductoId(productoId);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}
