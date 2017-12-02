#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion
namespace JLLR.Core.Contabilidad.Proveedor.DTOs
{
    /// <summary>
    /// Cuenta por cobrar
    /// </summary>
    
    public class CuentaPorCobrarDTOs
    {
        /// <summary>
        /// Cabecera de la cuentas por cobrar
        /// </summary>
        public CUENTA_POR_COBRAR CuentaPorCobrar { get; set; }

        /// <summary>
        /// HistorialCuentaPorCobrar
        /// </summary>
        public HISTORIAL_CUENTA_POR_COBRAR HistorialCuentaPorCobrar{ get; set; }


        /// <summary>
        /// Cliente
        /// </summary>
        public string Cliente { get; set; }

        /// <summary>
        /// Direccion
        /// </summary>
        public string Direccion { get; set; }

        /// <summary>
        /// NumeroTelefonos
        /// </summary>
        public string NumeroTelefonos { get; set; }



        /// <summary>
        /// IndividuoId
        /// </summary>
        public int?  IndividuoId{ get; set; }



    }
}
