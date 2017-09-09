#region using
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
    public class DetalleHistorialReprocesoDAOs:BaseDAOs
    {
        /// <summary>
        /// Declaraciones  e instancias
        /// </summary>
        private readonly  Decisiones_Inteligentes _entidad= new Decisiones_Inteligentes();


        /// <summary>
        /// Grabar el detalle
        /// </summary>
        /// <param name="detalleHistorialReproceso"></param>
        public void GrabarDetalleHistorialReproceso(DETALLE_HISTORIAL_REPROCESO detalleHistorialReproceso)
        {
            try
            {
                _entidad.DETALLE_HISTORIAL_REPROCESO.Add(detalleHistorialReproceso);
                _entidad.SaveChanges();
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }


         
    }
}
