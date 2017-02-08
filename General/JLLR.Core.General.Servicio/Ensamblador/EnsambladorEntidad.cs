#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using entidad = JLLR.Core.Base.Proveedor.Entidades;
using modelo= JLLR.Core.General.Servicio.Modelo;
#endregion
namespace JLLR.Core.General.Servicio.Ensamblador
{
    public class EnsambladorEntidad
    {
        

        #region COLOR
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.COLOR CrearColor(modelo.ColorModelo m)
        {
            return new entidad.COLOR()
            {
                COLOR_ID = m.ColorId,
                DESCRIPCION = m.Descripcion,
                ESTA_HABILITADO = m.EstaHabilitado
            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.COLOR> CrearColores(List<modelo.ColorModelo> listadoModelo)
        {
            List<entidad.COLOR> listaEntidad = new List<entidad.COLOR>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearColor(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region MARCA
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.MARCA CrearMarca(modelo.MarcaModelo m)
        {
            return new entidad.MARCA()
            {
                MARCA_ID = m.MarcaId,
                DESCRIPCION = m.Descripcion,
                ESTA_HABILITADO = m.EstaHabilitado

            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.MARCA> CrearMarcas(List<modelo.MarcaModelo> listadoModelo)
        {
            List<entidad.MARCA> listaEntidad = new List<entidad.MARCA>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearMarca(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region MATERIAL
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.MATERIAL CrearMaterial(modelo.MaterialModelo m)
        {
            return new entidad.MATERIAL()
            {
                MATERIAL_ID = m.MaterialId,
                DESCRIPCION = m.Descripcion,
                ESTA_HABILITADO = m.EstaHabilitado

            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.MATERIAL> CrearMateriales(List<modelo.MaterialModelo> listadoModelo)
        {
            List<entidad.MATERIAL> listaEntidad = new List<entidad.MATERIAL>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearMaterial(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region MODELO
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.MODELO CrearModelo(modelo.ModeloModelo m)
        {
            return new entidad.MODELO()
            {
                MODELO_ID = m.ModeloId,
                DESCRIPCION = m.Descripcion,
                ESTA_HABILITADO = m.EstaHabilitado


            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.MODELO> CrearModelos(List<modelo.ModeloModelo> listadoModelo)
        {
            List<entidad.MODELO> listaEntidad = new List<entidad.MODELO>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearModelo(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region TIPO DE LAVADO
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.TIPO_LAVADO CrearTipoLavado(modelo.TipoLavadoModelo m)
        {
            return new entidad.TIPO_LAVADO()
            {
               TIPO_LAVADO_ID=m.TipoLavadoId,
               DESCRIPCION=m.Descripcion,
               ESTA_HABILITADO=m.EstaHabilitado,
               
            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.TIPO_LAVADO> CrearTiposLavado(List<modelo.TipoLavadoModelo> listadoModelo)
        {
            List<entidad.TIPO_LAVADO> listaEntidad = new List<entidad.TIPO_LAVADO>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearTipoLavado(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region CIUDAD
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.CIUDAD CrearCiudad(modelo.CiudadModelo m)
        {
            return new entidad.CIUDAD()
            {
               PAIS_ID = m.PaisId,
               CIUDAD_ID = m.CiudadId,
               ESTADO_ID = m.EstadoId,
               DESCRIPCION = m.Descripcion

            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.CIUDAD> CrearCiudades(List<modelo.CiudadModelo> listadoModelo)
        {
            List<entidad.CIUDAD> listaEntidad = new List<entidad.CIUDAD>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearCiudad(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region ESTADO
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.ESTADO CrearEstado(modelo.EstadoModelo m)
        {
            return new entidad.ESTADO()
            {
               ESTADO_ID = m.EstadoId,
               PAIS_ID = m.PaisId,
               DESCRIPCION = m.Descripcion

            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.ESTADO> CrearEstados(List<modelo.EstadoModelo> listadoModelo)
        {
            List<entidad.ESTADO> listaEntidad = new List<entidad.ESTADO>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearEstado(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region ESTADO PAGO
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.ESTADO_PAGO CrearEstadoPago(modelo.EstadoPagoModelo m)
        {
            return new entidad.ESTADO_PAGO()
            {
                ESTADO_PAGO_ID = m.EstadoPagoId,
                DESCRIPCION = m.Descripcion

            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.ESTADO_PAGO> CrearEstadosPago(List<modelo.EstadoPagoModelo> listadoModelo)
        {
            List<entidad.ESTADO_PAGO> listaEntidad = new List<entidad.ESTADO_PAGO>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearEstadoPago(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region IMPUESTO
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.IMPUESTO CrearImpuesto(modelo.ImpuestoModelo m)
        {
            return new entidad.IMPUESTO()
            {
                IMPUESTO_ID = m.ImpuestoId,
                DESCRIPCION = m.Descripcion,
                ESTA_HABILITADO = m.EstaHabilitado,
                FECHA_CREACION = m.FechaCreacion

            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.IMPUESTO> CrearImpuestos(List<modelo.ImpuestoModelo> listadoModelo)
        {
            List<entidad.IMPUESTO> listaEntidad = new List<entidad.IMPUESTO>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearImpuesto(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region PAIS
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.PAIS CrearPais(modelo.PaisModelo m)
        {
            return new entidad.PAIS()
            {
              PAIS_ID = m.PaisId,
              DESCRIPCION = m.Descripcion,
              POR_DEFECTO = m.PorDefecto

            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.PAIS> CrearPaises(List<modelo.PaisModelo> listadoModelo)
        {
            List<entidad.PAIS> listaEntidad = new List<entidad.PAIS>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearPais(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region PUNTO DE VENTA 
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.PUNTO_VENTA CrearPuntoVenta(modelo.PuntoVentaModelo m)
        {
            return new entidad.PUNTO_VENTA()
            {
               PUNTO_VENTA_ID = m.PuntoVentaId,
               DESCRIPCION = m.Descripcion,
               HORA_FIN = m.HoraFin,
               HORA_INICIO = m.HoraInicio

            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.PUNTO_VENTA> CrearPuntosVenta(List<modelo.PuntoVentaModelo> listadoModelo)
        {
            List<entidad.PUNTO_VENTA> listaEntidad = new List<entidad.PUNTO_VENTA>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearPuntoVenta(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region SUCURSAL
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.SUCURSAL CrearSucursal(modelo.SucursalModelo m)
        {
            return new entidad.SUCURSAL()
            {
               SUCURSAL_ID = m.SucursalId,
               DESCRIPCION = m.Descripcion,
               ESTA_HABILITADO = m.EstaHabilitado

            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.SUCURSAL> CrearSucursales(List<modelo.SucursalModelo> listadoModelo)
        {
            List<entidad.SUCURSAL> listaEntidad = new List<entidad.SUCURSAL>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearSucursal(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region TIPO CORREO ELECTRONICO
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.TIPO_CORREO_ELECTRONICO CrearTipoCorreoElectronico(modelo.TipoCorreoElectronicoModelo m)
        {
            return new entidad.TIPO_CORREO_ELECTRONICO()
            {
                TIPO_CORREO_ELECTRONICO_ID = m.TipoCorreoElectronicoId,
                DESCRIPCION = m.Descripcion,
                POR_DEFECTO=m.PorDefecto

            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.TIPO_CORREO_ELECTRONICO> CrearTiposCorreoElectronico(List<modelo.TipoCorreoElectronicoModelo> listadoModelo)
        {
            List<entidad.TIPO_CORREO_ELECTRONICO> listaEntidad = new List<entidad.TIPO_CORREO_ELECTRONICO>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearTipoCorreoElectronico(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region TIPO DIRECCION
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.TIPO_DIRECCION CrearTipoDireccion(modelo.TipoDireccionModelo m)
        {
            return new entidad.TIPO_DIRECCION()
            {
               TIPO_DIRECCION_ID = m.TipoDireccionId,
               DESCRIPCION = m.Descripcion,
               POR_DEFECTO = m.PorDefecto

            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.TIPO_DIRECCION> CrearTiposDireccion(List<modelo.TipoDireccionModelo> listadoModelo)
        {
            List<entidad.TIPO_DIRECCION> listaEntidad = new List<entidad.TIPO_DIRECCION>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearTipoDireccion(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region TIPO GENERO
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.TIPO_GENERO CrearTipoGenero(modelo.TipoGeneroModelo m)
        {
            return new entidad.TIPO_GENERO()
            {
              TIPO_GENERO_ID = m.TipoGeneroId,
              DESCRIPCION = m.Descripcion,
              

            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.TIPO_GENERO> CrearTiposGenero(List<modelo.TipoGeneroModelo> listadoModelo)
        {
            List<entidad.TIPO_GENERO> listaEntidad = new List<entidad.TIPO_GENERO>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearTipoGenero(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region TIPO IDENTIFICACION 
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.TIPO_IDENTIFICACION CrearTipoIdentificacion(modelo.TipoIdentificacionModelo m)
        {
            return new entidad.TIPO_IDENTIFICACION()
            {
               TIPO_IDENTIFICACION_ID = m.TipoIdentificacionId,
               DESCRIPCION = m.Descripcion,
               POR_DEFECTO = m.PorDefecto


            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.TIPO_IDENTIFICACION> CrearTipoIdentificaciones(List<modelo.TipoIdentificacionModelo> listadoModelo)
        {
            List<entidad.TIPO_IDENTIFICACION> listaEntidad = new List<entidad.TIPO_IDENTIFICACION>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearTipoIdentificacion(modelo));
            }
            return listaEntidad;
        
        }
        #endregion

        #region TIPO PRODUCTO 
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.TIPO_PRODUCTO CrearTipoProducto(modelo.TipoProductoModelo m)
        {
            return new entidad.TIPO_PRODUCTO()
            {
               TIPO_PRODUCTO_ID = m.TipoProductoId,
               DESCRIPCION = m.Descripcion


            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.TIPO_PRODUCTO> CrearTipoProductos(List<modelo.TipoProductoModelo> listadoModelo)
        {
            List<entidad.TIPO_PRODUCTO> listaEntidad = new List<entidad.TIPO_PRODUCTO>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearTipoProducto(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region TIPO ROL INDIVIDUO 
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.TIPO_ROL_INDIVIDUO CrearTipoRolIndividuo(modelo.TipoRolIndividuoModelo m)
        {
            return new entidad.TIPO_ROL_INDIVIDUO()
            {
                TIPO_ROL_INDIVIDUO_ID = m.TipoRolIndividuoId,
                DESCRIPCION = m.Descripcion
             


            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.TIPO_ROL_INDIVIDUO> CrearTipoRolesIndividuo(List<modelo.TipoRolIndividuoModelo> listadoModelo)
        {
            List<entidad.TIPO_ROL_INDIVIDUO> listaEntidad = new List<entidad.TIPO_ROL_INDIVIDUO>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearTipoRolIndividuo(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region TIPO TELEFONO
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.TIPO_TELEFONO CrearTipoTelefono(modelo.TipoTelefonoModelo m)
        {
            return new entidad.TIPO_TELEFONO()
            {
                TIPO_TELEFONO_ID = m.TipoTelefonoId,
                DESCRIPCION = m.Descripcion,
                POR_DEFECTO = m.PorDefecto



            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.TIPO_TELEFONO> CrearTipoTelefonos(List<modelo.TipoTelefonoModelo> listadoModelo)
        {
            List<entidad.TIPO_TELEFONO> listaEntidad = new List<entidad.TIPO_TELEFONO>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearTipoTelefono(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region ETAPA PROCESO
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.ETAPA_PROCESO CrearEtapaProceso(modelo.EtapaProcesoModelo m)
        {
            return new entidad.ETAPA_PROCESO()
            {
             ETAPA_PROCESO_ID = m.EtapaProcesoId,
             DESCRIPCION = m.Descripcion,
             ESTA_HABILITADO = m.EstaHabilitado,
             HABILITA_ENVIO_MAIL = m.HabilitaEnvioMail
             
            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.ETAPA_PROCESO> CrearEtapasProceso(List<modelo.EtapaProcesoModelo> listadoModelo)
        {
            List<entidad.ETAPA_PROCESO> listaEntidad = new List<entidad.ETAPA_PROCESO>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearEtapaProceso(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region FORMA DE  PAGO
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.FORMA_PAGO CrearFormaPago(modelo.FormaPagoModelo m)
        {
            return new entidad.FORMA_PAGO()
            {
                FORMA_PAGO_ID = m.FormaPagoId,
                DESCRIPCION = m.Descripcion,
                ESTA_HABILITADO = m.EstaHabilitado

            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.FORMA_PAGO> CrearFormasPago(List<modelo.FormaPagoModelo> listadoModelo)
        {
            List<entidad.FORMA_PAGO> listaEntidad = new List<entidad.FORMA_PAGO>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearFormaPago(modelo));
            }
            return listaEntidad;

        }
        #endregion

        
    }
}