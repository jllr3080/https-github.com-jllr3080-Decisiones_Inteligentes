<%@ Page Title="<%$ Resources:Web_es_Ec,Titulo_Pagina_Entrega_Recepcion%>" Language="C#" MasterPageFile="~/PaginaMaestra/Site.Master" AutoEventWireup="true" CodeBehind="EntregaRecepcionPrendas.aspx.cs" Inherits="Web.Logistica.EntregaRecepcionPrendas" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=16.1.1.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <br>
    <br>
    <br>
   <h2>
        <asp:Literal runat="server" ID="_literalTitulo" Text="<%$ Resources:Web_es_Ec,Titulo_Pagina_Entrega_Recepcion%>"/>
    </h2>
    
    <section>
           <div class="panel panel-default" id="_datosBusquedaCliente">
           <div class="panel-heading"><asp:Literal runat="server" ID="_literalEncabezado" Text="<%$ Resources:Web_es_Ec,Panel_Listado_Prenda%>"/></div>
            <div class="panel-body">
            
                 <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="_labelNombrePerfil" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Nombre_Perfil%>" ></asp:Label>
                        </div>
                        <div class="col-md-3">
                            <asp:Label ID="_labelEtapaProceso" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Etapa_Proceso%>" ></asp:Label>
                        </div>
                        <div class="col-md-3">
                            <asp:Label ID="_labelEtapaProcesoDestino" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Etapa_Proceso_Destino%>"></asp:Label>
                         </div>
                </div>
                 <div class="row">
                        <div class="col-md-3">
                            <asp:TextBox ID="_nombrePerfil" runat="server" ValidationGroup="BusquedaPrenda" CssClass="form-control" AutoCompleteType="Disabled"  ReadOnly="True"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="_nombrePerfilValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="BusquedaPrenda" ControlToValidate="_nombrePerfil" ></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-3">
                            
                            <asp:DropDownList ID="_etapaProceso" runat="server" CssClass="form-control" ValidationGroup="BusquedaPrenda" DataTextField="Descripcion" DataValueField="EtapaProcesoId" AutoPostBack="True" OnSelectedIndexChanged="_etapaProceso_SelectedIndexChanged"></asp:DropDownList>
                          <asp:RequiredFieldValidator ID="_etapaProcesoValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="BusquedaPrenda" ControlToValidate="_etapaProceso" InitialValue="-1" ></asp:RequiredFieldValidator>
                        </div>
                     <div class="col-md-3">
                            <asp:DropDownList ID="_etapaProcesoDestino" runat="server" CssClass="form-control" ValidationGroup="GuardarPrenda" DataTextField="Descripcion" DataValueField="EtapaProcesoId"></asp:DropDownList>
                          <asp:RequiredFieldValidator ID="_etapaProcesoDestinoValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GuardarPrenda" ControlToValidate="_etapaProcesoDestino" InitialValue="-1" ></asp:RequiredFieldValidator>
                         </div>
                        
                </div>
                <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="_datos" runat="server" Width="100%" AutoGenerateColumns="False" OnRowCommand="_datos_RowCommand">
                                <Columns>
                                    <asp:BoundField DataField="OrdenTrabajo.OrdenTrabajoId"  HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Numero_Orden%>"/>
                                    <asp:BoundField DataField="OrdenTrabajo.NumeroOrden"  HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Numero_Orden%>"/>
                                    <asp:BoundField DataField="NumeroPrenda"  HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Numero_Prendas%>"/>
                                    <asp:BoundField DataField="OrdenTrabajo.FechaIngreso"  HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Fecha_Recepcion%>"/>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="_imgDetalleOrden" runat="server" ImageUrl="~/Content/Imagen/Editar.png"  CommandName="DetalleOrden" CommandArgument="<%# ((GridViewRow)Container).RowIndex%>" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="_aceptarEntrega" class="form-control" runat="server" />
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
        <asp:Button ID="_grabarEntregaRecepcionPrenda" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Entrega_Recepcion_Prenda%>"  class="btn btn-primary" OnClick="_grabarEntregaRecepcionPrenda_Click" ValidationGroup="GuardarPrenda"/>
        <asp:Button ID="_cancelar" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Cancelar%>"  class="btn btn-primary" OnClick="_cancelar_Click" />
      

    </nav>

     <div class="row" >
                  <div class="col-md-12" >
                <asp:Button ID="_btnMensaje" runat="server" Text="" Visible="false" />
                    <cc1:ModalPopupExtender ID="_btnMensaje_ModalPopupExtender" PopupControlID="_panelMensaje" runat="server" BehaviorID="_btnMensaje_ModalPopupExtender" TargetControlID="_btnMensaje" BackgroundCssClass="modal-Backgoround" X="500" OnCancelScript="_btnAceptar" Y="300">
                    </cc1:ModalPopupExtender>
                    <asp:Panel ID="_panelMensaje" runat="server" Style="display: none; background-color: white; width: 20%; height: auto;align-content:center ">
                        <div class="modal-header">
                            <h4 class="modal-title">
                                <asp:Literal ID="_literalMensajesistema" runat="server"  Text="<%$ Resources:Web_es_Ec,Mensaje_Sistema%>"></asp:Literal></h4>
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
                <asp:Button ID="_btnSeguridad" runat="server" Text="" Visible="false" />
                    <cc1:ModalPopupExtender ID="_btnSeguridad_ModalPopupExtender" PopupControlID="_panelSegurdidad" runat="server" BehaviorID="_btnSeguridad_ModalPopupExtender" TargetControlID="_btnSeguridad" BackgroundCssClass="modal-Backgoround" X="500" OnCancelScript="_btnCancelarGuardarInformacion" OnOkScript="_btnGuardarinformacion" Y="300">
                    </cc1:ModalPopupExtender>
                    <asp:Panel ID="_panelSegurdidad" runat="server" Style="display: none; background-color: white; width: 50%; height: auto;align-content:center ">
                        <div class="modal-header">
                            <h4 class="modal-title">
                                <asp:Literal ID="Literal1" runat="server"  Text="<%$ Resources:Web_es_Ec,Panel_Entrega_Recepcion_Seguridad%>"></asp:Literal></h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                    <div class="col-md-6">
                                        <asp:Label ID="_labelUsuario" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Usuario%>"></asp:Label>
                                    </div>
                                 <div class="col-md-6">
                                        <asp:Label ID="_labelContrasena" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Contrasena%>"></asp:Label>
                                    </div>
                              </div>    
                             <div class="row">
                                    <div class="col-md-6">
                                         <asp:TextBox ID="_usuario" runat="server" ValidationGroup="Guardar" CssClass="form-control" AutoCompleteType="Disabled"  ></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="_usuarioValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="Guardar" ControlToValidate="_usuario" ></asp:RequiredFieldValidator>
                                    </div>
                                 <div class="col-md-6">
                                        <asp:TextBox ID="_contrasena" runat="server" ValidationGroup="Guardar" CssClass="form-control" AutoCompleteType="Disabled" TextMode="Password" ></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="_contrasenaValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="Guardar" ControlToValidate="_contrasena" ></asp:RequiredFieldValidator>
                                    </div>
                              </div>                
                            
                        </div>
                        <div class="modal-footer">

                            <asp:Button ID="_btnGuardarinformacion" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Aceptar%>" class="btn btn-primary" data-dismiss="modal" OnClick="_btnGuardarinformacion_Click"  ValidationGroup="Guardar"/>
                            <asp:Button ID="_btnCancelarGuardarInformacion" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Cancelar%>"  class="btn btn-primary" data-dismiss="modal" />
                        </div>
                    </asp:Panel>
     </div>
    </div>
     <div class="row" >
                  <div class="col-md-12" >
                <asp:Button ID="_btnDetalleOrden" runat="server" Text="" Visible="false" />
                    <cc1:ModalPopupExtender ID="_btnDetalleOrden_ModalPopupExtender" PopupControlID="_panelDetalleOrden" runat="server" BehaviorID="_btnDetalleOrden_ModalPopupExtender" TargetControlID="_btnDetalleOrden" BackgroundCssClass="modal-Backgoround" X="500" OnCancelScript="_btnAceptarDetalle"  Y="300">
                    </cc1:ModalPopupExtender>
                    <asp:Panel ID="_panelDetalleOrden" runat="server" Style="display: none; background-color: white; width: 50%; height: auto;align-content:center ">
                        <div class="modal-header">
                            <h4 class="modal-title">
                                <asp:Literal ID="Literal2" runat="server"  Text="<%$ Resources:Web_es_Ec,Panel_Detalle_Orden_Trabajo%>"></asp:Literal></h4>
                        </div>
                        <div class="modal-body">
                             <div class="row">
                                    <div class="col-md-6">
                                        <asp:GridView ID="_datosDetalleOrden" runat="server">
                                            <HeaderStyle CssClass="tableCabecera" ></HeaderStyle>
                                            <FooterStyle CssClass="tablePiePagina"></FooterStyle> 
                                        </asp:GridView>
                                    </div>
                              </div>                
                            
                        </div>
                        <div class="modal-footer">

                            <asp:Button ID="_btnAceptarDetalle" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Aceptar%>" class="btn btn-primary" data-dismiss="modal" />
                            
                        </div>
                    </asp:Panel>
     </div>
    </div>
</asp:Content>
