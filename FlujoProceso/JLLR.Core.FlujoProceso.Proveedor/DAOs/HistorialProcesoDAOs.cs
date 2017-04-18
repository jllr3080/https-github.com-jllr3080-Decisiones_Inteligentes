#region  using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.DAOs;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion

namespace JLLR.Core.FlujoProceso.Proveedor.DAOs
{
    /// <summary>
    /// Metodos  de  historial de  proceso
    /// </summary>
    public class HistorialProcesoDAOs:BaseDAOs
    {

        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private readonly Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();

        /// <summary>
        /// Graba el  historial del proceso
        /// </summary>
        public void GrabarHistorialProceso(HISTORIAL_PROCESO historialProceso)
        {
            try
            {
                _entidad.HISTORIAL_PROCESO.Add(historialProceso);
                _entidad.SaveChanges();


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
        public IQueryable<HISTORIAL_PROCESO> ObtenerHIstorialProcesosPorNumeroOrden(string numeroOrden)
        {
            try
            {
                var historialProcesos = from historialProceso in _entidad.HISTORIAL_PROCESO
                    where historialProceso.NUMERO_ORDEN == numeroOrden
                    select historialProceso;
                return historialProcesos;

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
        public IQueryable<HISTORIAL_PROCESO> ObtenerHistorialProcesoPorFlujoProceso(int etapaProcesoId, int sucursalId,
            int puntoVentaId)
        {
            try
            {
                var historialProcesos = from historialProceso in _entidad.HISTORIAL_PROCESO
                    where
                        historialProceso.ETAPA_PROCESO_ID == etapaProcesoId &&
                        historialProceso.SUCURSAL_ID == sucursalId && historialProceso.PUNTO_VENTA_ID == puntoVentaId &&
                        historialProceso.PASO_ESTA_ETAPA == false
                                        select  historialProceso
                ;

                return historialProcesos;


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
        public void ActualizarHistorialProceso(HISTORIAL_PROCESO  historialProceso)
        {
            try
            {
                var original = _entidad.HISTORIAL_PROCESO.Find(historialProceso.HISTORIAL_PROCESO_ID);

                if (original != null)
                {
                    _entidad.Entry(original).CurrentValues.SetValues(historialProceso);
                    _entidad.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Devuelve  todos  los  historiales de  proceso  del clciente, anulados  y  entregados
        /// </summary>
        /// <returns></returns>
        public IQueryable<HISTORIAL_PROCESO> ObtenerHistorialProceso()
        {
            try
            {
                var historialProcesos = from historialProceso in _entidad.HISTORIAL_PROCESO
                    where
                        historialProceso.SE_ENVIO != true &&
                        (historialProceso.ETAPA_PROCESO_ID == 1 ||
                         historialProceso.ETAPA_PROCESO_ID == 8 || historialProceso.ETAPA_PROCESO_ID == 9 || historialProceso.ETAPA_PROCESO_ID == 7)
                    select historialProceso;

                return historialProcesos;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }


    }
}
