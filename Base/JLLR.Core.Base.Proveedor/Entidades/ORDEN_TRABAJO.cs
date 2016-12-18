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
    
    public partial class ORDEN_TRABAJO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ORDEN_TRABAJO()
        {
            this.DETALLE_ORDEN_TRABAJO = new HashSet<DETALLE_ORDEN_TRABAJO>();
            this.ENTREGA_ORDEN_TRABAJO = new HashSet<ENTREGA_ORDEN_TRABAJO>();
            this.HISTORIAL_PROCESO = new HashSet<HISTORIAL_PROCESO>();
        }
    
        public long ORDEN_TRABAJO_ID { get; set; }
        public Nullable<int> CLIENTE_ID { get; set; }
        public Nullable<int> TIPO_LAVADO_ID { get; set; }
        public Nullable<int> PUNTO_VENTA_ID { get; set; }
        public Nullable<System.DateTime> FECHA_INGRESO { get; set; }
        public Nullable<System.DateTime> FECHA_ENTREGA { get; set; }
        public Nullable<int> USUARIO_ID { get; set; }
        public Nullable<int> NRO_IMPRESION { get; set; }
        public Nullable<int> SUCURSAL_ID { get; set; }
        public Nullable<int> ESTADO_PAGO_ID { get; set; }
        public string NUMERO_ORDEN { get; set; }
    
        public virtual CLIENTE CLIENTE { get; set; }
        public virtual ESTADO_PAGO ESTADO_PAGO { get; set; }
        public virtual TIPO_LAVADO TIPO_LAVADO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_ORDEN_TRABAJO> DETALLE_ORDEN_TRABAJO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ENTREGA_ORDEN_TRABAJO> ENTREGA_ORDEN_TRABAJO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HISTORIAL_PROCESO> HISTORIAL_PROCESO { get; set; }
    }
}
