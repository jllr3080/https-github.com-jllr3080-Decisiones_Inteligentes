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
    
    public partial class HISTORIAL_REPROCESO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HISTORIAL_REPROCESO()
        {
            this.DETALLE_HISTORIAL_REPROCESO = new HashSet<DETALLE_HISTORIAL_REPROCESO>();
        }
    
        public long HISTORIAL_REPROCESO_ID { get; set; }
        public Nullable<int> HISTORIAL_PROCESO_ID { get; set; }
        public Nullable<int> DETALLE_PRENDA_ORDEN_TRABAJO_ID { get; set; }
        public Nullable<System.DateTime> FECHA_ESTIMADA_ENTREGA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_HISTORIAL_REPROCESO> DETALLE_HISTORIAL_REPROCESO { get; set; }
        public virtual HISTORIAL_PROCESO HISTORIAL_PROCESO { get; set; }
        public virtual DETALLE_PRENDA_ORDEN_TRABAJO DETALLE_PRENDA_ORDEN_TRABAJO { get; set; }
    }
}
