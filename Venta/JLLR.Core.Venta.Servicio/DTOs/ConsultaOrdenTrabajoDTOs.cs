#region using

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
        public decimal? Cantidad { get; set; }

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

        /// <summary>
        /// EstadoPagoId
        /// </summary>
        [DataMember]
        public int? EstadoPagoId { get; set; }


        /// <summary>
        /// OrdenTrabajoId
        /// </summary>
        [DataMember]
        public Int64? OrdenTrabajoId { get; set; }


        /// <summary>
        /// DetalleOrdenTrabajoId
        /// </summary>
        [DataMember]
        public Int64? DetalleOrdenTrabajoId { get; set; }

        /// <summary>
        /// Direccion
        /// </summary>
        [DataMember]
        public string Direccion { get; set; }

        /// <summary>
        /// Telefono
        /// </summary>
        [DataMember]
        public string Telefono { get; set; }

        /// <summary>
        /// Telefono
        /// </summary>
        [DataMember]
        public string CorreoElectronico { get; set; }

        /// <summary>
        /// NombrePuntoVenta
        /// </summary>

        [DataMember]
        public string NombrePuntoVenta { get; set; }

        /// <summary>
        /// NombreUsuario
        /// </summary>
        [DataMember]
        public string NombreUsuario { get; set; }

        /// <summary>
        /// Estado de  la Prenda
        /// </summary>
        [DataMember]
        public string EstadoPrenda { get; set; }

        /// <summary>
        ///Tratamiento Especial
        /// </summary>
        [DataMember]
        public string TratamientoEspecial { get; set; }

        /// <summary>
        ///InformacionVisual
        /// </summary>
        [DataMember]
        public string InformacionVisual { get; set; }

        /// <summary>
        ///NumeroInternoPrenda
        /// </summary>
        [DataMember]
        public string NumeroInternoPrenda { get; set; }

        /// <summary>
        ///NumeroInternoPrenda
        /// </summary>
        [DataMember]
        public int DetallePrendaOrdenTrabajoId { get; set; }

        /// <summary>
        ///EstaAnulada
        /// </summary>
        [DataMember]
        public bool? EstaAnulada { get; set; }
    }
}