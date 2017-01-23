#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion

namespace Web.Models.General
{
    public class EtapaProcesoPerfilVistaModelo
    {

        /// <summary>
        /// Id
        /// </summary>
        
        public int EtapaProcesoPerfilId { get; set; }

        /// <summary>
        /// EtapaProceso
        /// </summary>
        
        public EtapaProcesoVistaModelo EtapaProceso { get; set; }


        /// <summary>
        /// PerfilId
        /// </summary>
        
        public int? PerfilId { get; set; }
    }
}