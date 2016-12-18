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

    }
}
