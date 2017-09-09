#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion
namespace JLLR.Core.ServicioDelegado.Proveedor.ModeloVista.General
{
    public class MesModeloVista
    {
        /// <summary>
        /// Mes ID
        /// </summary>
       
        public int MesId { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
       
        public string Descripcion { get; set; }

        /// <summary>
        /// EstaHabilitado
        /// </summary>
       
        public bool? EstaHabilitado { get; set; }

        /// <summary>
        /// FechaDesde
        /// </summary>
        
        public DateTime? FechaDesde { get; set; }

        /// <summary>
        /// FechaHasta
        /// </summary>
       
        public DateTime? FechaHasta { get; set; }
    }
}
