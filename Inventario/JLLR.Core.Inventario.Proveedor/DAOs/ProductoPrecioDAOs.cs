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
                var productosPrecio = from productoPrecio in _entidad.PRODUCTO_PRECIO
                    where
                    productoPrecio.PRODUCTO_ID == productoId && productoPrecio.PRODUCTO_TALLA_ID == productoTallaId
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
