#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.DAOs;
using JLLR.Core.Base.Proveedor.Entidades;
using JLLR.Core.Individuo.Proveedor.DTOs;

#endregion
namespace JLLR.Core.Individuo.Proveedor.DAOs
{

    /// <summary>
    /// Metodos  generales de  la capa de  negocio de  Individuos
    /// </summary>
    public  class TransaccionalDAOs:BaseDAOs
    {
        #region DECLARACIONES E INSTANCIAS
        private Decisiones_Inteligentes entidad = new Decisiones_Inteligentes();
        private readonly  ClienteDAOs _clienteDaOs= new ClienteDAOs();
        private readonly  IndividuoDAOs _individuoDaOs= new IndividuoDAOs();
        private readonly  DireccionDAOs _direccionDaOs= new DireccionDAOs();
        private readonly  TelefonoDAOs _telefonoDaOs= new TelefonoDAOs();
        private readonly  IndividuoRolDAOs _individuoRolDaOs= new IndividuoRolDAOs();
        private readonly  CorreoElectronicoDAOs _correoElectronicoDaOs= new CorreoElectronicoDAOs();
        private readonly  Decisiones_Inteligentes _entidad= new Decisiones_Inteligentes();
        private readonly  ProveedorDAOs _proveedorDaOs=  new ProveedorDAOs();
        #endregion


        #region CLIENTE

        /// <summary>
        /// Obtiene   la informacion del cliente
        /// </summary>
        /// <param name="numeroIdentificacion"></param>
        /// <returns></returns>
        public ClienteDTOs ObtenerDatosClientePorNumeroIdentificacion(string numeroIdentificacion)
        {
            try
            {
                var clientes = from individuo in entidad.INDIVIDUO
                    join cliente in entidad.CLIENTE on individuo.INDIVIDUO_ID equals cliente.INDIVIDUO_ID
                    join direccion in entidad.DIRECCION on individuo.INDIVIDUO_ID equals direccion.INDIVIDUO_ID
                    join telefono in entidad.TELEFONO on individuo.INDIVIDUO_ID equals telefono.INDIVIDUO_ID
                    where individuo.NUMERO_IDENTIFICACION == numeroIdentificacion
                    select
                        new ClienteDTOs
                        {
                            ClienteId = cliente.CLIENTE_ID,
                            IndividuoId = individuo.INDIVIDUO_ID,
                            DireccionCliente = direccion.CALLE_PRINCIPAL + "-" + direccion.CALLE_SECUNDARIA + "-" + direccion.NUMERO_CASA + "-" + direccion.REFERENCIA,
                            TelefonoCliente = telefono.NUMERO_TELEFONO,
                            NombreCompleto =
                                individuo.PRIMER_CAMPO + " " + individuo.SEGUNDO_CAMPO + " " + individuo.TERCER_CAMPO +
                                " " + individuo.CUARTO_CAMPO,
                            NumeroDocumento = individuo.NUMERO_IDENTIFICACION
                        };

              
                    return clientes.FirstOrDefault();
               

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }


        /// <summary>
        /// Obtiene   la informacion del cliente
        /// </summary>
        /// <param name="apellidoPaterno"></param>
        /// <param name="apellidoMaterno"></param>
        /// <returns></returns>
        public IQueryable<ClienteDTOs> ObtenerDatosClientePorApellidos(string apellidoPaterno,string apellidoMaterno )
        {
            try
            {
                var clientes = from individuo in entidad.INDIVIDUO
                               join cliente in entidad.CLIENTE on individuo.INDIVIDUO_ID equals cliente.INDIVIDUO_ID
                               join direccion in entidad.DIRECCION on individuo.INDIVIDUO_ID equals direccion.INDIVIDUO_ID
                               join telefono in entidad.TELEFONO on individuo.INDIVIDUO_ID equals telefono.INDIVIDUO_ID
                               where individuo.PRIMER_CAMPO == apellidoPaterno || individuo.SEGUNDO_CAMPO==apellidoMaterno
                               select
                                   new ClienteDTOs
                                   {
                                       ClienteId = cliente.CLIENTE_ID,
                                       IndividuoId = individuo.INDIVIDUO_ID,
                                       DireccionCliente = direccion.CALLE_PRINCIPAL + "-" + direccion.CALLE_SECUNDARIA + "-" + direccion.NUMERO_CASA + "-" + direccion.REFERENCIA,
                                       TelefonoCliente = telefono.NUMERO_TELEFONO,
                                       NombreCompleto =
                                           individuo.PRIMER_CAMPO + " " + individuo.SEGUNDO_CAMPO + " " + individuo.TERCER_CAMPO +
                                           " " + individuo.CUARTO_CAMPO,
                                       NumeroDocumento = individuo.NUMERO_IDENTIFICACION
                                   };


                return clientes;


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Grabar cliente
        /// </summary>
        /// <param name="clienteGeneralDtOs"></param>
        /// <returns></returns>
        public CLIENTE GrabarCliente(ClienteGeneralDTOs clienteGeneralDtOs)
        {

            using (System.Transactions.TransactionScope transaction = new System.Transactions.TransactionScope())
            {
                try
                {
                    //Graba el  individuo
                    INDIVIDUO individuo = _individuoDaOs.GrabarIndividuo(clienteGeneralDtOs.Individuo);

                    //Graba el cliente
                    clienteGeneralDtOs.Cliente.INDIVIDUO_ID = individuo.INDIVIDUO_ID;
                    CLIENTE cliente = _clienteDaOs.GrabarCliente(clienteGeneralDtOs.Cliente);

                    //Graba la direccion
                    clienteGeneralDtOs.Direccion.INDIVIDUO_ID = individuo.INDIVIDUO_ID;
                    _direccionDaOs.GrabarDireccion(clienteGeneralDtOs.Direccion);

                    //Graba el telefono
                    if (clienteGeneralDtOs.Telefonos != null)
                    {
                        foreach (var telefono in clienteGeneralDtOs.Telefonos)
                        {
                            telefono.INDIVIDUO_ID = individuo.INDIVIDUO_ID;
                            _telefonoDaOs.GrabarTelefono(telefono);
                        }
                    }
                    

                    //Graba el correo electronico
                    clienteGeneralDtOs.CorreoElectronico.INDIVIDUO_ID = individuo.INDIVIDUO_ID;
                    _correoElectronicoDaOs.GrabarCorreoElectronico(clienteGeneralDtOs.CorreoElectronico);

                    //Graba el correo electronico
                    clienteGeneralDtOs.IndividuoRol.INDIVIDUO_ID = individuo.INDIVIDUO_ID;
                    _individuoRolDaOs.GrabarIndividuoRol(clienteGeneralDtOs.IndividuoRol);

                    transaction.Complete();
                    return cliente;


                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }


        /// <summary>
        /// Actualza  el  cliente
        /// </summary>
        /// <param name="clienteGeneralDtOs"></param>
        /// <returns></returns>
        public void ActualizarCliente(ClienteGeneralDTOs clienteGeneralDtOs)
        {

            using (System.Transactions.TransactionScope transaction = new System.Transactions.TransactionScope())
            {
                try
                {
                    //Graba el  individuo
                     _individuoDaOs.Actualizaindividuo(clienteGeneralDtOs.Individuo);

                    //Graba el cliente
                    
                    _clienteDaOs.ActualizaCliente(clienteGeneralDtOs.Cliente);

                    //Graba la direccion
                        
                    _direccionDaOs.ActualizaDireccion(clienteGeneralDtOs.Direccion);

                    //Graba el telefono

                    if (clienteGeneralDtOs.Telefonos !=null)
                    { 
                    foreach (var telefono in clienteGeneralDtOs.Telefonos)
                    {
                        _telefonoDaOs.ActualizaTelefono(telefono);
                    }
                    }


                    //Graba el correo electronico

                    _correoElectronicoDaOs.ActualizaCorreoElectronico(clienteGeneralDtOs.CorreoElectronico);

                    //Graba el correo electronico
                    
                    _individuoRolDaOs.ActualizaIndividuoRol(clienteGeneralDtOs.IndividuoRol);

                    transaction.Complete();
                    


                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }


        /// <summary>
        /// Obtiene el cliente completo por  numero  de documento
        /// </summary>
        /// <param name="numeroIdentificacion"></param>
        /// <returns></returns>
        public ClienteGeneralDTOs ObtenerClientePorNumeroIdentificacion(string numeroIdentificacion)
        {
            try
            {
                var clientes = from cliente in _entidad.CLIENTE
                    join individuo in _entidad.INDIVIDUO on cliente.INDIVIDUO_ID equals individuo.INDIVIDUO_ID
                    join direccion in _entidad.DIRECCION on individuo.INDIVIDUO_ID equals direccion.INDIVIDUO_ID
                    join telefono in _entidad.TELEFONO on individuo.INDIVIDUO_ID equals telefono.INDIVIDUO_ID
                    join email in _entidad.E_MAIL on individuo.INDIVIDUO_ID equals email.INDIVIDUO_ID
                    join individuoRol in _entidad.INDIVIDUO_ROL on individuo.INDIVIDUO_ID equals
                        individuoRol.INDIVIDUO_ID
                    where
                        individuo.NUMERO_IDENTIFICACION == numeroIdentificacion &&
                        individuoRol.TIPO_ROL_INDIVIDUO_ID == 1
                    select new ClienteGeneralDTOs()
                    {
                        Cliente = cliente,
                        Individuo = individuo,
                        IndividuoRol = individuoRol,
                        CorreoElectronico = email,
                        Direccion = direccion,
                        Telefono = telefono,
                        NombreCompleto = individuo.PRIMER_CAMPO + " " + individuo.SEGUNDO_CAMPO + " " + individuo.TERCER_CAMPO +
                                           " " + individuo.CUARTO_CAMPO,
                        DireccionCompleta = direccion.CALLE_PRINCIPAL + "-" + direccion.CALLE_SECUNDARIA + "-" + direccion.NUMERO_CASA + "-" + direccion.REFERENCIA
                    };

                return clientes.FirstOrDefault();
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }


        /// <summary>
        /// Obtiene el cliente completo por  numero  de documento
        /// </summary>
        /// <param name="primerApellido"></param>
        /// <param name="segundoApellido"></param>
        /// <returns></returns>
        public IQueryable<ClienteGeneralDTOs> ObtenerClientePorApellidos(string primerApellido, string segundoApellido)
        {
            try
            {
                var clientes = from cliente in _entidad.CLIENTE
                               join individuo in _entidad.INDIVIDUO on cliente.INDIVIDUO_ID equals individuo.INDIVIDUO_ID
                               join direccion in _entidad.DIRECCION on individuo.INDIVIDUO_ID equals direccion.INDIVIDUO_ID
                               join telefono in _entidad.TELEFONO on individuo.INDIVIDUO_ID equals telefono.INDIVIDUO_ID
                               join email in _entidad.E_MAIL on individuo.INDIVIDUO_ID equals email.INDIVIDUO_ID
                               join individuoRol in _entidad.INDIVIDUO_ROL on individuo.INDIVIDUO_ID equals
                                   individuoRol.INDIVIDUO_ID
                               where
                                   individuo.PRIMER_CAMPO == primerApellido || individuo.SEGUNDO_CAMPO== segundoApellido &&
                                   individuoRol.TIPO_ROL_INDIVIDUO_ID == 1
                               select new ClienteGeneralDTOs()
                               {
                                   Cliente = cliente,
                                   Individuo = individuo,
                                   IndividuoRol = individuoRol,
                                   CorreoElectronico = email,
                                   Direccion = direccion,
                                   Telefono = telefono,
                                   NombreCompleto = individuo.PRIMER_CAMPO + " " + individuo.SEGUNDO_CAMPO + " " + individuo.TERCER_CAMPO +
                                           " " + individuo.CUARTO_CAMPO,
                                   DireccionCompleta = direccion.CALLE_PRINCIPAL + "-" + direccion.CALLE_SECUNDARIA + "-" + direccion.NUMERO_CASA + "-" + direccion.REFERENCIA,

                               };

                

                return clientes.OrderBy(m=>m.Individuo.PRIMER_CAMPO);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion


        #region PROVEEDOR
        /// <summary>
        /// Grabar Proveedor
        /// </summary>
        /// <param name="proveedorDtOs"></param>
        /// <returns></returns>
        public PROVEEDOR GrabarProveedor(ProveedorDTOs proveedorDtOs)
        {

            using (System.Transactions.TransactionScope transaction = new System.Transactions.TransactionScope())
            {
                try
                {
                    //Graba el  individuo
                    INDIVIDUO individuo = _individuoDaOs.GrabarIndividuo(proveedorDtOs.Individuo);

                    //Graba el cliente
                    proveedorDtOs.Proveedor.INDIVIDUO_ID = individuo.INDIVIDUO_ID;
                    PROVEEDOR proveedor= _proveedorDaOs.GrabarProveedor(proveedorDtOs.Proveedor);

                    //Graba la direccion
                    proveedorDtOs.Direccion.INDIVIDUO_ID = individuo.INDIVIDUO_ID;
                    _direccionDaOs.GrabarDireccion(proveedorDtOs.Direccion);

                    //Graba el telefono
                    proveedorDtOs.Telefono.INDIVIDUO_ID = individuo.INDIVIDUO_ID;
                    _telefonoDaOs.GrabarTelefono(proveedorDtOs.Telefono);


                    //Graba el correo electronico
                    proveedorDtOs.CorreoElectronico.INDIVIDUO_ID = individuo.INDIVIDUO_ID;
                    _correoElectronicoDaOs.GrabarCorreoElectronico(proveedorDtOs.CorreoElectronico);

                    //Graba el correo electronico
                    proveedorDtOs.IndividuoRol.INDIVIDUO_ID = individuo.INDIVIDUO_ID;
                    _individuoRolDaOs.GrabarIndividuoRol(proveedorDtOs.IndividuoRol);

                    transaction.Complete();
                    return proveedor;


                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }

        /// <summary>
        /// Actualza  el  cliente
        /// </summary>
        /// <param name="clienteGeneralDtOs"></param>
        /// <returns></returns>
        public void ActualizarProveedor(ProveedorDTOs proveedorDtOs)
        {

            using (System.Transactions.TransactionScope transaction = new System.Transactions.TransactionScope())
            {
                try
                {
                    //Graba el  individuo
                    _individuoDaOs.Actualizaindividuo(proveedorDtOs.Individuo);

                    //Graba el cliente

                    _proveedorDaOs.ActualizaProveedor(proveedorDtOs.Proveedor);

                    //Graba la direccion

                    _direccionDaOs.ActualizaDireccion(proveedorDtOs.Direccion);

                    //Graba el telefono

                    _telefonoDaOs.ActualizaTelefono(proveedorDtOs.Telefono);


                    //Graba el correo electronico

                    _correoElectronicoDaOs.ActualizaCorreoElectronico(proveedorDtOs.CorreoElectronico);

                    //Graba el correo electronico

                    _individuoRolDaOs.ActualizaIndividuoRol(proveedorDtOs.IndividuoRol);

                    transaction.Complete();



                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }

        /// <summary>
        /// Obtiene el proveedor completo por  numero  de documento
        /// </summary>
        /// <param name="numeroIdentificacion"></param>
        /// <returns></returns>
        public ProveedorDTOs ObtenerProveedorPorNumeroIdentificacion(string numeroIdentificacion)
        {
            try
            {
                var proveedores = from proveedor in _entidad.PROVEEDOR
                               join individuo in _entidad.INDIVIDUO on proveedor.INDIVIDUO_ID equals individuo.INDIVIDUO_ID
                               join direccion in _entidad.DIRECCION on individuo.INDIVIDUO_ID equals direccion.INDIVIDUO_ID
                               join telefono in _entidad.TELEFONO on individuo.INDIVIDUO_ID equals telefono.INDIVIDUO_ID
                               join email in _entidad.E_MAIL on individuo.INDIVIDUO_ID equals email.INDIVIDUO_ID
                               join individuoRol in _entidad.INDIVIDUO_ROL on individuo.INDIVIDUO_ID equals
                                   individuoRol.INDIVIDUO_ID
                               where
                                   individuo.NUMERO_IDENTIFICACION == numeroIdentificacion &&
                                   individuoRol.TIPO_ROL_INDIVIDUO_ID == 2
                               select new ProveedorDTOs()
                               {
                                   Proveedor = proveedor,
                                   Individuo = individuo,
                                   IndividuoRol = individuoRol,
                                   CorreoElectronico = email,
                                   Direccion = direccion,
                                   Telefono = telefono
                               };

                return proveedores.FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}
