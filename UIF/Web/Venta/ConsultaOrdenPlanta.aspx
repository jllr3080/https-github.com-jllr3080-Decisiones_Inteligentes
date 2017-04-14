<%@ Page Title="<%$ Resources:Web_es_Ec,Titulo_Pagina_Consulta_Orden_Planta%>" Language="C#" MasterPageFile="~/PaginaMaestra/Site.Master" AutoEventWireup="true" CodeBehind="ConsultaOrdenPlanta.aspx.cs" Inherits="Web.Venta.ConsultaOrdenPlanta" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=16.1.1.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <br>
    <br>
    <br>
    <br>
   <h2>
        <asp:Literal runat="server" ID="_literalTitulo" Text="<%$ Resources:Web_es_Ec,Titulo_Pagina_Consulta_Orden_Planta%>"/>
    </h2>
     <section>
           <div class="panel panel-default" id="_datosBusquedaOrden">
           <div class="panel-heading"><asp:Literal runat="server" ID="Literal4" Text="<%$ Resources:Web_es_Ec,Panel_Busqueda_Orden_Trabajo%>"/></div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-3">
                                <asp:Label ID="_labelSucursal" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Sucursal%>"></asp:Label>
                            </div>    
                        <div class="col-md-3">
                                <asp:Label ID="labelNumeroOrden" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Numero_Orden%>"></asp:Label>
                            </div>
                            
                    
                    </div>
                    <div class="row">
                        
                         <div class="col-md-3">
                                  <asp:DropDownList ID="_sucursal" runat="server" CssClass="form-control" DataValueField="PuntoVentaId" DataTextField="Descripcion"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="_sucursalValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="Obligatorio" ControlToValidate="_sucursal" ></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-3">
                                  <asp:TextBox ID="_numeroOrden" runat="server" ValidationGroup="Busqueda" CssClass="form-control" AutoCompleteType="Disabled"  ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="_numeroOrdenValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="Busqueda" ControlToValidate="_numeroOrden" ></asp:RequiredFieldValidator>
                            </div>
                             <div class="col-md-3">
                                <asp:Button ID="_btnBuscar" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Buscar%>" ValidationGroup="Busqueda"  CssClass="btn btn-primary" OnClick="_btnBuscar_Click" />
                            </div>
                    </div>
                </div>
            </div>
         <div class="panel panel-default" id="_detalleOrden">
           <div class="panel-heading"><asp:Literal runat="server" ID="Literal1" Text="<%$ Resources:Web_es_Ec,Panel_Detalle_Orden_Trabajo%>"/></div>
                <div class="panel-body">
                  <div class="row">
                            <div class="col-md-12">
                            <asp:GridView ID="_datos" runat="server" AutoGenerateColumns="False" OnRowCommand="_datos_RowCommand" Width="100%" OnRowDataBound="_datos_RowDataBound" ShowFooter="True" >
                            <Columns>
                                <asp:BoundField DataField="DetallePrendaOrdenTrabajoId" HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Codigo_Orden_Trabajo%>" />
                                <asp:BoundField HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Prenda%>" DataField="Prenda" />
                                <asp:BoundField HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Marca%>" DataField="Marca" />
                                <asp:BoundField HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Color%>" DataField="Color" />
                                <asp:BoundField HeaderText="<%$ Resources:Web_es_Ec,Label_Informacion_Visual%>" DataField="InformacionVisual" />
                                <asp:BoundField HeaderText="<%$ Resources:Web_es_Ec,Label_Estado_Prenda%>" DataField="EstadoPrenda" />
                                <asp:BoundField HeaderText="<%$ Resources:Web_es_Ec,Label_Numero_Interno%>" DataField="NumeroInternoPrenda" />
                                <asp:BoundField HeaderText="<%$ Resources:Web_es_Ec,Label_Tratamiento_Especial%>" DataField="TratamientoEspecial" />
                                
                                <asp:TemplateField HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Mostrar_Observaciones%>">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="_imgObservaciones" runat="server" ImageUrl="~/Content/Imagen/Observar.png"  CommandName="Observacion" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                             <HeaderStyle CssClass="tableCabecera" ></HeaderStyle>
                             <FooterStyle CssClass="tablePiePagina"></FooterStyle>
                        </asp:GridView>
                          
                    </div>
                </div>
            </div>
    </section>
    <br />
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
    <br />
    <div class="row" >
                  <div class="col-md-12" >
                <asp:Button ID="_btnObservaciones" runat="server" Text="" Visible="false" />
                    <cc1:ModalPopupExtender ID="_btnObservaciones_ModalPopupExtender" PopupControlID="_panelObservacion" runat="server" BehaviorID="_btnObservaciones_ModalPopupExtender" TargetControlID="_btnObservaciones" BackgroundCssClass="modal-Backgoround" X="500" OnCancelScript="_btnCancelarObservaciones" OnOkScript="_btnAceptarObservaciones" Y="300">
                    </cc1:ModalPopupExtender>
                    <asp:Panel ID="_panelObservacion" runat="server" Style="display: none; background-color: white; width: 60%; height: auto;align-content:center ">
                        <div class="modal-header">
                            <h4 class="modal-title">Observaciones</h4>
                        </div>
                        <div class="modal-body">
                             <div class="row">
                                    <div class="col-md-12">
                                        <asp:GridView ID="_datosObservaciones" runat="server" Width="100%" AutoGenerateColumns="False">
                                             <Columns>
                                             
                                             <asp:BoundField DataField="NombreUsuario" HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Nombre_Usuario%>" />
                                            <asp:BoundField DataField="DetalleOrdenTrabajoObservacion.FechaCreacionObservacion" HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Fecha%>" DataFormatString="{0:d}" />
                                            <asp:BoundField DataField="DetalleOrdenTrabajoObservacion.Observacion" HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Observacion%>" />
                                            </Columns>
                                             <HeaderStyle CssClass="tableCabecera" ></HeaderStyle>
                                             <FooterStyle CssClass="tablePiePagina"></FooterStyle>

                                        </asp:GridView>     
                                    </div>
                                    
                              </div>
                             <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label ID="_labelObservacion" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Observacion%>"></asp:Label>
                                        <asp:HiddenField ID="_detalleOrdenTrabajoId" runat="server" />
                                    </div>
                                    
                              </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:TextBox ID="_observacion" runat="server" class="form-control" ValidationGroup="AgregarObservacion"  ></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="_observacionValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="AgregarObservacion" ControlToValidate="_observacion" ></asp:RequiredFieldValidator>

                                    </div>
                                    
                                </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="_btnAceptarObservaciones" runat="server" Text="Agregar Observacion" class="btn btn-primary" data-dismiss="modal" OnClick="_btnAceptarObservaciones_Click" ValidationGroup="AgregarObservacion" />
                            <asp:Button ID="_btnCancelarObservaciones" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Cancelar%>" class="btn btn-primary" data-dismiss="modal" />
                        </div>
                    </asp:Panel>
     </div>
     </div>
</asp:Content>
