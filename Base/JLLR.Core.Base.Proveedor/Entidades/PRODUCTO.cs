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
    
    public partial class PRODUCTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCTO()
        {
            this.PRODUCTO_VS_GRUPO_PRODUCTO = new HashSet<PRODUCTO_VS_GRUPO_PRODUCTO>();
            this.PRODUCTO_PRECIO = new HashSet<PRODUCTO_PRECIO>();
            this.PRODUCTO_TALLA = new HashSet<PRODUCTO_TALLA>();
            this.ACCION_REGLA = new HashSet<ACCION_REGLA>();
            this.DETALLE_ORDEN_TRABAJO = new HashSet<DETALLE_ORDEN_TRABAJO>();
        }
    
        public int PRODUCTO_ID { get; set; }
        public Nullable<int> TIPO_PRODUCTO_ID { get; set; }
        public Nullable<int> MARCA_ID { get; set; }
        public Nullable<int> MATERIAL_ID { get; set; }
        public string NOMBRE { get; set; }
        public Nullable<System.DateTime> FECHA_CREACION { get; set; }
        public Nullable<bool> PEDIR_MEDIDA { get; set; }
        public Nullable<int> UNIDAD_MEDIDA_ID { get; set; }
        public Nullable<int> MODELO_ID { get; set; }
        public Nullable<bool> VISIBLE { get; set; }
        public Nullable<int> TIEMPO_ENTREGA { get; set; }
        public Nullable<bool> PRENDA_ESPECIAL { get; set; }
    
        public virtual MARCA MARCA { get; set; }
        public virtual MATERIAL MATERIAL { get; set; }
        public virtual MODELO MODELO { get; set; }
        public virtual UNIDAD_MEDIDA UNIDAD_MEDIDA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCTO_VS_GRUPO_PRODUCTO> PRODUCTO_VS_GRUPO_PRODUCTO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCTO_PRECIO> PRODUCTO_PRECIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCTO_TALLA> PRODUCTO_TALLA { get; set; }
        public virtual TIPO_PRODUCTO TIPO_PRODUCTO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACCION_REGLA> ACCION_REGLA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_ORDEN_TRABAJO> DETALLE_ORDEN_TRABAJO { get; set; }
    }
}
