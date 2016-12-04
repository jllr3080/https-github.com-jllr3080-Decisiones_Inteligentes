﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Decisiones_Inteligentes : DbContext
    {
        public Decisiones_Inteligentes()
            : base("name=Decisiones_Inteligentes")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CONTROL_USUARIO> CONTROL_USUARIO { get; set; }
        public virtual DbSet<ARQUEO_CAJA> ARQUEO_CAJA { get; set; }
        public virtual DbSet<DETALLE_ARQUEO_CAJA> DETALLE_ARQUEO_CAJA { get; set; }
        public virtual DbSet<CABECERA_FACTURACION> CABECERA_FACTURACION { get; set; }
        public virtual DbSet<SECUENCIALES_SRI> SECUENCIALES_SRI { get; set; }
        public virtual DbSet<CIUDAD> CIUDAD { get; set; }
        public virtual DbSet<CLIENTE> CLIENTE { get; set; }
        public virtual DbSet<DIRECCION> DIRECCION { get; set; }
        public virtual DbSet<E_MAIL> E_MAIL { get; set; }
        public virtual DbSet<EMPLEADO> EMPLEADO { get; set; }
        public virtual DbSet<ESTADO> ESTADO { get; set; }
        public virtual DbSet<INDIVIDUO> INDIVIDUO { get; set; }
        public virtual DbSet<INDIVIDUO_BANCO> INDIVIDUO_BANCO { get; set; }
        public virtual DbSet<PAIS> PAIS { get; set; }
        public virtual DbSet<TELEFONO> TELEFONO { get; set; }
        public virtual DbSet<AGENDA_VISITA> AGENDA_VISITA { get; set; }
        public virtual DbSet<HISTORIAL_PROCESO> HISTORIAL_PROCESO { get; set; }
        public virtual DbSet<VISITA> VISITA { get; set; }
        public virtual DbSet<COLOR> COLOR { get; set; }
        public virtual DbSet<DIA> DIA { get; set; }
        public virtual DbSet<ESPECIALIDAD_EMPLEADO> ESPECIALIDAD_EMPLEADO { get; set; }
        public virtual DbSet<ESTADO_CIVIL> ESTADO_CIVIL { get; set; }
        public virtual DbSet<ESTADO_PAGO> ESTADO_PAGO { get; set; }
        public virtual DbSet<ETAPA_PROCESO> ETAPA_PROCESO { get; set; }
        public virtual DbSet<IMPUESTO> IMPUESTO { get; set; }
        public virtual DbSet<LLEVA_CONTABILIDAD> LLEVA_CONTABILIDAD { get; set; }
        public virtual DbSet<MARCA> MARCA { get; set; }
        public virtual DbSet<MATERIAL> MATERIAL { get; set; }
        public virtual DbSet<MODELO> MODELO { get; set; }
        public virtual DbSet<MONEDA> MONEDA { get; set; }
        public virtual DbSet<NIVEL_EDUCACION> NIVEL_EDUCACION { get; set; }
        public virtual DbSet<PARAMETRO> PARAMETRO { get; set; }
        public virtual DbSet<PUNTO_VENTA> PUNTO_VENTA { get; set; }
        public virtual DbSet<RUTA> RUTA { get; set; }
        public virtual DbSet<SUCURSAL> SUCURSAL { get; set; }
        public virtual DbSet<TIPO_AMBIENTE> TIPO_AMBIENTE { get; set; }
        public virtual DbSet<TIPO_CORREO_ELECTRONICO> TIPO_CORREO_ELECTRONICO { get; set; }
        public virtual DbSet<TIPO_CUENTA_BANCARIA> TIPO_CUENTA_BANCARIA { get; set; }
        public virtual DbSet<TIPO_DIRECCION> TIPO_DIRECCION { get; set; }
        public virtual DbSet<TIPO_EMISION> TIPO_EMISION { get; set; }
        public virtual DbSet<TIPO_GENERO> TIPO_GENERO { get; set; }
        public virtual DbSet<TIPO_IDENTIFICACION> TIPO_IDENTIFICACION { get; set; }
        public virtual DbSet<TIPO_INDIVIDUO> TIPO_INDIVIDUO { get; set; }
        public virtual DbSet<TIPO_LAVADO> TIPO_LAVADO { get; set; }
        public virtual DbSet<TIPO_ROL_INDIVIDUO> TIPO_ROL_INDIVIDUO { get; set; }
        public virtual DbSet<TIPO_TELEFONO> TIPO_TELEFONO { get; set; }
        public virtual DbSet<UNIDAD_MEDIDA> UNIDAD_MEDIDA { get; set; }
        public virtual DbSet<ZONA> ZONA { get; set; }
        public virtual DbSet<GRUPO_PRODUCTO> GRUPO_PRODUCTO { get; set; }
        public virtual DbSet<PRODUCTO> PRODUCTO { get; set; }
        public virtual DbSet<PRODUCTO_PRECIO> PRODUCTO_PRECIO { get; set; }
        public virtual DbSet<PRODUCTO_TALLA> PRODUCTO_TALLA { get; set; }
        public virtual DbSet<PRODUCTO_VS_GRUPO_PRODUCTO> PRODUCTO_VS_GRUPO_PRODUCTO { get; set; }
        public virtual DbSet<TIPO_PRODUCTO> TIPO_PRODUCTO { get; set; }
        public virtual DbSet<ACCESO> ACCESO { get; set; }
        public virtual DbSet<ACCESO_PERFIL> ACCESO_PERFIL { get; set; }
        public virtual DbSet<HISTORIAL_USUARIO> HISTORIAL_USUARIO { get; set; }
        public virtual DbSet<MODULO> MODULO { get; set; }
        public virtual DbSet<PERFIL> PERFIL { get; set; }
        public virtual DbSet<PREGUNTA_SEGURIDAD> PREGUNTA_SEGURIDAD { get; set; }
        public virtual DbSet<SUBMODULO> SUBMODULO { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }
        public virtual DbSet<USUARIO_PERFIL> USUARIO_PERFIL { get; set; }
        public virtual DbSet<USUARIO_PREGUNTA_SEGURIDAD> USUARIO_PREGUNTA_SEGURIDAD { get; set; }
        public virtual DbSet<USUARIO_SEGURIDAD> USUARIO_SEGURIDAD { get; set; }
        public virtual DbSet<DETALLE_ENTREGA_ORDEN_TRABAJO> DETALLE_ENTREGA_ORDEN_TRABAJO { get; set; }
        public virtual DbSet<DETALLE_ORDEN_TRABAJO> DETALLE_ORDEN_TRABAJO { get; set; }
        public virtual DbSet<DETALLE_TRABAJO_FOTOGRAFIA> DETALLE_TRABAJO_FOTOGRAFIA { get; set; }
        public virtual DbSet<ENTREGA_ORDEN_TRABAJO> ENTREGA_ORDEN_TRABAJO { get; set; }
        public virtual DbSet<NUMERACION_ORDEN> NUMERACION_ORDEN { get; set; }
        public virtual DbSet<ORDEN_TRABAJO> ORDEN_TRABAJO { get; set; }
        public virtual DbSet<VENTA_COMISION> VENTA_COMISION { get; set; }
    }
}