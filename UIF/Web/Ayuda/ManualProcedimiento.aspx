<%@ Page Title="<%$ Resources:Web_es_Ec,Titulo_Pagina_Manual_Procedimiento%>"  Language="C#" MasterPageFile="~/PaginaMaestra/Site.Master" AutoEventWireup="true" CodeBehind="ManualProcedimiento.aspx.cs" Inherits="Web.Ayuda.ManualProcedimiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <br />
    <br />
    <br />
    <br />
    <h2>
        <asp:Literal runat="server" ID="_literalTitulo" Text="<%$ Resources:Web_es_Ec,Titulo_Pagina_Manual_Procedimiento%>"/>
    </h2>
     <section>
         <iframe src="../Content/Imagen/MANUAL_PROCEDIMIENTO.pdf" width="100%" height="600px"></iframe>
    </section>
</asp:Content>
