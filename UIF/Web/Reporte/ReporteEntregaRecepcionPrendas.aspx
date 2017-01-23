<%@ Page Title="<%$ Resources:Web_es_Ec,Titulo_Pagina_Reporte_Entrega_Recepcion_Prendas%>" Language="C#" MasterPageFile="~/PaginaMaestra/Site.Master" AutoEventWireup="true" CodeBehind="ReporteEntregaRecepcionPrendas.aspx.cs" Inherits="Web.Reporte.ReporteEntregaRecepcionPrendas" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=16.1.1.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<%@ Register TagPrefix="rsweb" Namespace="Microsoft.Reporting.WebForms" Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <script>
        function validarNumerosParaFecha(e) {
            key = e.keyCode || e.which;
            tecla = String.fromCharCode(key).toString();
            letras = "1234567890/";//Se define todos los números que se quiere que se muestre.
            especiales = [8, 37, 39, 46, 6, 9]; //Es la validación del KeyCodes, que teclas recibe el campo de texto.

            tecla_especial = false
            for (var i in especiales) {
                if (key == especiales[i]) {
                    tecla_especial = true;
                    break;
                }
            }

            if (letras.indexOf(tecla) == -1 && !tecla_especial)
                return false;
        }
    </script>
    <br />
    <br />
    <br />
    <br />
    <h2>
        <asp:Literal runat="server" ID="_literalTitulo" Text="<%$ Resources:Web_es_Ec,Titulo_Pagina_Reporte_Entrega_Recepcion_Prendas%>"/>
    </h2>
    <section>
     <div class="panel panel-default" id="_datosBusquedaPorFecha">
           <div class="panel-heading"><asp:Literal runat="server" ID="_litearlBusquedaPorFecha" Text="<%$ Resources:Web_es_Ec,Panel_Busqueda_Orden_Trabajo%>"/></div>
        <div class="panel-body">
            <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="_labelSucursal" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Sucursal%>"></asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="_labelEtapaProceso" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Etapa_Proceso%>"></asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="_labelFecha" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Fecha%>"></asp:Label>
                    </div>


            </div>
            
            <div class="row">
                    <div class="col-md-3">
                        <asp:DropDownList ID="_sucursal" runat="server" CssClass="form-control" ValidationGroup="Obligatorio"  DataTextField="Descripcion" DataValueField="PuntoVentaId"></asp:DropDownList> 
                        <asp:RequiredFieldValidator ID="_sucursalValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="Obligatorio" ControlToValidate="_sucursal" ></asp:RequiredFieldValidator>
                    </div>
                  <div class="col-md-3">
                      <asp:DropDownList ID="_etapaProceso" runat="server" CssClass="form-control" ValidationGroup="Obligatorio"  DataTextField="Descripcion" DataValueField="EtapaProcesoId"></asp:DropDownList> 
                        <asp:RequiredFieldValidator ID="_etapaProcesoValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="Obligatorio" ControlToValidate="_etapaProceso" ></asp:RequiredFieldValidator>
                    </div>
                   <div class="col-md-3">
                            <asp:TextBox ID="_fecha" runat="server"  AutoCompleteType="Disabled" CssClass="form-control" onkeypress="return validarNumerosParaFecha(event)" MaxLength="10"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="_fechaValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="Obligatorio" ControlToValidate="_fecha" ></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="_fechaExpresionRegular" runat="server" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d" ControlToValidate="_fecha" ValidationGroup="Obligatorio"/>
                            <ajaxToolkit:CalendarExtender ID="_fechaExtensor" runat="server" BehaviorID="_fecha_CalendarExtender" TargetControlID="_fecha" Format="dd/MM/yyyy" />
                            <ajaxToolkit:TextBoxWatermarkExtender id="_fechaMarcaAgua" runat="server" targetcontrolid="_fecha" enabled="True" watermarktext="<%$ Resources:Web_es_Ec,WaterMarke_Fecha%>"></ajaxToolkit:TextBoxWatermarkExtender>  

                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="_generarReporte" runat="server" Text="<%$ Resources:Web_es_Ec,Btn_Generar_Reporte%>" CssClass="btn btn-primary"  ValidationGroup="Obligatorio" OnClick="_generarReporte_Click"  />
                    </div>
                    
            </div>
             <div class="row" style="text-align:center ">
         
                   <rsweb:ReportViewer ID="_reporteEntregaRecepcionPrendas" runat="server" Width="100%" AsyncRendering="False" ExportContentDisposition="AlwaysInline">
                    </rsweb:ReportViewer>
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
