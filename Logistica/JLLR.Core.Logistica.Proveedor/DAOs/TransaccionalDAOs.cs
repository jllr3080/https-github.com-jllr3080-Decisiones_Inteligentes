#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.Entidades;
using  JLLR.Core.Logistica.Proveedor.DTOs;

#endregion
namespace JLLR.Core.Logistica.Proveedor.DAOs
{
    /// <summary>
    /// Metodos  generales 
    /// </summary>
    public class TransaccionalDAOs
    {
        #region DECLARACIONES  E INSTANACIAS
        private readonly EntregaOrdenTrabajoDAOs _entregaOrdenTrabajoDaOs= new EntregaOrdenTrabajoDAOs();
        private readonly  DetalleEntregaOrdenTrabajoDAOs _detalleEntregaOrdenTrabajoDaOs= new DetalleEntregaOrdenTrabajoDAOs();

        #endregion

        #region TRANSACCIONAL

        /// <summary>
        /// Graba la  entrega de la orden hacia  el tranbsporte 
        /// </summary>
        /// <param name="entregaOrdenTrabajoDtOs"></param>
        /// <returns></returns>
        public ENTREGA_ORDEN_TRABAJO GrabarEntregaOrdenTrabajoCompleta(EntregaOrdenTrabajoDTOs entregaOrdenTrabajoDtOs)
        {
            using (System.Transactions.TransactionScope transaction = new System.Transactions.TransactionScope())
            {
                try
                {
                    ENTREGA_ORDEN_TRABAJO entregaOrdenTrabajo= _entregaOrdenTrabajoDaOs.GrabaEntregaOrdenTrabajo(entregaOrdenTrabajoDtOs.EntregaOrdenTrabajo);



                    foreach (var detalleEntregaOrdenTrabajo in entregaOrdenTrabajoDtOs.DetalleEntregaOrdenTrabajo)
                    {
                        detalleEntregaOrdenTrabajo.ENTREGA_ORDEN_TRABAJO_ID = entregaOrdenTrabajo.ENTREGA_ORDEN_TRABAJO_ID;
                        _detalleEntregaOrdenTrabajoDaOs.GrabaDetalleEntregaOrdenTrabajo(detalleEntregaOrdenTrabajo);
                    }

                    transaction.Complete();

                    return entregaOrdenTrabajoDtOs.EntregaOrdenTrabajo;

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        #endregion
    }
}
