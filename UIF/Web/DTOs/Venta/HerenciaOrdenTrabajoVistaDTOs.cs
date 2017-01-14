
#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion
namespace Web.DTOs.Venta
{

    /// <summary>
    /// Herencia de la orden de  trabajo DTOs
    /// </summary>
    public class HerenciaOrdenTrabajoVistaDTOs:OrdenTrabajoVistaDTOs
    {
        /// <summary>
        /// Numero de Prendas
        /// </summary>

        public int NumeroPrenda{ get; set; }


    }
}