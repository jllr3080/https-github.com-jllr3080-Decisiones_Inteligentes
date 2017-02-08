#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models.General;
#endregion

namespace Web.Models.Individuo
{
    public class ProveedorVistaModelo
    {
        /// <summary>
        /// Id del cliente
        /// </summary>
        public int ProveedorId { get; set; }

        /// <summary>
        /// FormaPago
        /// </summary>
        
        public FormaPagoVistaModelo FormaPago { get; set; }

        /// <summary>
        /// Individuo
        /// </summary>
        
        public IndividuoVistaModelo Individuo { get; set; }

        /// <summary>
        /// DiasCredito
        /// </summary>
        
        public int? DiasCredito { get; set; }
    }
}