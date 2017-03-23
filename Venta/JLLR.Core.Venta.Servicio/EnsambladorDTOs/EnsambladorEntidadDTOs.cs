#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using entidadDTOs = JLLR.Core.Venta.Proveedor.DTOs;
using modeloDTOs = JLLR.Core.Venta.Servicio.DTOs;
using ensamblador= JLLR.Core.Venta.Servicio.Ensamblador; 

#endregion

namespace JLLR.Core.Venta.Servicio.EnsambladorDTOs
{

    /// <summary>
    /// Ingresa un modelo y devuleve una entidad
    /// </summary>
    public class EnsambladorEntidadDTOs
    {

        #region  DECLARACIONES  E INSTANCIAS
        private readonly ensamblador.EnsambladorEntidad _ensambladorEntidad= new ensamblador.EnsambladorEntidad();
        private readonly ensamblador.EnsambladorModelo _ensambladorModelo= new ensamblador.EnsambladorModelo();
        #endregion


        #region PRENDA MARCA DTO
        /// <summary>
        /// Convierte el modelo DTO en una entidad DTO
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidadDTOs.PrendaMarcaDTOs CrearPrendaMarcaDtOs(modeloDTOs.PrendaMarcaDTOs m)
        {
            return new entidadDTOs.PrendaMarcaDTOs()
            {
             NumeroOrden = m.NumeroOrden,
             FechaIngreso = m.FechaIngreso,
             NombreSucursal = m.NombreSucursal,
             NombrePrenda = m.NombrePrenda,
             NombreMarca = m.NombreMarca
            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidadDTOs.PrendaMarcaDTOs> CrearPrendaMarcasDtOs(IQueryable<modeloDTOs.PrendaMarcaDTOs> listadoModelo)
        {
            List<entidadDTOs.PrendaMarcaDTOs> listaEntidad = new List<entidadDTOs.PrendaMarcaDTOs>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearPrendaMarcaDtOs(modelo));
            }
            return listaEntidad;

        }

        #endregion


        #region DETALLE ORDEN  TRABAJO OBSERVACION
        /// <summary>
        /// Convierte el modelo DTO en una entidad DTO
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidadDTOs.DetalleOrdenTrabajoObservacionDTOs CrearDetalleOrdenTrabajoObservacionDtOs(modeloDTOs.DetalleOrdenTrabajoObservacionDTOs m)
        {
            return new entidadDTOs.DetalleOrdenTrabajoObservacionDTOs()
            {
            NombreUsuario = m.NombreUsuario,
            DetalleOrdenTrabajoObservacion =_ensambladorEntidad.CrearDetalleOrdenTrabajoObservacion( m.DetalleOrdenTrabajoObservacion)
            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidadDTOs.DetalleOrdenTrabajoObservacionDTOs> CrearDetalleOrdenTrabajosObservacionDtOs(IQueryable<modeloDTOs.DetalleOrdenTrabajoObservacionDTOs> listadoModelo)
        {
            List<entidadDTOs.DetalleOrdenTrabajoObservacionDTOs> listaEntidad = new List<entidadDTOs.DetalleOrdenTrabajoObservacionDTOs>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearDetalleOrdenTrabajoObservacionDtOs(modelo));
            }
            return listaEntidad;

        }

        #endregion


        #region NUMERO  PRENDA DTO
        /// <summary>
        /// Convierte el modelo DTO en una entidad DTO
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidadDTOs.NumeroPrendaDTOs CrearNumeroPrendaDtOs(modeloDTOs.NumeroPrendaDTOs m)
        {
            return new entidadDTOs.NumeroPrendaDTOs()
            {
            Cantidad = m.Cantidad,
            NombreProducto = m.NombreProducto
            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidadDTOs.NumeroPrendaDTOs> CrearNumerosPrendaDtOs(List<modeloDTOs.NumeroPrendaDTOs> listadoModelo)
        {
            List<entidadDTOs.NumeroPrendaDTOs> listaEntidad = new List<entidadDTOs.NumeroPrendaDTOs>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearNumeroPrendaDtOs(modelo));
            }
            return listaEntidad;

        }

        #endregion


        #region ESTADO CUENTA DTO
        /// <summary>
        /// Convierte el modelo DTO en una entidad DTO
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidadDTOs.EstadoCuentaDTOs CrearEstadoCuentaDtOs(modeloDTOs.EstadoCuentaDTOs m)
        {
            return new entidadDTOs.EstadoCuentaDTOs()
            {
               NumeroOrden = m.NumeroOrden,
               Valor = m.Valor,
               NumeroPrenda = m.NumeroPrenda,
               FechaIngreso = m.FechaIngreso,
               Detalle = m.Detalle
            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidadDTOs.EstadoCuentaDTOs> CrearEstadosCuentaDtOs(List<modeloDTOs.EstadoCuentaDTOs> listadoModelo)
        {
            List<entidadDTOs.EstadoCuentaDTOs> listaEntidad = new List<entidadDTOs.EstadoCuentaDTOs>();

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
        public entidadDTOs.OrdenTrabajoDTOs CrearOrdenTrabajotOs(modeloDTOs.OrdenTrabajoDTOs m)
        {
            return new entidadDTOs.OrdenTrabajoDTOs()
            {
                OrdenTrabajo = _ensambladorEntidad.CrearOrdenTrabajo( m.OrdenTrabajo),
                DetalleOrdenTrabajos = _ensambladorEntidad.CrearDetalleOrdenesTrabajo(m.DetalleOrdenTrabajo)
            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidadDTOs.OrdenTrabajoDTOs> CrearOrdenesTrabajotOs(List<modeloDTOs.OrdenTrabajoDTOs> listadoModelo)
        {
            List<entidadDTOs.OrdenTrabajoDTOs> listaEntidad = new List<entidadDTOs.OrdenTrabajoDTOs>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearOrdenTrabajotOs(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region CONSULTA ORDEN DE  TRABAJO
        /// <summary>
        /// Convierte el modelo DTO en una entidad DTO
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidadDTOs.ConsultaOrdenTrabajoDTOs CrearConsultaOrdenTrabajoDTOs(modeloDTOs.ConsultaOrdenTrabajoDTOs m)
        {
            return new entidadDTOs.ConsultaOrdenTrabajoDTOs()
            {
               EstadoPago = m.EstadoPago,
               TipoLavado = m.TipoLavado,
               Marca = m.Marca,
               NumeroOrden = m.NumeroOrden,
               FechaIngreso = m.FechaIngreso,
               FechaEntrega = m.FechaEntrega,
               ValorUnitario = m.ValorUnitario,
               Cantidad = m.Cantidad,
               Color = m.Color,
               Prenda = m.Prenda,
               ValorTotal = m.ValorTotal,
               NombreCliente = m.NombreCliente,
               Observacion = m.Observacion,
                EstadoPagoId = m.EstadoPagoId,
                DetalleOrdenTrabajoId = m.DetalleOrdenTrabajoId,
                OrdenTrabajoId = m.OrdenTrabajoId,
                Direccion = m.Direccion,
                CorreoElectronico = m.CorreoElectronico,
                Telefono = m.Telefono,
                NombrePuntoVenta = m.NombrePuntoVenta,
                NombreUsuario = m.NombreUsuario
              
            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidadDTOs.ConsultaOrdenTrabajoDTOs> CrearConsultaOrdenesTrabajoDTOs(List<modeloDTOs.ConsultaOrdenTrabajoDTOs> listadoModelo)
        {
            List<entidadDTOs.ConsultaOrdenTrabajoDTOs> listaEntidad = new List<entidadDTOs.ConsultaOrdenTrabajoDTOs>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearConsultaOrdenTrabajoDTOs(modelo));
            }
            return listaEntidad;

        }
        #endregion


        #region ORDEN TRABAJO  DESCUENTO DTO
        /// <summary>
        /// Convierte el modelo DTO en una entidad DTO
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidadDTOs.OrdenTrabajoDescuentoDTO CrearOrdenTrabajoDescuentoDto(modeloDTOs.OrdenTrabajoDescuentoDTO m)
        {
            return new entidadDTOs.OrdenTrabajoDescuentoDTO()
            {
                NombrePuntoVenta = m.NombrePuntoVenta,
                 OrdenTrabajoDescuento= _ensambladorEntidad.CrearOrdenTrabajoDescuento(m.OrdenTrabajoDescuento)
            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidadDTOs.OrdenTrabajoDescuentoDTO> CrearOrdenTrabajoDescuentoDtos(List<modeloDTOs.OrdenTrabajoDescuentoDTO> listadoModelo)
        {
            List<entidadDTOs.OrdenTrabajoDescuentoDTO> listaEntidad = new List<entidadDTOs.OrdenTrabajoDescuentoDTO>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearOrdenTrabajoDescuentoDto(modelo));
            }
            return listaEntidad;

        }
        #endregion
    }
}