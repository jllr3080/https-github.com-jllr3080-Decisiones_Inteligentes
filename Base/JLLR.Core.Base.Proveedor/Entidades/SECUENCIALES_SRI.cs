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
    
    public partial class SECUENCIALES_SRI
    {
        public int SECUENCIALES_SRI_ID { get; set; }
        public Nullable<int> PUNTO_VENTA_ID { get; set; }
        public Nullable<int> SUCURSAL_ID { get; set; }
        public Nullable<int> TIPO_COMPROBANTE_ID { get; set; }
        public string SECUENCIAL_TEXTO { get; set; }
        public Nullable<int> SECUENCIAL_NUMERO { get; set; }
        public string ESTABLECIMIENTO { get; set; }
        public string TEXTO_PUNTO_EMISION { get; set; }
        public Nullable<int> TIPO_OPERACION_SRI { get; set; }
    
        public virtual PUNTO_VENTA PUNTO_VENTA { get; set; }
        public virtual SUCURSAL SUCURSAL { get; set; }
        public virtual TIPO_COMPROBANTE TIPO_COMPROBANTE { get; set; }
    }
}
