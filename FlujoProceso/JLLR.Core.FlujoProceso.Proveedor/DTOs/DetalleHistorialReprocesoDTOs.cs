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
    public class DetalleHistorialReprocesoDTOs
    {

        ///// <summary>
        ///// Historial  reproceso
        ///// </summary>
        //public HISTORIAL_REPROCESO HistorialReproceso { get; set; }

        ///// <summary>
        ///// DetalleHistorialReproceso
        ///// </summary>
        //public DETALLE_HISTORIAL_REPROCESO DetalleHistorialReproceso { get; set; }

        ///// <summary>
        ///// TipoReproceso
        ///// </summary>
        //public TIPO_REPROCESO TipoReproceso { get; set; }


        /// <summary>
        /// TipoMotivoProceso
        /// </summary>
        public string TipoMotivoProceso { get; set; }

        /// <summary>
        /// Motivo
        /// </summary>
        public string Motivo { get; set; }

    }
}
