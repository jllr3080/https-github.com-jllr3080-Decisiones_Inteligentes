#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using entidadDTOs = JLLR.Core.Venta.Proveedor.DTOs;
using modeloDTOs = JLLR.Core.Venta.Servicio.DTOs;
using ensamblador = JLLR.Core.Venta.Servicio.Ensamblador;

#endregion

namespace JLLR.Core.Venta.Servicio.EnsambladorDTOs
{
    /// <summary>
    /// Ingresa una  entidad y lo transforma en un modelo
    /// </summary>
    public class EnsambladorModeloDTOs
    {
        #region  DECLARACIONES  E INSTANCIAS
        private readonly ensamblador.EnsambladorEntidad _ensambladorEntidad = new ensamblador.EnsambladorEntidad();
        private readonly ensamblador.EnsambladorModelo _ensambladorModelo = new ensamblador.EnsambladorModelo();
        #endregion

        #region PRENDA MARCA  DTO
        /// <summary>
        /// Convierte el modelo DTO en una entidad DTO
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public modeloDTOs.PrendaMarcaDTOs CrearPrendaMarcaDtOs(entidadDTOs.PrendaMarcaDTOs e)
        {
            return new modeloDTOs.PrendaMarcaDTOs()
            {
             NumeroOrden = e.NumeroOrden,
             FechaIngreso = e.FechaIngreso,
             NombreSucursal = e.NombreSucursal,
             NombrePrenda = e.NombrePrenda,
             NombreMarca = e.NombreMarca
            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<modeloDTOs.PrendaMarcaDTOs> CrearPrendaMarcasDtOs(IQueryable<entidadDTOs.PrendaMarcaDTOs> listadoModelo)
        {
            List<modeloDTOs.PrendaMarcaDTOs> listaEntidad = new List<modeloDTOs.PrendaMarcaDTOs>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearPrendaMarcaDtOs(modelo));
            }
            return listaEntidad;

        }

        #endregion

        #region NUMERO  DE  PRENDA
        /// <summary>
        /// Convierte el modelo DTO en una entidad DTO
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public modeloDTOs.DetalleOrdenTrabajoObservacionDTOs CrearDetalleOrdenTrabajoObservacionDtOs(entidadDTOs.DetalleOrdenTrabajoObservacionDTOs e)
        {
            return new modeloDTOs.DetalleOrdenTrabajoObservacionDTOs()
            {
              NombreUsuario = e.NombreUsuario,
              DetalleOrdenTrabajoObservacion = _ensambladorModelo.CrearDetalleOrdenTrabajoObservacion(e.DetalleOrdenTrabajoObservacion)
            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<modeloDTOs.DetalleOrdenTrabajoObservacionDTOs> CrearDetalleOrdenTrabajosObservacionDtOs(IQueryable<entidadDTOs.DetalleOrdenTrabajoObservacionDTOs> listadoModelo)
        {
            List<modeloDTOs.DetalleOrdenTrabajoObservacionDTOs> listaEntidad = new List<modeloDTOs.DetalleOrdenTrabajoObservacionDTOs>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearDetalleOrdenTrabajoObservacionDtOs(modelo));
            }
            return listaEntidad;

        }

        #endregion

        #region NUMERO  DE  PRENDA
        /// <summary>
        /// Convierte el modelo DTO en una entidad DTO
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public modeloDTOs.NumeroPrendaDTOs CrearNumeroPrendaDtOs(entidadDTOs.NumeroPrendaDTOs e)
        {
            return new modeloDTOs.NumeroPrendaDTOs()
            {
               NombreProducto = e.NombreProducto,
               Cantidad = e.Cantidad
            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<modeloDTOs.NumeroPrendaDTOs> CrearNumeroPrendasDtOs(List<entidadDTOs.NumeroPrendaDTOs> listadoModelo)
        {
            List<modeloDTOs.NumeroPrendaDTOs> listaEntidad = new List<modeloDTOs.NumeroPrendaDTOs>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearNumeroPrendaDtOs(modelo));
            }
            return listaEntidad;

        }

        #endregion

        #region ESTADO CUENTA
        /// <summary>
        /// Convierte el modelo DTO en una entidad DTO
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public modeloDTOs.EstadoCuentaDTOs CrearEstadoCuentaDtOs(entidadDTOs.EstadoCuentaDTOs e)
        {
            return new modeloDTOs.EstadoCuentaDTOs()
            {
              Detalle = e.Detalle,
              Valor=e.Valor,
              NumeroOrden=e.NumeroOrden,
              NumeroPrenda = e.NumeroPrenda,
              FechaIngreso = e.FechaIngreso
            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<modeloDTOs.EstadoCuentaDTOs> CrearEstadosCuentaDtOs(List<entidadDTOs.EstadoCuentaDTOs> listadoModelo)
        {
            List<modeloDTOs.EstadoCuentaDTOs> listaEntidad = new List<modeloDTOs.EstadoCuentaDTOs>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearEstadoCuentaDtOs(modelo));
            }
            return listaEntidad;

        }

        #endregion


        #region ORDEN TRABAJO DTO
        /// <summary>
        /// Convierte el modelo DTO en una entidad DTO
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public modeloDTOs.OrdenTrabajoDTOs CrearOrdenTrabajotOs(entidadDTOs.OrdenTrabajoDTOs e)
        {
            return new modeloDTOs.OrdenTrabajoDTOs()
            {
              OrdenTrabajo =_ensambladorModelo.CrearOrdenTrabajo(e.OrdenTrabajo),
              DetalleOrdenTrabajo =_ensambladorModelo.CrearColeecionDetalleOrdenesTrabajo(e.DetalleOrdenTrabajos),
              PerfilId = e.PerfilId,
              Abono = e.Abono
            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<modeloDTOs.OrdenTrabajoDTOs> CrearOrdenesTrabajosDtOs(List<entidadDTOs.OrdenTrabajoDTOs> listadoModelo)
        {
            List<modeloDTOs.OrdenTrabajoDTOs> listaEntidad = new List<modeloDTOs.OrdenTrabajoDTOs>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearOrdenTrabajotOs(modelo));
            }
            return listaEntidad;

        }

        #endregion

        #region  CONSULTA ORDEN DE TRABJO
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modeloDTOs.ConsultaOrdenTrabajoDTOs CrearConsultaOrdenTrabajoDtOs(entidadDTOs.ConsultaOrdenTrabajoDTOs e)
        {
          
            return new modeloDTOs.ConsultaOrdenTrabajoDTOs
            {
               TipoLavado = e.TipoLavado,
               EstadoPago = e.EstadoPago,
               Marca = e.Marca,
               NumeroOrden = e.NumeroOrden,
               FechaIngreso = e.FechaIngreso,
               FechaEntrega = e.FechaEntrega,
               ValorUnitario = e.ValorUnitario,
               Cantidad = e.Cantidad,
               Color = e.Color,
               Prenda = e.Prenda,
               ValorTotal = e.ValorTotal,
               NombreCliente = e.NombreCliente,
               Observacion = e.Observacion,
                EstadoPagoId = e.EstadoPagoId,
                DetalleOrdenTrabajoId = e.DetalleOrdenTrabajoId,
                OrdenTrabajoId = e.OrdenTrabajoId,
                Direccion = e.Direccion,
                CorreoElectronico = e.CorreoElectronico,
                Telefono = e.Telefono,
                NombrePuntoVenta = e.NombrePuntoVenta,
                NombreUsuario = e.NombreUsuario,
                TratamientoEspecial = e.TratamientoEspecial,
                NumeroInternoPrenda = e.NumeroInternoPrenda,
                DetallePrendaOrdenTrabajoId = e.DetallePrendaOrdenTrabajoId,
                EstadoPrenda = e.EstadoPrenda,
                InformacionVisual = e.InformacionVisual

            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modeloDTOs.ConsultaOrdenTrabajoDTOs> CrearConsultaOrdenesTrabajoDtOs(IQueryable<entidadDTOs.ConsultaOrdenTrabajoDTOs> listadoEntidad)
        {
            List<modeloDTOs.ConsultaOrdenTrabajoDTOs> listaModelo = new List<modeloDTOs.ConsultaOrdenTrabajoDTOs> ();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearConsultaOrdenTrabajoDtOs(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  ORDEN  DE  TRABAJO DESCUENTO DTO
        /// <summary>
        /// Convierte el modelo DTO en una entidad DTO
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public modeloDTOs.OrdenTrabajoDescuentoDTO CrearOrdenTrabajoDescuentoDto(entidadDTOs.OrdenTrabajoDescuentoDTO e)
        {
            return new modeloDTOs.OrdenTrabajoDescuentoDTO()
            {
                NombrePuntoVenta = e.NombrePuntoVenta,
                OrdenTrabajoDescuento = _ensambladorModelo.CrearOrdenTrabajoDescuento(e.OrdenTrabajoDescuento)
            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<modeloDTOs.OrdenTrabajoDescuentoDTO> CrearOrdenTrabajoDescuentoDtos(IQueryable<entidadDTOs.OrdenTrabajoDescuentoDTO> listadoModelo)
        {
            List<modeloDTOs.OrdenTrabajoDescuentoDTO> listaEntidad = new List<modeloDTOs.OrdenTrabajoDescuentoDTO>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearOrdenTrabajoDescuentoDto(modelo));
            }
            return listaEntidad;

        }
        #endregion

    }
}