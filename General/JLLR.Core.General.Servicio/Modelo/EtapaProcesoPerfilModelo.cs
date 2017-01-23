#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
#endregion

namespace JLLR.Core.General.Servicio.Modelo
{
    /// <summary>
    /// Modelo de la etapa del proceso   perfil 
    /// </summary>
    [DataContract]
    public class EtapaProcesoPerfilModelo
    {

        /// <summary>
        /// Id
        /// </summary>
        [DataMember]
        public int EtapaProcesoPerfilId { get; set; }

        /// <summary>
        /// EtapaProceso
        /// </summary>
        [DataMember]
        public EtapaProcesoModelo EtapaProceso{ get; set; }


        /// <summary>
        /// PerfilId
        /// </summary>
        [DataMember]
        public int? PerfilId { get; set; }

       
    }
}