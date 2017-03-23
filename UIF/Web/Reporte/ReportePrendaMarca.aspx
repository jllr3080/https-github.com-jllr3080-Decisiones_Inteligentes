<%@ Page Title="<%$ Resources:Web_es_Ec,Titulo_Pagina_Reporte_Prenda_Marca%>" Language="C#" MasterPageFile="~/PaginaMaestra/Site.Master" AutoEventWireup="true" CodeBehind="ReportePrendaMarca.aspx.cs" Inherits="Web.Reporte.ReportePrendaMarca" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=16.1.1.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<%@ Register TagPrefix="rsweb" Namespace="Microsoft.Reporting.WebForms" Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
     <br>
    <br>
    <br>
    <br>
   <h2>
        <asp:Literal runat="server" ID="_literalTitulo" Text="<%$ Resources:Web_es_Ec,Titulo_Pagina_Reporte_Prenda_Marca%>"/>
    </h2>
     <section>
         
         <div class="panel panel-default" id="_datosBusqueda">
           <div class="panel-heading"><asp:Literal runat="server" ID="_litearlBusquedaPorFecha" Text="<%$ Resources:Web_es_Ec,Panel_Busqueda_Orden_Trabajo%>"/></div>
        <div class="panel-body">
            <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="_labelNumeroOrden" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Prenda%>"></asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="_labelMarca" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Marca%>"></asp:Label>
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
                     <asp:DropDownList ID="_prenda" runat="server" CssClass="form-control" ValidationGroup="Obligatorio" DataTextField="Nombre" DataValueField="ProductoId" ></asp:DropDownList>
                     <asp:RequiredFieldValidator ID="_prendaValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="Obligatorio" ControlToValidate="_prenda" ></asp:RequiredFieldValidator>
                     
                    </div>
                   <div class="col-md-3">
                         <asp:DropDownList ID="_marca" runat="server" CssClass="form-control" ValidationGroup="Obligatorio" DataTextField="Descripcion" DataValueField="MarcaId" ></asp:DropDownList>
                     <asp:RequiredFieldValidator ID="_marcavalidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="Obligatorio" ControlToValidate="_marca" ></asp:RequiredFieldValidator>
                    </div>
                   <div class="col-md-3">
                         <asp:TextBox ID="_fechaDesde" runat="server" CssClass="form-control"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="_fechaDesdeExtensor" runat="server" BehaviorID="_fechaDesde_CalendarExtender" TargetControlID="_fechaDesde" Format="dd/MM/yyyy"  />
                            <ajaxToolkit:TextBoxWatermarkExtender id="_fechaDesdeMarcaAgua" runat="server" targetcontrolid="_fechaDesde" enabled="True" watermarktext="<%$ Resources:Web_es_Ec,Marca_Agua_Fecha%>"></ajaxToolkit:TextBoxWatermarkExtender>  
                            <asp:RequiredFieldValidator ID="_fechaDesdeValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="Obligatorio" ControlToValidate="_fechaDesde" ></asp:RequiredFieldValidator>
                       
                    </div>
                  
                  <div class="col-md-3">
                         <asp:Button ID="_generarReporte" runat="server" Text="<%$ Resources:Web_es_Ec,Btn_Generar_Reporte%>" CssClass="btn btn-primary"  ValidationGroup="Obligatorio" OnClick="_generarReporte_Click"  />
                    </div>
                    
            </div>
              <div class="row" style="text-align:center ">
         
                   <rsweb:ReportViewer ID="_reportePrendaMarca" runat="server" Width="100%" AsyncRendering="False" ExportContentDisposition="AlwaysInline">
                    </rsweb:ReportViewer>
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
</asp:Content>
