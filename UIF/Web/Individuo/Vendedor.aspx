<%@ Page Title="<%$ Resources:Web_es_Ec,Titulo_Pagina_Vendedor%>" Language="C#" MasterPageFile="~/PaginaMaestra/Site.Master" AutoEventWireup="true" CodeBehind="Vendedor.aspx.cs" Inherits="Web.Individuo.Vendedor" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=16.1.1.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <br/>
    <br/>
    <br/>
    <br/>
    <h2><asp:Literal runat="server" Text="<%$ Resources:Web_es_Ec,Titulo_Pagina_Vendedor%>"></asp:Literal></h2>
   <section>
    
   </section>
    
      <nav>
        <asp:Button ID="_grabarVendedor" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Crear_Modificar_Cliente%>" CssClass="btn btn-primary"  ValidationGroup="CrearModificarVendedor" OnClick="_grabarVendedor_Click"  />
        <asp:Button ID="_cancelar" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Cancelar%>" CssClass="btn btn-primary" OnClick="_cancelar_Click"  />
    </nav>
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
