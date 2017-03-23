#region  using
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using JLLR.Core.ReglaNegocio.Servicio.Modelo;

#endregion

namespace JLLR.Core.Venta.Servicio.Modelo
{
    /// <summary>
    /// modelo  del historial de reglas
    /// </summary>
    [DataContract]
    public class HistorialReglaModelo
    {

        /// <summary>
        /// Historial de la  regla id
        /// </summary>
        [DataMember]
        public Int64 HistorialReglaId { get; set; }

        /// <summary>
        /// OrdenTrabajo    
        /// </summary>
        [DataMember]
        public OrdenTrabajoModelo OrdenTrabajo{ get; set; }

        /// <summary>
        /// AccionRegla    
        /// </summary>
        [DataMember]
        public AccionReglaModelo AccionRegla { get; set; }


        /// <summary>
        /// FechaEjecucion    
        /// </summary>
        [DataMember]
        public DateTime? FechaEjecucion{ get; set; }

        /// <summary>
        /// UsuarioId    
        /// </summary>
        [DataMember]
        public int? UsuarioId { get; set; }
    }
}