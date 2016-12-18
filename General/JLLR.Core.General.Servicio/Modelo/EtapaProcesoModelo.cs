#region using

using System.Collections;
using System.Runtime.Serialization;

#endregion


namespace JLLR.Core.General.Servicio.Modelo
{
    /// <summary>
    /// Modelo de  Etapa de  Proceso
    /// </summary>
    public class EtapaProcesoModelo
    {
        /// <summary>
        /// Id 
        /// </summary>
        [DataMember]
        public int EtapaProcesoId { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        [DataMember]
        public string Descripcion { get; set; }

        /// <summary>
        /// EstaHabilitado
        /// </summary>
        [DataMember]
        public bool? EstaHabilitado { get; set; }

        /// <summary>
        /// HabilitaEnvioMail
        /// </summary>
        [DataMember]
        public bool? HabilitaEnvioMail { get; set; }
    }
}