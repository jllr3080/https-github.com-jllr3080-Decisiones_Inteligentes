#region  using
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

    /// <summary>
    /// Cierre mes 
    /// </summary>
   public  class CierreMesDAOs:BaseDAOs
    {
        /// <summary>
        /// Declaraciones  e instancias
        /// </summary>
         private  readonly  Decisiones_Inteligentes _entidad= new Decisiones_Inteligentes();


        /// <summary>
        /// Graba  el cierre  de  mes 
        /// </summary>
        /// <param name="cierreMes"></param>
        /// <returns></returns>
        public CIERRE_MES GrabarCierreMes(CIERRE_MES cierreMes)
        {
            try
            {
                _entidad.CIERRE_MES.Add(cierreMes);
                _entidad.SaveChanges();
                return cierreMes;
            }
            catch (Exception)
            {
                    
                throw;
            }
        }


        /// <summary>
        /// Cierre  de  mes 
        /// </summary>
        /// <param name="mesId"></param>
        /// <param name="puntoVentaId"></param>
        /// <returns></returns>
        public IQueryable<CIERRE_MES> ObtenerCierresMesPorAplicacionPendiente(int mesId, int puntoVentaId)
        {
            try
            {
                var cierreMeses = from cierreMes in _entidad.CIERRE_MES
                                  where cierreMes.PUNTO_VENTA_ID==puntoVentaId && cierreMes.MES_ID== mesId
                                  select cierreMes;

                return cierreMeses;
            }
            catch (Exception)
            {
                
                throw;
            }
        }



    }
}
