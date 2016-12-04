﻿#region using

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using JLLR.Core.Venta.Servicio.Modelo;

#endregion
namespace JLLR.Core.Venta.Servicio.DTOs
{

    /// <summary>
    /// Consulta los datos mas  importantes de la orden y del detalle de la orden
    /// </summary>
    [DataContract]
    public class ConsultaOrdenTrabajoDTOs
    {
        /// <summary>
        /// Nombre del cliente
        /// </summary>
        [DataMember]
        public string NombreCliente { get; set; }

        /// <summary>
        /// FechaIngreso
        /// </summary>
        [DataMember]
        public DateTime? FechaIngreso { get; set; }

        /// <summary>
        /// FechaEntrega
        /// </summary>
        [DataMember]
        public DateTime? FechaEntrega { get; set; }

        /// <summary>
        /// NumeroOrden
        /// </summary>
        [DataMember]
        public string NumeroOrden { get; set; }

        /// <summary>
        /// EstadoPago
        /// </summary>
        [DataMember]
        public string EstadoPago { get; set; }

        /// <summary>
        /// EstadoPago
        /// </summary>
        [DataMember]
        public string TipoLavado { get; set; }

        /// <summary>
        /// EstadoPago
        /// </summary>
        [DataMember]
        public int? Cantidad { get; set; }

        /// <summary>
        /// Prenda
        /// </summary>
        [DataMember]
        public string Prenda { get; set; }

        /// <summary>
        /// Color
        /// </summary>
        [DataMember]
        public string Color { get; set; }

        /// <summary>
        /// Marca
        /// </summary>
        [DataMember]
        public string Marca { get; set; }

        /// <summary>
        /// ValorUnitario
        /// </summary>
        [DataMember]
        public decimal? ValorUnitario { get; set; }

        /// <summary>
        /// ValorTotal
        /// </summary>
        [DataMember]
        public decimal? ValorTotal { get; set; }

        /// <summary>
        /// Observacion
        /// </summary>
        [DataMember]
        public string Observacion { get; set; }
    }
}