<%@ Page Title="<%$ Resources:Web_es_Ec,Titulo_Pagina_Administracion_Feriados%>" Language="C#" MasterPageFile="~/PaginaMaestra/Site.Master" AutoEventWireup="true" CodeBehind="Feriado.aspx.cs" Inherits="Web.Parametrizacion.Feriado" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=16.1.1.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
     <br>
    <br>
    <br>
    <br>
   <h2>
        <asp:Literal runat="server" ID="_literalTitulo" Text="<%$ Resources:Web_es_Ec,Titulo_Pagina_Administracion_Feriados%>"/>
    </h2>
     <section>
     <div class="panel panel-default" id="_datosIniciales">
           <div class="panel-heading"><asp:Literal runat="server" ID="_literalDatos" Text="<%$ Resources:Web_es_Ec,Panel_Ingreso_Datos%>"/></div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-3">
                    <asp:CheckBox ID="_habilitarFeriado" runat="server" CssClass="form-control" Text="Habilitar Feriado" />
                 </div>
                
                 <div class="col-md-3">
                    <asp:Button ID="_ingresarInformacion" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Ingresar_Actualizar_Informacion%>" CssClass="btn btn-primary"  ValidationGroup="Obligatorio" OnClick="_ingresarInformacion_OnClick"  /> 
                 </div>
                <div class="col-md-3">
                         <asp:Button ID="_cancelar" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Cancelar%>" CssClass="btn btn-primary" OnClick="_cancelar_OnClick"   /> 
                    </div>
                     
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
