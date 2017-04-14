#region  using

using System;
using System.Runtime.Serialization;
using JLLR.Core.General.Servicio.Modelo;
using JLLR.Core.Individuo.Servicio.Modelo;
using JLLR.Core.Seguridad.Servicio.Modelo;

#endregion
namespace JLLR.Core.Venta.Servicio.Modelo
{
    /// <summary>
    /// Modelo de la orden de trabajo
    /// </summary>
    [DataContract]
    public class OrdenTrabajoModelo
    {
        /// <summary>
        /// Id de la orden de trabajo
        /// </summary>
        [DataMember]
        public Int64 OrdenTrabajoId { get; set; }

        /// <summary>
        /// Cliente
        /// </summary>
        [DataMember]
        public ClienteModelo ClienteModelo { get; set; }

        /// <summary>
        /// TipoLavado
        /// </summary>
        [DataMember]
        public TipoLavadoModelo TipoLavado { get; set; }

        /// <summary>
        /// PuntoVenta
        /// </summary>
        [DataMember]
        public PuntoVentaModelo PuntoVenta{ get; set; }

        /// <summary>
        /// FechaIngreso
        /// </summary>
        [DataMember]
        public DateTime? FechaIngreso { get; set; }

        /// <summary>
        /// Fecha de  Entrega
        /// </summary>
        [DataMember]
        public DateTime? FechaEntrega { get; set; }

        /// <summary>
        /// Usuario
        /// </summary>
        [DataMember]
        public UsuarioModelo Usuario{ get; set; }
        
        /// <summary>
        /// Numero de impresion
        /// </summary>
        [DataMember]
        public int? NumeroImpresion{ get; set; }

        /// <summary>
        /// Sucursal
        /// </summary>
        [DataMember]
        public SucursalModelo Sucursal{ get; set; }

        /// <summary>
        /// EstadoPago
        /// </summary>
        [DataMember]
        public EstadoPagoModelo EstadoPago { get; set; }

        /// <summary>
        /// NumeroOrden
        /// </summary>
        [DataMember]
        public string NumeroOrden { get; set; }

        /// <summary>
        /// envio a matriz la orden
        /// </summary>
        [DataMember]
        public bool? EnvioMatriz{ get; set; }

        /// <summary>
        /// Se envio la orden 
        /// </summary>
        [DataMember]
        public bool? SeEnvio { get; set; }

        /// <summary>
        /// NumeroOrdenManual
        /// </summary>
        [DataMember]
        public string NumeroOrdenManual { get; set; }

        

    }
}