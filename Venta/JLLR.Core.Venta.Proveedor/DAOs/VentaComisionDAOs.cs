#region using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.DAOs;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion

namespace JLLR.Core.Venta.Proveedor.DAOs
{
    /// <summary>
    /// Venta de  comision 
    /// </summary>
    public class VentaComisionDAOs:BaseDAOs
    {

        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private readonly Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();

        /// <summary>
        /// Obtener Comision de las sucursal
        /// </summary>
        /// <param name="sucursalId"></param>
        /// <param name="puntoVentaId"></param>
        /// <param name="vendedorId"></param>
        /// <returns></returns>
        public VENTA_COMISION ObtenerbVentaComisionPorVariosParametros(int sucursalId, int puntoVentaId, int vendedorId)
        {
            try
            {
                var ventasComision = from ventaComision in _entidad.VENTA_COMISION
                    where
                    ventaComision.SUCURSAL_ID == sucursalId && ventaComision.PUNTO_VENTA_ID == puntoVentaId &&
                    ventaComision.VENDEDOR_ID == vendedorId && ventaComision.ESTA_HABILITADO == true
                    select ventaComision;

                return ventasComision.FirstOrDefault();
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
    }
}
