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
using Web.Util;

#endregion

namespace Web.Individuo
{
    public partial class Cliente : PaginaBase
    {
        #region Declaracion  e instancias

        private readonly ServicioDelegadoGeneral _servicioDelegadoGeneral = new ServicioDelegadoGeneral();
        private readonly ServicioDelegadoIndividuo _servicioDelegadoIndividuo = new ServicioDelegadoIndividuo();
        private static bool _banderaActualizacion=false;
        private static ClienteGeneralVistaDTOs _clienteGeneralVistaDtOs = null;
        private Validacion _validacion= new Validacion();
        #endregion

        #region Eventos

        /// <summary>
        /// Valida el numero de  digitos  que se ingresa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _tipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_tipoDocumento.SelectedItem.Value == "3")
                    _numeroDocumento.MaxLength = 10;
                else if (_tipoDocumento.SelectedItem.Value == "1")
                    _numeroDocumento.MaxLength = 13;
                else
                    _numeroDocumento.MaxLength = 20;
                _numeroDocumento.Text=String.Empty;


            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// Carga la parroquia  dependeiendo del pais, provincia  y  canton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _ciudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _parroquia.DataSource = _servicioDelegadoGeneral.ObtenerParroquiasPorVariosParametros(Convert.ToInt32(_pais.SelectedItem.Value), Convert.ToInt32(_ciudad.SelectedItem.Value), Convert.ToInt32(_provincia.SelectedItem.Value));
                _parroquia.DataBind();

            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarCliente");
            }
        }
        /// <summary>
        /// busca  un cliente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _btnBusquedaCliente_Click(object sender, EventArgs e)
        {
            try
            {
                 _clienteGeneralVistaDtOs =
                    _servicioDelegadoIndividuo.ObtenerClientePorNumeroIdentificacion(_numeroDocumentoBusqueda.Text.ToUpper());

                if (_clienteGeneralVistaDtOs != null)
                {

                    _apellidoPaterno.Text = _clienteGeneralVistaDtOs.Individuo.PrimerCampo;
                    _apellidoMaterno.Text = _clienteGeneralVistaDtOs.Individuo.SegundoCampo;
                    _primerNombre.Text = _clienteGeneralVistaDtOs.Individuo.TercerCampo;
                    _segundoNombre.Text = _clienteGeneralVistaDtOs.Individuo.CuartoCampo;
                    _numeroDocumento.Text = _clienteGeneralVistaDtOs.Individuo.NumeroIdentificacion;
                    _fechaNacimiento.Text = _clienteGeneralVistaDtOs.Cliente.FechaNacimiento.Value.ToShortDateString();
                    _direccion.Text = _clienteGeneralVistaDtOs.Direccion.DescripcionDireccion;
                    _email.Text = _clienteGeneralVistaDtOs.CorreoElectronico.DireccionCorreoElectronico;
                    _telefono.Text = _clienteGeneralVistaDtOs.Telefono.NumeroTelefono;
                    _tipoDocumento.SelectedIndex =
                        _tipoDocumento.Items.IndexOf(
                            _tipoDocumento.Items.FindByValue(
                                _clienteGeneralVistaDtOs.Individuo.TipoIdentificacion.TipoIdentificacionId.ToString()));
                    _genero.SelectedIndex =
                        _genero.Items.IndexOf(
                            _genero.Items.FindByValue(
                                _clienteGeneralVistaDtOs.Cliente.TipoGenero.TipoGeneroId.ToString()));
                    _pais.SelectedIndex =
                        _pais.Items.IndexOf(
                            _pais.Items.FindByValue(_clienteGeneralVistaDtOs.Direccion.Pais.PaisId.ToString()));
                    _provincia.SelectedIndex =
                        _provincia.Items.IndexOf(
                            _provincia.Items.FindByValue(_clienteGeneralVistaDtOs.Direccion.Estado.EstadoId.ToString()));
                    _ciudad.DataSource =
                        _servicioDelegadoGeneral.ObtenerCiudadPorPaisIdYEstadoId(
                            Convert.ToInt32(_pais.SelectedItem.Value),
                            Convert.ToInt32(_provincia.SelectedItem.Value));
                    _ciudad.DataBind();
                    _ciudad.SelectedIndex =
                        _ciudad.Items.IndexOf(
                            _ciudad.Items.FindByValue(_clienteGeneralVistaDtOs.Direccion.Ciudad.CiudadId.ToString()));


                    _parroquia.DataSource =
                        _servicioDelegadoGeneral.ObtenerParroquiasPorVariosParametros(
                            _clienteGeneralVistaDtOs.Direccion.Pais.PaisId, _clienteGeneralVistaDtOs.Direccion.Ciudad.CiudadId, _clienteGeneralVistaDtOs.Direccion.Estado.EstadoId);
                    _parroquia.DataBind();
                    _parroquia.SelectedIndex =
                        _parroquia.Items.IndexOf(
                            _parroquia.Items.FindByValue(_clienteGeneralVistaDtOs.Direccion.Parroquia.ParroquiaId.ToString()));


                    _tipoDireccion.SelectedIndex =
                        _tipoDireccion.Items.IndexOf(
                            _tipoDireccion.Items.FindByValue(
                                _clienteGeneralVistaDtOs.Direccion.TipoDireccion.TipoDireccionId.ToString()));
                    _tipoCorreo.SelectedIndex =
                        _tipoCorreo.Items.IndexOf(
                            _tipoCorreo.Items.FindByValue(
                                _clienteGeneralVistaDtOs.CorreoElectronico.TipoCorreoElectronico.TipoCorreoElectronicoId
                                    .ToString()));
                    _tipoTelefono.SelectedIndex =
                        _tipoTelefono.Items.IndexOf(
                            _tipoTelefono.Items.FindByValue(
                                _clienteGeneralVistaDtOs.Telefono.TipoTelefono.TipoTelefonoId.ToString()));
                    _tipoDocumento.Enabled = false;
                    _numeroDocumento.Enabled = false;
                    _banderaActualizacion = true;

                }
                else
                {
                    LimpiarControles();
                    Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Informacion_No_existe").ToString(), "_grabarCliente");
                }
                

            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarCliente");
            }
        }

        /// <summary>
        ///  Valida si el numero de documento existe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _numeroDocumento_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (_tipoDocumento.SelectedItem.Value == "3")
                {
                    if (_validacion.ValidacionCedula(_numeroDocumento.Text) != true)
                    {
                        Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Cedula_No_Valida").ToString(),
                            "_grabarCliente");
                        _numeroDocumento.Text = String.Empty;
                        _numeroDocumento.Focus();
                    }
                    else
                    {
                        if (_servicioDelegadoIndividuo.ValidarExistenciaClientePorNumeroIdentificacion(_numeroDocumento.Text.ToUpper()))
                        {
                            _numeroDocumento.Text = string.Empty;
                            Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Cliente_Existe").ToString(), "_grabarCliente");
                            _numeroDocumento.Focus();
                            _numeroDocumento.Focus();
                        }
                    }

                }
                else if (_tipoDocumento.SelectedItem.Value == "1")
                {
                    if (_validacion.ValidaPersonaNatural(_numeroDocumento.Text) != true)
                    {
                        Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_RUC_Persona_Natural_No_Valido").ToString(),
                            "_grabarCliente");
                        _numeroDocumento.Text = String.Empty;
                        _numeroDocumento.Focus();
                    }
                    else
                    {
                        if (_servicioDelegadoIndividuo.ValidarExistenciaClientePorNumeroIdentificacion(_numeroDocumento.Text.ToUpper()))
                        {
                            _numeroDocumento.Text = string.Empty;
                            Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Cliente_Existe").ToString(), "_grabarCliente");
                            _numeroDocumento.Focus();
                        }
                    }
                }
                else
                {
                    if (
                        _servicioDelegadoIndividuo.ValidarExistenciaClientePorNumeroIdentificacion(
                            _numeroDocumento.Text.ToUpper()))
                    {
                        _numeroDocumento.Text = string.Empty;
                        Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Cliente_Existe").ToString(),
                            "_grabarCliente");
                        _numeroDocumento.Focus();
                    }
                }


            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarCliente");
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

                if (_banderaActualizacion == false)
                {
                    _clienteGeneralVistaDtOs = new ClienteGeneralVistaDTOs();


                    #region individuo 

                    //Individuo
                    IndividuoVistaModelo _individuoVistaModelo = new IndividuoVistaModelo();

                    TipoIdentificacionVistaModelo _tipoIdentificacionVistaModelo = new TipoIdentificacionVistaModelo();
                    _tipoIdentificacionVistaModelo.TipoIdentificacionId =
                        Convert.ToInt32(_tipoDocumento.SelectedItem.Value);
                    _individuoVistaModelo.TipoIdentificacion = _tipoIdentificacionVistaModelo;

                    TipoIndividuoVistaModelo _tipoIndividuoVistaModelo = new TipoIndividuoVistaModelo();
                    _tipoIndividuoVistaModelo.TipoIndividuoId = Convert.ToInt32(Util.TipoIndividuo.PersonaNatural);
                    _individuoVistaModelo.TipoIndividuo = _tipoIndividuoVistaModelo;


                    _individuoVistaModelo.PrimerCampo = _apellidoPaterno.Text.ToUpper();
                    _individuoVistaModelo.SegundoCampo = _apellidoMaterno.Text.ToUpper();
                    _individuoVistaModelo.TercerCampo = _primerNombre.Text.ToUpper();
                    _individuoVistaModelo.CuartoCampo = _segundoNombre.Text.ToUpper();
                    _individuoVistaModelo.NumeroIdentificacion = _numeroDocumento.Text.ToUpper();
                    _individuoVistaModelo.Habilitado = true;
                    _individuoVistaModelo.FechaCreacion = DateTime.Now;
                    _individuoVistaModelo.FechaModificacion = DateTime.Now;
                    _individuoVistaModelo.UsuarioId = User.Id;

                    _clienteGeneralVistaDtOs.Individuo = _individuoVistaModelo;

                    #endregion

                    #region Direccion

                    //Direccion

                    DireccionVistaModelo _direccionVistaModelo = new DireccionVistaModelo();

                    PaisVistaModelo _paisVistaModelo = new PaisVistaModelo();
                    _paisVistaModelo.PaisId = Convert.ToInt32(_pais.SelectedItem.Value);

                    EstadoVistaModelo _estadoVistaModelo = new EstadoVistaModelo();
                    _estadoVistaModelo.EstadoId = Convert.ToInt32(_provincia.SelectedItem.Value);

                    CiudadVistaModelo _ciudadVistaModelo = new CiudadVistaModelo();
                    _ciudadVistaModelo.CiudadId = Convert.ToInt32(_ciudad.SelectedItem.Value);

                    ParroquiaVistaModelo _parroquiaVistaModelo= new ParroquiaVistaModelo();
                    _parroquiaVistaModelo.ParroquiaId = Convert.ToInt32(_parroquia.SelectedItem.Value);


                    TipoDireccionVistaModelo _tipoDireccionVistaModelo = new TipoDireccionVistaModelo();
                    _tipoDireccionVistaModelo.TipoDireccionId = Convert.ToInt32(_tipoDireccion.SelectedItem.Value);

                    _direccionVistaModelo.Individuo = _individuoVistaModelo;
                    _direccionVistaModelo.DescripcionDireccion = _direccion.Text.ToUpper();
                    _direccionVistaModelo.Pais = _paisVistaModelo;
                    _direccionVistaModelo.Estado = _estadoVistaModelo;
                    _direccionVistaModelo.Ciudad = _ciudadVistaModelo;
                    _direccionVistaModelo.TipoDireccion = _tipoDireccionVistaModelo;
                    _direccionVistaModelo.Parroquia = _parroquiaVistaModelo;
                    _clienteGeneralVistaDtOs.Direccion = _direccionVistaModelo;

                    #endregion

                    #region  Telefono y Email

                    TelefonoVistaModelo _telefonoVistaModelo = new TelefonoVistaModelo();
                    CorreoElectronicoVistaModelo _correoElectronicoVistaModelo = new CorreoElectronicoVistaModelo();
                    TipoTelefonoVistaModelo _tipoTelefonoVistaModelo = new TipoTelefonoVistaModelo();
                    TipoCorreoElectronicoVistaModelo _tipoCorreoElectronicoVistaModelo =
                        new TipoCorreoElectronicoVistaModelo();

                    _tipoTelefonoVistaModelo.TipoTelefonoId = Convert.ToInt32(_tipoTelefono.SelectedItem.Value);
                    _tipoCorreoElectronicoVistaModelo.TipoCorreoElectronicoId =
                        Convert.ToInt32(_tipoCorreo.SelectedItem.Value);


                    _telefonoVistaModelo.TipoTelefono = _tipoTelefonoVistaModelo;
                    _telefonoVistaModelo.Individuo = _individuoVistaModelo;
                    _telefonoVistaModelo.NumeroTelefono = _telefono.Text.ToUpper();
                    _clienteGeneralVistaDtOs.Telefono = _telefonoVistaModelo;

                    _correoElectronicoVistaModelo.TipoCorreoElectronico = _tipoCorreoElectronicoVistaModelo;
                    _correoElectronicoVistaModelo.Individuo = _individuoVistaModelo;
                    _correoElectronicoVistaModelo.DireccionCorreoElectronico = _email.Text;
                    _clienteGeneralVistaDtOs.CorreoElectronico = _correoElectronicoVistaModelo;



                    #endregion

                    #region Cliente

                    ClienteVistaModelo _clienteVistaModelo = new ClienteVistaModelo();
                    TipoGeneroVistaModelo _tipoGeneroVistaModelo = new TipoGeneroVistaModelo();
                    _tipoGeneroVistaModelo.TipoGeneroId = Convert.ToInt32(_genero.SelectedItem.Value);
                    _clienteVistaModelo.TipoGenero = _tipoGeneroVistaModelo;
                    _clienteVistaModelo.Individuo = _individuoVistaModelo;
                    _clienteVistaModelo.FechaNacimiento = Convert.ToDateTime(_fechaNacimiento.Text);
                    _clienteGeneralVistaDtOs.Cliente = _clienteVistaModelo;

                    #endregion

                    #region Individuo Rol

                    IndividuoRolVistaModelo _individuoRolVistaModelo = new IndividuoRolVistaModelo();
                    TipoRolIndividuoVistaModelo _tipoRolIndividuoVistaModelo = new TipoRolIndividuoVistaModelo();
                    _tipoRolIndividuoVistaModelo.TipoRolIndividuoId = Convert.ToInt32(Util.TipoRolIndividuo.Cliente);
                    _individuoRolVistaModelo.TipoRolIndividuo = _tipoRolIndividuoVistaModelo;
                    _clienteGeneralVistaDtOs.IndividuoRol = _individuoRolVistaModelo;

                    #endregion

                    _servicioDelegadoIndividuo.GrabarCliente(_clienteGeneralVistaDtOs);
                }
                else
                {
                    #region individuo 

                    //Individuo
                    IndividuoVistaModelo _individuoVistaModelo = _clienteGeneralVistaDtOs.Individuo;

                    TipoIdentificacionVistaModelo _tipoIdentificacionVistaModelo = new TipoIdentificacionVistaModelo();
                    _tipoIdentificacionVistaModelo.TipoIdentificacionId =
                        Convert.ToInt32(_tipoDocumento.SelectedItem.Value);
                    _individuoVistaModelo.TipoIdentificacion = _tipoIdentificacionVistaModelo;

                    TipoIndividuoVistaModelo _tipoIndividuoVistaModelo = new TipoIndividuoVistaModelo();
                    _tipoIndividuoVistaModelo.TipoIndividuoId = Convert.ToInt32(Util.TipoIndividuo.PersonaNatural);
                    _individuoVistaModelo.TipoIndividuo = _tipoIndividuoVistaModelo;


                    _individuoVistaModelo.PrimerCampo = _apellidoPaterno.Text.ToUpper();
                    _individuoVistaModelo.SegundoCampo = _apellidoMaterno.Text.ToUpper();
                    _individuoVistaModelo.TercerCampo = _primerNombre.Text.ToUpper();
                    _individuoVistaModelo.CuartoCampo = _segundoNombre.Text.ToUpper();
                    _individuoVistaModelo.NumeroIdentificacion = _numeroDocumento.Text.ToUpper();
                    _individuoVistaModelo.Habilitado = true;
                    _individuoVistaModelo.FechaCreacion = DateTime.Now;
                    _individuoVistaModelo.FechaModificacion = DateTime.Now;
                    _individuoVistaModelo.UsuarioId = User.Id;

                    _clienteGeneralVistaDtOs.Individuo = _individuoVistaModelo;

                    #endregion

                    #region Direccion

                    //Direccion

                    DireccionVistaModelo _direccionVistaModelo =_clienteGeneralVistaDtOs.Direccion;

                    PaisVistaModelo _paisVistaModelo = new PaisVistaModelo();
                    _paisVistaModelo.PaisId = Convert.ToInt32(_pais.SelectedItem.Value);

                    EstadoVistaModelo _estadoVistaModelo = new EstadoVistaModelo();
                    _estadoVistaModelo.EstadoId = Convert.ToInt32(_provincia.SelectedItem.Value);

                    CiudadVistaModelo _ciudadVistaModelo = new CiudadVistaModelo();
                    _ciudadVistaModelo.CiudadId = Convert.ToInt32(_ciudad.SelectedItem.Value);

                    ParroquiaVistaModelo _parroquiaVistaModelo = new ParroquiaVistaModelo();
                    _parroquiaVistaModelo.ParroquiaId = Convert.ToInt32(_parroquia.SelectedItem.Value);

                    TipoDireccionVistaModelo _tipoDireccionVistaModelo = new TipoDireccionVistaModelo();
                    _tipoDireccionVistaModelo.TipoDireccionId = Convert.ToInt32(_tipoDireccion.SelectedItem.Value);

                    _direccionVistaModelo.Individuo = _individuoVistaModelo;
                    _direccionVistaModelo.DescripcionDireccion = _direccion.Text.ToUpper();
                    _direccionVistaModelo.Pais = _paisVistaModelo;
                    _direccionVistaModelo.Estado = _estadoVistaModelo;
                    _direccionVistaModelo.Ciudad = _ciudadVistaModelo;
                    _direccionVistaModelo.TipoDireccion = _tipoDireccionVistaModelo;
                    _direccionVistaModelo.Parroquia = _parroquiaVistaModelo;
                    _clienteGeneralVistaDtOs.Direccion = _direccionVistaModelo;

                    #endregion

                    #region  Telefono y Email

                    TelefonoVistaModelo _telefonoVistaModelo = _clienteGeneralVistaDtOs.Telefono;
                    CorreoElectronicoVistaModelo _correoElectronicoVistaModelo = _clienteGeneralVistaDtOs.CorreoElectronico;
                    TipoTelefonoVistaModelo _tipoTelefonoVistaModelo = new TipoTelefonoVistaModelo();
                    TipoCorreoElectronicoVistaModelo _tipoCorreoElectronicoVistaModelo =
                        new TipoCorreoElectronicoVistaModelo();

                    _tipoTelefonoVistaModelo.TipoTelefonoId = Convert.ToInt32(_tipoTelefono.SelectedItem.Value);
                    _tipoCorreoElectronicoVistaModelo.TipoCorreoElectronicoId =
                        Convert.ToInt32(_tipoCorreo.SelectedItem.Value);


                    _telefonoVistaModelo.TipoTelefono = _tipoTelefonoVistaModelo;
                    _telefonoVistaModelo.Individuo = _individuoVistaModelo;
                    _telefonoVistaModelo.NumeroTelefono = _telefono.Text.ToUpper();
                    _clienteGeneralVistaDtOs.Telefono = _telefonoVistaModelo;

                    _correoElectronicoVistaModelo.TipoCorreoElectronico = _tipoCorreoElectronicoVistaModelo;
                    _correoElectronicoVistaModelo.Individuo = _individuoVistaModelo;
                    _correoElectronicoVistaModelo.DireccionCorreoElectronico = _email.Text;
                    _clienteGeneralVistaDtOs.CorreoElectronico = _correoElectronicoVistaModelo;



                    #endregion

                    #region Cliente

                    ClienteVistaModelo _clienteVistaModelo = _clienteGeneralVistaDtOs.Cliente;
                    TipoGeneroVistaModelo _tipoGeneroVistaModelo = new TipoGeneroVistaModelo();
                    _tipoGeneroVistaModelo.TipoGeneroId = Convert.ToInt32(_genero.SelectedItem.Value);
                    _clienteVistaModelo.TipoGenero = _tipoGeneroVistaModelo;
                    _clienteVistaModelo.Individuo = _individuoVistaModelo;
                    _clienteVistaModelo.FechaNacimiento = Convert.ToDateTime(_fechaNacimiento.Text);
                    _clienteGeneralVistaDtOs.Cliente = _clienteVistaModelo;

                    #endregion

                    #region Individuo Rol

                    IndividuoRolVistaModelo _individuoRolVistaModelo = _clienteGeneralVistaDtOs.IndividuoRol;
                    TipoRolIndividuoVistaModelo _tipoRolIndividuoVistaModelo = new TipoRolIndividuoVistaModelo();
                    _tipoRolIndividuoVistaModelo.TipoRolIndividuoId = Convert.ToInt32(Util.TipoRolIndividuo.Cliente);
                    _individuoRolVistaModelo.TipoRolIndividuo = _tipoRolIndividuoVistaModelo;
                    _clienteGeneralVistaDtOs.IndividuoRol = _individuoRolVistaModelo;

                    #endregion

                    _servicioDelegadoIndividuo.ActualizarCliente(_clienteGeneralVistaDtOs);
                }
                LimpiarControles();
                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Exitoso").ToString(), "_grabarCliente");

            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarCliente");
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

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarCliente");
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
                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarCliente");
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
                _provincia.SelectedIndex =_provincia.Items.IndexOf(_provincia.Items.FindByValue("1"));
                _ciudad.DataSource =
                    _servicioDelegadoGeneral.ObtenerCiudadPorPaisIdYEstadoId(Convert.ToInt32(_pais.SelectedItem.Value),
                        Convert.ToInt32(_provincia.SelectedItem.Value));
                _ciudad.DataBind();
                _ciudad.SelectedIndex = _ciudad.Items.IndexOf(_ciudad.Items.FindByValue("1"));
                _parroquia.DataSource =_servicioDelegadoGeneral.ObtenerParroquiasPorVariosParametros(Convert.ToInt32(_pais.SelectedItem.Value), Convert.ToInt32(_ciudad.SelectedItem.Value), Convert.ToInt32(_provincia.SelectedItem.Value));
                _parroquia.DataBind();
                _tipoDireccion.DataSource = _servicioDelegadoGeneral.ObtenerTipoDirecciones();
                _tipoDireccion.DataBind();
                _tipoCorreo.DataSource = _servicioDelegadoGeneral.ObtenerTiposCorreoElectronico();
                _tipoCorreo.DataBind();
                _tipoTelefono.DataSource = _servicioDelegadoGeneral.ObtenerTiposTelefonos();
                _tipoTelefono.DataBind();
                _numeroDocumento.Enabled = true;
                _tipoDocumento.Enabled = true;
                _banderaActualizacion = false;
                _numeroDocumento.MaxLength = 10;
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarCliente");
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
            _numeroDocumentoBusqueda.Text=String.Empty;
            _clienteGeneralVistaDtOs = null;
            CargarDatos();
        }






        #endregion

       
    }
}