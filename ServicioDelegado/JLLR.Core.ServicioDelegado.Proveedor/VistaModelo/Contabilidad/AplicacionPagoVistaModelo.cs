#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion
namespace JLLR.Core.ServicioDelegado.Proveedor.VistaModelo.Contabilidad
{
   public  class AplicacionPagoVistaModelo
    {
        /// <summary>
        /// AprobacionPagoId
        /// </summary>
        
        public int AplicacionPagoId { get; set; }

        /// <summary>
        /// CierreMes
        /// </summary>
        
        public CierreMesVistaModelo CierreMes { get; set; }

        /// <summary>
        /// Valor
        /// </summary>
        
        public decimal? Valor { get; set; }

        /// <summary>
        /// FechaCreacion
        /// </summary>
        
        public DateTime? FechaCreacion { get; set; }


        /// <summary>
        /// EstaValidado
        /// </summary>
        
        public bool? EstaValidado { get; set; }

        /// <summary>
        /// NumeroDocumento
        /// </summary>
        
        public string NumeroDocumento { get; set; }

        /// <summary>
        /// NumeroDocumento
        /// </summary>
        
        public DateTime? FechaDeposito { get; set; }

        /// <summary>
        /// FechaValidacion
        /// </summary>
        
        public DateTime? FechaValidacion { get; set; }

        /// <summary>
        /// FechaValidacion
        /// </summary>
        
        public byte[] Documento { get; set; }


        /// <summary>
        /// UsuarioAplicaId
        /// </summary>
        
        public int? UsuarioAplicaId { get; set; }

        /// <summary>
        /// UsuarioValidaId
        /// </summary>
        
        public int? UsuarioValidaId { get; set; }
    }
}
