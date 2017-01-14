#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using entidad = JLLR.Core.Base.Proveedor.Entidades;
using  modelo=JLLR.Core.Venta.Servicio.Modelo;
using modeloParametrizacion = JLLR.Core.Venta.Servicio.Modelo.Parametrizacion;
#endregion
namespace JLLR.Core.Venta.Servicio.Ensamblador
{
    /// <summary>
    /// Ingresa un modelo y devuleve una entidad
    /// </summary>
    public class EnsambladorEntidad
    {
        #region DECLARACIONES  E INSTANCIAS
        
        
        #endregion

        #region NEGOCIO
        #region ORDEN TRABAJO
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.ORDEN_TRABAJO CrearOrdenTrabajo(modelo.OrdenTrabajoModelo m)
        {
            return new entidad.ORDEN_TRABAJO()
            {
               ORDEN_TRABAJO_ID = m.OrdenTrabajoId,
               CLIENTE_ID = m.ClienteModelo.ClienteId,
               TIPO_LAVADO_ID = m.TipoLavado.TipoLavadoId,
               PUNTO_VENTA_ID = m.PuntoVenta.PuntoVentaId,
               USUARIO_ID = m.Usuario.UsuarioId,
               SUCURSAL_ID = m.Sucursal.SucursalId,
               FECHA_ENTREGA = m.FechaEntrega,
               FECHA_INGRESO = m.FechaIngreso,
               NRO_IMPRESION = m.NumeroImpresion,
               NUMERO_ORDEN = m.NumeroOrden,
               ESTADO_PAGO_ID = m.EstadoPago.EstadoPagoId,
               SE_ENVIO = m.SeEnvio,
               ENVIO_MATRIZ = m.EnvioMatriz
            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.ORDEN_TRABAJO> CrearOrdenesTrabajo(List<Modelo.OrdenTrabajoModelo> listadoModelo)
        {
            List<entidad.ORDEN_TRABAJO> listaEntidad = new List<entidad.ORDEN_TRABAJO>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearOrdenTrabajo(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region DETALLE ORDEN TRABAJO
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.DETALLE_ORDEN_TRABAJO CrearDetalleOrdenTrabajo(modelo.DetalleOrdenTrabajoModelo m)
        {
            List<entidad.DETALLE_ORDEN_TRABAJO_OBSERVACION> _lisaDetalleOrdenTrabajoObservacion =
                CrearDetalleOrdenTrabajosObservacion(m.DetalleOrdenTrabajoObservacion);
            return new entidad.DETALLE_ORDEN_TRABAJO()
            {
                DETALLE_ORDEN_TRABAJO_ID = m.DetalleOrdenTrabajoId,
                ORDEN_TRABAJO_ID = m.OrdenTrabajo.OrdenTrabajoId,
                PRODUCTO_ID = m.Producto.ProductoId,
                IMPUESTO_ID = m.Impuesto.ImpuestoId,
                COLOR_ID = m.Color.ColorId,
                CANTIDAD = m.Cantidad,
                VALOR_UNITARIO = m.ValorUnitario,
                PORCENTAJE_IMPUESTO = m.PorcentajeImpuesto,
                VALOR_TOTAL = m.ValorTotal,
                OBSERVACION = m.Observacion,
                VENTA_COMISION_ID = m.VentaComision.VentaComisionId,
                PRODUCTO_TALLA_ID = m.ProductoTalla.ProductoTallaId,
                MARCA_ID = m.Marca.MarcaId,
                MATERIAL_ID = m.Material.MaterialId,
                DETALLE_ORDEN_TRABAJO_OBSERVACION = _lisaDetalleOrdenTrabajoObservacion


            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.DETALLE_ORDEN_TRABAJO> CrearDetalleOrdenesTrabajo(List<Modelo.DetalleOrdenTrabajoModelo> listadoModelo)
        {
            return listadoModelo.Select(CrearDetalleOrdenTrabajo).ToList();
        }

        #endregion

        #region DETALLA ORDEN TRABAJO OBSERVACION
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.DETALLE_ORDEN_TRABAJO_OBSERVACION CrearDetalleOrdenTrabajoObservacion(modelo.DetalleOrdenTrabajoObservacionModelo m)
        {
            return new entidad.DETALLE_ORDEN_TRABAJO_OBSERVACION()
            {
               DETALLE_ORDEN_TRABAJO_OBSERVACION_ID = m.DetalleOrdenTrabajoObservacionId,
               DETALLE_ORDEN_TRABAJO_ID = m.DetalleOrdenTrabajoId,
               OBSERVACION = m.Observacion,
               USUARIO_ID = m.UsuarioId,
               FECHA_CREACION_OBSERVACION = m.FechaCreacionObservacion
            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.DETALLE_ORDEN_TRABAJO_OBSERVACION> CrearDetalleOrdenTrabajosObservacion(List<Modelo.DetalleOrdenTrabajoObservacionModelo> listadoModelo)
        {
            List<entidad.DETALLE_ORDEN_TRABAJO_OBSERVACION> listaEntidad = new List<entidad.DETALLE_ORDEN_TRABAJO_OBSERVACION>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearDetalleOrdenTrabajoObservacion(modelo));
            }
            return listaEntidad;

        }

        #endregion

        #endregion

        #region PARAMTRIZACION

        #region NUMERO ORDEN
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.NUMERACION_ORDEN CrearNumeroOrden(modeloParametrizacion.NumeroOrdenModelo m)
        {
            return new entidad.NUMERACION_ORDEN()
            {
               NUMERACION_ORDEN_ID = m.NumeroOrdenId,
               TIPO_LAVADO_ID = m.TipoLavado.TipoLavadoId,
               SUCURSAL_ID = m.SucursalId,
               PUNTO_VENTA_ID = m.PuntoVentaId,
               NUMERO_ORDEN = m.NumeroOden,
               NUMERO = m.Numero

               
            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.NUMERACION_ORDEN> CrearNumerosOrden(List<modeloParametrizacion.NumeroOrdenModelo> listadoModelo)
        {
            List<entidad.NUMERACION_ORDEN> listaEntidad = new List<entidad.NUMERACION_ORDEN>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearNumeroOrden(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region VENTA COMISION
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.VENTA_COMISION CrearVentaComision(modeloParametrizacion.VentaComisionModelo m)
        {
            return new entidad.VENTA_COMISION()
            {
              VENTA_COMISION_ID = m.VentaComisionId,
              VENDEDOR_ID = m.VendedorId,
              FECHA_COMISION = m.FechaComision,
              ESTA_HABILITADO = m.EstaHabilitado,
              PORCENTAJE_COMISION = m.PorcentajeComision,
              SUCURSAL_ID = m.SucursalId,
              PUNTO_VENTA_ID = m.PuntoVentaId
              


            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.VENTA_COMISION> CrearVentaComisiones(List<modeloParametrizacion.VentaComisionModelo> listadoModelo)
        {
            List<entidad.VENTA_COMISION> listaEntidad = new List<entidad.VENTA_COMISION>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearVentaComision(modelo));
            }
            return listaEntidad;

        }
        #endregion


        #endregion
    }
}