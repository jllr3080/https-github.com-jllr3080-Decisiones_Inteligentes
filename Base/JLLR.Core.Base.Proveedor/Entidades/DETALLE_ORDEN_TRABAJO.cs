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
    
    public partial class DETALLE_ORDEN_TRABAJO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DETALLE_ORDEN_TRABAJO()
        {
            this.DETALLE_ORDEN_TRABAJO_OBSERVACION = new HashSet<DETALLE_ORDEN_TRABAJO_OBSERVACION>();
            this.DETALLE_TRABAJO_FOTOGRAFIA = new HashSet<DETALLE_TRABAJO_FOTOGRAFIA>();
        }
    
        public int DETALLE_ORDEN_TRABAJO_ID { get; set; }
        public Nullable<long> ORDEN_TRABAJO_ID { get; set; }
        public Nullable<int> PRODUCTO_ID { get; set; }
        public Nullable<int> IMPUESTO_ID { get; set; }
        public Nullable<int> COLOR_ID { get; set; }
        public Nullable<int> CANTIDAD { get; set; }
        public Nullable<decimal> VALOR_UNITARIO { get; set; }
        public Nullable<decimal> PORCENTAJE_IMPUESTO { get; set; }
        public Nullable<decimal> VALOR_TOTAL { get; set; }
        public string OBSERVACION { get; set; }
        public Nullable<int> PRODUCTO_TALLA_ID { get; set; }
        public Nullable<int> MARCA_ID { get; set; }
        public Nullable<int> MATERIAL_ID { get; set; }
        public Nullable<int> VENTA_COMISION_ID { get; set; }
    
        public virtual COLOR COLOR { get; set; }
        public virtual IMPUESTO IMPUESTO { get; set; }
        public virtual PRODUCTO PRODUCTO { get; set; }
        public virtual ORDEN_TRABAJO ORDEN_TRABAJO { get; set; }
        public virtual VENTA_COMISION VENTA_COMISION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_ORDEN_TRABAJO_OBSERVACION> DETALLE_ORDEN_TRABAJO_OBSERVACION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_TRABAJO_FOTOGRAFIA> DETALLE_TRABAJO_FOTOGRAFIA { get; set; }
    }
}
