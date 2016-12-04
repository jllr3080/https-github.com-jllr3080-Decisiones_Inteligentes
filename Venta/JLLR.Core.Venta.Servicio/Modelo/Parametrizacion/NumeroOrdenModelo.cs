#region  using

using System;
using System.Runtime.Serialization;
using JLLR.Core.General.Servicio.Modelo;
using JLLR.Core.Individuo.Servicio.Modelo;
using JLLR.Core.Seguridad.Servicio.Modelo;

#endregion

namespace JLLR.Core.Venta.Servicio.Modelo.Parametrizacion
{
    /// <summary>
    /// Modelo de numero de  orden
    /// </summary>
    [DataContract]
    public class NumeroOrdenModelo
    {
        /// <summary>
        /// Id 
        /// </summary>
        [DataMember]
        public int NumeroOrdenId { get; set; }

        /// <summary>
        /// TipoLavado 
        /// </summary>
        [DataMember]
        public TipoLavadoModelo TipoLavado { get; set; }

        /// <summary>
        /// SucursalId 
        /// </summary>
        [DataMember]
        public int? SucursalId { get; set; }

        /// <summary>
        /// PuntoVentaId 
        /// </summary>
        [DataMember]
        public int? PuntoVentaId { get; set; }


        /// <summary>
        /// NumeroOden 
        /// </summary>
        [DataMember]
        public string NumeroOden { get; set; }

        /// <summary>
        /// NumeroOden 
        /// </summary>
        [DataMember]
        public int? Numero { get; set; }
    }
}