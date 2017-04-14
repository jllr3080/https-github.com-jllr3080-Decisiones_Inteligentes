#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.Entidades;
using JLLR.Core.Venta.Proveedor.DAOs;

#endregion
namespace JLLR.Core.Venta.Proveedor.Negocio
{
    /// <summary>
    /// Parametrizacion de las  tablas de  venta
    /// </summary>
    public class VentaParametrizacion
    {

        #region DECLARACIONES  E INSTANCIAS
        private readonly  NumeroOrdenDAOs _numeroOrdenDaOs= new NumeroOrdenDAOs();
        private readonly  VentaComisionDAOs _ventaComisionDaOs= new VentaComisionDAOs();
        #endregion

        #region NUMERO ORDEN
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

                return _numeroOrdenDaOs.ObtenerNumeroOrdenPorVariosParametros(tipoLavadoId, sucursalId, puntoVentaId);

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
                _numeroOrdenDaOs.ActualizarNumeroOrden(numeracionOrden);


            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region VENTA COMISION

        /// <summary>
        /// Obtener Comision de las sucursal
        /// </summary>
        /// <param name="sucursalId"></param>
        /// <param name="puntoVentaId"></param>
        /// <param name="vieneRegla"></param>
        /// <param name="tipoLavadoId"></param>
        /// <returns></returns>
        public VENTA_COMISION ObtenerbVentaComisionPorVariosParametros(int sucursalId, int puntoVentaId, bool vieneRegla, int tipoLavadoId, int promocionAplicada)
        {
            try
            {
                return _ventaComisionDaOs.ObtenerbVentaComisionPorVariosParametros(sucursalId, puntoVentaId,vieneRegla,tipoLavadoId,promocionAplicada);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion


    }
}
