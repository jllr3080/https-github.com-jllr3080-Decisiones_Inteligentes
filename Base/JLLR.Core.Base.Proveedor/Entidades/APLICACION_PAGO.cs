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
    
    public partial class APLICACION_PAGO
    {
        public int APLICACION_PAGO_ID { get; set; }
        public Nullable<int> CIERRE_MES_ID { get; set; }
        public Nullable<decimal> VALOR { get; set; }
        public Nullable<System.DateTime> FECHA_CREACION { get; set; }
        public Nullable<bool> ESTA_VALIDADO { get; set; }
        public string NUMERO_DOCUMENTO { get; set; }
        public Nullable<System.DateTime> FECHA_DEPOSITO { get; set; }
        public Nullable<System.DateTime> FECHA_VALIDACION { get; set; }
        public byte[] DOCUMENTO { get; set; }
        public Nullable<int> USUARIO_APLICA_ID { get; set; }
        public Nullable<int> USUARIO_VALIDA_ID { get; set; }
    
        public virtual CIERRE_MES CIERRE_MES { get; set; }
    }
}