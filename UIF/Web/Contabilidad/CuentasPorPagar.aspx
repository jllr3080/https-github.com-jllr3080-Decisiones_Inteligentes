﻿<%@ Page Title="<%$ Resources:Web_es_Ec,Titulo_Pagina_Cuenta_Por_Pagar%>" Language="C#" MasterPageFile="~/PaginaMaestra/Site.Master" AutoEventWireup="true" CodeBehind="CuentasPorPagar.aspx.cs" Inherits="Web.Contabilidad.CuentasPorPagar" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=16.1.1.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <br>
    <br>
    <br>
    <br>
   <h2>
        <asp:Literal runat="server" ID="_literalTitulo" Text="<%$ Resources:Web_es_Ec,Titulo_Pagina_Cuenta_Por_Pagar%>"/>
    </h2>
    
     <section>
          <div class="panel panel-default" id="_datosBusqueda">
           <div class="panel-heading"><asp:Literal runat="server" ID="_literalEncabezado" Text="<%$ Resources:Web_es_Ec,Panel_Cabecera_Cuenta_Por_Pagar%>"/></div>
        <div class="panel-body">
            
            <div class="row">
                 <div class="col-md-3">
                                <asp:Label ID="_labelSucursal" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Sucursal%>"></asp:Label>
                  </div>   
                    <div class="col-md-3">
                        
                        <asp:Label ID="_labelFechaDesde" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Fecha_Desde%>"></asp:Label>
                    </div>
                      <div class="col-md-3">
                        
                        <asp:Label ID="_labelFechaHasta" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Fecha_Hasta%>"></asp:Label>
                    </div>
            </div>
            <div class="row">
                 <div class="col-md-3">
                                  <asp:DropDownList ID="_sucursal" runat="server" CssClass="form-control" DataValueField="PuntoVentaId" DataTextField="Descripcion"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="_sucursalValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="Obligatorio" ControlToValidate="_sucursal" ></asp:RequiredFieldValidator>
                            </div>
                   <div class="col-md-3">
                            <asp:TextBox ID="_fechaDesde" runat="server" CssClass="form-control"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="_fechaDesdeExtensor" runat="server" BehaviorID="_fechaDesde_CalendarExtender" TargetControlID="_fechaDesde" Format="dd/MM/yyyy"  />
                            <ajaxToolkit:TextBoxWatermarkExtender id="_fechaDesdeMarcaAgua" runat="server" targetcontrolid="_fechaDesde" enabled="True" watermarktext="<%$ Resources:Web_es_Ec,Marca_Agua_Fecha%>"></ajaxToolkit:TextBoxWatermarkExtender>  
                            <asp:RequiredFieldValidator ID="_fechaDesdeValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="Obligatorio" ControlToValidate="_fechaDesde" ></asp:RequiredFieldValidator>
                        </div>
                 <div class="col-md-3">
                            <asp:TextBox ID="_fechaHasta" runat="server" CssClass="form-control"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="_fechaHastaExtensor" runat="server" BehaviorID="_fechaHasta_CalendarExtender" TargetControlID="_fechaHasta" Format="dd/MM/yyyy"  />
                            <ajaxToolkit:TextBoxWatermarkExtender id="_fechaHastaMarcaAgua" runat="server" targetcontrolid="_fechaHasta" enabled="True" watermarktext="<%$ Resources:Web_es_Ec,Marca_Agua_Fecha%>"></ajaxToolkit:TextBoxWatermarkExtender>  
                            <asp:RequiredFieldValidator ID="_fechaHastaValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="Obligatorio" ControlToValidate="_fechaHasta" ></asp:RequiredFieldValidator>
                        </div>
                  
                    <div class="col-md-3">
                        <asp:Button ID="_btnBusqueda" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Buscar%>"  ValidationGroup="Obligatorio" class="btn btn-primary" OnClick="_btnBusqueda_Click"  />
                     
                    </div>
                
                  
                     
                    
            </div>
            <div class="row">
              <div class="col-md-12">
                        <asp:GridView ID="_datos" runat="server" Width="100%" AutoGenerateColumns="False"  OnRowDataBound="_datos_RowDataBound" ShowFooter="True" AllowPaging="True" PageSize="20" OnPageIndexChanging="_datos_OnPageIndexChanging" >
                            <Columns>
                             <asp:BoundField DataField="CuentaPorPagar.CuentaPorPagarId" HeaderText="<%$ Resources:Web_es_Ec,Label_Codigo_Interno%>" />
                            <asp:BoundField DataField="CuentaPorPagar.FechaCreacion" HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Fecha_Creacion%>"  DataFormatString="{0:d}"/>
                            <asp:BoundField DataField="CuentaPorPagar.NumeroOrden" HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Numero_Orden%>" />
                            <asp:BoundField DataField="CuentaPorPagar.Valor" HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Valor%>" DataFormatString="{0:C2}" ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle" />
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
</asp:Content>
