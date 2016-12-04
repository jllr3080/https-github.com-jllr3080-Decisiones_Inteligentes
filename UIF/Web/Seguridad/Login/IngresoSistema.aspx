<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra/Login.Master"  AutoEventWireup="true" CodeBehind="IngresoSistema.aspx.cs" Inherits="Web.Seguridad.Login.IngresoSistema" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=16.1.1.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="_contenido" runat="server">
    <div  id="_imagenfondo" style="background-image: url('../../Content/Imagen/ImagenInicial.png')" >
    <br/>
    <br/>
    <br/>
     <div class="form-group" style="">
                <h1><asp:Literal runat="server" Text="<%$ Resources:Web_es_Ec,Titulo_Ingreso_Sistema%>"></asp:Literal></h1>
    </div>
    
    <br/>        
    <br/>
    <br/>
    <div class="panel panel-default" id="_datosBusquedaCliente" style="width: 450px">
           <div class="panel-heading"><asp:Literal runat="server" ID="Literal4" Text="<%$ Resources:Web_es_Ec,Panel_Ingreso_Sistema%>"/></div>
        <div class="panel-body">
            <div class="row">
                    <div class="col-md-6">
                       <asp:Label runat="server" AssociatedControlID="_usuario"  Style="text-align:left" Text="<%$ Resources:Web_es_Ec,Label_Usuario%>"></asp:Label>
                    </div>
                    
            </div>
            <div class="row">
                    <div class="col-md-6">
                       <asp:TextBox runat="server" ID="_usuario" CssClass="form-control" AutoCompleteType="Disabled" ValidationGroup="IngresoSistema" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="_usuario" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="IngresoSistema" />
                    </div>
                    
            </div>
             <div class="row">
                    <div class="col-md-6">
                        <asp:Label runat="server" AssociatedControlID="_contrasena"  Style="text-align:left" Text="<%$ Resources:Web_es_Ec,Label_Contrasena%>"></asp:Label>
                    </div>
                    
            </div>
            <div class="row">
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="_contrasena" TextMode="Password" CssClass="form-control" ValidationGroup="IngresoSistema" AutoCompleteType="Disabled"/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="_contrasena" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="IngresoSistema"/>
                    </div>
                    
            </div>
             <div class="row">
                    <div class="col-md-6">
                         <asp:Button runat="server"  Text="<%$ Resources:Web_es_Ec,Boton_Ingreso_Sistema%>" CssClass="btn btn-primary" ID="_ingresoSistema" ValidationGroup="IngresoSistema" OnClick="_ingresoSistema_Click" />
                    </div>
                    
            </div>

        </div>
         </div>

     <br/>
        <br/>
        <br/>
        
        <br/><br/>

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
