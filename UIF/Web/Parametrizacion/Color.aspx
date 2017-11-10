<%@ Page Title="<%$ Resources:Web_es_Ec,Titulo_Pagina_Color%>" Language="C#" MasterPageFile="~/PaginaMaestra/Site.Master" AutoEventWireup="true" CodeBehind="Color.aspx.cs" Inherits="Web.Parametrizacion.Color" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=16.1.1.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <br>
    <br>
    <br>
   <h2>
        <asp:Literal runat="server" ID="_literalTitulo" Text="<%$ Resources:Web_es_Ec,Titulo_Pagina_Color%>"/>
    </h2>
     <section>
      <div class="panel panel-default" id="_datosIniciales">
           <div class="panel-heading"><asp:Literal runat="server" ID="_literalDatos" Text="<%$ Resources:Web_es_Ec,Panel_Ingreso_Datos%>"/></div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-3">
                                <asp:Label ID="_labelCodigoInterno" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Codigo_Interno%>"></asp:Label>
                     </div>
                     <div class="col-md-3">
                                <asp:Label ID="_labelColor" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Color%>"></asp:Label>
                     </div>    
                     <div class="col-md-3">
                                <asp:Label ID="_labelEstaHabilitado" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Esta_Habilitado%>"></asp:Label>
                      </div>
                    
            </div>
            
            <div class="row">
                  <div class="col-md-3">
                                  <asp:TextBox ID="_codigoInterno" runat="server" CssClass="form-control" ValidationGroup="Obligatorio"  ReadOnly="True" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="_codigoInternoValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="Obligatorio" ControlToValidate="_codigoInterno" ></asp:RequiredFieldValidator>
                    </div>
                 <div class="col-md-3">
                                  <asp:TextBox ID="_color" runat="server" CssClass="form-control" ValidationGroup="Obligatorio"  MaxLength="20" AutoCompleteType="Disabled" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="_colorValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="Obligatorio" ControlToValidate="_color" ></asp:RequiredFieldValidator>
                            </div>
                    <div class="col-md-3">
                        <asp:CheckBox ID="_estaHabilitado" runat="server"  CssClass="form-control"/>
                        
                    </div>
                 
                    
            </div>
              <div class="row">
                 <div class="col-md-3">
                               <asp:Button ID="_ingresarInformacion" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Ingresar_Actualizar_Informacion%>" CssClass="btn btn-primary"  ValidationGroup="Obligatorio" OnClick="_ingresarInformacion_Click"  /> 
                    </div>
                    <div class="col-md-3">
                         <asp:Button ID="_cancelar" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Cancelar%>" CssClass="btn btn-primary" OnClick="_cancelar_Click"   /> 
                    </div>
                 
                    
            </div>
           
        </div>
    </div>
     
      <div class="panel panel-default" id="_datos">
           <div class="panel-heading"><asp:Literal runat="server" ID="Literal1" Text="<%$ Resources:Web_es_Ec,Panel_Detalle_Datos%>"/></div>
        <div class="panel-body">
            <div class="row">
                     <div class="col-md-12">
                                 <asp:GridView ID="_datos" runat="server" AutoGenerateColumns="False"  ShowFooter="True" Width="100%" OnRowCommand="_datos_RowCommand" OnRowDataBound="_datos_RowDataBound" AllowPaging="True" PageSize="5" OnPageIndexChanging="_datos_PageIndexChanging" >
                                    <Columns>
                                        <asp:BoundField HeaderText="<%$ Resources:Web_es_Ec,Label_Codigo_Interno%>" DataField="ColorId" />
                                      <asp:BoundField HeaderText="<%$ Resources:Web_es_Ec,Label_Color%>" DataField="Descripcion" />
                                      <asp:BoundField HeaderText="<%$ Resources:Web_es_Ec,Label_Esta_Habilitado%>" DataField="EstaHabilitado" />
                                     <asp:TemplateField HeaderText="<%$ Resources:Web_es_Ec,Label_Editar%>" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                    <ItemTemplate >
                                        <asp:ImageButton ID="_imgObservaciones" runat="server" ImageUrl="~/Content/Imagen/Editar.png"  CommandName="Editar" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" />
                                    </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                    </Columns>
                                     <HeaderStyle CssClass="tableCabecera" ></HeaderStyle>
                                     <RowStyle CssClass="tableItem"></RowStyle>
                                     <FooterStyle CssClass="tablePiePagina"></FooterStyle>
                                </asp:GridView>
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
