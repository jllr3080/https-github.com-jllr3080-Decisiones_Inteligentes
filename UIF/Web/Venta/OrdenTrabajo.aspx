<%@ Page Title="<%$ Resources:Web_es_Ec,Titulo_Pagina_Orden_Trabajo%>" Language="C#" MasterPageFile="~/PaginaMaestra/Site.Master" AutoEventWireup="true" CodeBehind="OrdenTrabajo.aspx.cs" Inherits="Web.Venta.OrdenTrabajo" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=16.1.1.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <br>
    <br>
    <br>
   <h2>
        <asp:Literal runat="server" ID="_literalTitulo" Text="<%$ Resources:Web_es_Ec,Titulo_Pagina_Orden_Trabajo%>"/>
    </h2>
    <section>
        <div class="panel panel-default" id="_datosBusquedaCliente">
           <div class="panel-heading"><asp:Literal runat="server" ID="_literalEncabezado" Text="<%$ Resources:Web_es_Ec,Panel_Cabecera_Orden_Trabajo%>"/></div>
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
                        <asp:Button ID="_btnBusquedaCliente" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Buscar%>"  ValidationGroup="BusquedaCliente" class="btn btn-primary" OnClick="_btnBusquedaCliente_Click"/>
                        

                    </div>
                     <div class="col-md-3">
                        <asp:Button ID="_btnCrearCliente" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Crear_Cliente%>"  ValidationGroup="BusquedaCliente" class="btn btn-primary" OnClick="_btnCrearCliente_Click"/>
                    </div>
                    
            </div>
            <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="_labelSucursal" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Sucursal%>"></asp:Label>
                        
                    </div>
                   
                    <div class="col-md-3">
                        <asp:Label ID="_labelUsuario" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Usuario%>"></asp:Label>
                        
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="_labelFecha" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Fecha%>"></asp:Label>
                        
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="_labelFechaEntrega" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Fecha_Entrega%>"></asp:Label>
                        
                    </div>
                    
            </div>
             <div class="row">
                    <div class="col-md-3">
                        <asp:TextBox ID="_sucursal" runat="server" class="form-control" ValidationGroup="GuardarOrden" ReadOnly="True"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="_sucursalValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GuardarOrden" ControlToValidate="_sucursal" ></asp:RequiredFieldValidator>
                        
                    </div>
                   
                    <div class="col-md-3">
                        <asp:TextBox ID="_usuario" runat="server" class="form-control" ValidationGroup="GuardarOrden" ReadOnly="True"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="_usuarioValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GuardarOrden" ControlToValidate="_usuario" ></asp:RequiredFieldValidator>
 
                    </div>
                     <div class="col-md-3">
                         <asp:TextBox ID="_fecha" runat="server" class="form-control" ValidationGroup="GuardarOrden" ReadOnly="True"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="_fechaValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GuardarOrden" ControlToValidate="_fecha" ></asp:RequiredFieldValidator>
                        
                    </div>
                     <div class="col-md-3">
                         <asp:TextBox ID="_fechaEntrega" runat="server" class="form-control" ValidationGroup="GuardarOrden"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="_fechaEntregaValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GuardarOrden" ControlToValidate="_fechaEntrega" ></asp:RequiredFieldValidator>

                    </div>
                    
            </div>
            <br>
             <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="_labelCliente" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Nombre_Cliente%>"></asp:Label>
                        
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="_labelDireccion" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Direccion%>"></asp:Label>
                        
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="_labelTelefono" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Telefono_Cliente%>"></asp:Label>
                        
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="_labelTipoLavado" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Tipo_Lavado%>"></asp:Label>
                        <span id="MainContent__labelTipoLavado">Tipo de Lavado</span>
                    </div>
                    
            </div>
            <div class="row">
                    <div class="col-md-3">
                        <asp:TextBox ID="_cliente" ReadOnly="True" runat="server" class="form-control" ValidationGroup="GuardarOrden"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="_clienteValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GuardarOrden" ControlToValidate="_cliente" ></asp:RequiredFieldValidator>
                       
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="_direccion" runat="server" ReadOnly="True"  class="form-control" ValidationGroup="GuardarOrden"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="_direccionValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GuardarOrden" ControlToValidate="_direccion" ></asp:RequiredFieldValidator>
                       
                        
                    </div>
                    <div class="col-md-3">
                         <asp:TextBox ID="_telefono" runat="server" ReadOnly="True"  class="form-control" ValidationGroup="GuardarOrden"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="_telefonoValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GuardarOrden" ControlToValidate="_telefono" ></asp:RequiredFieldValidator>
                         
                    </div>
                    <div class="col-md-3">
                        <asp:DropDownList ID="_tipoLavado" runat="server" CssClass="form-control" ValidationGroup="GuardarOrden" DataTextField="Descripcion" DataValueField="TipoLavadoId" OnSelectedIndexChanged="_tipoLavado_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                         
                    </div>
                </div>
         </div>
        </div>
        <br>
        <div class="panel panel-default" id="_datosDetalleOrdenTrabajo">
        <div class="panel-heading"><asp:Literal runat="server" ID="_literalDetalleOrdenTrabajo" Text="<%$ Resources:Web_es_Ec,Panel_Detalle_Orden_Trabajo%>"/></div>

        <asp:Panel ID="_panelLavadoSeco" runat="server" Visible="False">
            
        <div class="panel-body">
            <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="_labelPrenda" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Prenda%>"></asp:Label>
                        
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="_labelTalla" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Talla%>"></asp:Label>
                        
                    </div>    
                    <div class="col-md-3">
                        <asp:Label ID="_labelCantidad" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Cantidad%>"></asp:Label>
                        
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="_labelMarca" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Marca%>"></asp:Label>
                        
                    </div>
                    
            </div>
             <div class="row">
                 <div class="col-md-3">
                     <asp:DropDownList ID="_prenda" AutoPostBack="True" runat="server" CssClass="form-control" ValidationGroup="GrabarDetalleOrdenTrabajo" DataTextField="Nombre" DataValueField="ProductoId" OnSelectedIndexChanged="_prenda_SelectedIndexChanged"></asp:DropDownList>
                     <asp:RequiredFieldValidator ID="_prendaValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GrabarDetalleOrdenTrabajo" ControlToValidate="_prenda" ></asp:RequiredFieldValidator>
                        
                 </div>  
                  <div class="col-md-3">
                      <asp:DropDownList ID="_talla" AutoPostBack="True"  runat="server" CssClass="form-control" ValidationGroup="GrabarDetalleOrdenTrabajo" DataTextField="Descripcion" DataValueField="ProductoTallaId" OnSelectedIndexChanged="_talla_SelectedIndexChanged"></asp:DropDownList>
                      <asp:RequiredFieldValidator ID="_tallaValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GrabarDetalleOrdenTrabajo" ControlToValidate="_talla" ></asp:RequiredFieldValidator>
                 </div>   
                 <div class="col-md-3">
                     <asp:TextBox ID="_cantidad" runat="server" AutoPostBack="True" class="form-control" ValidationGroup="GrabarDetalleOrdenTrabajo" OnTextChanged="_cantidad_TextChanged" TextMode="Number"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="_cantidadValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GrabarDetalleOrdenTrabajo" ControlToValidate="_cantidad" ></asp:RequiredFieldValidator>

                </div>
                  
                <div class="col-md-3">
                   <asp:DropDownList ID="_marca" runat="server" CssClass="form-control" ValidationGroup="GrabarDetalleOrdenTrabajo" DataTextField="Descripcion" DataValueField="MarcaId" OnSelectedIndexChanged="_talla_SelectedIndexChanged"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="_marcaValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GrabarDetalleOrdenTrabajo" ControlToValidate="_marca" ></asp:RequiredFieldValidator>
   
                </div>
                    
            </div>
            <br>
            <div class="row">
                    <div class="col-md-3">
                            <asp:Label ID="_labelMaterial" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Material%>"></asp:Label>
                        
                    </div>
                    <div class="col-md-3">
                            <asp:Label ID="_labelColor" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Color%>"></asp:Label>
                        
                    </div>
                    <div class="col-md-3">
                            <asp:Label ID="_labelValorUnitario" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Valor_Unitario%>"></asp:Label>
                        
                    </div>
                    <div class="col-md-3">
                         <asp:Label ID="_labelValorTotal" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Valor_Total%>"></asp:Label>
                        
                    </div>
                    
                    
            </div>
            <div class="row">
                  
                    <div class="col-md-3">
                        <asp:DropDownList ID="_material" runat="server" CssClass="form-control" ValidationGroup="GrabarDetalleOrdenTrabajo" DataTextField="Descripcion" DataValueField="MaterialId" ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="_materialValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GrabarDetalleOrdenTrabajo" ControlToValidate="_material" ></asp:RequiredFieldValidator>

                    </div>   
                 <div class="col-md-3">
                     <asp:DropDownList ID="_color" runat="server" CssClass="form-control" ValidationGroup="GrabarDetalleOrdenTrabajo" DataTextField="Descripcion" DataValueField="ColorId" ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="_colorValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GrabarDetalleOrdenTrabajo" ControlToValidate="_color" ></asp:RequiredFieldValidator>

                    </div>
                    <div class="col-md-3">
                         <asp:TextBox ID="_valorUnitario" runat="server" class="form-control" ValidationGroup="GrabarDetalleOrdenTrabajo"  ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="_valorUnitarioValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GrabarDetalleOrdenTrabajo" ControlToValidate="_valorUnitario" ></asp:RequiredFieldValidator>
                         <cc1:MaskedEditExtender ID="_mascaraValorUnitario" runat="server" TargetControlID="_valorUnitario" Mask="999.99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" MaskType="Number" InputDirection="RightToLeft" AcceptNegative="Left" DisplayMoney="Left" ErrorTooltipEnabled="True" />

                    </div>
                    <div class="col-md-3">
                         <asp:TextBox ID="_valorTotal" runat="server" class="form-control" ValidationGroup="GrabarDetalleOrdenTrabajo"  ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="_valorTotalValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GrabarDetalleOrdenTrabajo" ControlToValidate="_valorTotal" ></asp:RequiredFieldValidator>
                         <cc1:MaskedEditExtender ID="_valorTotalMascara" runat="server" TargetControlID="_valorUnitario" Mask="999.99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" MaskType="Number" InputDirection="RightToLeft" AcceptNegative="Left" DisplayMoney="Left" ErrorTooltipEnabled="True" />

                    </div>
                    
                    
            </div>
            <br>
             <div class="row">
                   <div class="col-md-3">
                         <asp:Label ID="_labelObservacion" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Observacion%>"></asp:Label>
                    </div>
              </div> 
             <div class="row">
                   <div class="col-md-3">
                        <asp:TextBox ID="_observacion" runat="server" class="form-control" ValidationGroup="GrabarDetalleOrdenTrabajo"  ></asp:TextBox>
                    </div>
              </div> 
            <br>

            <div class="row">
                    <div class="col-md-3">
                       <asp:Button ID="_btnAgregarDetalleOrdenTrabajo" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Agregar_Orden_Trabajo%>"  ValidationGroup="GrabarDetalleOrdenTrabajo" class="btn btn-primary" OnClick="_btnAgregarDetalleOrdenTrabajo_Click"/>
                       
                    </div>
                   
                    
            </div>
            <br>
              <div class="row">
                    <div class="col-md-12" style="text-align: center">
                       

                            <asp:GridView ID="_datos" AutoGenerateColumns="True" runat="server" CssClass="tableCabecera">
                                
                            </asp:GridView>
		
                    </div>    
    
              </div>
        </div>
   
        
        </asp:Panel>
         
        <asp:Panel runat="server" ID="_panelLavadoMojado" Visible="False">
            
        </asp:Panel>
         </div>
     <br/>
         <div class="panel panel-default" id="_datosFormaPago">
           <div class="panel-heading">Datos de Pago</div>
        <div class="panel-body">
            <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="_labelEstadoPago" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Estado_Pago%>"></asp:Label>
                    </div>
                     <div class="col-md-3">
                          <asp:Label ID="_labelNumeroOrden" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Numero_Orden%>"></asp:Label>
                        
                    </div>
                    
            </div>
             <div class="row">
                    <div class="col-md-3">
                         <asp:DropDownList ID="_estadoPago" runat="server" CssClass="form-control" ValidationGroup="GuardarOrden" DataTextField="Descripcion" DataValueField="EstadoPagoId" ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="_estadoPagoValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GuardarOrden" ControlToValidate="_estadoPago" ></asp:RequiredFieldValidator>

                    </div>
                       <div class="col-md-3">
                        <asp:TextBox ID="_numeroOrden" runat="server" class="form-control" ValidationGroup="GuardarOrden"  ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="_numeroOrdenValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GuardarOrden" ControlToValidate="_numeroOrden" ></asp:RequiredFieldValidator>
                         
                    </div>
            </div>

        </div>
         </div>
    </section>
        <nav>
        <asp:Button ID="_grabarOrdenTrabajo" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Guardar_Orden_Trabajo%>"  ValidationGroup="GuardarOrden" class="btn btn-primary" OnClick="_grabarOrdenTrabajo_Click"/>
        <asp:Button ID="_cancelar" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Cancelar%>"  class="btn btn-primary" OnClick="_cancelar_Click"/>

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
