#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion

namespace JLLR.Core.Venta.Servicio.Enums
{
    public class Enum
    {
        public enum FormaPago
        {
            Efectivo=1
        }

        public enum Proveedor
        {
            Quimica=1
        }
        public enum EtapaProceso
        {
            EntregaClienteHaciaFranquicia = 1,
            EntregaFranquiciaHaciaTransporte = 2,
            EntregaTranporteHaciaMatriz = 3,
            ProcesoProduccionEtapa1 = 4,
            ProcesoProduccionEtapa2 = 5,
            EntregaMatrizHaciaTransporte = 6,
            EntregaTransporteHaciaFranquicia = 7,
            EntregaFranquiciaHaciaCliente = 8,
            AnulacionOrdenTrabajo = 9
        }
    }
}