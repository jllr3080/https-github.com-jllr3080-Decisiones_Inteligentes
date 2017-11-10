#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using JLLR.Core.Contabilidad.Servicio.Modelo;

#endregion
namespace JLLR.Core.Contabilidad.Servicio.DTOs
{
    [DataContract]
    public class AplicacionPagoDTOs
    {
        /// <summary>
        ///AplicacionPago
        /// </summary>
        [DataMember]
        public AplicacionPagoModelo AplicacionPago { get; set; }

        /// <summary>
        ///PuntoVenta
        /// </summary>
        [DataMember]
        public string PuntoVenta { get; set; }


        /// <summary>
        ///Mes
        /// </summary>
        [DataMember]
        public string Mes { get; set; }

        /// <summary>
        ///FechaCierreMes
        /// </summary>
        [DataMember]
        public DateTime? FechaCierreMes { get; set; }

        /// <summary>
        ///ValorCierre
        /// </summary>
        [DataMember]
        public decimal? ValorCierre { get; set; }



        /// <summary>
        ///UsuarioAplicacion
        /// </summary>
        [DataMember]
        public string UsuarioAplicacion { get; set; }
    }
}