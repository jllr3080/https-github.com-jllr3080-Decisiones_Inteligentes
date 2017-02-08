#region  public
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
    /// Metodo de las  formas d e pago
    /// </summary>
    public class FormaPagoDAOs
    {
        /// <summary>
        /// Declaraciones  e instancias
        /// </summary>
        private readonly  Decisiones_Inteligentes _entidad = new  Decisiones_Inteligentes();


        /// <summary>
        /// Obtiene  todas las   formas  de  pago
        /// </summary>
        /// <returns></returns>
        public IQueryable<FORMA_PAGO> ObtenerFormaPagos()
        {

            try
            {
                var formaPagos = from formaPago in _entidad.FORMA_PAGO
                    select formaPago;

                return formaPagos.OrderBy(a => a.DESCRIPCION);
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

    }
}
