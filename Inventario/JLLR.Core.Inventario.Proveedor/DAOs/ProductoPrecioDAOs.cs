#region using

using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.DAOs;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion

namespace JLLR.Core.Inventario.Proveedor.DAOs
{
    /// <summary>
    /// Metodos  de producto    precio
    /// </summary>
    public class ProductoPrecioDAOs : BaseDAOs
    {
        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private readonly Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();

      /// <summary>
      /// Obtiene  los precios de las prendas  que tengan el ultimo precio habilitado
      /// </summary>
      /// <param name="productoId"></param>
      /// <returns></returns>

        public IQueryable<PRODUCTO_PRECIO> ObtenerProductoPrecioPorProductoId(int productoId)
        {
            try
            {
                var productosPrecio = from productoPrecio in _entidad.PRODUCTO_PRECIO
                    where
                    productoPrecio.PRODUCTO_ID == productoId && productoPrecio.ESTA_HABILITADO==true
                    select productoPrecio;

                return productosPrecio.OrderBy(m => m.PRECIO);

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
                _entidad.PRODUCTO_PRECIO.Add(productoPrecio);
                _entidad.SaveChanges();

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
                var original = _entidad.PRODUCTO_PRECIO.Find(productoPrecio.PRODUCTO_PRECIO_ID);

                if (original != null)
                {
                    _entidad.Entry(original).CurrentValues.SetValues(productoPrecio);
                    _entidad.SaveChanges();
                }
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
                var productosPrecio = from productoPrecio in _entidad.PRODUCTO_PRECIO
                                      where
                                      productoPrecio.PRODUCTO_ID == productoId 
                                      select productoPrecio;

                return productosPrecio.OrderBy(m => m.PRECIO);

            }
            catch (Exception ex)
            {

                throw;
            }
        }





    }
}
