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
        /// Obtiene el producto  
        /// </summary>
        /// <param name="productoId"></param>
        /// <returns></returns>
        public modeloParametrizacion.ProductoModelo ObtenerProductoPorId(int productoId)
        {
            try
            {
                return _ensambladorModelo.CrearProducto(_inventarioParametrizacion.ObtenerProductoPorId(productoId));
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
                return
                    _ensambladorModelo.CrearProductos(
                        _inventarioParametrizacion.ObtenerProductoPorTipoProductoId(tipoProductoId));

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
             _inventarioParametrizacion.GrabarProducto(_ensambladorEntidad.CrearProducto(producto));

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
                _inventarioParametrizacion.ActualizarProducto(_ensambladorEntidad.CrearProducto(producto));
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
                    _ensambladorModelo.CrearProductosPrecio(_inventarioParametrizacion.ObtenerProductoPrecioPorProductoId(productoId));

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
             _inventarioParametrizacion.GrabarProductoPrecio(_ensambladorEntidad.CrearProductoPrecio(productoPrecio));

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
                _inventarioParametrizacion.ActualizarProductoPrecio(_ensambladorEntidad.CrearProductoPrecio(productoPrecio));
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
              return  _ensambladorModelo.CrearProductosPrecio(
                    _inventarioParametrizacion.ObtenerProductoPrecioPorEstadoYProductoId(productoId));

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion


    }
}