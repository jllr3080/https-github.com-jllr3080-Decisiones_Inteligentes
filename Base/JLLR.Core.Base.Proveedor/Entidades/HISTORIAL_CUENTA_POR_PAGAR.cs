//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JLLR.Core.Base.Proveedor.Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class HISTORIAL_CUENTA_POR_PAGAR
    {
        public long HISTORIAL_CUENTA_POR_PAGAR_ID { get; set; }
        public Nullable<long> CUENTA_POR_PAGAR_ID { get; set; }
        public Nullable<System.DateTime> FECHA_PAGO { get; set; }
        public Nullable<decimal> VALOR_PAGO { get; set; }
        public Nullable<int> USUARIO_ID { get; set; }
    
        public virtual CUENTA_POR_PAGAR CUENTA_POR_PAGAR { get; set; }
    }
}
