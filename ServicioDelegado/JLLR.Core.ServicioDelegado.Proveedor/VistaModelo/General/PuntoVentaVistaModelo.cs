#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion
namespace JLLR.Core.ServicioDelegado.Proveedor.VistaModelo.General
{
   public class PuntoVentaVistaModelo
    {

        /// <summary>
        /// Id del punto venta 
        /// </summary>
        
        public int PuntoVentaId { get; set; }

        /// <summary>
        /// Descripcion del punto de  venta
        /// </summary>
        
        public string Descripcion { get; set; }

        /// <summary>
        /// Hora de Inicio
        /// </summary>
        
        public string HoraInicio { get; set; }

        /// <summary>
        /// Hora de Inicio
        /// </summary>
        
        public string HoraFin { get; set; }
    }
}
