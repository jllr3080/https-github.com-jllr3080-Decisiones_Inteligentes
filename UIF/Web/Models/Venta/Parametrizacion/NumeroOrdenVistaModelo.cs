#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models.General;

#endregion
namespace Web.Models.Venta.Parametrizacion
{
    public class NumeroOrdenVistaModelo
    {
        /// <summary>
        /// Id 
        /// </summary>
        
        public int NumeroOrdenId { get; set; }

        /// <summary>
        /// TipoLavado 
        /// </summary>
        
        public TipoLavadoVistaModelo TipoLavado { get; set; }

        /// <summary>
        /// SucursalId 
        /// </summary>
        
        public int? SucursalId { get; set; }

        /// <summary>
        /// PuntoVentaId 
        /// </summary>
        
        public int? PuntoVentaId { get; set; }


        /// <summary>
        /// NumeroOden 
        /// </summary>
        
        public string NumeroOden { get; set; }

        /// <summary>
        /// NumeroOden 
        /// </summary>
        
        public int? Numero { get; set; }
    }
}