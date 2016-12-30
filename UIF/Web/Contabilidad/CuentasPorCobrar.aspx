<%@ Page Title="<%$ Resources:Web_es_Ec,Titulo_Pagina_Cuenta_Por_Cobrar%>" Language="C#" MasterPageFile="~/PaginaMaestra/Site.Master" AutoEventWireup="true" CodeBehind="CuentasPorCobrar.aspx.cs" Inherits="Web.Contabilidad.CuentasPorCobrar" %>
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
           <div class="panel-heading"><asp:Literal runat="server" ID="_literalEncabezado" Text="<%$ Resources:Web_es_Ec,Panel_Cabecera_Cuenta_Por_Cobrar%>"/></div>
        <div class="panel-body">
            
            <div class="row">
                    <div class="col-md-3">
                        
                        <asp:Label ID="_labelNumeroDocumento" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Numero_Documento%>"></asp:Label>
                    </div>
            </div>
            <div class="row">
                    <div class="col-md-3">
                        <asp:TextBox ID="_numeroDocumento" runat="server" maxlength="13" class="form-control" ValidationGroup="BusquedaCliente"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="_numeroDocumentoValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="BusquedaCliente" ControlToValidate="_numeroDocumento" ></asp:RequiredFieldValidator>
                        
                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="_btnBusquedaCliente" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Buscar%>"  ValidationGroup="BusquedaCliente" class="btn btn-primary" OnClick="_btnBusquedaCliente_Click" />
                     
                    </div>
                     
                    
            </div>
         </div>
         </div>      
     
     </section>

</asp:Content>
