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
    /// Metodos de los numero de  orden
    /// </summary>
    public class NumeroOrdenDAOs:BaseDAOs
    {

        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private readonly Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();


        /// <summary>
        /// Obtiene el numero de orden por varios parametros
        /// </summary>
        /// <param name="tipoLavadoId"></param>
        /// <param name="sucursalId"></param>
        /// <param name="puntoVentaId"></param>
        /// <returns></returns>
        public NUMERACION_ORDEN ObtenerNumeroOrdenPorVariosParametros(int tipoLavadoId, int sucursalId, int puntoVentaId)
        {
            try
            {
                var numeroOrdenes = from numeroOrden in _entidad.NUMERACION_ORDEN
                    where
                    numeroOrden.TIPO_LAVADO_ID == tipoLavadoId && numeroOrden.SUCURSAL_ID == sucursalId &&
                    numeroOrden.PUNTO_VENTA_ID == puntoVentaId
                    select numeroOrden;

                return numeroOrdenes.FirstOrDefault();

            }
            catch (Exception ex)
            {

                throw;
            }
        }


        /// <summary>
        /// Actualiza  la entidad de  numero de  orden
        /// </summary>
        /// <param name="numeracionOrden"></param>

        public void ActualizarNumeroOrden(NUMERACION_ORDEN numeracionOrden)
        {
            try
            {
                var original = _entidad.NUMERACION_ORDEN.Find(numeracionOrden.NUMERACION_ORDEN_ID);

                if (original != null)
                {
                    _entidad.Entry(original).CurrentValues.SetValues(numeracionOrden);
                    _entidad.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }



    }
}
