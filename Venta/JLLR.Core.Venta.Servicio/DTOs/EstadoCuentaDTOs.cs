﻿#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
#endregion

namespace JLLR.Core.Venta.Servicio.DTOs
{
    [DataContract]
    public class EstadoCuentaDTOs
    {

        /// <summary>
        /// Numero de Orden
        /// </summary>
        [DataMember]
        public string NumeroOrden { get; set; }

        /// <summary>
        /// Fecha de  Ingreso
        /// </summary>
        [DataMember]
        public DateTime? FechaIngreso { get; set; }

        /// <summary>
        /// Fecha de  Ingreso
        /// </summary>
        [DataMember]
        public decimal? ValorTotal { get; set; }


        /// <summary>
        /// ValorFranquicia
        /// </summary>
        [DataMember]
        public decimal? ValorFranquicia { get; set; }

        /// <summary>
        /// ValorQuimica
        /// </summary>
        [DataMember]
        public decimal? ValorQuimica { get; set; }

        /// <summary>
        /// ValorIndustriales
        /// </summary>
        [DataMember]
        public decimal? ValorIndustriales { get; set; }

        /// <summary>
        /// Fecha de  Ingreso
        /// </summary>
        [DataMember]
        public int? NumeroPrenda { get; set; }

        /// <summary>
        /// Detalle
        /// </summary>
        [DataMember]
        public string Detalle { get; set; }
    }
}