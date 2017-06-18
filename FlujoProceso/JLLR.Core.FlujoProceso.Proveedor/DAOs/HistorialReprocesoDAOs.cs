#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion

namespace JLLR.Core.FlujoProceso.Proveedor.DAOs
{
    /// <summary>
    /// Metodos de  reporoceso
    /// </summary>
    public class HistorialReprocesoDAOs
    {

        /// <summary>
        /// Declaraciones  s instancias
        /// </summary>
        private readonly Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();

        /// <summary>
        /// Graba el  historial del reproceso de prendas   y los reclamos 
        /// </summary>
        /// <param name="historialReclamoReprocesoPrenda"></param>
        public void GrabarHistorialReproceso(HISTORIAL_REPROCESO historialReproceso)
        {
            try
            {
                _entidad.HISTORIAL_REPROCESO.Add(historialReproceso);
                _entidad.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;

            }
        }
    }
}
