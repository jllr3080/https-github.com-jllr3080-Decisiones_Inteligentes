<%@ Page Title="<%$ Resources:Web_es_Ec,Titulo_Pagina_Aprobar_Pago%>" Language="C#" MasterPageFile="~/PaginaMaestra/Site.Master" AutoEventWireup="true" CodeBehind="AprobarPago.aspx.cs" Inherits="Web.Contabilidad.AprobarPago" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=16.1.1.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <br>
    <br>
    <br>
   <h2>
        <asp:Literal runat="server" ID="_literalTitulo" Text="<%$ Resources:Web_es_Ec,Titulo_Pagina_Aprobar_Pago%>"/>
    </h2>
    
     <section>
          <div class="panel panel-default" id="_datosBusquedaOrden">
           <div class="panel-heading"><asp:Literal runat="server" ID="Literal4" Text="<%$ Resources:Web_es_Ec,Panel_Busqueda%>"/></div>
                <div class="panel-body">
                    <div class="row">
                        
                        <div class="col-md-3">
                                <asp:Label ID="_labelSucursal" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Sucursal%>"></asp:Label>
                            </div>    
                        <div class="col-md-3">
                                <asp:Label ID="labelNumeroOrden" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Mes%>"></asp:Label>
                            </div>
                            
                    
                    </div>
                    <div class="row">
                        
                         <div class="col-md-3">
                                  <asp:DropDownList ID="_sucursal" runat="server" CssClass="form-control" DataValueField="PuntoVentaId" DataTextField="Descripcion"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="_sucursalValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="Obligatorio" ControlToValidate="_sucursal" ></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-3">
                                  <asp:DropDownList ID="_mes" runat="server" CssClass="form-control" DataValueField="MesId" DataTextField="Descripcion"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="_mesValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="Obligatorio" ControlToValidate="_mes" ></asp:RequiredFieldValidator>
                            </div>
                             <div class="col-md-3">
                                <asp:Button ID="_btnBuscar" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Buscar%>" ValidationGroup="Busqueda"  CssClass="btn btn-primary"  OnClick="_btnBuscar_OnClick" />
                            </div>
                    </div>
                </div>
            </div>
         <br/>
          
          
          <div class="panel panel-default">
           <div class="panel-heading"><asp:Literal runat="server" ID="Literal1" Text="<%$ Resources:Web_es_Ec,Panel_Resultado_Busqueda%>"/></div>
                <div class="panel-body">
         <div class="row">
              <div class="col-md-12">
                        <asp:GridView ID="_datos" runat="server" Width="100%" AutoGenerateColumns="False" OnRowCommand="_datos_OnRowCommand"  >
                            <Columns>
                             <asp:BoundField DataField="AplicacionPago.AplicacionPagoId" HeaderText="<%$ Resources:Web_es_Ec,Label_Codigo_Interno%>" />
                            <asp:BoundField DataField="FechaCierreMes" HeaderText="<%$ Resources:Web_es_Ec,Label_Fecha_Cierre_Mes%>" DataFormatString="{0:d}"/>
                            <asp:BoundField DataField="ValorCierre" HeaderText="<%$ Resources:Web_es_Ec,Label_Valor_Cierre_Mes%>" DataFormatString="{0:C2}" ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle" />
                            <asp:BoundField DataField="UsuarioAplicacion" HeaderText="<%$ Resources:Web_es_Ec,Label_Usuario_Aplicacion%>" />
                            <asp:BoundField DataField="AplicacionPago.FechaDeposito" HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Fecha_Deposito%>" DataFormatString="{0:d}"/>
                            <asp:BoundField DataField="AplicacionPago.NumeroDocumento" HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Numero_Documento%>" />
                            <asp:BoundField DataField="AplicacionPago.Valor" HeaderText="<%$ Resources:Web_es_Ec,Label_Valor_Aplicado%>" DataFormatString="{0:C2}" ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle" />
                            <asp:BoundField DataField="AplicacionPago.EstaValidado" HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Esta_Validado%>"   />
                                  <asp:TemplateField HeaderText="<%$ Resources:Web_es_Ec,Label_Seleccionar%>" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                          
                                        <ItemTemplate >
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
              </div>
         <br/>
          
          <div class="panel panel-default">
           <div class="panel-heading"><asp:Literal runat="server" ID="Literal2" Text="<%$ Resources:Web_es_Ec,Panel_Aplicacion_Pago%>"/></div>
                <div class="panel-body">
                     <div class="row">
                        <div class="col-md-3">
                                <asp:Label ID="_labelNumeroDocumento" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Numero_Transaccion%>"></asp:Label>
                        </div> 
                         <div class="col-md-3">
                                <asp:Label ID="_labelFechaCreacion" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Fecha_Creacion%>"></asp:Label>
                        </div>   
                        <div class="col-md-3">
                                <asp:Label ID="_labelFechaDeposito" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Fecha_Deposito%>"></asp:Label>
                        </div>
                         <div class="col-md-3">
                                <asp:Label ID="_labelValor" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Valor_Deposito%>"></asp:Label>
                        </div>
                      
                        
                    </div>
                    
                     <div class="row">
                      
                          <div class="col-md-3">
                              <asp:HiddenField ID="_cierreMesId" runat="server" />
                                   <asp:TextBox ID="_numeroDocumento" runat="server"  class="form-control" ValidationGroup="BusquedaCliente" AutoCompleteType="Disabled" MaxLength="20"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="_numeroDocumentoValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="Grabar" ControlToValidate="_numeroDocumento" ></asp:RequiredFieldValidator>
                        
                        </div> 
                          <div class="col-md-3">
                                  <asp:TextBox ID="_fechaCreacion" runat="server" class="form-control" ValidationGroup="Grabar" ReadOnly="True" ></asp:TextBox>
                                   
                        </div>   
                        <div class="col-md-3">
                                  <asp:TextBox ID="_fechaDeposito" runat="server" class="form-control" ValidationGroup="Grabar" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="_fechaDepositoValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="Grabar" ControlToValidate="_fechaDeposito" ></asp:RequiredFieldValidator>
                                       <ajaxToolkit:CalendarExtender ID="_fechaDepositoExtensor" runat="server" BehaviorID="_fechaEntrega_CalendarExtender" TargetControlID="_fechaDeposito" Format="dd/MM/yyyy"  />
                                    <ajaxToolkit:TextBoxWatermarkExtender id="_fechaDepositoMarcaAgua" runat="server" targetcontrolid="_fechaDeposito" enabled="True" watermarktext="<%$ Resources:Web_es_Ec,Marca_Agua_Fecha%>"></ajaxToolkit:TextBoxWatermarkExtender>  
                      
                        </div>
                         
                         
                         <div class="col-md-3">
                               <asp:TextBox ID="_valor" runat="server" class="form-control" ValidationGroup="Grabar"  ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="_valorValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="Grabar" ControlToValidate="_valor" ></asp:RequiredFieldValidator>
                         <cc1:MaskedEditExtender ID="_valorMascara" runat="server" TargetControlID="_valor" Mask="999.99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" MaskType="Number" InputDirection="RightToLeft" AcceptNegative="None" DisplayMoney="Left" ErrorTooltipEnabled="True"  />

                               
                        </div>
                        
                        
            </div>
                   
                    
                     <div class="row">
                          <div class="col-md-3">
                            <asp:CheckBox ID="_estaValidado" runat="server" CssClass="form-control" Text="<%$ Resources:Web_es_Ec,Label_Esta_Validado%>" />
                                
                        </div>
                         <div class="col-md-3">
                            <asp:Button ID="_aplicarPago" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Aplicar_Pago%>" class="btn btn-primary" data-dismiss="modal"   OnClick="_aplicarPago_OnClick" ValidationGroup="Grabar"/>
                        </div>
                           <div class="col-md-3">
                               <asp:Button ID="_visualizarPago" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Visualizar_Pago%>" class="btn btn-primary" data-dismiss="modal"   OnClick="_aplicarPago_OnClick" ValidationGroup="Grabar"/>
                                
                        </div>
                         <div class="col-md-3">
                            <asp:Button ID="_cancelar" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Cancelar%>" class="btn btn-primary" data-dismiss="modal"   OnClick="_cancelar_OnClick" />
                        </div>
                       

                    </div>
                         
                   
                        
                    </div>

                </div>
         
    </section>
    
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
