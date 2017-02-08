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
         
          <br/>
    <div class="panel panel-default" id="_datoOrdenTrabajo" data-toggle="collapse" data-target="#_divOrdenTrabajo">
           <div class="panel-heading"><asp:Literal runat="server" ID="Literal1" Text="<%$ Resources:Web_es_Ec,Panel_Orden_Trabajo%>" /></div>
        <div class="panel-body" id="_divOrdenTrabajo">
            
           
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
                        <asp:GridView ID="_datos" runat="server" AutoGenerateColumns="False" OnRowCommand="_datos_RowCommand" Width="100%" OnRowDataBound="_datos_RowDataBound" ShowFooter="True" >
                            <Columns>
                                <asp:BoundField DataField="DetalleOrdenTrabajoId" HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Codigo_Orden_Trabajo%>" />
                                <asp:BoundField DataField="Cantidad" HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Cantidad%>"/>
                                <asp:BoundField HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Prenda%>" DataField="Prenda" />
                                <asp:BoundField HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Color%>" DataField="Color" />
                                <asp:BoundField HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Marca%>" DataField="Marca" />
                                <asp:BoundField HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Valor_Unitario%>" DataField="ValorUnitario" DataFormatString="{0:C2}" ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle"  />
                                <asp:BoundField HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Valor_Total%>" DataField="ValorTotal"  DataFormatString="{0:C2}" ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle" />
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
    </div>
         
         <br />
         
     <div class="panel panel-default" id="_datoOrdenTrabajo" data-toggle="collapse" data-target="#_divHistorial">
           <div class="panel-heading"><asp:Literal runat="server" ID="_literalDetallaHistorial" Text="<%$ Resources:Web_es_Ec,Panel_Historial_Proceso%>"/></div>
        <div class="panel-body" id="_divHistorial" >
            
             <div class="row">
                
                    <div class="row">
                            <div class="col-md-6">
                                <asp:GridView ID="_datosHistorial" runat="server" AutoGenerateColumns="False" Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="NumeroOrden" HeaderText="Numero de Orden" />
                                        <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha" />
                                        <asp:BoundField DataField="EtapaProceso.Descripcion" HeaderText="Etapa Proceso" />
                                    </Columns>
                                     <HeaderStyle CssClass="tableCabecera" ></HeaderStyle>
                                       <FooterStyle CssClass="tablePiePagina"></FooterStyle>
                                </asp:GridView> 
                            </div>
                             <div class="col-md-6">
                                <asp:HiddenField ID="_cuentaPorCobrarId" runat="server" />
                                <asp:GridView ID="_datosPago" runat="server"   AutoGenerateColumns="False" Width="100%" ShowFooter="True" OnRowDataBound="_datosPago_RowDataBound">
                                    <Columns>
                                          <asp:BoundField DataField="HistorialCuentaPorCobrar.FechaCobro" HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Fecha_Creacion%>"/>
                                        <asp:BoundField DataField="HistorialCuentaPorCobrar.ValorCobro" HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Valor%>" DataFormatString="{0:C2}" ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle" />
                                        
                                    </Columns>
                                  <HeaderStyle CssClass="tableCabecera" ></HeaderStyle>
                                <FooterStyle CssClass="tablePiePagina"></FooterStyle>
                                </asp:GridView> 
                            </div>

                    </div>
             </div>
        </div>
    </div>
     </section>
 <nav>
        <asp:Button ID="_cerrarOrdenTrabajo" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Cerrar_Orden_Trabajo%>"  ValidationGroup="GuardarOrden" class="btn btn-primary" OnClick="_cerrarOrdenTrabajo_Click" />
        <asp:Button ID="_anularOrden" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Anular_Orden_Trabajo%>"  ValidationGroup="GuardarOrden" class="btn btn-primary" OnClick="_anularOrden_Click"  />
        
        <asp:Button ID="_abonar" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Abonar%>"  ValidationGroup="AbonarOrden" class="btn btn-primary" OnClick="_abonar_Click"  />
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
                            <asp:Button ID="_btnCancelaAnulacionrOrden" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Cancelar%>"  class="btn btn-primary" data-dismiss="modal" />
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
                            <asp:Button ID="_btnCancelarCerrarOrden" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Cancelar%>"  class="btn btn-primary" data-dismiss="modal" />
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
                                    <div class="col-md-6">
                                        <asp:GridView ID="_datosObservaciones" runat="server" Width="100%">
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
    
     <br />
    <div class="row" >
                  <div class="col-md-12" >
                <asp:Button ID="_btnAbonar" runat="server" Text="" Visible="false" />
                    <cc1:ModalPopupExtender ID="_btnAbonar_ModalPopupExtender" PopupControlID="_panelAbonar" runat="server" BehaviorID="_btnAbonar_ModalPopupExtender" TargetControlID="_btnAbonar" BackgroundCssClass="modal-Backgoround" X="500" OnCancelScript="_cancelarValorAbonar" OnOkScript="_abonarValor" Y="300">
                    </cc1:ModalPopupExtender>
                    <asp:Panel ID="_panelAbonar" runat="server" Style="display: none; background-color: white; width: 30%; height: auto;align-content:center ">
                        <div class="modal-header">
                            <h4 class="modal-title"><asp:Literal ID="_literalAbono" runat="server" Text="<%$ Resources:Web_es_Ec,Literal_Agregar_Abono%>"></asp:Literal></h4>
                        </div>
                        <div class="modal-body">
                             <div class="row">
                                    <div class="col-md-6">
                                        <asp:Label ID="_labelValorAbonar" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Valor_Abonar%>"></asp:Label>
                                    </div>
                                    
                              </div>
                              <div class="row">
                                    <div class="col-md-6">
                                        <asp:TextBox ID="_valorAbonar" runat="server" class="form-control" ValidationGroup="Abonar"  ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="_valorAbonarValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="Abonar" ControlToValidate="_valorAbonar" ></asp:RequiredFieldValidator>
                                     <cc1:MaskedEditExtender ID="_valorAbonarExtensor" runat="server" TargetControlID="_valorAbonar" Mask="999.99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" MaskType="Number" InputDirection="RightToLeft" AcceptNegative="Left" DisplayMoney="Left" ErrorTooltipEnabled="True" />

                                    </div>
                                    
                                </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="_abonarValor" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Agregar_Abono%>" class="btn btn-primary" data-dismiss="modal"  ValidationGroup="Abonar" OnClick="_abonarValor_Click" />
                            <asp:Button ID="_cancelarValorAbonar" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Cancelar%>"  class="btn btn-primary" data-dismiss="modal" />
                        </div>
                    </asp:Panel>
     </div>
     </div>
 </asp:Content>
