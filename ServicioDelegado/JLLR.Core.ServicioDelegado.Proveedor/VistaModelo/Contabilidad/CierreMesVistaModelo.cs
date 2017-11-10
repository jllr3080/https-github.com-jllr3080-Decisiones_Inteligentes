#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.ServicioDelegado.Proveedor.VistaModelo.General;
using JLLR.Core.ServicioDelegado.Proveedor.VistaModelo.Seguridad;

#endregion
namespace JLLR.Core.ServicioDelegado.Proveedor.VistaModelo.Contabilidad
{
    public class CierreMesVistaModelo
    {
        /// <summary>
        /// Cierre Mes Id
        /// </summary>
        
        public int CierreMesId { get; set; }

        /// <summary>
        /// Sucursal
        /// </summary>
        
        public SucursalVistaModelo Sucursal { get; set; }

        /// <summary>
        /// PuntoVenta
        /// </summary>
        
        public PuntoVentaVistaModelo PuntoVenta { get; set; }

        /// <summary>
        /// Usuario
        /// </summary>
        
        public UsuarioVistaModelo Usuario { get; set; }


       

        /// <summary>
        /// Mes
        /// </summary>
        
        public MesVistaModelo Mes { get; set; }

        /// <summary>
        /// FechaCreacion
        /// </summary>
        
        public DateTime? FechaCreacion { get; set; }

        /// <summary>
        /// Valor
        /// </summary>
        
        public decimal? Valor { get; set; }


        /// <summary>
        /// AplicacionPendiente
        /// </summary>
        
        public bool? AplicacionPendiente { get; set; }
    }
}
