<%@ Page Title="<%$ Resources:Web_es_Ec,Titulo_Pagina_Orden_Trabajo_Pendiente%>" Language="C#" MasterPageFile="~/PaginaMaestra/Site.Master" AutoEventWireup="true" CodeBehind="OrdenesPendientes.aspx.cs" Inherits="Web.Venta.OrdenesPendientes" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=16.1.1.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <br/>
    <br/>
    <br/>
    <br/>
     <h2>
        <asp:Literal runat="server" ID="_literalTitulo" Text="<%$ Resources:Web_es_Ec,Titulo_Pagina_Orden_Trabajo_Pendiente%>"/>
    </h2>
    <section>
           <div class="panel panel-default" id="_datosBusquedaCliente">
                               <div class="panel-heading">
                                     <div class="row">
                                        <div class="col-md-3">
                                            <asp:Literal runat="server" ID="_literalDatosPersonales" Text="<%$ Resources:Web_es_Ec,Panel_Ordenes_Pendientes%>"/>
                                        </div>
                                             
                                     </div>                
                                </div>       

                               
                            <div class="panel-body">
                                
                                 <div class="row">
               
                                                <div class="col-md-3">
                                                     <asp:Label ID="_labelOrdenPendiente" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Ordenes_Pendientes%>"></asp:Label>
                        
                                                </div>
                                </div>
                                  <div class="row">
               
                                                <div class="col-md-3">
                                                  <asp:DropDownList ID="_ordenPendiente" AutoPostBack="True" runat="server" CssClass="form-control" ValidationGroup="GrabarDetalleOrdenTrabajo" DataTextField="NumeroOrden" DataValueField="OrdenTrabajoId" OnSelectedIndexChanged="_ordenPendiente_OnSelectedIndexChanged"></asp:DropDownList>
                                                 <asp:RequiredFieldValidator ID="_ordenPendienteValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GrabarDetalleOrdenTrabajo" ControlToValidate="_ordenPendiente" ></asp:RequiredFieldValidator>
                        
                        
                                                </div>
                                </div>
                                <br/>
                                <div class="row">
                
                                      <div class="col-md-12">
                                        
                                                    <asp:HiddenField ID="_nombreMarca" runat="server" />
                                                        <asp:GridView ID="_datos" runat="server" AutoGenerateColumns="False"   Width="100%"  ShowFooter="True" >
                                
                                                            <Columns>
                                                               
                                                                <asp:BoundField DataField="Producto.Nombre" HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Prenda%>"  >
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                </asp:BoundField>
                                                               <asp:BoundField DataField="PromocionAplicada" HeaderText="<%$ Resources:Web_es_Ec,Label_Codigo_Promocion%>"    ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle" >
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                </asp:BoundField>
                                                                  <asp:BoundField DataField="NombrePromocionAplicada" HeaderText="<%$ Resources:Web_es_Ec,Label_Promocion_Aplicada%>"   DataFormatString="{0:C2}" ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle" >
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                </asp:BoundField>
                                                                 <asp:BoundField DataField="Cantidad" HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Cantidad%>"   ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"  >
                                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="ValorUnitario"  HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Valor_Unitario%>"  DataFormatString="{0:C2}" ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle" >
                                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="ValorTotalUnitario" HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Valor_Total%>"   DataFormatString="{0:C2}" ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle" >
                                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="ValorDescuento" HeaderText="<%$ Resources:Web_es_Ec,Label_Valor_Descuento%>"   DataFormatString="{0:C2}" ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle" >
                                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                                </asp:BoundField>
                                                                 <asp:BoundField DataField="ValorTotal" HeaderText="<%$ Resources:Web_es_Ec,Label_Valor_Total_Pagar%>"   DataFormatString="{0:C2}" ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle" >
                                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                                </asp:BoundField>
                                                              
                                                                 <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="_agregarDetalle" runat="server" ImageUrl="~/Content/Imagen/Nuevo.png"  CommandName="Agregar" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"/>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                 <asp:TemplateField  >
                                                                                <ItemTemplate >
                                                                                    <asp:ImageButton ID="_visualizarDetalle" runat="server" ImageUrl="~/Content/Imagen/mas.jpg"  CommandName="Visualizar" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"/>
                                                                                    <asp:ImageButton ID="_esconderDetalle" runat="server" ImageUrl="~/Content/Imagen/menos.png"  CommandName="EsconderVisualizar" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" />
                                                                                     <tr>
                                                                                        <td colspan="100%" style="text-align: right">
                                                                                        <asp:Panel ID="Detalles" runat="server" Visible="False">
                                                                                        <asp:GridView ID="_detalleCuotas" runat="server" AutoGenerateColumns="false" Width="100%">
                                                                                            <Columns>
                                                                                                  
                                                                                                   <asp:BoundField DataField="NombreColor" HeaderText="<%$ Resources:Web_es_Ec,Label_Color%>"  >
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="NombreMarca" HeaderText="<%$ Resources:Web_es_Ec,Label_Marca%>"  >
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="EstadoPrenda" HeaderText="<%$ Resources:Web_es_Ec,Label_Estado_Prenda%>"  ></asp:BoundField>
                                                                                                  <asp:BoundField DataField="TratamientoEspecial" HeaderText="<%$ Resources:Web_es_Ec,Label_Tratamiento_Especial%>"  ></asp:BoundField>
                                                                                                  <asp:BoundField DataField="NumeroInternoPrenda" HeaderText="<%$ Resources:Web_es_Ec,Label_Numero_Interno%>"  ></asp:BoundField>
                                                                                                  <asp:BoundField DataField="InformacionVisual" HeaderText="<%$ Resources:Web_es_Ec,Label_Informacion_Visual%>"  ></asp:BoundField>
                                                                                                    <asp:TemplateField>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:ImageButton ID="_eliminarDetallePrenda" runat="server" ImageUrl="~/Content/Imagen/Borrar.png"  CommandName="Eliminar" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"/>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                              </Columns>
                                                                                            <HeaderStyle CssClass="tableCabecera"></HeaderStyle>
                                                                                            <RowStyle CssClass="tableItem"></RowStyle>
                                                                                        </asp:GridView>
                                                                                    </asp:Panel>
                                                                                             </td>
                                                                                      </tr>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                            </Columns>
                                                            <HeaderStyle CssClass="tableCabeceraIntenso" ></HeaderStyle>
                                                            <RowStyle CssClass="tableItem"></RowStyle>
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
                        <h4 class="modal-title"><asp:Literal runat="server" Text="<%$ Resources:Web_es_Ec,Mensaje_Sistema%>"></asp:Literal></h4>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="_labelMensaje" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="_btnAceptar" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Aceptar%>" class="btn btn-primary" data-dismiss="modal" />
                    </div>
                </asp:Panel>
            </div>
    </div>
</asp:Content>
