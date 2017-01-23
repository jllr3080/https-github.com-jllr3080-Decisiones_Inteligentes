#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion
namespace JLLR.Core.General.Proveedor.DAOs
{
    /// <summary>
    /// Metodos de  los puntos de  venta
    /// </summary>
    public class PuntoVentaDAOs
    {

        /// <summary>
        /// Declaracion e instancias
        /// </summary>
        private readonly  Decisiones_Inteligentes _entidad= new Decisiones_Inteligentes();


        /// <summary>
        /// Obtiene los puntos de  venta por sucursal Id
        /// </summary>
        /// <param name="sucursalId"></param>
        /// <returns></returns>
        public IQueryable<PUNTO_VENTA> ObtenerPuntosVentaPorSucursalId(int sucursalId)
        {
            try
            {
                var puntosVenta = from puntoVenta in _entidad.PUNTO_VENTA
                    where puntoVenta.SUCURSAL_ID == sucursalId
                    select puntoVenta;

                return puntosVenta.OrderBy(m => m.DESCRIPCION);

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
    }
}
