#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JLLR.Core.General.Servicio.Modelo;
using JLLR.Core.Individuo.Servicio.Modelo;
using JLLR.Core.Inventario.Servicio.Modelo.Parametrizacion;
using JLLR.Core.Seguridad.Servicio.Modelo;
using modelo=JLLR.Core.Venta.Servicio.Modelo;
using  entidad=JLLR.Core.Base.Proveedor.Entidades;
using modeloParametrizacion = JLLR.Core.Venta.Servicio.Modelo.Parametrizacion;
#endregion

namespace JLLR.Core.Venta.Servicio.Ensamblador
{
    /// <summary>
    /// Ingresa una  entidad y lo transforma en un modelo
    /// </summary>
    public class EnsambladorModelo
    {

        #region NEGOCIO

        #region  ORDEN TRABAJO
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.OrdenTrabajoModelo CrearOrdenTrabajo(entidad.ORDEN_TRABAJO e)
        {
            UsuarioModelo usuario = new UsuarioModelo()
            {
                UsuarioId = Convert.ToInt32(e.USUARIO_ID)

            };
            PuntoVentaModelo puntoVenta = new PuntoVentaModelo()
            {
                PuntoVentaId = Convert.ToInt32(e.PUNTO_VENTA_ID)
            };

            SucursalModelo sucursal = new SucursalModelo()
            {

                SucursalId = Convert.ToInt32(e.SUCURSAL_ID)
            };

            ClienteModelo cliente = new ClienteModelo()
            {
                ClienteId = Convert.ToInt32(e.CLIENTE_ID)
            };

            TipoLavadoModelo tipoLavado = new TipoLavadoModelo()
            {
                TipoLavadoId=Convert.ToInt32(e.TIPO_LAVADO_ID)
            };
            EstadoPagoModelo _estadoPago = new EstadoPagoModelo()
            {
                EstadoPagoId = Convert.ToInt32(e.ESTADO_PAGO_ID)
            };
            return new modelo.OrdenTrabajoModelo
            {
                OrdenTrabajoId = e.ORDEN_TRABAJO_ID,
                Usuario = usuario,
                PuntoVenta = puntoVenta,
                Sucursal = sucursal,
                ClienteModelo = cliente,
                TipoLavado = tipoLavado,
                NumeroImpresion =e.NRO_IMPRESION,
                FechaIngreso = e.FECHA_INGRESO,
                FechaEntrega = e.FECHA_ENTREGA,
                NumeroOrden = e.NUMERO_ORDEN,
                EstadoPago = _estadoPago

            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.OrdenTrabajoModelo> CrearOrdenesTrabajo(IQueryable<entidad.ORDEN_TRABAJO> listadoEntidad)
        {
            List <modelo.OrdenTrabajoModelo > listaModelo = new List<modelo.OrdenTrabajoModelo > ();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearOrdenTrabajo(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  DETALLE ORDEN TRABAJO
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.DetalleOrdenTrabajoModelo CrearDetalleOrdenTrabajo(entidad.DETALLE_ORDEN_TRABAJO e)
        {

            modelo.OrdenTrabajoModelo ordenTrabajo = new modelo.OrdenTrabajoModelo()
            {
                OrdenTrabajoId =Convert.ToInt64(e.ORDEN_TRABAJO_ID)
            };
            ImpuestoModelo impuesto = new ImpuestoModelo()
            {
                ImpuestoId = Convert.ToInt32(e.IMPUESTO_ID)
            };
            ProductoModelo producto = new ProductoModelo()
            {
                ProductoId = Convert.ToInt32(e.PRODUCTO_ID)
            };
            General.Servicio.Modelo.ColorModelo color = new General.Servicio.Modelo.ColorModelo()
            {
                ColorId =Convert.ToInt32( e.COLOR_ID)

            };
            ProductoTallaModelo _productoTalla = new ProductoTallaModelo()
            {
                ProductoTallaId = Convert.ToInt32(e.PRODUCTO_TALLA_ID)

            };

            General.Servicio.Modelo.MarcaModelo _marca = new General.Servicio.Modelo.MarcaModelo()
            {
                MarcaId = Convert.ToInt32(e.MARCA_ID)
            };

            General.Servicio.Modelo.MaterialModelo _material = new General.Servicio.Modelo.MaterialModelo()
            {
                MaterialId = Convert.ToInt32(e.MATERIAL_ID)
            };

            modeloParametrizacion.VentaComisionModelo  _vetComisionModelo = new modeloParametrizacion.VentaComisionModelo()
            {
                 VentaComisionId= Convert.ToInt32(e.VENTA_COMISION_ID)

            };
            return new modelo.DetalleOrdenTrabajoModelo
            {
                DetalleOrdenTrabajoId = e.DETALLE_ORDEN_TRABAJO_ID,
                OrdenTrabajo = ordenTrabajo,
                Impuesto = impuesto,
                Cantidad = e.CANTIDAD,
                Observacion = e.OBSERVACION,
                PorcentajeImpuesto = e.PORCENTAJE_IMPUESTO,
                ValorTotal = e.VALOR_TOTAL,
                ValorUnitario = e.VALOR_UNITARIO,
                Producto = producto,
                Color = color,
                ProductoTalla = _productoTalla,
                Marca = _marca,
                Material = _material,
                VentaComision = _vetComisionModelo
               


            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.DetalleOrdenTrabajoModelo> CrearDetalleOrdenesTrabajo(IQueryable<entidad.DETALLE_ORDEN_TRABAJO> listadoEntidad)
        {
            List<modelo.DetalleOrdenTrabajoModelo> listaModelo = new List<modelo.DetalleOrdenTrabajoModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearDetalleOrdenTrabajo(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region DETALLE ORDEN TRABAJO OBSERVACION
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.DetalleOrdenTrabajoObservacionModelo CrearDetalleOrdenTrabajoObservacion(entidad.DETALLE_ORDEN_TRABAJO_OBSERVACION e)
        {

           
            return new modelo.DetalleOrdenTrabajoObservacionModelo
            {
              DetalleOrdenTrabajoId = e.DETALLE_ORDEN_TRABAJO_ID,
              DetalleOrdenTrabajoObservacionId = e.DETALLE_ORDEN_TRABAJO_OBSERVACION_ID,
              Observacion = e.OBSERVACION,
              UsuarioId = e.USUARIO_ID,
              FechaCreacionObservacion = e.FECHA_CREACION_OBSERVACION

            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.DetalleOrdenTrabajoObservacionModelo> CrearDetalleOrdenTrabajosObservacion(IQueryable<entidad.DETALLE_ORDEN_TRABAJO_OBSERVACION> listadoEntidad)
        {
            List<modelo.DetalleOrdenTrabajoObservacionModelo> listaModelo = new List<modelo.DetalleOrdenTrabajoObservacionModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearDetalleOrdenTrabajoObservacion(entidad));
            }
            return listaModelo;

        }

        #endregion
        #endregion

        #region PARAMETRIZACION

        #region  NUMERO ORDEN
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modeloParametrizacion.NumeroOrdenModelo CrearNumeroOrden(entidad.NUMERACION_ORDEN e)
        {
           
            TipoLavadoModelo tipoLavado = new TipoLavadoModelo()
            {
                TipoLavadoId = Convert.ToInt32(e.TIPO_LAVADO_ID)
            };
            return new modeloParametrizacion.NumeroOrdenModelo
            {
              PuntoVentaId = e.PUNTO_VENTA_ID,
              Numero = e.NUMERO,
              NumeroOden = e.NUMERO_ORDEN,
              NumeroOrdenId = e.NUMERACION_ORDEN_ID,
              SucursalId = e.SUCURSAL_ID,
              TipoLavado = tipoLavado


            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modeloParametrizacion.NumeroOrdenModelo> CrearNumerosOrden(IQueryable<entidad.NUMERACION_ORDEN> listadoEntidad)
        {
            List<modeloParametrizacion.NumeroOrdenModelo> listaModelo = new List<modeloParametrizacion.NumeroOrdenModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearNumeroOrden(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  VENTA COMISION
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modeloParametrizacion.VentaComisionModelo CrearVentaComision(entidad.VENTA_COMISION e)
        {

            return new modeloParametrizacion.VentaComisionModelo
            {
                PuntoVentaId = e.PUNTO_VENTA_ID,
               EstaHabilitado = e.ESTA_HABILITADO,
               VentaComisionId = e.VENTA_COMISION_ID,
               SucursalId = e.SUCURSAL_ID,
               VendedorId = e.VENDEDOR_ID,
               PorcentajeComision = e.PORCENTAJE_COMISION,
               FechaComision = e.FECHA_COMISION


            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modeloParametrizacion.VentaComisionModelo> CrearVentaComisiones(IQueryable<entidad.VENTA_COMISION> listadoEntidad)
        {
            List<modeloParametrizacion.VentaComisionModelo> listaModelo = new List<modeloParametrizacion.VentaComisionModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearVentaComision(entidad));
            }
            return listaModelo;

        }

        #endregion
        #endregion
    }
}