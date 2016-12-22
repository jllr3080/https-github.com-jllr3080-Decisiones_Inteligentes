#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.Entidades;
using JLLR.Core.Logistica.Proveedor.DAOs;
using JLLR.Core.Logistica.Proveedor.DTOs;

#endregion
namespace JLLR.Core.Logistica.Proveedor.Negocio
{
    /// <summary>
    /// Metodos de  toda la capa  de logistica
    /// </summary>
    public class LogisticaNegocio
    {
        #region DECLARACIONES  E INSTANCIAS
        private readonly  EntregaOrdenTrabajoDAOs _entregaOrdenTrabajoDaOs= new EntregaOrdenTrabajoDAOs();
        private readonly  TransaccionalDAOs _transaccionalDaOs= new TransaccionalDAOs();

        #endregion

        #region ENTREGA ORDEN DE  TRABAJO
        /// <summary>
        /// Graba la entrega de las ordenes de  trabajo
        /// </summary>
        /// <param name="entregaOrdenTrabajo"></param>
        public void GrabaEntregaOrdenTrabajo(ENTREGA_ORDEN_TRABAJO entregaOrdenTrabajo)
        {
            try
            {
                _entregaOrdenTrabajoDaOs.GrabaEntregaOrdenTrabajo(entregaOrdenTrabajo);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion

        #region TRANSACCIONAL
        /// <summary>
        /// Graba la  entrega de la orden hacia  el tranbsporte 
        /// </summary>
        /// <param name="entregaOrdenTrabajoDtOs"></param>
        /// <returns></returns>
        public ENTREGA_ORDEN_TRABAJO GrabarEntregaOrdenTrabajoCompleta(EntregaOrdenTrabajoDTOs entregaOrdenTrabajoDtOs)
        {
            try
            {
                return _transaccionalDaOs.GrabarEntregaOrdenTrabajoCompleta(entregaOrdenTrabajoDtOs);
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
        #endregion
    }
}
