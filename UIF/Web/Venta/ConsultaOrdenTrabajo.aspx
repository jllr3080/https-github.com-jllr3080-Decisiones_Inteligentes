 <%@ Page Title="<%$ Resources:Web_es_Ec,Titulo_Pagina_Consulta_Orden_Trabajo%>" Language="C#" MasterPageFile="~/PaginaMaestra/Site.Master" AutoEventWireup="true" CodeBehind="ConsultaOrdenTrabajo.aspx.cs" Inherits="Web.Venta.ConsultaOrdenTrabajo" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=16.1.1.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <br>
    <br>
    <br>
   <h2>
        <asp:Literal runat="server" ID="_literalTitulo" Text="<%$ Resources:Web_es_Ec,Titulo_Pagina_Consulta_Orden_Trabajo%>"/>
    </h2>
     <section>
          <div class="panel panel-default" id="_datosBusquedaCliente">
           <div class="panel-heading"><asp:Literal runat="server" ID="Literal4" Text="<%$ Resources:Web_es_Ec,Panel_Busqueda_Orden_Trabajo%>"/></div>
        <div class="panel-body">
            <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="labelNumeroOrden" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Numero_Orden%>"></asp:Label>
                    </div>
                    
            </div>
            <div class="row">
                    <div class="col-md-3">
                          <asp:TextBox ID="_numeroOrden" runat="server" ValidationGroup="Busqueda" CssClass="form-control" AutoCompleteType="Disabled" TextMode="Number" MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="_numeroOrdenValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="Busqueda" ControlToValidate="_numeroOrden" ></asp:RequiredFieldValidator>
                    </div>
                     <div class="col-md-3">
                        <asp:Button ID="_btnBuscar" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Buscar%>" ValidationGroup="Busqueda"  CssClass="btn btn-primary" OnClick="_btnBuscar_Click" />
                    </div>
            </div>
        </div>
    </div>
    <br />
     <div class="panel panel-default" id="_datoOrdenTrabajo">
           <div class="panel-heading"><asp:Literal runat="server" ID="_literalDetallaHistorial" Text="<%$ Resources:Web_es_Ec,Panel_Historial_Proceso%>"/></div>
        <div class="panel-body">
            
             <div class="row">
                
                    <div class="row">
                            <div class="col-md-12">
                                <asp:GridView ID="_datosHistorial" runat="server"  CssClass="tableCabecera" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField DataField="NumeroOrden" HeaderText="Numero de Orden" />
                                        <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha" />
                                        <asp:BoundField DataField="EtapaProceso.Descripcion" HeaderText="Etapa Proceso" />
                                    </Columns>
                                </asp:GridView> 
                            </div>
                    </div>
             </div>
        </div>
    </div>
          <br/>
    <div class="panel panel-default" id="_datoOrdenTrabajo">
           <div class="panel-heading"><asp:Literal runat="server" ID="Literal1" Text="<%$ Resources:Web_es_Ec,Panel_Orden_Trabajo%>"/></div>
        <div class="panel-body">
            
           
             <div class="row">
                  <div class="col-md-3">
                        <asp:Label ID="_labelNumeroOrden" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Numero_Orden%>"></asp:Label>
                        
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="_labelCliente" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Nombre_Cliente%>"></asp:Label>
                        
                    </div>
                  <div class="col-md-3">
                        <asp:Label ID="_labelTipoLavado" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Tipo_Lavado%>"></asp:Label>
                       
                    </div>
                    
                    <div class="col-md-3">
                        <asp:Label ID="_labelEstadoPago" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Estado_Pago%>"></asp:Label>
                        
                    </div>
                    
            </div>
           
            <div class="row">
                 <div class="col-md-3">
                        <asp:TextBox ID="_numeroOrdenResultado" runat="server"  CssClass="form-control" ReadOnly="True" ></asp:TextBox>
                        
                    </div>
                    <div class="col-md-3">
                       <asp:TextBox ID="_cliente" runat="server"  CssClass="form-control" ReadOnly="True" ></asp:TextBox>
                       
                    </div>
                <div class="col-md-3">
                         <asp:TextBox ID="_tipoLavado" runat="server"  CssClass="form-control" ReadOnly="True" ></asp:TextBox>
                    </div>
                 <div class="col-md-3">
                        <asp:TextBox ID="_estadoPago" runat="server"  CssClass="form-control" ReadOnly="True" ></asp:TextBox>
                        
                    </div>
                   
                    
                </div>
             <br/>
             <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="_labelFechaIngreso" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Fecha%>"></asp:Label>
                        
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="_labelFechaEntrega" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Fecha_Entrega%>"></asp:Label>
                        
                    </div>
                   
                  <div class="col-md-3">
                        <asp:Label ID="_labelFechaEntregaEfectiva" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Fecha_Entrega_Real%>"></asp:Label>
                        
                    </div>
                    
            </div>
             <div class="row">
                    <div class="col-md-3">
                        
                        <asp:TextBox ID="_fechaIngreso" runat="server"  CssClass="form-control" ReadOnly="True" ></asp:TextBox>
                        
                    </div>
                    <div class="col-md-3">
                         <asp:TextBox ID="_fechaEntrega" runat="server"  CssClass="form-control" ReadOnly="True" ></asp:TextBox>
                    </div>
                   
                  <div class="col-md-3">
                        <asp:TextBox ID="_fechaEntregaEfectiva" runat="server"  CssClass="form-control" ReadOnly="True" ></asp:TextBox>
                        
                    </div>
                    
            </div>
            <br/>
            <div class="row">
                    <div class="col-md-12">
                        <asp:GridView ID="_datos" runat="server" AutoGenerateColumns="False" CssClass="tableCabecera" OnRowCommand="_datos_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad de Prenda" />
                                <asp:BoundField HeaderText="Prenda" DataField="Prenda" />
                                <asp:BoundField HeaderText="Color" DataField="Color" />
                                <asp:BoundField HeaderText="Marca" DataField="Marca" />
                                <asp:BoundField HeaderText="Valor Unitario" DataField="ValorUnitario" />
                                <asp:BoundField HeaderText="Valor Total" DataField="ValorTotal" />
                                <asp:TemplateField HeaderText="Mostrar Observaciones">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Content/Imagen/Observar.png"  CommandName="Observacion" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            
                        </asp:GridView>
                    </div>
                    
            </div>
            
        </div>
    </div>
     </section>
 <nav>
        <asp:Button ID="_cerrarOrdenTrabajo" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Cerrar_Orden_Trabajo%>"  ValidationGroup="GuardarOrden" class="btn btn-primary" OnClick="_cerrarOrdenTrabajo_Click" />
     <asp:Button ID="_anularOrden" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Anular_Orden_Trabajo%>"  ValidationGroup="GuardarOrden" class="btn btn-primary" OnClick="_anularOrden_Click"  />
        <asp:Button ID="_cancelar" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Cancelar%>"  class="btn btn-primary" OnClick="_cancelar_Click" />

    </nav>
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
                <asp:Button ID="_btnAnularOrden" runat="server" Text="" Visible="false" />
                    <cc1:ModalPopupExtender ID="_btnAnularOrden_ModalPopupExtender" PopupControlID="_panelAnularOrden" runat="server" BehaviorID="_btnAnularOrden_ModalPopupExtender" TargetControlID="_btnAnularOrden" BackgroundCssClass="modal-Backgoround" X="500" OnCancelScript="_btnCancelaAnulacionrOrden" OnOkScript="_btnAceptaAnulacionOrden" Y="300">
                    </cc1:ModalPopupExtender>
                    <asp:Panel ID="_panelAnularOrden" runat="server" Style="display: none; background-color: white; width: 50%; height: auto;align-content:center ">
                        <div class="modal-header">
                            <h4 class="modal-title"><asp:Literal runat="server" Text="<%$ Resources:Web_es_Ec,Literal_Anular_Orden%>"></asp:Literal></h4>
                        </div>
                        <div class="modal-body">
                                 <div class="row">
                                    <div class="col-md-4">
                                         <asp:Label ID="_labelEstadoPagoAnularOrden" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Estado_Pago%>"></asp:Label>
                                    </div>
                                    <div class="col-md-4">
                                         <asp:Label ID="_labelValorTotalAnularOrden" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Valor_Total%>"></asp:Label>
                                    </div>
                                     
                                     <div class="col-md-4">
                                         <asp:Label ID="_labelObservacionAnulacion" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Observaciones_Anulacion%>"></asp:Label>
                                    </div>
                                  
                                </div>
                                <div class="row">
                                    <div class="col-md-4">
                                          <asp:TextBox ID="_estadoPagoAnularOrden" runat="server" ValidationGroup="AnularOrden" CssClass="form-control" AutoCompleteType="Disabled"  ReadOnly="True"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="_estadoPagoAnularOrdenValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="AnularOrden" ControlToValidate="_estadoPagoAnularOrden" ></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="_valorTotalAnularOrden" runat="server" class="form-control" ValidationGroup="AnularOrden"  ReadOnly="True" ></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="_valorTotalAnularOrdenValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="AnularOrden" ControlToValidate="_valorTotalAnularOrden" ></asp:RequiredFieldValidator>
                                        <cc1:MaskedEditExtender ID="_valorTotalAnularOrdenExtensor" runat="server" TargetControlID="_valorTotalAnularOrden" Mask="999.99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" MaskType="Number" InputDirection="RightToLeft" AcceptNegative="Left" DisplayMoney="Left" ErrorTooltipEnabled="True" /> 
                                    </div>
                                    <div class="col-md-4">
                                         <asp:TextBox ID="_observacionAnularOrden" runat="server" ValidationGroup="AnularOrden" CssClass="form-control" AutoCompleteType="Disabled"  ></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="_observacionAnularOrdenValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="AnularOrden" ControlToValidate="_observacionAnularOrden" ></asp:RequiredFieldValidator>
                                         
                                    </div>
                                  
                                </div>

                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="_btnAceptaAnulacionOrden" runat="server" Text="Anular Orden" class="btn btn-primary" data-dismiss="modal" OnClick="_btnAceptaAnulacionOrden_Click" ValidationGroup="AnularOrden" />
                            <asp:Button ID="_btnCancelaAnulacionrOrden" runat="server" Text="Cancelar" class="btn btn-primary" data-dismiss="modal" />
                        </div>
                    </asp:Panel>
     </div>
     </div>
    
    <br />
    <div class="row" >
                  <div class="col-md-12" >
                <asp:Button ID="_btnCerrarOrden" runat="server" Text="" Visible="false" />
                    <cc1:ModalPopupExtender ID="_btnCerrarOrden_ModalPopupExtender" PopupControlID="_panelCerrarOrden" runat="server" BehaviorID="_btnCerrarOrden_ModalPopupExtender" TargetControlID="_btnCerrarOrden" BackgroundCssClass="modal-Backgoround" X="500" OnCancelScript="_btnCancelarCerrarOrden" OnOkScript="_btnAceptarCerrarOrden" Y="300">
                    </cc1:ModalPopupExtender>
                    <asp:Panel ID="_panelCerrarOrden" runat="server" Style="display: none; background-color: white; width: 40%; height: auto;align-content:center ">
                        <div class="modal-header">
                            <h4 class="modal-title"><asp:Literal runat="server" Text="<%$ Resources:Web_es_Ec,Literal_Cerrar_Orden%>"></asp:Literal> </h4>
                        </div>
                        <div class="modal-body">
                                
                                <div class="row">
                                    <div class="col-md-6">
                                         <asp:Label ID="_labelEstadoPagoOrden" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Estado_Pago%>"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                         <asp:Label ID="_labelvalor" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Valor_Total%>"></asp:Label>
                                    </div>
                                  
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                         <asp:DropDownList ID="_estadoPagoOrden" runat="server" CssClass="form-control" ValidationGroup="CerrarOrden" DataTextField="Descripcion" DataValueField="EstadoPagoId" ></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="_estadoPagoOrdenValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="CerrarOrden" ControlToValidate="_estadoPagoOrden" ></asp:RequiredFieldValidator>
                                    </div>
                                     <div class="col-md-6">
                                         <asp:TextBox ID="_valorTotal" runat="server" class="form-control" ValidationGroup="CerrarOrden"  ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="_valorTotalValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="CerrarOrden" ControlToValidate="_valorTotal" ></asp:RequiredFieldValidator>
                                     <cc1:MaskedEditExtender ID="_valorTotalMascara" runat="server" TargetControlID="_valorTotal" Mask="999.99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" MaskType="Number" InputDirection="RightToLeft" AcceptNegative="Left" DisplayMoney="Left" ErrorTooltipEnabled="True" />
                                    </div>
                                  
                                </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="_btnAceptarCerrarOrden" runat="server" Text="Cerrar Orden" class="btn btn-primary" data-dismiss="modal" OnClick="_btnAceptarCerrarOrden_Click"  />
                            <asp:Button ID="_btnCancelarCerrarOrden" runat="server" Text="Cancelar" class="btn btn-primary" data-dismiss="modal" />
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
                    <asp:Panel ID="_panelObservacion" runat="server" Style="display: none; background-color: white; width: 20%; height: auto;align-content:center ">
                        <div class="modal-header">
                            <h4 class="modal-title">Observaciones</h4>
                        </div>
                        <div class="modal-body">
                            <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="_btnAceptarObservaciones" runat="server" Text="Agregar Observacion" class="btn btn-primary" data-dismiss="modal" OnClick="_btnAceptarObservaciones_Click" />
                            <asp:Button ID="_btnCancelarObservaciones" runat="server" Text="Cancelar" class="btn btn-primary" data-dismiss="modal" />
                        </div>
                    </asp:Panel>
     </div>
     </div>
</asp:Content>
