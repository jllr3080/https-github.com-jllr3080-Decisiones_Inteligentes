﻿#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion
namespace JLLR.Core.Venta.Proveedor.DTOs
{
    /// <summary>
    /// Consulta los datos mas  importantes de la orden y del detalle de la orden
    /// </summary>
   public  class ConsultaOrdenTrabajoDTOs
    {
        /// <summary>
        /// Nombre del cliente
        /// </summary>
        public string NombreCliente { get; set; }

        /// <summary>
        /// FechaIngreso
        /// </summary>
        public DateTime? FechaIngreso{ get; set; }

        /// <summary>
        /// FechaEntrega
        /// </summary>
        public DateTime? FechaEntrega { get; set; }

        /// <summary>
        /// NumeroOrden
        /// </summary>
        public string NumeroOrden{ get; set; }

        /// <summary>
        /// EstadoPago
        /// </summary>
        public string EstadoPago { get; set; }

        /// <summary>
        /// EstadoPago
        /// </summary>
        public string TipoLavado { get; set; }

        /// <summary>
        /// EstadoPago
        /// </summary>
        public decimal? Cantidad{ get; set; }

        /// <summary>
        /// Prenda
        /// </summary>
        public string Prenda { get; set; }

        /// <summary>
        /// Color
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Marca
        /// </summary>
        public string Marca { get; set; }

        /// <summary>
        /// ValorUnitario
        /// </summary>
        public decimal? ValorUnitario{ get; set; }

        /// <summary>
        /// ValorTotal
        /// </summary>
        public decimal? ValorTotal { get; set; }

        /// <summary>
        /// Observacion
        /// </summary>
        public string Observacion{ get; set; }

        /// <summary>
        /// EstadoPagoId
        /// </summary>
        public int? EstadoPagoId { get; set; }


        /// <summary>
        /// OrdenTrabajoId
        /// </summary>
        public Int64? OrdenTrabajoId { get; set; }


        /// <summary>
        /// DetalleOrdenTrabajoId
        /// </summary>
        public Int64? DetalleOrdenTrabajoId { get; set; }


        /// <summary>
        /// Direccion
        /// </summary>
        public string Direccion{ get; set; }

        /// <summary>
        /// Telefono
        /// </summary>
        public string Telefono{ get; set; }

        /// <summary>
        /// Telefono
        /// </summary>
        public string CorreoElectronico { get; set; }

        /// <summary>
        /// NombrePuntoVenta
        /// </summary>
        public string NombrePuntoVenta { get; set; }

        /// <summary>
        /// NombreUsuario
        /// </summary>
        public string NombreUsuario { get; set; }


        /// <summary>
        /// Estado de  la Prenda
        /// </summary>
        public string EstadoPrenda { get; set; }

        /// <summary>
        ///Tratamiento Especial
        /// </summary>
        public string TratamientoEspecial { get; set; }

        /// <summary>
        ///InformacionVisual
        /// </summary>
        public string InformacionVisual { get; set; }

        /// <summary>
        ///NumeroInternoPrenda
        /// </summary>
        public string NumeroInternoPrenda { get; set; }

        /// <summary>
        ///NumeroInternoPrenda
        /// </summary>
        public int DetallePrendaOrdenTrabajoId { get; set; }


        /// <summary>
        ///EstaAnulada
        /// </summary>
        public bool? EstaAnulada{ get; set; }




    }
}
