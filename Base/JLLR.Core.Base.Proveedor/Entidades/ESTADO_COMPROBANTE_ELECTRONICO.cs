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
    
    public partial class ESTADO_COMPROBANTE_ELECTRONICO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ESTADO_COMPROBANTE_ELECTRONICO()
        {
            this.CABECERA_MOVIMIENTO_FE = new HashSet<CABECERA_MOVIMIENTO_FE>();
        }
    
        public int ESTADO_COMPROBANTE_ELECTRONICO_ID { get; set; }
        public string DESCRIPCION { get; set; }
        public string ABREVIATURA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CABECERA_MOVIMIENTO_FE> CABECERA_MOVIMIENTO_FE { get; set; }
    }
}
