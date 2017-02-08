#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using entidad = JLLR.Core.Base.Proveedor.Entidades;
using modelo = JLLR.Core.General.Servicio.Modelo;
#endregion
namespace JLLR.Core.General.Servicio.Ensamblador
{
    public class EnsambladorModelo
    {
        #region  COLOR
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.ColorModelo CrearColor(entidad.COLOR e)
        {
            return new modelo.ColorModelo
            {
                ColorId = e.COLOR_ID,
                Descripcion = e.DESCRIPCION,
                EstaHabilitado = e.ESTA_HABILITADO
            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.ColorModelo> CrearColores(IQueryable<entidad.COLOR> listadoEntidad)
        {
            List<modelo.ColorModelo> listaModelo = new List<modelo.ColorModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearColor(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  MARCA
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.MarcaModelo CrearMarca(entidad.MARCA e)
        {
            return new modelo.MarcaModelo
            {
                MarcaId = e.MARCA_ID,
                Descripcion = e.DESCRIPCION,
                EstaHabilitado = e.ESTA_HABILITADO

            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.MarcaModelo> CrearMarcas(IQueryable<entidad.MARCA> listadoEntidad)
        {
            List<modelo.MarcaModelo> listaModelo = new List<modelo.MarcaModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearMarca(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  MATERIAL
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.MaterialModelo CrearMaterial(entidad.MATERIAL e)
        {
            return new modelo.MaterialModelo
            {
                MaterialId = e.MATERIAL_ID,
                Descripcion = e.DESCRIPCION,
                EstaHabilitado = e.ESTA_HABILITADO

            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.MaterialModelo> CrearMateriales(IQueryable<entidad.MATERIAL> listadoEntidad)
        {
            List<modelo.MaterialModelo> listaModelo = new List<modelo.MaterialModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearMaterial(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  MODELO
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.ModeloModelo CrearModelo(entidad.MODELO e)
        {
            return new modelo.ModeloModelo
            {
                ModeloId = e.MODELO_ID,
                Descripcion = e.DESCRIPCION,
                EstaHabilitado = e.ESTA_HABILITADO,


            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.ModeloModelo> CrearModelos(IQueryable<entidad.MODELO> listadoEntidad)
        {
            List<modelo.ModeloModelo> listaModelo = new List<modelo.ModeloModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearModelo(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  TIPO DE LAVADO
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.TipoLavadoModelo CrearTipoLavado(entidad.TIPO_LAVADO e)
        {
            return new modelo.TipoLavadoModelo
            {
               TipoLavadoId=e.TIPO_LAVADO_ID,
               Descripcion= e.DESCRIPCION,
               EstaHabilitado= e.ESTA_HABILITADO


            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.TipoLavadoModelo> CrearTiposLavado(IQueryable<entidad.TIPO_LAVADO> listadoEntidad)
        {
            List<modelo.TipoLavadoModelo> listaModelo = new List<modelo.TipoLavadoModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearTipoLavado(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  CIUDAD
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.CiudadModelo CrearCiudad(entidad.CIUDAD e)
        {
            return new modelo.CiudadModelo
            {
                CiudadId = e.CIUDAD_ID,
                Descripcion = e.DESCRIPCION,
                EstadoId = e.ESTADO_ID,
                PaisId = e.PAIS_ID


            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.CiudadModelo> CrearCiudades(IQueryable<entidad.CIUDAD> listadoEntidad)
        {
            List<modelo.CiudadModelo> listaModelo = new List<modelo.CiudadModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearCiudad(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  ESTADO
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.EstadoModelo CrearEstado(entidad.ESTADO e)
        {
            return new modelo.EstadoModelo
            {
                Descripcion = e.DESCRIPCION,
                EstadoId = e.ESTADO_ID,
                PaisId = e.PAIS_ID


            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.EstadoModelo> CrearEstados(IQueryable<entidad.ESTADO> listadoEntidad)
        {
            List<modelo.EstadoModelo> listaModelo = new List<modelo.EstadoModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearEstado(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  ESTADO PAGO
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.EstadoPagoModelo CrearEstadoPago(entidad.ESTADO_PAGO e)
        {
            return new modelo.EstadoPagoModelo
            {
                EstadoPagoId = e.ESTADO_PAGO_ID,
                Descripcion = e.DESCRIPCION
               
                


            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.EstadoPagoModelo> CrearEstadoPagos(IQueryable<entidad.ESTADO_PAGO> listadoEntidad)
        {
            List<modelo.EstadoPagoModelo> listaModelo = new List<modelo.EstadoPagoModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearEstadoPago(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  IMPUESTO
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.ImpuestoModelo CrearImpuesto(entidad.IMPUESTO e)
        {
            return new modelo.ImpuestoModelo
            {
               ImpuestoId = e.IMPUESTO_ID,
               Descripcion = e.DESCRIPCION,
               FechaCreacion = e.FECHA_CREACION,
               EstaHabilitado = e.ESTA_HABILITADO




            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.ImpuestoModelo> CrearImpuestos(IQueryable<entidad.IMPUESTO> listadoEntidad)
        {
            List<modelo.ImpuestoModelo> listaModelo = new List<modelo.ImpuestoModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearImpuesto(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  PAIS
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.PaisModelo CrearPais(entidad.PAIS e)
        {
            return new modelo.PaisModelo
            {
               PaisId = e.PAIS_ID,
               PorDefecto = e.POR_DEFECTO,
               Descripcion = e.DESCRIPCION




            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.PaisModelo> CrearPaises(IQueryable<entidad.PAIS> listadoEntidad)
        {
            List<modelo.PaisModelo> listaModelo = new List<modelo.PaisModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearPais(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  PUNTO VENTA
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.PuntoVentaModelo CrearPuntoVenta(entidad.PUNTO_VENTA e)
        {
            return new modelo.PuntoVentaModelo
            {
              PuntoVentaId = e.PUNTO_VENTA_ID,
              Descripcion = e.DESCRIPCION,
              HoraInicio = e.HORA_INICIO,
              HoraFin = e.HORA_FIN
            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.PuntoVentaModelo> CrearPuntosVenta(IQueryable<entidad.PUNTO_VENTA> listadoEntidad)
        {
            List<modelo.PuntoVentaModelo> listaModelo = new List<modelo.PuntoVentaModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearPuntoVenta(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  SUCURSAL
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.SucursalModelo CrearSucursal(entidad.SUCURSAL e)
        {
            return new modelo.SucursalModelo
            {
               SucursalId = e.SUCURSAL_ID,
               Descripcion = e.DESCRIPCION,
               EstaHabilitado = e.ESTA_HABILITADO
            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.SucursalModelo> CrearSucursales(IQueryable<entidad.SUCURSAL> listadoEntidad)
        {
            List<modelo.SucursalModelo> listaModelo = new List<modelo.SucursalModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearSucursal(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  TIPO CORREO ELECTRONICO
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.TipoCorreoElectronicoModelo CrearTipoCorreoElectronico(entidad.TIPO_CORREO_ELECTRONICO e)
        {
            return new modelo.TipoCorreoElectronicoModelo
            {
               TipoCorreoElectronicoId = e.TIPO_CORREO_ELECTRONICO_ID,
               Descripcion = e.DESCRIPCION,
               PorDefecto = e.POR_DEFECTO
            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.TipoCorreoElectronicoModelo> CrearTipoCorreoElectronicos(IQueryable<entidad.TIPO_CORREO_ELECTRONICO> listadoEntidad)
        {
            List<modelo.TipoCorreoElectronicoModelo> listaModelo = new List<modelo.TipoCorreoElectronicoModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearTipoCorreoElectronico(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  TIPO DIRECCION
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.TipoDireccionModelo CrearTipoDireccion(entidad.TIPO_DIRECCION e)
        {
            return new modelo.TipoDireccionModelo
            {
                TipoDireccionId = e.TIPO_DIRECCION_ID,
                Descripcion = e.DESCRIPCION,
                PorDefecto = e.POR_DEFECTO
            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.TipoDireccionModelo> CrearTipoDirecciones(IQueryable<entidad.TIPO_DIRECCION> listadoEntidad)
        {
            List<modelo.TipoDireccionModelo> listaModelo = new List<modelo.TipoDireccionModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearTipoDireccion(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  TIPO GENERO
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.TipoGeneroModelo CrearTipoGenero(entidad.TIPO_GENERO e)
        {
            return new modelo.TipoGeneroModelo
            {
                TipoGeneroId = e.TIPO_GENERO_ID,
                Descripcion = e.DESCRIPCION
               
            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.TipoGeneroModelo> CrearTipoGeneros(IQueryable<entidad.TIPO_GENERO> listadoEntidad)
        {
            List<modelo.TipoGeneroModelo> listaModelo = new List<modelo.TipoGeneroModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearTipoGenero(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  TIPO IDENTIFICACION
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.TipoIdentificacionModelo CrearTipoIdentificacion(entidad.TIPO_IDENTIFICACION e)
        {
            return new modelo.TipoIdentificacionModelo
            {
                TipoIdentificacionId = e.TIPO_IDENTIFICACION_ID,
                Descripcion = e.DESCRIPCION,
                PorDefecto = e.POR_DEFECTO,
                TipoIdentificacionSri = e.TIPO_IDENTIFICACION_SRI_ID

            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.TipoIdentificacionModelo> CrearTipoIdentificaciones(IQueryable<entidad.TIPO_IDENTIFICACION> listadoEntidad)
        {
            List<modelo.TipoIdentificacionModelo> listaModelo = new List<modelo.TipoIdentificacionModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearTipoIdentificacion(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  TIPO PRODUCTO MODELO
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.TipoProductoModelo CrearTipoProducto(entidad.TIPO_PRODUCTO e)
        {
            return new modelo.TipoProductoModelo
            {
                TipoProductoId = e.TIPO_PRODUCTO_ID,
                Descripcion = e.DESCRIPCION

            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.TipoProductoModelo> CrearTipoProductos(IQueryable<entidad.TIPO_PRODUCTO> listadoEntidad)
        {
            List<modelo.TipoProductoModelo> listaModelo = new List<modelo.TipoProductoModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearTipoProducto(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  TIPO ROL INDIVIDUO
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.TipoRolIndividuoModelo CrearTipoRolIndividuo(entidad.TIPO_ROL_INDIVIDUO e)
        {
            return new modelo.TipoRolIndividuoModelo
            {
               TipoRolIndividuoId = e.TIPO_ROL_INDIVIDUO_ID,
                Descripcion = e.DESCRIPCION

            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.TipoRolIndividuoModelo> CrearTipoRolesIndividuo(IQueryable<entidad.TIPO_ROL_INDIVIDUO> listadoEntidad)
        {
            List<modelo.TipoRolIndividuoModelo> listaModelo = new List<modelo.TipoRolIndividuoModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearTipoRolIndividuo(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  TIPO TELEFONO
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.TipoTelefonoModelo CrearTipoTelefono(entidad.TIPO_TELEFONO e)
        {
            return new modelo.TipoTelefonoModelo
            {
               TipoTelefonoId = e.TIPO_TELEFONO_ID,
                Descripcion = e.DESCRIPCION,
                PorDefecto = e.POR_DEFECTO

            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.TipoTelefonoModelo> CrearTipoTelefonos(IQueryable<entidad.TIPO_TELEFONO> listadoEntidad)
        {
            List<modelo.TipoTelefonoModelo> listaModelo = new List<modelo.TipoTelefonoModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearTipoTelefono(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  ETAPA DE PROCESO
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.EtapaProcesoModelo CrearEtapaProceso(entidad.ETAPA_PROCESO e)
        {
            return new modelo.EtapaProcesoModelo
            {
                EtapaProcesoId = e.ETAPA_PROCESO_ID,
                Descripcion=e.DESCRIPCION,
                EstaHabilitado = e.ESTA_HABILITADO,
                HabilitaEnvioMail = e.HABILITA_ENVIO_MAIL

            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.EtapaProcesoModelo> CrearEtapasProceso(IQueryable<entidad.ETAPA_PROCESO> listadoEntidad)
        {
            List<modelo.EtapaProcesoModelo> listaModelo = new List<modelo.EtapaProcesoModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearEtapaProceso(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  FORMA PAGO
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.FormaPagoModelo CrearFormaPago(entidad.FORMA_PAGO e)
        {
            return new modelo.FormaPagoModelo
            {
              FormaPagoId = e.FORMA_PAGO_ID,
              Descripcion = e.DESCRIPCION,
              EstaHabilitado = e.ESTA_HABILITADO

            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.FormaPagoModelo> CrearFormasPago(IQueryable<entidad.FORMA_PAGO> listadoEntidad)
        {
            List<modelo.FormaPagoModelo> listaModelo = new List<modelo.FormaPagoModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearFormaPago(entidad));
            }
            return listaModelo;

        }

        #endregion

        
    }

}