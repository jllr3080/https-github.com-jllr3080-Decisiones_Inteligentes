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
    public class VentaComisionIndustrialesDAOs:BaseDAOs
    {

        //Declaraciones e instancias
        private readonly Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();

        /// <summary>
        /// Graba la orden de trabajo
        /// </summary>
        /// <param name="ordenTrabajo"></param>
        /// <returns></returns>
        public VENTA_COMISION_INDUSTRIALES GrabarVentaComisionIndustriales(VENTA_COMISION_INDUSTRIALES ventaComisionIndustriales)
        {
            try
            {
                _entidad.VENTA_COMISION_INDUSTRIALES.Add(ventaComisionIndustriales);
                _entidad.SaveChanges();
                return ventaComisionIndustriales;
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
        public void ActualizarVentaComisionIndustriales(VENTA_COMISION_INDUSTRIALES ventaComisionIndustriales)
        {
            try
            {
                var original = _entidad.VENTA_COMISION_INDUSTRIALES.Find(ventaComisionIndustriales.VENTA_COMISION_INDUSTRIALES_ID);

                if (original != null)
                {
                    _entidad.Entry(original).CurrentValues.SetValues(ventaComisionIndustriales);
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
