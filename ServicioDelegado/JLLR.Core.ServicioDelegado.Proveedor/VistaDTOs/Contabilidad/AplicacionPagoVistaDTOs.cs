#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.ServicioDelegado.Proveedor.VistaModelo.Contabilidad;

#endregion
namespace JLLR.Core.ServicioDelegado.Proveedor.VistaDTOs.Contabilidad
{
    public class AplicacionPagoVistaDTOs
    {
        /// <summary>
        ///AplicacionPago
        /// </summary>
        public AplicacionPagoVistaModelo AplicacionPago { get; set; }

        /// <summary>
        ///PuntoVenta
        /// </summary>
        public string PuntoVenta { get; set; }


        /// <summary>
        ///Mes
        /// </summary>
        public string Mes { get; set; }

        /// <summary>
        ///FechaCierreMes
        /// </summary>
        public DateTime? FechaCierreMes { get; set; }

        /// <summary>
        ///ValorCierre
        /// </summary>
        public decimal? ValorCierre { get; set; }



        /// <summary>
        ///UsuarioAplicacion
        /// </summary>
        public string UsuarioAplicacion { get; set; }
    }
}
