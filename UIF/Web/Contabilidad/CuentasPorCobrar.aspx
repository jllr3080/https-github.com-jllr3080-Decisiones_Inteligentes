<%@ Page Title="<%$ Resources:Web_es_Ec,Titulo_Pagina_Cuenta_Por_Cobrar%>" Language="C#" MasterPageFile="~/PaginaMaestra/Site.Master" AutoEventWireup="true" CodeBehind="CuentasPorCobrar.aspx.cs" Inherits="Web.Contabilidad.CuentasPorCobrar" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=16.1.1.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<br>
    <br>
    <br>
    <br>
   <h2>
        <asp:Literal runat="server" ID="_literalTitulo" Text="<%$ Resources:Web_es_Ec,Titulo_Pagina_Cuenta_Por_Cobrar%>"/>
    </h2>
    
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
                        <asp:Button ID="_btnBusquedaCliente" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Buscar%>"  ValidationGroup="BusquedaCliente" class="btn btn-primary" OnClick="_btnBusquedaCliente_Click" />
                    </div>
            </div>
        </div>
    </div>
         <div class="panel panel-default" id="_datosBusquedaCliente">
           <div class="panel-heading"><asp:Literal runat="server" ID="_literalEncabezado" Text="<%$ Resources:Web_es_Ec,Panel_Cabecera_Cuenta_Por_Cobrar%>"/></div>
        <div class="panel-body">
            
           <div class="row">
              <div class="col-md-12">
                        <asp:GridView ID="_datos" runat="server" Width="100%" AutoGenerateColumns="False" OnRowCommand="_datos_RowCommand" AllowPaging="true" PageSize="20" OnPageIndexChanging="_datos_OnPageIndexChanging" >
                            <Columns>
                            
                             <asp:BoundField DataField="CuentaPorCobrar.CuentaPorCobrarId" HeaderText="<%$ Resources:Web_es_Ec,Label_Codigo_Interno%>" />
                                <asp:BoundField DataField="CuentaPorCobrar.NumeroOrden" HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Numero_Orden%>" />
                            <asp:BoundField DataField="Cliente" HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Nombre_Cliente%>"  />
                            <asp:BoundField DataField="Direccion" HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Direccion%>" />
                                <asp:BoundField DataField="NumeroTelefonos" HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Telefono%>" />
                            <asp:BoundField DataField="CuentaPorCobrar.Valor" HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Valor%>" DataFormatString="{0:C2}" ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle" />
                             <asp:BoundField DataField="CuentaPorCobrar.Saldo" HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Saldo%>" DataFormatString="{0:C2}" ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle" />
                            
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="_imgResumenCobro" runat="server" ImageUrl="~/Content/Imagen/Editar.png" HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Resumen_Cobro%>" CommandName="Historial" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" />
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
    
     <br />
    <div class="row" >
                  <div class="col-md-12" >
                <asp:Button ID="_btnHistorialPago" runat="server" Text="" Visible="false" />
                    <cc1:ModalPopupExtender ID="_btnHistorialPago_ModalPopupExtender" PopupControlID="_panelHistorialCobro" runat="server" BehaviorID="_btnHistorialPago_ModalPopupExtender" TargetControlID="_btnHistorialPago" BackgroundCssClass="modal-Backgoround" X="500" OnCancelScript="_aceptarHistorial" Y="300">
                    </cc1:ModalPopupExtender>
                    <asp:Panel ID="_panelHistorialCobro" runat="server" Style="display: none; background-color: white; width: 30%; height: auto;align-content:center ">
                        <div class="modal-header">
                            <h4 class="modal-title"><asp:Literal ID="_literalAbono" runat="server" Text="<%$ Resources:Web_es_Ec,Literal_Datos_Pago%>"></asp:Literal></h4>
                        </div>
                        <div class="modal-body">
                             <div class="row">
                            <div class="col-md-12">
                                <asp:GridView ID="_datosPago" runat="server"   AutoGenerateColumns="False" Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="FechaCobro" HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Fecha_Creacion%>"/>
                                        <asp:BoundField DataField="ValorCobro" HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Valor%>" DataFormatString="{0:C2}" ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle" />
                                    </Columns>
                                  <HeaderStyle CssClass="tableCabecera" ></HeaderStyle>
                                <FooterStyle CssClass="tablePiePagina"></FooterStyle>
                                </asp:GridView> 
                            </div>
                    </div>

                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="_aceptarHistorial" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Aceptar%>"  class="btn btn-primary" data-dismiss="modal" />
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
