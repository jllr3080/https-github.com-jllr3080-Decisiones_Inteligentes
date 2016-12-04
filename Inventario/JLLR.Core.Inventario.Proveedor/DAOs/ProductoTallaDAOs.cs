#region using

using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion

namespace JLLR.Core.Inventario.Proveedor.DAOs
{

    /// <summary>
    /// Metodos de producto talla
    /// </summary>
    public class ProductoTallaDAOs
    {

        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private readonly Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();


        /// <summary>
        /// Obtiene las tallas  de los productos por el codigo del producto
        /// </summary>
        /// <param name="productoId"></param>
        /// <returns></returns>
        public IQueryable<PRODUCTO_TALLA> ObtenProductoTallaPorProductoId(int productoId)
        {
            try
            {
                var productoTallas = from productoTalla in _entidad.PRODUCTO_TALLA
                    where productoTalla.PRODUCTO_ID == productoId
                    select productoTalla;

                return productoTallas;

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
    }
}
