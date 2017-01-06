#region using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Base;
using Web.DTOs.Individuo;
using Web.Models.General;
using Web.Models.Individuo;
using Web.ServicioDelegado;

#endregion

namespace Web.Individuo
{
    public partial class Cliente : PaginaBase
    {
        #region Declaracion  e instancias

        private readonly ServicioDelegadoGeneral _servicioDelegadoGeneral = new ServicioDelegadoGeneral();
        private readonly ServicioDelegadoIndividuo _servicioDelegadoIndividuo = new ServicioDelegadoIndividuo();


        #endregion

        #region Eventos

        /// <summary>
        ///  Valida si el numero de documento existe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _numeroDocumento_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (_servicioDelegadoIndividuo.ValidarExistenciaClientePorNumeroIdentificacion(_numeroDocumento.Text))
                {
                    _numeroDocumento.Text = string.Empty;
                    Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Cliente_Existe").ToString(), "_grabarCliente");
                    _numeroDocumento.Focus();
                }

            }
            catch (Exception)
            {
                
                throw;
            }
        }
        /// <summary>
        /// Grabar  cliente 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _grabarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                ClienteGeneralVistaDTOs _clienteGeneralVistaDtOs= new ClienteGeneralVistaDTOs();

                #region individuo 
                //Individuo
                IndividuoVistaModelo _individuoVistaModelo= new IndividuoVistaModelo();

                TipoIdentificacionVistaModelo _tipoIdentificacionVistaModelo= new TipoIdentificacionVistaModelo();
                _tipoIdentificacionVistaModelo.TipoIdentificacionId = Convert.ToInt32(_tipoDocumento.SelectedItem.Value);
                _individuoVistaModelo.TipoIdentificacion = _tipoIdentificacionVistaModelo;

                TipoIndividuoVistaModelo _tipoIndividuoVistaModelo= new TipoIndividuoVistaModelo();
                _tipoIndividuoVistaModelo.TipoIndividuoId = Convert.ToInt32(Util.TipoIndividuo.PersonaNatural);
                _individuoVistaModelo.TipoIndividuo = _tipoIndividuoVistaModelo;

              
                _individuoVistaModelo.PrimerCampo = _apellidoPaterno.Text;
                _individuoVistaModelo.SegundoCampo = _apellidoMaterno.Text;
                _individuoVistaModelo.TercerCampo= _primerNombre.Text;
                _individuoVistaModelo.CuartoCampo = _segundoNombre.Text;
                _individuoVistaModelo.NumeroIdentificacion = _numeroDocumento.Text;
                _individuoVistaModelo.Habilitado = true;
                _individuoVistaModelo.FechaCreacion = DateTime.Now;
                _individuoVistaModelo.FechaModificacion = DateTime.Now;
                _individuoVistaModelo.UsuarioId = User.Id;

                _clienteGeneralVistaDtOs.Individuo = _individuoVistaModelo;
                #endregion

                #region Direccion
                //Direccion

                DireccionVistaModelo _direccionVistaModelo= new DireccionVistaModelo();

                PaisVistaModelo _paisVistaModelo= new PaisVistaModelo();
                _paisVistaModelo.PaisId = Convert.ToInt32(_pais.SelectedItem.Value);

                EstadoVistaModelo _estadoVistaModelo= new  EstadoVistaModelo();
                _estadoVistaModelo.EstadoId= Convert.ToInt32(_provincia.SelectedItem.Value);

                CiudadVistaModelo _ciudadVistaModelo= new CiudadVistaModelo();
                _ciudadVistaModelo.CiudadId = Convert.ToInt32(_ciudad.SelectedItem.Value);


                TipoDireccionVistaModelo _tipoDireccionVistaModelo= new TipoDireccionVistaModelo();
                _tipoDireccionVistaModelo.TipoDireccionId = Convert.ToInt32(_tipoDireccion.SelectedItem.Value);

                _direccionVistaModelo.Individuo = _individuoVistaModelo;
                _direccionVistaModelo.DescripcionDireccion = _direccion.Text;
                _direccionVistaModelo.Pais = _paisVistaModelo;
                _direccionVistaModelo.Estado = _estadoVistaModelo;
                _direccionVistaModelo.Ciudad = _ciudadVistaModelo;
                _direccionVistaModelo.TipoDireccion = _tipoDireccionVistaModelo;

                _clienteGeneralVistaDtOs.Direccion = _direccionVistaModelo;
                #endregion

                #region  Telefono y Email
                TelefonoVistaModelo _telefonoVistaModelo = new TelefonoVistaModelo();
                CorreoElectronicoVistaModelo _correoElectronicoVistaModelo= new CorreoElectronicoVistaModelo();
                TipoTelefonoVistaModelo _tipoTelefonoVistaModelo= new TipoTelefonoVistaModelo();
                TipoCorreoElectronicoVistaModelo _tipoCorreoElectronicoVistaModelo= new TipoCorreoElectronicoVistaModelo();

                _tipoTelefonoVistaModelo.TipoTelefonoId = Convert.ToInt32(_tipoTelefono.SelectedItem.Value);
                _tipoCorreoElectronicoVistaModelo.TipoCorreoElectronicoId =
                    Convert.ToInt32(_tipoCorreo.SelectedItem.Value);


                _telefonoVistaModelo.TipoTelefono = _tipoTelefonoVistaModelo;
                _telefonoVistaModelo.Individuo = _individuoVistaModelo;
                _telefonoVistaModelo.NumeroTelefono = _telefono.Text;
                _clienteGeneralVistaDtOs.Telefono = _telefonoVistaModelo;

                _correoElectronicoVistaModelo.TipoCorreoElectronico = _tipoCorreoElectronicoVistaModelo;
                _correoElectronicoVistaModelo.Individuo = _individuoVistaModelo;
                _correoElectronicoVistaModelo.DireccionCorreoElectronico = _email.Text;
                _clienteGeneralVistaDtOs.CorreoElectronico = _correoElectronicoVistaModelo;



                #endregion

                #region Cliente
                ClienteVistaModelo _clienteVistaModelo= new ClienteVistaModelo();
                TipoGeneroVistaModelo _tipoGeneroVistaModelo= new TipoGeneroVistaModelo();
                _tipoGeneroVistaModelo.TipoGeneroId = Convert.ToInt32(_genero.SelectedItem.Value);
                _clienteVistaModelo.TipoGenero = _tipoGeneroVistaModelo;
                _clienteVistaModelo.Individuo = _individuoVistaModelo;
                _clienteVistaModelo.FechaNacimiento = Convert.ToDateTime(_fechaNacimiento.Text);
                _clienteGeneralVistaDtOs.Cliente = _clienteVistaModelo;

                #endregion

                #region Individuo Rol
                IndividuoRolVistaModelo _individuoRolVistaModelo= new IndividuoRolVistaModelo();
                TipoRolIndividuoVistaModelo _tipoRolIndividuoVistaModelo= new TipoRolIndividuoVistaModelo();
                _tipoRolIndividuoVistaModelo.TipoRolIndividuoId = Convert.ToInt32(Util.TipoRolIndividuo.Cliente);
                _individuoRolVistaModelo.TipoRolIndividuo = _tipoRolIndividuoVistaModelo;
                _clienteGeneralVistaDtOs.IndividuoRol = _individuoRolVistaModelo;
                
                #endregion

                _servicioDelegadoIndividuo.GrabarCliente(_clienteGeneralVistaDtOs);
                LimpiarControles();
                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Exitoso").ToString(), "_grabarCliente");

            }
            catch (Exception ex)
            {

                throw;
            }

        }


        /// <summary>
        /// Carga las ciudades por el pais y la provincia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _provincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _ciudad.DataSource =
                    _servicioDelegadoGeneral.ObtenerCiudadPorPaisIdYEstadoId(Convert.ToInt32(_pais.SelectedItem.Value),
                        Convert.ToInt32(_provincia.SelectedItem.Value));
                _ciudad.DataBind();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Load de la pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    CargarDatos();
                }
            }
            catch (Exception)
            {

                throw;
            }


        }

        protected void _cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Inicio/Default.aspx");
            }
            catch (Exception ex)
            {
            }

        }

        #endregion

        #region Metodos

        /// <summary>
        /// Carga los datos de la pagina web
        /// </summary>
        private void CargarDatos()
        {
            try
            {
                _tipoDocumento.DataSource = _servicioDelegadoGeneral.ObtenerTipoIdentificaciones();
                _tipoDocumento.DataBind();
                _genero.DataSource = _servicioDelegadoGeneral.ObtenerTipoGeneros();
                _genero.DataBind();
                _pais.DataSource = _servicioDelegadoGeneral.ObtenerPaises();
                _pais.DataBind();
                _provincia.DataSource =
                    _servicioDelegadoGeneral.ObtenerEstadoPorPaisId(Convert.ToInt32(_pais.SelectedItem.Value));
                _provincia.DataBind();
                _ciudad.DataSource =
                    _servicioDelegadoGeneral.ObtenerCiudadPorPaisIdYEstadoId(Convert.ToInt32(_pais.SelectedItem.Value),
                        Convert.ToInt32(_provincia.SelectedItem.Value));
                _ciudad.DataBind();
                _tipoDireccion.DataSource = _servicioDelegadoGeneral.ObtenerTipoDirecciones();
                _tipoDireccion.DataBind();
                _tipoCorreo.DataSource = _servicioDelegadoGeneral.ObtenerTiposCorreoElectronico();
                _tipoCorreo.DataBind();
                _tipoTelefono.DataSource = _servicioDelegadoGeneral.ObtenerTiposTelefonos();
                _tipoTelefono.DataBind();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        /// <summary>
        /// Despliega  los mensajes    de las diferentes acciones de las  pantallas
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="boton"></param>
        private void Mensajes(string texto, string boton)
        {

            _labelMensaje.Text = texto;
            _btnMensaje_ModalPopupExtender.TargetControlID = boton;
            _btnMensaje_ModalPopupExtender.Show();
        }


        /// <summary>
        /// Limpia los controles  y carga los datos nuevamente
        /// </summary>
        public void LimpiarControles()
        {

            _numeroDocumento.Text = string.Empty;
            _apellidoMaterno.Text = string.Empty;
            _apellidoPaterno.Text = string.Empty;
            _primerNombre.Text = string.Empty;
            _segundoNombre.Text = string.Empty;
            _numeroDocumento.Text = string.Empty;
            _fechaNacimiento.Text = string.Empty;
            _direccion.Text = string.Empty;
            _email.Text = string.Empty;
            _telefono.Text = string.Empty;
            CargarDatos();
        }


        #endregion

       
    }
}