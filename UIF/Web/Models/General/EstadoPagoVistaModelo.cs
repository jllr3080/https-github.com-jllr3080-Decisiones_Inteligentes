#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion
namespace Web.Models.General
{
    /// <summary>
    /// Modelo del estado de pago
    /// </summary>
    public class EstadoPagoVistaModelo
    {

        /// <summary>
        /// Id del estado del pago
        /// </summary>
       
        public int EstadoPagoId { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
       
        public string Descripcion { get; set; }
    }
}