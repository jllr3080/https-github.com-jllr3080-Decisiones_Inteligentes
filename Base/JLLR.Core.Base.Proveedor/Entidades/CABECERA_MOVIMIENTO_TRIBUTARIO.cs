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
    
    public partial class CABECERA_MOVIMIENTO_TRIBUTARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CABECERA_MOVIMIENTO_TRIBUTARIO()
        {
            this.CABECERA_MOVIMIENTO_FACTURA = new HashSet<CABECERA_MOVIMIENTO_FACTURA>();
            this.CABECERA_MOVIMIENTO_FE = new HashSet<CABECERA_MOVIMIENTO_FE>();
        }
    
        public long CABECERA_MOVIMIENTO_TRIBUTARIO_ID { get; set; }
        public Nullable<int> CABECERA_FACTURACION_ID { get; set; }
        public string ESTABLECIMIENTO { get; set; }
        public string PUNTO_EMISION { get; set; }
        public string SECUENCIAL { get; set; }
    
        public virtual CABECERA_FACTURACION CABECERA_FACTURACION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CABECERA_MOVIMIENTO_FACTURA> CABECERA_MOVIMIENTO_FACTURA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CABECERA_MOVIMIENTO_FE> CABECERA_MOVIMIENTO_FE { get; set; }
    }
}
