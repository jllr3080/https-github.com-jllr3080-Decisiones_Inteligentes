#region  using
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
    /// 
    /// </summary>

    public class DetalleVentaComisionIndustrialesDAOs:BaseDAOs
    {
        //Declaraciones e instancias
        private readonly  Decisiones_Inteligentes _entidad= new Decisiones_Inteligentes();

        /// <summary>
        /// Graba la orden de trabajo
        /// </summary>
        /// <param name="ordenTrabajo"></param>
        /// <returns></returns>
        public DETALLE_VENTA_COMISION_INDUSTRIALES GrabarDetalleVentaComisionIndustriales(DETALLE_VENTA_COMISION_INDUSTRIALES detalleVentaComisionIndustriales)
        {
            try
            {
                _entidad.DETALLE_VENTA_COMISION_INDUSTRIALES.Add(detalleVentaComisionIndustriales);
                _entidad.SaveChanges();
                return detalleVentaComisionIndustriales;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Actualiza las comisiones de industriales
        /// </summary>
        /// <param name="detalleVentaComisionIndustriales"></param>
        public void ActualizarDetalleVentaComisionIndustriales(DETALLE_VENTA_COMISION_INDUSTRIALES detalleVentaComisionIndustriales)
        {
            try
            {
                var original = _entidad.DETALLE_VENTA_COMISION_INDUSTRIALES.Find(detalleVentaComisionIndustriales.DETALLE_VENTA_COMISION_INDUSTRIALES_ID);

                if (original != null)
                {
                    _entidad.Entry(original).CurrentValues.SetValues(detalleVentaComisionIndustriales);
                    _entidad.SaveChanges();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
