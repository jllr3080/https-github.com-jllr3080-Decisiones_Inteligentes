#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.DAOs;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion
namespace JLLR.Core.Contabilidad.Proveedor.DAOs
{
    public class AplicacionPagoDAOs:BaseDAOs
    {

        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
         private readonly  Decisiones_Inteligentes _entidad= new Decisiones_Inteligentes();

        /// <summary>
        /// Graba  el cierre  de  mes 
        /// </summary>
        /// <param name="aplicacionPago"></param>
        /// <returns></returns>
        public APLICACION_PAGO GrabaAplicacionPago(APLICACION_PAGO aplicacionPago)
        {
            try
            {
                _entidad.APLICACION_PAGO.Add(aplicacionPago);
                _entidad.SaveChanges();
                return aplicacionPago;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Graba  el cierre  de  mes 
        /// </summary>
        /// <param name="aplicacionPago"></param>
        /// <returns></returns>
        public APLICACION_PAGO ActualizaAplicacionPago(APLICACION_PAGO aplicacionPago)
        {
            try
            {
                var original = _entidad.APLICACION_PAGO.Find(aplicacionPago.APLICACION_PAGO_ID);

                if (original != null)
                {
                    _entidad.Entry(original).CurrentValues.SetValues(aplicacionPago);
                    _entidad.SaveChanges();
                }
                return aplicacionPago;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        ///Obtiene  los pagos por cada  cierre  de  mes 
        /// </summary>
        /// <param name="cierreMesId"></param>
        /// <returns></returns>
        public IQueryable<APLICACION_PAGO> ObtenerAplicacionPagoPorCierreMesId(int cierreMesId)
        {
            try
            {
                var aplicacionesPago = from aplicacionPago in _entidad.APLICACION_PAGO
                    where aplicacionPago.CIERRE_MES_ID == cierreMesId
                    select aplicacionPago;

                return aplicacionesPago;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
