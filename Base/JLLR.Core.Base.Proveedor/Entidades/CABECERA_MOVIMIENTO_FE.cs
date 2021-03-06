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
    
    public partial class CABECERA_MOVIMIENTO_FE
    {
        public long CABECERA_MOVIMIENTO_FE_ID { get; set; }
        public Nullable<int> TIPO_COMPROBANTE_ID { get; set; }
        public Nullable<int> TIPO_IDENTIFICACION_ID { get; set; }
        public Nullable<int> ESTADO_COMPROBANTE_ELECTRONICO_ID { get; set; }
        public Nullable<int> USUARIO_ID { get; set; }
        public Nullable<int> MONEDA_ID { get; set; }
        public Nullable<int> INDIVIDUO_ROL_ID { get; set; }
        public Nullable<int> MENSAJE_ID { get; set; }
        public Nullable<long> CABECERA_MOVIMIENTO_TRIBUTARIO_ID { get; set; }
        public Nullable<System.DateTime> FECHA_EMISION { get; set; }
        public string CORREO_ELECTRONICO { get; set; }
        public Nullable<System.DateTime> FECHA_ENVIO { get; set; }
        public string DIRECCION { get; set; }
        public string TELEFONO { get; set; }
        public string FAX { get; set; }
        public Nullable<long> NUMERO_COMPROBANTE { get; set; }
        public Nullable<bool> COMPRA_O_VENTA { get; set; }
        public string CLAVE_ACCESO { get; set; }
        public string NUMERO_AUTORIZACION { get; set; }
        public Nullable<System.DateTime> FECHA_AUTORIZACION { get; set; }
    
        public virtual USUARIO USUARIO { get; set; }
        public virtual ESTADO_COMPROBANTE_ELECTRONICO ESTADO_COMPROBANTE_ELECTRONICO { get; set; }
        public virtual INDIVIDUO_ROL INDIVIDUO_ROL { get; set; }
        public virtual MONEDA MONEDA { get; set; }
        public virtual CABECERA_MOVIMIENTO_TRIBUTARIO CABECERA_MOVIMIENTO_TRIBUTARIO { get; set; }
        public virtual MENSAJE MENSAJE { get; set; }
        public virtual TIPO_COMPROBANTE TIPO_COMPROBANTE { get; set; }
        public virtual TIPO_IDENTIFICACION TIPO_IDENTIFICACION { get; set; }
    }
}
