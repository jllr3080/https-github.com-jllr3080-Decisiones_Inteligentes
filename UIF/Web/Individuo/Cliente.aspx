<%@ Page Title="<%$ Resources:Web_es_Ec,Titulo_Pagina_Cliente%>" Language="C#" MasterPageFile="~/PaginaMaestra/Site.Master" AutoEventWireup="true" CodeBehind="Cliente.aspx.cs" Inherits="Web.Individuo.Cliente"  MaintainScrollPositionOnPostback="true"%>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=16.1.1.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <script>
        function validarNumerosParaFecha(e) {
            key = e.keyCode || e.which;
            tecla = String.fromCharCode(key).toString();
            letras = "1234567890/";//Se define todos los números que se quiere que se muestre.
            especiales = [8, 37, 39, 46, 6, 9]; //Es la validación del KeyCodes, que teclas recibe el campo de texto.

            tecla_especial = false
            for (var i in especiales) {
                if (key == especiales[i]) {
                    tecla_especial = true;
                    break;
                }
            }

            if (letras.indexOf(tecla) == -1 && !tecla_especial)
                return false;
        }
    </script>
     <br/>
    <br/>
    <br/>
    <br/>
    <h2><asp:Literal runat="server" Text="<%$ Resources:Web_es_Ec,Titulo_Pagina_Cliente%>"></asp:Literal></h2>
   <section>
    <div class="panel panel-default" id="_datosBusquedaCliente">
           <div class="panel-heading"><asp:Literal runat="server" ID="Literal4" Text="<%$ Resources:Web_es_Ec,Panel_Busqueda_Cliente%>"/></div>
        <div class="panel-body">
            <div class="row">
                
                    <div class="col-md-3">
                        <asp:Label ID="_labelTipoBusqueda" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Tipo_Busqueda%>"></asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="_labelNumeroDocumentoBusqueda" runat="server"></asp:Label>
                    </div>
                  <div class="col-md-3">
                        
                        <asp:Label ID="_labelParametroDos" runat="server" ></asp:Label>
                    </div>
                    
            </div>
            <div class="row">
                
                 <div class="col-md-3">
                         <asp:DropDownList ID="_tipoBusqueda" runat="server" CssClass="form-control" ValidationGroup="BusquedaCliente" DataTextField="Busqueda" DataValueField="TipoBusquedaId" OnSelectedIndexChanged="_tipoBusqueda_OnSelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                          <asp:RequiredFieldValidator ID="_tipoBusquedaValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="BusquedaCliente" ControlToValidate="_tipoBusqueda" InitialValue="-1" ></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3">
                          <asp:TextBox ID="_numeroDocumentoBusqueda" runat="server" ValidationGroup="BusquedaCliente" CssClass="form-control" AutoCompleteType="Disabled" MaxLength="13"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="_numeroDocumentoBusquedaValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="BusquedaCliente" ControlToValidate="_numeroDocumentoBusqueda" ></asp:RequiredFieldValidator>
                    </div>
                 <div class="col-md-3">
                        <asp:TextBox ID="_parametroDos" runat="server" maxlength="13" class="form-control" ValidationGroup="BusquedaCliente" AutoCompleteType="Disabled"></asp:TextBox>
                        
                        
                    </div>
                     <div class="col-md-3">
                        <asp:Button ID="_btnBusquedaCliente" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Buscar%>" ValidationGroup="BusquedaCliente"  CssClass="btn btn-primary" OnClick="_btnBusquedaCliente_Click" />
                    </div>
            </div>
        </div>
    </div>
     <div class="panel panel-default" id="_datosGeneralesClientes">
           <div class="panel-heading"><asp:Literal runat="server" ID="Literal1" Text="<%$ Resources:Web_es_Ec,Panel_Datos_Generales_Cliente%>"/></div>
        <div class="panel-body">
             <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="_labelTipoDocumento" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Tipo_Documento%>"></asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="_labelNumeroDocumento" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Numero_Documento%>"></asp:Label>
                    </div>
                     <div class="col-md-3">
                        <asp:Label ID="_labelGenero" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Genero%>"></asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="_labelFechaNacimiento" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Fecha_Nacimiento%>"></asp:Label>
                    </div>
                    
            </div>
            <div class="row">
                    <div class="col-md-3">
                          <asp:DropDownList ID="_tipoDocumento" runat="server" CssClass="form-control" ValidationGroup="CrearModificarCliente" DataTextField="Descripcion" DataValueField="TipoIdentificacionId" AutoPostBack="True" OnSelectedIndexChanged="_tipoDocumento_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                     <div class="col-md-3">
                         <asp:TextBox ID="_numeroDocumento" runat="server" ValidationGroup="CrearModificarCliente" CssClass="form-control" AutoCompleteType="Disabled" AutoPostBack="True" OnTextChanged="_numeroDocumento_TextChanged" MaxLength="13"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="_numeroDocumentoValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="CrearModificarCliente" ControlToValidate="_numeroDocumento" ></asp:RequiredFieldValidator>
                       </div>
                    <div class="col-md-3">
                         <asp:DropDownList ID="_genero" runat="server" CssClass="form-control" ValidationGroup="CrearModificarCliente" DataTextField="Descripcion" DataValueField="TipoGeneroId"></asp:DropDownList>
                    </div>
                    <div class="col-md-3">
                         <asp:TextBox ID="_fechaNacimiento" runat="server"  AutoCompleteType="Disabled" CssClass="form-control" onkeypress="return validarNumerosParaFecha(event)"  TextMode="DateTime" MaxLength="10" ValidationGroup="CrearModificarCliente" OnTextChanged="_fechaNacimiento_OnTextChanged" AutoPostBack="True"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="_fechaNacimientoValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="CrearModificarCliente" ControlToValidate="_fechaNacimiento" ></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="_fechaNacimientoRegular" runat="server" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d" ControlToValidate="_fechaNacimiento" ValidationGroup="CrearModificarCliente"/>
                            <ajaxToolkit:CalendarExtender ID="_fechaNacimientoExtensor" runat="server" BehaviorID="_fecha_CalendarExtender" TargetControlID="_fechaNacimiento" Format="dd/MM/yyyy"  />
                            <ajaxToolkit:TextBoxWatermarkExtender id="_fechaNacimientoMarcaAgua" runat="server" targetcontrolid="_fechaNacimiento" enabled="True" watermarktext="<%$ Resources:Web_es_Ec,WaterMarke_Fecha%>"></ajaxToolkit:TextBoxWatermarkExtender>  

                         
                    </div>
            </div>
            <br />
            <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="_labelApellidoPaterno" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Apellido_Paterno%>"></asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="_labelApellidoMaterno" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Apellido_Materno%>"></asp:Label>
                    </div>
                     <div class="col-md-3">
                        <asp:Label ID="_labelPrimerNombre" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Primer_Nombre%>"></asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="_labelSegundoNombre" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Segundo_Nombre%>"></asp:Label>
                    </div>
                    
            </div>
            <div class="row">
                    <div class="col-md-3">
                          <asp:TextBox ID="_apellidoPaterno" runat="server" ValidationGroup="CrearModificarCliente" CssClass="form-control" AutoCompleteType="Disabled" MaxLength="20" ></asp:TextBox>
                          <asp:RequiredFieldValidator ID="_apellidoPaternoValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="CrearModificarCliente" ControlToValidate="_apellidoPaterno" ></asp:RequiredFieldValidator>
                    </div>
                     <div class="col-md-3">
                         <asp:TextBox ID="_apellidoMaterno" runat="server" ValidationGroup="CrearModificarCliente" CssClass="form-control" AutoCompleteType="Disabled" MaxLength="20"></asp:TextBox>
                          <%--<asp:RequiredFieldValidator ID="_apellidoMaternoValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="CrearModificarCliente" ControlToValidate="_apellidoMaterno" ></asp:RequiredFieldValidator>--%>
                       </div>
                    <div class="col-md-3">
                         <asp:TextBox ID="_primerNombre" runat="server" ValidationGroup="CrearModificarCliente" CssClass="form-control" AutoCompleteType="Disabled" MaxLength="20"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="_primerNombreValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="CrearModificarCliente" ControlToValidate="_primerNombre" ></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3">
                         <asp:TextBox ID="_segundoNombre" runat="server" ValidationGroup="CrearModificarCliente" CssClass="form-control" AutoCompleteType="Disabled" MaxLength="20"></asp:TextBox>
                         <%-- <asp:RequiredFieldValidator ID="_segundoNombreValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="CrearModificarCliente" ControlToValidate="_segundoNombre" ></asp:RequiredFieldValidator>--%>
                    </div>
            </div>
            
           

        </div>
    </div>
       
     <div class="panel panel-default" id="_datosDirecion">
           <div class="panel-heading">
               <div class="row">
                    <div class="col-md-3">
                        <asp:Literal runat="server" ID="_literalDireccion" Text="<%$ Resources:Web_es_Ec,Panel_Datos_Domicilio_Cliente%>"></asp:Literal>
                    </div>       
                    <div class="col-md-3">
                    <asp:Button ID="_mapaParroquias" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Mapa_Parroquias%>"   class="btn btn-primary" OnClick="_mapaParroquias_OnClick" />
                    </div>
                 
            </div>
           </div>
        <div class="panel-body">
            <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="_labelPais" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Pais%>"></asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="_labelProvincia" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Provincia%>"></asp:Label>
                    </div>
                     <div class="col-md-3">
                        <asp:Label ID="_labelCiudad" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Ciudad%>"></asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="_labelParroquia" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Parroquia%>"></asp:Label>
                    </div>
                   
                    
            </div>
            <div class="row">
                    <div class="col-md-3">
                         <asp:DropDownList ID="_pais" runat="server" CssClass="form-control" AutoPostBack="True" ValidationGroup="CrearModificarCliente" DataTextField="Descripcion" DataValueField="PaisId"></asp:DropDownList>
                          <asp:RequiredFieldValidator ID="_paisValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="CrearModificarCliente" ControlToValidate="_pais" InitialValue="-1" ></asp:RequiredFieldValidator>
                    </div>
                     <div class="col-md-3">
                         <asp:DropDownList ID="_provincia" runat="server" CssClass="form-control" AutoPostBack="True" ValidationGroup="CrearModificarCliente" DataTextField="Descripcion" DataValueField="EstadoId" OnSelectedIndexChanged="_provincia_SelectedIndexChanged"></asp:DropDownList>
                          <asp:RequiredFieldValidator ID="_provinciaValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="CrearModificarCliente" ControlToValidate="_provincia" ></asp:RequiredFieldValidator>
                       </div>
                    <div class="col-md-3">
                         <asp:DropDownList ID="_ciudad" runat="server" CssClass="form-control" ValidationGroup="CrearModificarCliente" DataTextField="Descripcion" DataValueField="CiudadId" OnSelectedIndexChanged="_ciudad_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                          <asp:RequiredFieldValidator ID="_ciudadValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="CrearModificarCliente" ControlToValidate="_ciudad" ></asp:RequiredFieldValidator>
                    </div>
                 <div class="col-md-3">
                         <asp:DropDownList ID="_parroquia" runat="server" CssClass="form-control" ValidationGroup="CrearModificarCliente" DataTextField="Descripcion" DataValueField="ParroquiaId"></asp:DropDownList>
                          <asp:RequiredFieldValidator ID="_parroquiaValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="CrearModificarCliente" ControlToValidate="_parroquia" ></asp:RequiredFieldValidator>
                    </div>
                   
            </div>
            <br />
            <div class="row">
                 <div class="col-md-3">
                        <asp:Label ID="_labelTipoDireccion" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Tipo_Direccion%>"></asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="_labelCallePrincipal" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Calle_Principal%>"></asp:Label>
                    </div>
                <div class="col-md-3">
                        <asp:Label ID="_labelCalleSecundaria" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Calle_Secundaria%>"></asp:Label>
                    </div>
                    
                
                <div class="col-md-3">
                        <asp:Label ID="_labelNumeroCasa" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Numero_Casa%>"></asp:Label>
                    </div>
                    
            </div>
            <div class="row">
                 <div class="col-md-3">
                         <asp:DropDownList ID="_tipoDireccion" runat="server" CssClass="form-control" ValidationGroup="CrearModificarCliente" DataTextField="Descripcion" DataValueField="TipoDireccionId"></asp:DropDownList>
                          <asp:RequiredFieldValidator ID="_tipoDireccionValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="CrearModificarCliente" ControlToValidate="_tipoDireccion" ></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3">
                          <asp:TextBox ID="_callePrincipal" runat="server" ValidationGroup="CrearModificarCliente" CssClass="form-control" AutoCompleteType="Disabled" MaxLength="100"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="_callePrincipalValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="CrearModificarCliente" ControlToValidate="_callePrincipal" ></asp:RequiredFieldValidator>
                    </div>
                     <div class="col-md-3">
                          <asp:TextBox ID="_calleSecundaria" runat="server" ValidationGroup="CrearModificarCliente" CssClass="form-control" AutoCompleteType="Disabled" MaxLength="100"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="_calleSecundariaValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="CrearModificarCliente" ControlToValidate="_calleSecundaria" ></asp:RequiredFieldValidator>
                    </div>
                  <div class="col-md-3">
                          <asp:TextBox ID="_numeroCasa" runat="server" ValidationGroup="CrearModificarCliente" CssClass="form-control" AutoCompleteType="Disabled" MaxLength="100"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="_numeroCasaValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="CrearModificarCliente" ControlToValidate="_numeroCasa" ></asp:RequiredFieldValidator>
                    </div>

                    
            </div>
            <br/>
             <div class="row">
                 <div class="col-md-3">
                        <asp:Label ID="_labelReferencia" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Referencia%>"></asp:Label>
                    </div>
             </div>
              <div class="row">
                 <div class="col-md-3">
                          <asp:TextBox ID="_referencia" runat="server" ValidationGroup="CrearModificarCliente" CssClass="form-control" AutoCompleteType="Disabled" MaxLength="100"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="_referenciaValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="CrearModificarCliente" ControlToValidate="_numeroCasa" ></asp:RequiredFieldValidator>
                    </div>
                   
                    
            </div>

        </div>
    </div>
    
      <div class="panel panel-default" id="_datosTelefonoMail">
           <div class="panel-heading"><asp:Literal runat="server" ID="Literal2" Text="<%$ Resources:Web_es_Ec,Panel_Datos_Telefono_Mail_Cliente%>"/></div>
        <div class="panel-body">
            <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="_labelTipoCorreo" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Tipo_Correo%>"></asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="_labelEmail" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Direccion_Correo%>"></asp:Label>
                    </div>
                     <div class="col-md-3">
                        <asp:Label ID="_labelTipoTelefono" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Tipo_Telefono%>"></asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="_labelTelefono" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Numero_Telefono%>"></asp:Label>
                    </div>
                    
            </div>
            <div class="row">
                    <div class="col-md-3">
                          <asp:DropDownList ID="_tipoCorreo" runat="server" CssClass="form-control" ValidationGroup="CrearModificarCliente" DataTextField="Descripcion" DataValueField="TipoCorreoElectronicoId"></asp:DropDownList>
                          <asp:RequiredFieldValidator ID="_tipoCorreoValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="CrearModificarCliente" ControlToValidate="_tipoCorreo" ></asp:RequiredFieldValidator>
                    </div>
                     <div class="col-md-3">
                         <asp:TextBox ID="_email" runat="server" ValidationGroup="CrearModificarCliente" CssClass="form-control" AutoCompleteType="Disabled" MaxLength="35" TextMode="Email" AutoPostBack="True" OnTextChanged="_email_TextChanged"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="_emailValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="CrearModificarCliente" ControlToValidate="_email" ></asp:RequiredFieldValidator>
                       </div>
                    <div class="col-md-3">
                         <asp:DropDownList ID="_tipoTelefono" runat="server" CssClass="form-control" ValidationGroup="CrearModificarCliente" DataTextField="Descripcion" DataValueField="TipoTelefonoId"></asp:DropDownList>
                          <asp:RequiredFieldValidator ID="_tipoTelefonoValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="CrearModificarCliente" ControlToValidate="_tipoTelefono" ></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3">
                         <asp:TextBox ID="_telefono" runat="server" ValidationGroup="CrearModificarCliente" CssClass="form-control" AutoCompleteType="Disabled" MaxLength="10" TextMode="SingleLine"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="_telefonoValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="CrearModificarCliente" ControlToValidate="_telefono" ></asp:RequiredFieldValidator>
                    </div>
            </div>
            <div class="row">
                 <div class="col-md-3">
                        <asp:Button ID="_btnAgregarTelefono" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Agregar_Telefono%>"  ValidationGroup="GrabaTelefono" class="btn btn-primary" OnClick="_btnAgregarTelefono_OnClick" />
                  </div>

            </div>
            <br />
             <div class="row">
                 <div class="col-md-12">
                         <asp:GridView ID="_telefonos" runat="server" AutoGenerateColumns="False"   Width="100%"  ShowFooter="True" OnRowCommand="_telefonos_OnRowCommand" >
                                
                                <Columns>
                                     <asp:BoundField DataField="Individuo.NumeroIdentificacion" HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Numero_Documento%>"  >
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="NombreCompleto" HeaderText="<%$ Resources:Web_es_Ec,Label_Nombre_Completo%>"  >
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                      <asp:BoundField DataField="DireccionCompleta" HeaderText="<%$ Resources:Web_es_Ec,Label_Direccion_Personal%>" DataFormatString="{0:d}"  >
                                          <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" ></ItemStyle>
                                      </asp:BoundField>
                                      <asp:BoundField DataField="Telefono.NumeroTelefono" HeaderText="<%$ Resources:Web_es_Ec,Label_Telefono_Personal%>"  DataFormatString="{0:d}">
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"  />
                                    </asp:BoundField>
                                      <asp:TemplateField HeaderText="<%$ Resources:Web_es_Ec,Label_Editar%>" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="_editarTelefono" runat="server" ImageUrl="~/Content/Imagen/Editar.png"  CommandName="Editar" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                     <asp:TemplateField HeaderText="<%$ Resources:Web_es_Ec,Label_Eliminar%>" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="_eliminarTelefono" runat="server" ImageUrl="~/Content/Imagen/Editar.png"  CommandName="Eliminar" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="tableCabecera" ></HeaderStyle>
                                <FooterStyle CssClass="tablePiePagina"></FooterStyle>
                            </asp:GridView>
                  </div>

            </div>
            

        </div>
    </div>
     </section>
     <nav>
        <asp:Button ID="_grabarCliente" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Crear_Modificar_Cliente%>" CssClass="btn btn-primary"  ValidationGroup="CrearModificarCliente" OnClick="_grabarCliente_Click"/>
        <asp:Button ID="_cancelar" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Cancelar%>" CssClass="btn btn-primary" OnClick="_cancelar_Click"/>
    </nav>
    <div class="row" >
                  <div class="col-md-12" >
                <asp:Button ID="_btnMensaje" runat="server" Text="" Visible="false" />
                    <cc1:ModalPopupExtender ID="_btnMensaje_ModalPopupExtender" PopupControlID="_panelMensaje" runat="server" BehaviorID="_btnMensaje_ModalPopupExtender" TargetControlID="_btnMensaje" BackgroundCssClass="modal-Backgoround" X="500" OnCancelScript="_btnAceptar" Y="300">
                    </cc1:ModalPopupExtender>
                    <asp:Panel ID="_panelMensaje" runat="server" Style="display: none; background-color: white; width: 20%; height: auto;align-content:center ">
                        <div class="modal-header">
                            <h4 class="modal-title">Mensaje del Sistema</h4>
                        </div>
                        <div class="modal-body">
                            <asp:Label ID="_labelMensaje" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="modal-footer">

                            <asp:Button ID="_btnAceptar" runat="server" Text="Aceptar" class="btn btn-primary" data-dismiss="modal" />
                        </div>
                    </asp:Panel>
     </div>
        </div>
    
    <div class="row" >
                  <div class="col-md-12" >
                <asp:Button ID="_btnMapaParroquias" runat="server" Text="" Visible="false" />
                    <cc1:ModalPopupExtender ID="_btnMapaParroquias_ModalPopupExtender" PopupControlID="_panelMapaParroquia" runat="server" BehaviorID="_btnMapaParroquias_ModalPopupExtender" TargetControlID="_btnMensaje" BackgroundCssClass="modal-Backgoround" X="150" OnCancelScript="_aceptarMapaParroquia" Y="0">
                    </cc1:ModalPopupExtender>
                    <asp:Panel ID="_panelMapaParroquia" runat="server" Style="display: none; background-color: white; width: 50%; height: auto;align-content:center ">
                       
                        <div class="modal-body">
                           <img src="../Content/Imagen/ParroquiasQuito.png"/>
                        </div>
                        <div class="modal-footer">

                            <asp:Button ID="_aceptarMapaParroquia" runat="server" Text="Aceptar" class="btn btn-primary" data-dismiss="modal" />
                        </div>
                    </asp:Panel>
     </div>
        </div>
    
    <div class="row" >
                  <div class="col-md-12" >
                <asp:Button ID="_btnCliente" runat="server" Text="" Visible="false" />
                    <cc1:ModalPopupExtender ID="_btnCliente_ModalPopupExtender" PopupControlID="_panelCliente" runat="server" BehaviorID="_btnCliente_ModalPopupExtender" TargetControlID="_btnCliente" BackgroundCssClass="modal-Backgoround" X="200" OnCancelScript="_btnCerrarClientes" Y="150">
                    </cc1:ModalPopupExtender>
                    <asp:Panel ID="_panelCliente" runat="server" Style="display: none; background-color: white; width:60%; height: auto;align-content:center ">
                        <div class="modal-header">
                            <h4 class="modal-title">
                                <asp:Literal ID="Literal3" runat="server"  Text="<%$ Resources:Web_es_Ec,Label_Promociones_Vigentes%>"></asp:Literal></h4>
                        </div>
                        <div class="modal-body">
                            
                                
                         <div class="row">
                               <div class="col-md-12">
                               <asp:GridView ID="_clientes" runat="server" AutoGenerateColumns="False"   Width="100%"  ShowFooter="True" OnRowCommand="_clientes_OnRowCommand" >
                                
                                <Columns>
                                     <asp:BoundField DataField="Individuo.NumeroIdentificacion" HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Numero_Documento%>"  >
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="NombreCompleto" HeaderText="<%$ Resources:Web_es_Ec,Label_Nombre_Completo%>"  >
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                      <asp:BoundField DataField="DireccionCompleta" HeaderText="<%$ Resources:Web_es_Ec,Label_Direccion_Personal%>" DataFormatString="{0:d}"  >
                                          <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" ></ItemStyle>
                                      </asp:BoundField>
                                      <asp:BoundField DataField="Telefono.NumeroTelefono" HeaderText="<%$ Resources:Web_es_Ec,Label_Telefono_Personal%>"  DataFormatString="{0:d}">
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"  />
                                    </asp:BoundField>
                                      <asp:TemplateField HeaderText="<%$ Resources:Web_es_Ec,Label_Seleccionar%>" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="_seleccionarCliente" runat="server" ImageUrl="~/Content/Imagen/Seleccionar.png"  CommandName="Seleccionar" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="tableCabecera" ></HeaderStyle>
                                <FooterStyle CssClass="tablePiePagina"></FooterStyle>
                            </asp:GridView>
                                   </div> 
                             </div> 
                        </div>
                         <div class="modal-footer">

                            
                            <asp:Button ID="_btnCerrarClientes" runat="server" Text="Cancelar" class="btn btn-primary" data-dismiss="modal" />
                        </div>
                    </asp:Panel>
     </div>
        </div>
</asp:Content>
