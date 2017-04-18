#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.DAOs;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion

namespace JLLR.Core.Venta.Proveedor.DAOs
{
    /// <summary>
    /// Graba el historial de promociones que se aplicaron 
    /// </summary>
    public class HistorialReglaDAOs : BaseDAOs
    {
        /// <summary>
        /// Declaraciones  e instancias
        /// </summary>
        private  readonly  Decisiones_Inteligentes _entidad= new Decisiones_Inteligentes();


        /// <summary>
        /// Graba el  historial de las  reglas
        /// </summary>
        /// <param name="historialRegla"></param>
        public void GrabarHistorialRegla(HISTORIAL_REGLA historialRegla)
        {
            try
            {
                _entidad.HISTORIAL_REGLA.Add(historialRegla);
                _entidad.SaveChanges();

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        

    }
}
