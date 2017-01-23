#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.DAOs;
using JLLR.Core.Base.Proveedor.Entidades;
using JLLR.Core.Venta.Proveedor.DTOs;

#endregion
namespace JLLR.Core.Venta.Proveedor.DAOs
{
    /// <summary>
    /// Metodos de  las ordenes de  trabajo 
    /// </summary>
    public class OrdenTrabajoDAOs:BaseDAOs
    {
        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private readonly  Decisiones_Inteligentes _entidad= new Decisiones_Inteligentes();


        /// <summary>
        /// Graba la orden de trabajo
        /// </summary>
        /// <param name="ordenTrabajo"></param>
        /// <returns></returns>
        public ORDEN_TRABAJO GrabarOrdenTrabajo(ORDEN_TRABAJO ordenTrabajo)
        {
            try
            {
                _entidad.ORDEN_TRABAJO.Add(ordenTrabajo);
                _entidad.SaveChanges();
                return ordenTrabajo;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Actualiza la orden de trabajo
        /// </summary>
        /// <param name=""></param>
        public void ActualizarOrdenTrabajo(ORDEN_TRABAJO ordenTrabajo )
        {
            try
            {
                var original = _entidad.ORDEN_TRABAJO.Find(ordenTrabajo.ORDEN_TRABAJO_ID);

                if (original != null)
                {
                    _entidad.Entry(original).CurrentValues.SetValues(ordenTrabajo);
                    _entidad.SaveChanges();
                }

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Obtiene  por  id de la orden de trabajo
        /// </summary>
        /// <param name="ordenTrabajoId"></param>
        /// <returns></returns>
        public OrdenTrabajoDTOs ObtenerOrdenTrabajoPorOrdenTrabajoId(int ordenTrabajoId)
        {
            try
            {
                var ordenesTrabajo = from ordenTrabajo in _entidad.ORDEN_TRABAJO
                                     where ordenTrabajo.ORDEN_TRABAJO_ID==ordenTrabajoId
                                     select new OrdenTrabajoDTOs()
                                     {
                                         OrdenTrabajo = ordenTrabajo,
                                         DetalleOrdenTrabajos = (List<DETALLE_ORDEN_TRABAJO>)(ordenTrabajo.DETALLE_ORDEN_TRABAJO)
                                     };

                List<OrdenTrabajoDTOs> _ordenTrabajoDtOses = new List<OrdenTrabajoDTOs>();
                foreach (var objetoOrdenTrabajoDTOs in ordenesTrabajo)
                {
                    _ordenTrabajoDtOses.Add(objetoOrdenTrabajoDTOs);
                }

                return _ordenTrabajoDtOses.FirstOrDefault();
                
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }



    }
}
