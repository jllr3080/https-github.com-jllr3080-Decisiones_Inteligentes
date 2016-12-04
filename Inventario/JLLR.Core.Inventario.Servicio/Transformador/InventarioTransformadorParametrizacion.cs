#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JLLR.Core.Inventario.Proveedor.Negocio;
using JLLR.Core.Inventario.Servicio.Ensamblador;
using entidad = JLLR.Core.Base.Proveedor.Entidades;
using modeloParametrizacion = JLLR.Core.Inventario.Servicio.Modelo.Parametrizacion;
#endregion

namespace JLLR.Core.Inventario.Servicio.Transformador
{

    /// <summary>
    /// Metodos de las tablas de parametrizacion
    /// </summary>
    public class InventarioTransformadorParametrizacion
    {
        /// <summary>
        /// Declaraciones e  instancias
        /// </summary>
        private readonly InventarioParametrizacion _inventarioParametrizacion = new InventarioParametrizacion();
        private readonly EnsambladorEntidad _ensambladorEntidad= new EnsambladorEntidad();
        private readonly  EnsambladorModelo _ensambladorModelo = new EnsambladorModelo();
        
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
                return
                    _ensambladorModelo.CrearProductos(
                        _inventarioParametrizacion.ObtenerProductoPorTipoProductoId(tipoProductoId));

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
                    _ensambladorModelo.CrearProductosPrecio(
                        _inventarioParametrizacion.ObtenerProductoPrecioPorProductoIdYProductoTallaId(productoId,
                            productoTallaId));

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
                    _ensambladorModelo.CrearProductosTalla(
                        _inventarioParametrizacion.ObtenProductoTallaPorProductoId(productoId));

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}