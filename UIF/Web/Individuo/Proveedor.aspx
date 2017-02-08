<%@ Page Title="<%$ Resources:Web_es_Ec,Titulo_Pagina_Proveedor%>" Language="C#" MasterPageFile="~/PaginaMaestra/Site.Master" AutoEventWireup="true" CodeBehind="Proveedor.aspx.cs" Inherits="Web.Individuo.Proveedor" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=16.1.1.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
    <br/>
    <br/>
    <br/>
    <h2><asp:Literal runat="server" Text="<%$ Resources:Web_es_Ec,Titulo_Pagina_Proveedor%>"></asp:Literal></h2>
     <section>
    <div class="panel panel-default" id="_datosBusquedaCliente">
           <div class="panel-heading"><asp:Literal runat="server" ID="Literal4" Text="<%$ Resources:Web_es_Ec,Panel_Busqueda_Proveedor%>"/></div>
        <div class="panel-body">
            <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="_labelNumeroDocumentoBusqueda" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Numero_Documento%>"></asp:Label>
                    </div>
                    
            </div>
            <div class="row">
                    <div class="col-md-3">
                          <asp:TextBox ID="_numeroDocumentoBusqueda" runat="server" ValidationGroup="Busqueda" CssClass="form-control" AutoCompleteType="Disabled" MaxLength="13"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="_numeroDocumentoBusquedaValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="Busqueda" ControlToValidate="_numeroDocumentoBusqueda" ></asp:RequiredFieldValidator>
                    </div>
                     <div class="col-md-3">
                        <asp:Button ID="_btnBusqueda" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Buscar%>" ValidationGroup="Busqueda"  CssClass="btn btn-primary" OnClick="_btnBusqueda_Click"  />
                    </div>
        
            </div>
        </div>
    </div>
     <div class="panel panel-default" id="_datosGeneralesProveedor">
           <div class="panel-heading"><asp:Literal runat="server" ID="Literal1" Text="<%$ Resources:Web_es_Ec,Panel_Datos_Generales_Proveedor%>"/></div>
        <div class="panel-body">
            <div class="row">
                   
                    <div class="col-md-6">
                        <asp:Label ID="_labelRazonSocial" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Razon_Social%>" Width="100%"></asp:Label>
                    </div>
                     <div class="col-md-6">
                        <asp:Label ID="_labelNombreRepresentanteLegal" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Nombre_Representante_Legal%>" Width="100%"></asp:Label>
                    </div>
                    
            </div>
            <div class="row">
                    <div class="col-md-6">
                          <asp:TextBox ID="_razonSocial" runat="server" ValidationGroup="CrearModificarProveedor" CssClass="form-control" AutoCompleteType="Disabled" Width="100%" ></asp:TextBox>
                          <asp:RequiredFieldValidator ID="_razonSocialValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="CrearModificarProveedor" ControlToValidate="_razonSocial" ></asp:RequiredFieldValidator>
                    </div>
                     <div class="col-md-6">
                         <asp:TextBox ID="_nombreRepresentanteLegal" runat="server" ValidationGroup="CrearModificarProveedor" CssClass="form-control" AutoCompleteType="Disabled" Width="100%"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="_nombreRepresentanteLegalValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="CrearModificarProveedor" ControlToValidate="_nombreRepresentanteLegal" ></asp:RequiredFieldValidator>
                       </div>
                    
            </div>
            <br />
            <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="_labelTipoDocumento" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Tipo_Documento%>"></asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="_labelNumeroDocumento" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Numero_Documento%>"></asp:Label>
                    </div>
                     <div class="col-md-3">
                        <asp:Label ID="_labelFormaPago" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Forma_Pago_Opcional%>"></asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="_labelDiasCredito" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Dias_Credito%>"></asp:Label>
                    </div>
                    
            </div>
            <div class="row">
                    <div class="col-md-3">
                          <asp:DropDownList ID="_tipoDocumento" runat="server" CssClass="form-control" ValidationGroup="CrearModificarProveedor" DataTextField="Descripcion" DataValueField="TipoIdentificacionId"></asp:DropDownList>
                    </div>
                     <div class="col-md-3">
                         <asp:TextBox ID="_numeroDocumento" runat="server" ValidationGroup="CrearModificarProveedor" CssClass="form-control" AutoCompleteType="Disabled" AutoPostBack="True" OnTextChanged="_numeroDocumento_TextChanged" MaxLength="13"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="_numeroDocumentoValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="CrearModificarProveedor" ControlToValidate="_numeroDocumento" ></asp:RequiredFieldValidator>
                       </div>
                    <div class="col-md-3">
                         <asp:DropDownList ID="_formaPago" runat="server" CssClass="form-control" ValidationGroup="CrearModificarProveedor" DataTextField="Descripcion" DataValueField="FormaPagoId"></asp:DropDownList>
                    </div>
                    <div class="col-md-3">
                         <asp:TextBox ID="_diasCredito" runat="server"  AutoCompleteType="Disabled" CssClass="form-control" onkeypress="return validarNumerosParaFecha(event)" MaxLength="10" ValidationGroup="CrearModificarProveedor"></asp:TextBox>
                          
                         
                    </div>
            </div>

        </div>
    </div>
       
     <div class="panel panel-default" id="_datosDirecion">
           <div class="panel-heading"><asp:Literal runat="server" ID="_literalDireccion" Text="<%$ Resources:Web_es_Ec,Panel_Datos_Direccion_Proveedor%>"/></div>
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
                        <asp:Label ID="_labelTipoDireccion" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Tipo_Direccion%>"></asp:Label>
                    </div>
                    
            </div>
            <div class="row">
                    <div class="col-md-3">
                         <asp:DropDownList ID="_pais" runat="server" CssClass="form-control" AutoPostBack="True" ValidationGroup="CrearModificarProveedor" DataTextField="Descripcion" DataValueField="PaisId"></asp:DropDownList>
                          <asp:RequiredFieldValidator ID="_paisValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="CrearModificarProveedor" ControlToValidate="_pais" InitialValue="-1" ></asp:RequiredFieldValidator>
                    </div>
                     <div class="col-md-3">
                         <asp:DropDownList ID="_provincia" runat="server" CssClass="form-control" AutoPostBack="True" ValidationGroup="CrearModificarProveedor" DataTextField="Descripcion" DataValueField="EstadoId" OnSelectedIndexChanged="_provincia_SelectedIndexChanged"></asp:DropDownList>
                          <asp:RequiredFieldValidator ID="_provinciaValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="CrearModificarProveedor" ControlToValidate="_provincia" ></asp:RequiredFieldValidator>
                       </div>
                    <div class="col-md-3">
                         <asp:DropDownList ID="_ciudad" runat="server" CssClass="form-control" ValidationGroup="CrearModificarProveedor" DataTextField="Descripcion" DataValueField="CiudadId"></asp:DropDownList>
                          <asp:RequiredFieldValidator ID="_ciudadValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="CrearModificarProveedor" ControlToValidate="_ciudad" ></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3">
                         <asp:DropDownList ID="_tipoDireccion" runat="server" CssClass="form-control" ValidationGroup="CrearModificarProveedor" DataTextField="Descripcion" DataValueField="TipoDireccionId"></asp:DropDownList>
                          <asp:RequiredFieldValidator ID="_tipoDireccionValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="CrearModificarProveedor" ControlToValidate="_tipoDireccion" ></asp:RequiredFieldValidator>
                    </div>
            </div>
            <br />
            <div class="row">
                    <div class="col-md-6">
                        <asp:Label ID="_labelDireccion" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Direccion%>"></asp:Label>
                    </div>
                    
                    
            </div>
            <div class="row">
                    <div class="col-md-6">
                          <asp:TextBox ID="_direccion" runat="server" ValidationGroup="CrearModificarProveedor" CssClass="form-control" AutoCompleteType="Disabled" MaxLength="100"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="_direccionValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="CrearModificarProveedor" ControlToValidate="_direccion" ></asp:RequiredFieldValidator>
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
                          <asp:DropDownList ID="_tipoCorreo" runat="server" CssClass="form-control" ValidationGroup="CrearModificarProveedor" DataTextField="Descripcion" DataValueField="TipoCorreoElectronicoId"></asp:DropDownList>
                          <asp:RequiredFieldValidator ID="_tipoCorreoValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="CrearModificarProveedor" ControlToValidate="_tipoCorreo" ></asp:RequiredFieldValidator>
                    </div>
                     <div class="col-md-3">
                         <asp:TextBox ID="_email" runat="server" ValidationGroup="CrearModificarProveedor" CssClass="form-control" AutoCompleteType="Disabled" MaxLength="35" TextMode="Email"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="_emailValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="CrearModificarProveedor" ControlToValidate="_email" ></asp:RequiredFieldValidator>
                       </div>
                    <div class="col-md-3">
                         <asp:DropDownList ID="_tipoTelefono" runat="server" CssClass="form-control" ValidationGroup="CrearModificarProveedor" DataTextField="Descripcion" DataValueField="TipoTelefonoId"></asp:DropDownList>
                          <asp:RequiredFieldValidator ID="_tipoTelefonoValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="CrearModificarProveedor" ControlToValidate="_tipoTelefono" ></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3">
                         <asp:TextBox ID="_telefono" runat="server" ValidationGroup="CrearModificarProveedor" CssClass="form-control" AutoCompleteType="Disabled" MaxLength="10" TextMode="SingleLine"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="_telefonoValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="CrearModificarProveedor" ControlToValidate="_telefono" ></asp:RequiredFieldValidator>
                    </div>
            </div>
            <br />
            

        </div>
    </div>
   </section>
     <nav>
        <asp:Button ID="_grabarProveedor" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Crear_Modificar_Cliente%>" CssClass="btn btn-primary"  ValidationGroup="CrearModificarProveedor" OnClick="_grabarProveedor_Click" />
        <asp:Button ID="_cancelar" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Cancelar%>" CssClass="btn btn-primary" OnClick="_cancelar_Click" />
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
</asp:Content>
