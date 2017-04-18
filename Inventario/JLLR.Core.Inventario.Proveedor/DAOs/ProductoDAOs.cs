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
    /// Metodos de producto
    /// </summary>
    public class ProductoDAOs : BaseDAOs
    {
        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private readonly  Decisiones_Inteligentes _entidad= new Decisiones_Inteligentes();

        /// <summary>
        /// Obtener producto por  tipo de  producto servicio o produccion etc
        /// </summary>
        /// <param name="tipoProductoId"></param>
        /// <returns></returns>
        public IQueryable<PRODUCTO> ObtenerProductoPorTipoProductoId(int tipoProductoId)
        {
            try
            {
                var productos = from producto in _entidad.PRODUCTO
                    where producto.TIPO_PRODUCTO_ID == tipoProductoId
                    select producto;

                return productos.OrderBy(m=>m.NOMBRE);

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

    }
}
