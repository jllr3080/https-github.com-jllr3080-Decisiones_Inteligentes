#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.DAOs;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion
namespace JLLR.Core.General.Proveedor.DAOs
{
    /// <summary>
    /// Metodos de estado de pago
    /// </summary>
    public class EstadoPagoDAOs : BaseDAOs
    {
        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private readonly Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();


        /// <summary>
        /// Obtener  de estados de pago
        /// </summary>
        /// <returns></returns>
        public IQueryable<ESTADO_PAGO> ObtenerEstadosPago()
        {
            try
            {

                var estadosPago = from estadoPago in _entidad.ESTADO_PAGO
                                    select estadoPago;

                return estadosPago.OrderBy(m => m.DESCRIPCION);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
