#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using entidad = JLLR.Core.Base.Proveedor.Entidades;
using modelo = JLLR.Core.Individuo.Servicio.Modelo;
using modeloGeneral = JLLR.Core.General.Servicio.Modelo;
#endregion

namespace JLLR.Core.Individuo.Servicio.Ensamblador
{
    /// <summary>
    /// Ingresa una  entidad y lo transforma en un modelo
    /// </summary>
    public class EnsambladorModelo
    {
        #region  INDIVIDUO
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.IndividuoModelo CrearIndividuo(entidad.INDIVIDUO e)
        {
            modeloGeneral.TipoIndividuoModelo _tipoIndividuo= new modeloGeneral.TipoIndividuoModelo();
            _tipoIndividuo.TipoIndividuoId =Convert.ToInt32(e.TIPO_INDIVIDUO_ID);


            modeloGeneral.TipoIdentificacionModelo _tipoIdentificacion = new modeloGeneral.TipoIdentificacionModelo();
            _tipoIdentificacion.TipoIdentificacionId = Convert.ToInt32(e.TIPO_IDENTIFICACION_ID);

         

            return new modelo.IndividuoModelo
            {
                IndividuoId = e.INDIVIDUO_ID,
                TipoIndividuo = _tipoIndividuo,
                TipoIdentificacion = _tipoIdentificacion,
                PrimerCampo = e.PRIMER_CAMPO,
                SegundoCampo = e.SEGUNDO_CAMPO,
                TercerCampo = e.TERCER_CAMPO,
                CuartoCampo = e.CUARTO_CAMPO,
                UsuarioId = e.USUARIO_ID,
                FechaCreacion = e.FECHA_CREACION,
                FechaModificacion = e.FECHA_MODIFICACION,
                NumeroIdentificacion = e.NUMERO_IDENTIFICACION,
                Habilitado = e.HABILITADO

               
            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.IndividuoModelo> CrearIndividuos(IQueryable<entidad.INDIVIDUO> listadoEntidad)
        {
            List<modelo.IndividuoModelo> listaModelo = new List<modelo.IndividuoModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearIndividuo(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  INDIVIDUO ROL
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.IndividuoRolModelo CrearIndividuoRol(entidad.INDIVIDUO_ROL e)
        {
            modeloGeneral.TipoRolIndividuoModelo _tipoRolIndividuo = new modeloGeneral.TipoRolIndividuoModelo()
            {
                TipoRolIndividuoId = Convert.ToInt32(e.TIPO_ROL_INDIVIDUO_ID)
            };

            return new modelo.IndividuoRolModelo()
            {
                IndividuoId = e.INDIVIDUO_ID,
                IndividuoRolId = e.INDIVIDUO_ROL_ID,
                TipoRolIndividuo = _tipoRolIndividuo

            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.IndividuoRolModelo> CrearIndividuoRoles(IQueryable<entidad.INDIVIDUO_ROL> listadoEntidad)
        {
            List<modelo.IndividuoRolModelo> listaModelo = new List<modelo.IndividuoRolModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearIndividuoRol(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  CLIENTE
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.ClienteModelo CrearCliente(entidad.CLIENTE e)
        {
            modelo.IndividuoModelo _individuo = new modelo.IndividuoModelo();
            _individuo.IndividuoId = Convert.ToInt32(e.INDIVIDUO_ID);


            modeloGeneral.TipoGeneroModelo _tipoGenero = new modeloGeneral.TipoGeneroModelo();
            _tipoGenero.TipoGeneroId = Convert.ToInt32(e.TIPO_GENERO_ID);

            return new modelo.ClienteModelo
            {
               ClienteId = e.CLIENTE_ID,
               Individuo = _individuo,
               TipoGenero = _tipoGenero,
               FechaNacimiento = e.FECHA_NACIMIENTO


            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.ClienteModelo> CrearClientes(IQueryable<entidad.CLIENTE> listadoEntidad)
        {
            List<modelo.ClienteModelo> listaModelo = new List<modelo.ClienteModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearCliente(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  CORREO ELECTRONICO
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.CorreoElectronicoModelo CrearCorreoElectronico(entidad.E_MAIL e)
        {
            modelo.IndividuoModelo _individuo = new modelo.IndividuoModelo();
            _individuo.IndividuoId = Convert.ToInt32(e.INDIVIDUO_ID);


            modeloGeneral.TipoCorreoElectronicoModelo _tipoCorreoElectronico= new modeloGeneral.TipoCorreoElectronicoModelo();
            _tipoCorreoElectronico.TipoCorreoElectronicoId = Convert.ToInt32(e.TIPO_CORREO_ELECTRONICO_ID);

            return new modelo.CorreoElectronicoModelo
            {
               CorreoElectronicoId = e.E_MAIL_ID,
               Individuo = _individuo,
               TipoCorreoElectronico = _tipoCorreoElectronico,
               DireccionCorreoElectronico = e.DIRECCION_CORREO_ELECTRONICO


            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.CorreoElectronicoModelo> CrearCorreosElectronico(IQueryable<entidad.E_MAIL> listadoEntidad)
        {
            List<modelo.CorreoElectronicoModelo> listaModelo = new List<modelo.CorreoElectronicoModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearCorreoElectronico(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  DIRECCION
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.DireccionModelo CrearDireccion (entidad.DIRECCION e)
        {
            modelo.IndividuoModelo _individuo = new modelo.IndividuoModelo();
            _individuo.IndividuoId = Convert.ToInt32(e.INDIVIDUO_ID);


            modeloGeneral.TipoDireccionModelo _tipoDireccion = new modeloGeneral.TipoDireccionModelo();
            _tipoDireccion.TipoDireccionId = Convert.ToInt32(e.TIPO_DIRECCION_ID);

            modeloGeneral.PaisModelo _pais = new modeloGeneral.PaisModelo();
            _pais.PaisId = Convert.ToInt32(e.PAIS_ID);

            modeloGeneral.EstadoModelo _estado = new modeloGeneral.EstadoModelo();
            _estado.EstadoId = Convert.ToInt32(e.ESTADO_ID);

            modeloGeneral.CiudadModelo _ciudad = new modeloGeneral.CiudadModelo();
            _ciudad.CiudadId = Convert.ToInt32(e.CIUDAD_ID);

            return new modelo.DireccionModelo
            {
               DireccionId = e.DIRECCION_ID,
               Individuo =_individuo,
               DescripcionDireccion = e.DESCRIPCION_DIRECCION,
               TipoDireccion = _tipoDireccion,
               Pais = _pais,
               Ciudad = _ciudad,
               Estado =_estado
               

            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.DireccionModelo> CrearDirecciones(IQueryable<entidad.DIRECCION> listadoEntidad)
        {
            List<modelo.DireccionModelo> listaModelo = new List<modelo.DireccionModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearDireccion(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  TELEFONO
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.TelefonoModelo CrearTelefono(entidad.TELEFONO e)
        {
            modelo.IndividuoModelo _individuo = new modelo.IndividuoModelo();
            _individuo.IndividuoId = Convert.ToInt32(e.INDIVIDUO_ID);


            modeloGeneral.TipoTelefonoModelo _tipoTelefono = new modeloGeneral.TipoTelefonoModelo();
            _tipoTelefono.TipoTelefonoId = Convert.ToInt32(e.TIPO_TELEFONO_ID);

            return new modelo.TelefonoModelo
            {
               TelefonoId = e.TELEFONO_ID,
               Individuo = _individuo,
               TipoTelefono = _tipoTelefono,
               NumeroTelefono = e.NUMERO_TELEFONO


            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.TelefonoModelo> CrearTelefonos(IQueryable<entidad.TELEFONO> listadoEntidad)
        {
            List<modelo.TelefonoModelo> listaModelo = new List<modelo.TelefonoModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearTelefono(entidad));
            }
            return listaModelo;

        }

        #endregion
    }
}