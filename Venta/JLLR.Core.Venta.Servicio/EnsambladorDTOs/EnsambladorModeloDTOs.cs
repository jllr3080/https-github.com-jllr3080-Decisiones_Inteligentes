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
              DetalleOrdenTrabajo =_ensambladorModelo.CrearColeecionDetalleOrdenesTrabajo(e.DetalleOrdenTrabajos)
            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<modeloDTOs.OrdenTrabajoDTOs> CrearOrdenesTrabajotOs(List<entidadDTOs.OrdenTrabajoDTOs> listadoModelo)
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
                NombreUsuario = e.NombreUsuario

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

        
    }
}