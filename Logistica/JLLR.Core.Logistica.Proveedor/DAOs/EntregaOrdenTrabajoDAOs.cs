#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion
namespace JLLR.Core.Logistica.Proveedor.DAOs
{

    /// <summary>
    /// Metodo para la entrega de  prendas  hacia la ruta
    /// </summary>
    public class EntregaOrdenTrabajoDAOs
    {

        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private readonly Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();



      /// <summary>
      /// Graba la entrega de las ordenes de  trabajo
      /// </summary>
      /// <param name="entregaOrdenTrabajo"></param>
        public ENTREGA_ORDEN_TRABAJO GrabaEntregaOrdenTrabajo(ENTREGA_ORDEN_TRABAJO entregaOrdenTrabajo)
        {
            try
            {
                _entidad.ENTREGA_ORDEN_TRABAJO.Add(entregaOrdenTrabajo);
                _entidad.SaveChanges();
                return entregaOrdenTrabajo;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Obtiene las  ordenes de trabajo para el flujo de proceso
        /// </summary>
        /// <param name="puntoVentaId"></param>
        /// <param name="sucursalId"></param>
        /// <param name="etapaProcesoPerfilId"></param>
        /// <returns></returns>

        public IQueryable<ENTREGA_ORDEN_TRABAJO> ObtenerEntregaOrdenTrabajosPorVariosParametros(int puntoVentaId, int sucursalId,int etapaProcesoPerfilId)
        {
            try
            {
                var entregaOrdenesTrabajo = from entregaOrdenTrabajo in _entidad.ENTREGA_ORDEN_TRABAJO
                    where
                        entregaOrdenTrabajo.PUNTO_VENTA_ID == puntoVentaId &&
                        entregaOrdenTrabajo.SUCURSAL_ID == sucursalId &&
                        entregaOrdenTrabajo.ETAPA_PROCESO_PERFIL_ID == etapaProcesoPerfilId
                    select entregaOrdenTrabajo;

                return entregaOrdenesTrabajo.OrderBy(m => m.ORDEN_TRABAJO_ID);

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        
        /// <summary>
        /// Actualiza  la orden de trabajo
        /// </summary>
        /// <param name="entregaOrdenTrabajo"></param>
        public void ActualizarEntregaOrdenTrabajo(ENTREGA_ORDEN_TRABAJO entregaOrdenTrabajo)
        {
            try
            {
                var original = _entidad.ENTREGA_ORDEN_TRABAJO.Find(entregaOrdenTrabajo.ENTREGA_ORDEN_TRABAJO_ID);

                if (original != null)
                {
                    _entidad.Entry(original).CurrentValues.SetValues(entregaOrdenTrabajo);
                    _entidad.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Obtiene  la orden de trabajo por  id
        /// </summary>
        /// <param name="entregaOrdenTrabajoId"></param>
        /// <returns></returns>
        public ENTREGA_ORDEN_TRABAJO ObtenerEntregaOrdenTrabajoPorId(int entregaOrdenTrabajoId)
        {
            try
            {
                var entregaOrdenesTrabajo = from entregaOrdenTrabajo in _entidad.ENTREGA_ORDEN_TRABAJO
                    where entregaOrdenTrabajo.ORDEN_TRABAJO_ID == entregaOrdenTrabajoId
                                            select  entregaOrdenTrabajo
                ;

                return entregaOrdenesTrabajo.FirstOrDefault();
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
    }
}
