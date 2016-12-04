<%@ Page Title="<%$ Resources:Web_es_Ec,Titulo_Reporte_Diario%>"  Language="C#" MasterPageFile="~/PaginaMaestra/Site.Master" AutoEventWireup="true" CodeBehind="ReporteDiario.aspx.cs" Inherits="Web.Reporte.Venta.Reporte.ReporteDiario" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=16.1.1.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <br />
    <br />
    <h2>
        <asp:Literal runat="server" ID="_literalTitulo" Text="<%$ Resources:Web_es_Ec,Titulo_Reporte_Diario%>"/>
    </h2>
    
    <div class="panel panel-default" id="_datosBusquedaPorFecha">
           <div class="panel-heading"><asp:Literal runat="server" ID="_litearlBusquedaPorFecha" Text="<%$ Resources:Web_es_Ec,Panel_Busqueda_Cliente%>"/></div>
        <div class="panel-body">
            <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="_labelFecha" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Fecha%>"></asp:Label>
                    </div>
                    
            </div>
            
            <div class="row">
                    <div class="col-md-3">
                         <asp:TextBox ID="_fecha" runat="server" CssClass="form-control" ValidationGroup="Obligatorio" ></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="_fechaValidadorExtensor" runat="server" BehaviorID="_fechaEmision_CalendarExtender" TargetControlID="_fecha" Format="dd/MM/yyyy"  />
                        <ajaxToolkit:TextBoxWatermarkExtender id="_fechaMarcaAgua" runat="server" targetcontrolid="_fecha" enabled="True" watermarktext="<%$ Resources:Web_es_Ec,Marca_Agua_Fecha%>"></ajaxToolkit:TextBoxWatermarkExtender>  
                        <asp:RequiredFieldValidator ID="_fechaValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="Obligatorio" ControlToValidate="_fecha" ></asp:RequiredFieldValidator>
                    </div>
                  <div class="col-md-3">
                         <asp:Button ID="_generarReporte" runat="server" Text="<%$ Resources:Web_es_Ec,Btn_Generar_Reporte%>" CssClass="btn btn-primary" OnClick="_generarReporte_Click"  ValidationGroup="Obligatorio" />
                    </div>
                    
            </div>
        </div>
    </div>
     <div class="row" style="text-align:center ">
         
                   <rsweb:ReportViewer ID="_reporteDiario" runat="server" Width="100%" AsyncRendering="False" ExportContentDisposition="AlwaysInline">
                    </rsweb:ReportViewer>
     </div>
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
