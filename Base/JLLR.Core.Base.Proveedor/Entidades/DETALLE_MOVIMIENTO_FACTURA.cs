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
    
    public partial class DETALLE_MOVIMIENTO_FACTURA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DETALLE_MOVIMIENTO_FACTURA()
        {
            this.DETALLE_IMPUESTO_MOVIMIENTO_FACTURA = new HashSet<DETALLE_IMPUESTO_MOVIMIENTO_FACTURA>();
        }
    
        public long DETALLE_MOVIMIENTO_FACTURA_ID { get; set; }
        public Nullable<long> CABECERA_MOVIMIENTO_FACTURA_ID { get; set; }
        public string DESCRIPCION { get; set; }
        public Nullable<int> CANTIDAD { get; set; }
        public Nullable<decimal> PRECIO_UNITARIO { get; set; }
        public Nullable<decimal> DESCUENTO { get; set; }
        public Nullable<decimal> TOTAL_SIN_IMPUESTOS { get; set; }
    
        public virtual CABECERA_MOVIMIENTO_FACTURA CABECERA_MOVIMIENTO_FACTURA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_IMPUESTO_MOVIMIENTO_FACTURA> DETALLE_IMPUESTO_MOVIMIENTO_FACTURA { get; set; }
    }
}
