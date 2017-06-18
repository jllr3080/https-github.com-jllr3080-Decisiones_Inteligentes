#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion
namespace JLLR.Core.FlujoProceso.Proveedor.DTOs
{
    
    public  class HistorialReprocesoDTOs
    {
        /// <summary>
        /// HistorialProceso
        /// </summary>
        
        public HISTORIAL_PROCESO HistorialProceso { get; set; }


        /// <summary>
        /// Graba los  reprocesos
        /// </summary>
        
        public List<HISTORIAL_REPROCESO> HistorialReprocesos { get; set; }

    }
}
