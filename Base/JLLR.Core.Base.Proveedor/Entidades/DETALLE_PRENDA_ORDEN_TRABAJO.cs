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
    
    public partial class DETALLE_PRENDA_ORDEN_TRABAJO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DETALLE_PRENDA_ORDEN_TRABAJO()
        {
            this.DETALLE_ORDEN_TRABAJO_OBSERVACION = new HashSet<DETALLE_ORDEN_TRABAJO_OBSERVACION>();
            this.DETALLE_TRABAJO_FOTOGRAFIA = new HashSet<DETALLE_TRABAJO_FOTOGRAFIA>();
            this.HISTORIAL_RECLAMO_REPROCESO_PRENDA = new HashSet<HISTORIAL_RECLAMO_REPROCESO_PRENDA>();
            this.HISTORIAL_REPROCESO = new HashSet<HISTORIAL_REPROCESO>();
        }
    
        public int DETALLE_PRENDA_ORDEN_TRABAJO_ID { get; set; }
        public Nullable<int> DETALLE_ORDEN_TRABAJO_ID { get; set; }
        public Nullable<int> MARCA_ID { get; set; }
        public Nullable<int> COLOR_ID { get; set; }
        public string ESTADO_PRENDA { get; set; }
        public string INFORMACION_VISUAL { get; set; }
        public string NUMERO_INTERNO_PRENDA { get; set; }
        public string TRATAMIENTO_ESPECIAL { get; set; }
    
        public virtual COLOR COLOR { get; set; }
        public virtual MARCA MARCA { get; set; }
        public virtual DETALLE_ORDEN_TRABAJO DETALLE_ORDEN_TRABAJO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_ORDEN_TRABAJO_OBSERVACION> DETALLE_ORDEN_TRABAJO_OBSERVACION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_TRABAJO_FOTOGRAFIA> DETALLE_TRABAJO_FOTOGRAFIA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HISTORIAL_RECLAMO_REPROCESO_PRENDA> HISTORIAL_RECLAMO_REPROCESO_PRENDA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HISTORIAL_REPROCESO> HISTORIAL_REPROCESO { get; set; }
    }
}
