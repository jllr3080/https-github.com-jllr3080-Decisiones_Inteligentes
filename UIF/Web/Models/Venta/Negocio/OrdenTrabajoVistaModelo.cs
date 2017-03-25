#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models.General;
using Web.Models.Individuo;
using Web.Models.Seguridad.Negocio;

#endregion

namespace Web.Models.Venta.Negocio
{
    public class OrdenTrabajoVistaModelo
    {

        /// <summary>
        /// Id de la orden de trabajo
        /// </summary>
        
        public Int64 OrdenTrabajoId { get; set; }

        /// <summary>
        /// Cliente
        /// </summary>
        
        public ClienteVistaModelo ClienteModelo { get; set; }

        /// <summary>
        /// TipoLavado
        /// </summary>
        
        public TipoLavadoVistaModelo TipoLavado { get; set; }

        /// <summary>
        /// PuntoVenta
        /// </summary>
        
        public PuntoVentaVistaModelo PuntoVenta { get; set; }

        /// <summary>
        /// FechaIngreso
        /// </summary>
        
        public DateTime? FechaIngreso { get; set; }

        /// <summary>
        /// Fecha de  Entrega
        /// </summary>
        
        public DateTime? FechaEntrega { get; set; }

        /// <summary>
        /// Usuario
        /// </summary>
        
        public UsuarioVistaModelo Usuario { get; set; }

        /// <summary>
        /// Numero de impresion
        /// </summary>
        
        public int? NumeroImpresion { get; set; }

        /// <summary>
        /// Sucursal
        /// </summary>
        
        public SucursalVistaModelo Sucursal { get; set; }

        /// <summary>
        /// EstadoPago
        /// </summary>
        
        public EstadoPagoVistaModelo EstadoPago { get; set; }

        /// <summary>
        /// NumeroOrden
        /// </summary>
        
        public string NumeroOrden { get; set; }


        /// <summary>
        /// envio a matriz la orden
        /// </summary>
        
        public bool? EnvioMatriz { get; set; }

        /// <summary>
        /// Se envio la orden 
        /// </summary>
        
        public bool? SeEnvio { get; set; }

        /// <summary>
        /// NumeroOrdenManual
        /// </summary>
        public string NumeroOrdenManual { get; set; }
    }
}