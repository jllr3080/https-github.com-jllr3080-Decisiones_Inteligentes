<%@ Page Title="<%$ Resources:Web_es_Ec,Titulo_Pagina_Aprobacion_Descuento%>" Language="C#" MasterPageFile="~/PaginaMaestra/Site.Master" AutoEventWireup="true" CodeBehind="AprobacionDescuento.aspx.cs" Inherits="Web.Venta.AprobacionDescuento" MaintainScrollPositionOnPostback="true"%>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=16.1.1.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <br>
    <br>
    <br>
    <br>
   <h2>
        <asp:Literal runat="server" ID="_literalTitulo" Text="<%$ Resources:Web_es_Ec,Titulo_Pagina_Aprobacion_Descuento%>"/>
    </h2>
    <section>
     <div class="panel panel-default" id="_datosDescuento">
           <div class="panel-heading"><asp:Literal runat="server" ID="_literalEncabezado" Text="<%$ Resources:Web_es_Ec,Panel_Datos_Aprobacion_Descuento%>"/></div>
        <div class="panel-body">
            <div class="row">
                <asp:HiddenField ID="_ordenTrabajoDescuentoId" runat="server" />
                    <div class="col-md-12">
                         <asp:GridView ID="_datos" runat="server" AutoGenerateColumns="False"  ShowFooter="True" OnRowCommand="_datos_RowCommand" Width="100%">
                            <Columns>
                               
                                
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="_seleccionar" runat="server" ImageUrl="~/Content/Imagen/Editar.png"  CommandName="Editar" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                                <asp:BoundField DataField="OrdenTrabajoDescuento.OrdenTrabajoDescuentoId" HeaderText="Código Interno" />
                                <asp:BoundField DataField="NombrePuntoVenta" HeaderText="Sucursal" />
                                 <asp:BoundField DataField="OrdenTrabajoDescuento.OrdenTrabajo.NumeroOrden" HeaderText="Numero de Orden" />
                                <asp:BoundField DataField="OrdenTrabajoDescuento.Valor" HeaderText="Valor Descuento" />
                                <asp:BoundField DataField="OrdenTrabajoDescuento.Motivo" HeaderText="Motivo" />
                                <asp:BoundField DataField="OrdenTrabajoDescuento.PorcentajeFranquicia" HeaderText="Porcentaje Franquicia" />
                                <asp:BoundField DataField="OrdenTrabajoDescuento.PorcentajeMatriz" HeaderText="Porcentaje Matriz" />
                               
                            </Columns>
                             <HeaderStyle CssClass="tableCabecera" ></HeaderStyle>
                             <FooterStyle CssClass="tablePiePagina"></FooterStyle>
                        </asp:GridView>
                        
                    </div>
                    
            </div>

         </div>
        </div>
        <br>
     <div class="panel panel-default" id="_datosAprobacionDecuento">
           <div class="panel-heading"><asp:Literal runat="server" ID="Literal1" Text="<%$ Resources:Web_es_Ec,Panel_Aprobacion_Descuento%>"/></div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-3">
                          <asp:Label ID="_labelPuntoVenta" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Sucursal%>"></asp:Label>
                        
                    </div>    
                <div class="col-md-3">
                          <asp:Label ID="labelNumeroOrden" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Numero_Orden%>"></asp:Label>
                        
                </div>
                
                <div class="col-md-3">
                          <asp:Label ID="_labelValor" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Valor_Descuento%>"></asp:Label>
                        
                </div>
                <div class="col-md-3">
                          <asp:Label ID="_labelMotivo" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Motivo_Descuento%>"></asp:Label>
                        
                </div>
                    

                    
            </div>
            <div class="row">
                    <div class="col-md-3">
                            <asp:TextBox ID="_puntoVenta" runat="server" ValidationGroup="Aprobacion" CssClass="form-control"  ReadOnly="True"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="_puntoVentaValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="Aprobacion" ControlToValidate="_puntoVenta" ></asp:RequiredFieldValidator>
                        
                    </div>
                    <div class="col-md-3">
                            <asp:TextBox ID="_numeroOrden" runat="server" ValidationGroup="Aprobacion" CssClass="form-control"  ReadOnly="True"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="_numeroOrdenValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="Aprobacion" ControlToValidate="_numeroOrden" ></asp:RequiredFieldValidator>
                        
                    </div>
                  <div class="col-md-3">
                            <asp:TextBox ID="_valor" runat="server" ValidationGroup="Aprobacion" CssClass="form-control"  ReadOnly="True"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="_valorValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="Aprobacion" ControlToValidate="_valor" ></asp:RequiredFieldValidator>
                        
                    </div>
                 <div class="col-md-3">
                            <asp:TextBox ID="_motivo" runat="server" ValidationGroup="Aprobacion" CssClass="form-control"  ReadOnly="True"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="_motivovalidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="Aprobacion" ControlToValidate="_motivo" ></asp:RequiredFieldValidator>
                        
                    </div>

                    
            </div>
            <br/>
            <div class="row">
                <div class="col-md-3">
                          <asp:Label ID="_labelPorcentajeFranquicia" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Porcentaje_Franquicia%>"></asp:Label>
                        
                    </div>    
                <div class="col-md-3">
                          <asp:Label ID="_labelPorcentajeMatriz" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Porcentaje_Matriz%>"></asp:Label>
                        
                </div>
                
                <div class="col-md-3">
                          <asp:Label ID="_labelValorAprobadoFranquicia" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Valor_Aprobado_Franquicia%>"></asp:Label>
                        
                </div>
                <div class="col-md-3">
                          <asp:Label ID="_labelValorAprobadoMatriz" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Valor_Aprobado_Matriz%>"></asp:Label>
                        
                </div>
                    

                    
            </div>
            <div class="row">
                    <div class="col-md-3">
                            <asp:TextBox ID="_porcentajeFranquicia" runat="server" ValidationGroup="Aprobacion" CssClass="form-control"  ReadOnly="True"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="Aprobacion" ControlToValidate="_puntoVenta" ></asp:RequiredFieldValidator>
                        
                    </div>
                    <div class="col-md-3">
                            <asp:TextBox ID="_porcentajeMatriz" runat="server" ValidationGroup="Aprobacion" CssClass="form-control"  ReadOnly="True"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="Aprobacion" ControlToValidate="_numeroOrden" ></asp:RequiredFieldValidator>
                        
                    </div>
                  <div class="col-md-3">
                            <asp:TextBox ID="_valorAprobadoFranquicia" runat="server" ValidationGroup="Aprobacion" CssClass="form-control"  ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="Aprobacion" ControlToValidate="_valor" ></asp:RequiredFieldValidator>
                        
                    </div>
                 <div class="col-md-3">
                            <asp:TextBox ID="_valorAprobadoMatriz" runat="server" ValidationGroup="Aprobacion" CssClass="form-control"  ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="Aprobacion" ControlToValidate="_motivo" ></asp:RequiredFieldValidator>
                        
                    </div>

                    
            </div>

         </div>
        </div>
     

    </section>
      <nav>
        <asp:Button ID="_aprobacionDescuento" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Guardar_Orden_Trabajo%>"  ValidationGroup="Aprobacion" class="btn btn-primary" OnClick="_aprobacionDescuento_Click" />
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
</asp:Content>
