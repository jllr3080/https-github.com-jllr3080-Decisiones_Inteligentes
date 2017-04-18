#region using
using System;
using System.Collections.Generic;
using JLLR.Core.FlujoProceso.Servicio.Modelo;
using JLLR.Core.FlujoProceso.Servicio.Transformador;
using JLLR.Core.FlujoProceso.Servicio.DTOs;
#endregion
namespace JLLR.Core.FlujoProceso.Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioFlujoProceso : IServicioFlujoProceso
    {
        #region DECLARACIONES  E INSTANCIAS
        private readonly FlujoProcesoTransformadorNegocio _flujoProcesoTransformadorNegocio= new FlujoProcesoTransformadorNegocio();
        #endregion

        #region HISTORIAL PROCESO
        /// <summary>
        /// Devuelve  todos  los  historiales de  proceso  del clciente, anulados  y  entregados
        /// </summary>
        /// <returns></returns>
        public List<HistorialProcesoModelo> ObtenerHistorialProceso()
        {
            try
            {

                return _flujoProcesoTransformadorNegocio.ObtenerHistorialProceso();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// Graba el  historial del proceso
        /// </summary>
        public void GrabarHistorialProceso(HistorialProcesoModelo historialProceso)
        {
            try
            {
                _flujoProcesoTransformadorNegocio.GrabarHistorialProceso(historialProceso);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtener el historial del proceso por numero  de orden
        /// </summary>
        /// <param name="numeroOrden"></param>
        /// <returns></returns>
        public List<HistorialProcesoModelo> ObtenerHIstorialProcesosPorNumeroOrden(string numeroOrden)
        {
            try
            {
                return _flujoProcesoTransformadorNegocio.ObtenerHIstorialProcesosPorNumeroOrden(numeroOrden);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// Obtiene todas las prendas  para  la logistica
        /// </summary>
        /// <param name="etapaProcesoId"></param>
        /// <param name="sucursalId"></param>
        /// <param name="puntoVentaId"></param>
        /// <returns></returns>
        public List<HistorialProcesoModelo> ObtenerHistorialProcesoPorFlujoProceso(int etapaProcesoId, int sucursalId,
            int puntoVentaId)
        {
            try
            {

                return _flujoProcesoTransformadorNegocio.ObtenerHistorialProcesoPorFlujoProceso(etapaProcesoId,
                    sucursalId, puntoVentaId);


            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Actualiza  el historial de proceso
        /// </summary>
        /// <param name="historialProceso"></param>
        public void ActualizarHistorialProceso(HistorialProcesoModelo historialProceso)
        {
            try
            {
                _flujoProcesoTransformadorNegocio.ActualizarHistorialProceso(historialProceso);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region TRANSACCIONAL

        #region REPORTES

        /// <summary>
        /// Obtiene el historial de prendas 
        /// </summary>
        /// <param name="sucursalId"></param>
        /// <param name="puntoVentaId"></param>
        /// <param name="fechaRegistro"></param>
        /// <param name="etapaProcesoId"></param>
        /// <returns></returns>
        public List<HistorialProcesoDTOs> ObtenerHistorialProcesoPrendasPorVariosParametros(int sucursalId,
            int puntoVentaId, string fechaRegistro, int etapaProcesoId)
        {
            try
            {

                return _flujoProcesoTransformadorNegocio.ObtenerHistorialProcesoPrendasPorVariosParametros(sucursalId,
                    puntoVentaId,Convert.ToDateTime(fechaRegistro), etapaProcesoId);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion

        #endregion
    }
}
