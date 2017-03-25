
<%@ Page Title="<%$ Resources:Web_es_Ec,Titulo_Pagina_Orden_Trabajo%>" Language="C#" MasterPageFile="~/PaginaMaestra/Site.Master" AutoEventWireup="true"  CodeBehind="OrdenTrabajo.aspx.cs" Inherits="Web.Venta.OrdenTrabajo" MaintainScrollPositionOnPostback="true"%>
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
                           <ajaxToolkit:CalendarExtender ID="_fechaEntregaExtensor" runat="server" BehaviorID="_fechaEntrega_CalendarExtender" TargetControlID="_fechaEntrega" Format="dd/MM/yyyy"  />
                        <ajaxToolkit:TextBoxWatermarkExtender id="_fechaEntregaMarcaAgua" runat="server" targetcontrolid="_fechaEntrega" enabled="True" watermarktext="<%$ Resources:Web_es_Ec,Marca_Agua_Fecha%>"></ajaxToolkit:TextBoxWatermarkExtender>  
                        

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
                        <asp:Label ID="_labelColor" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Color%>"></asp:Label>
                        
                        
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
                 <asp:DropDownList ID="_color" runat="server" CssClass="form-control" ValidationGroup="GrabarDetalleOrdenTrabajo" DataTextField="Descripcion" DataValueField="ColorId" ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="_colorValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GrabarDetalleOrdenTrabajo" ControlToValidate="_color" ></asp:RequiredFieldValidator>
                </div>
                    
            </div>
            <br>
            <div class="row">
                    <div class="col-md-3">
                            <%--<asp:Label ID="_labelMaterial" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Material%>"></asp:Label>--%>
                        <asp:Label ID="_labelMarca" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Marca%>"></asp:Label>
                    </div>
                    <div class="col-md-3">
                            
                        
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
                      <asp:DropDownList ID="_marca" runat="server" CssClass="form-control" ValidationGroup="GrabarDetalleOrdenTrabajo" DataTextField="Descripcion" DataValueField="MarcaId" OnSelectedIndexChanged="_talla_SelectedIndexChanged"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="_marcaValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GrabarDetalleOrdenTrabajo" ControlToValidate="_marca" ></asp:RequiredFieldValidator>
   
                    </div>   
                 <div class="col-md-3">
                     <asp:Button ID="_crearMarca" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Crear_Marca%>" class="btn btn-primary" OnClick="_crearMarca_Click" Width="100%" />

                    </div>
                    <div class="col-md-3">
                         <asp:TextBox ID="_valorUnitario" runat="server" class="form-control" ValidationGroup="GrabarDetalleOrdenTrabajo"  ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="_valorUnitarioValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GrabarDetalleOrdenTrabajo" ControlToValidate="_valorUnitario" ></asp:RequiredFieldValidator>
                         <cc1:MaskedEditExtender ID="_mascaraValorUnitario" runat="server" TargetControlID="_valorUnitario" Mask="999.99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" MaskType="Number" InputDirection="RightToLeft" AcceptNegative="Left" DisplayMoney="Left" ErrorTooltipEnabled="True" />

                    </div>
                    <div class="col-md-3">
                         <asp:TextBox ID="_valorTotal" runat="server" class="form-control" ValidationGroup="GrabarDetalleOrdenTrabajo"  ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="_valorTotalValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GrabarDetalleOrdenTrabajo" ControlToValidate="_valorTotal" ></asp:RequiredFieldValidator>
                         <cc1:MaskedEditExtender ID="_valorTotalMascara" runat="server" TargetControlID="_valorTotal" Mask="999.99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" MaskType="Number" InputDirection="RightToLeft" AcceptNegative="Left" DisplayMoney="Left" ErrorTooltipEnabled="True" />

                    </div>
                    
                    
            </div>
            <br>
             <div class="row">
                   <div class="col-md-3">
                         <asp:Label ID="_labelObservacion" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Estado_Prenda%>"></asp:Label>
                    </div>
                 <div class="col-md-3">
                         <asp:Label ID="_labelTratamientoEspecial" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Tratamiento_Especial%>"></asp:Label>
                    </div>
                  <div class="col-md-3">
                         <asp:Label ID="_labelNumeroInterno" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Numero_Interno%>"></asp:Label>
                    </div>
                    <div class="col-md-3">
                         <asp:Label ID="_labelinformacionVisual" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Informacion_Visual%>"></asp:Label>
                    </div>
              </div> 
             <div class="row">
                   <div class="col-md-3">
                        <asp:TextBox ID="_observacion" runat="server" class="form-control" ValidationGroup="GrabarDetalleOrdenTrabajo"  ></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="_tratamientoEspecial" runat="server" class="form-control" ValidationGroup="GrabarDetalleOrdenTrabajo"  ></asp:TextBox>
                    </div>
                  <div class="col-md-3">
                        <asp:TextBox ID="_numeroInterno" runat="server" class="form-control" ValidationGroup="GrabarDetalleOrdenTrabajo"  MaxLength="10" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="_numeroInternoValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GrabarDetalleOrdenTrabajo" ControlToValidate="_numeroInterno" ></asp:RequiredFieldValidator>
                    </div>
                  <div class="col-md-3">
                        <asp:TextBox ID="_informacionVisual" runat="server" class="form-control" ValidationGroup="GrabarDetalleOrdenTrabajo"   ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="_informacionVisualValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GrabarDetalleOrdenTrabajo" ControlToValidate="_informacionVisual" ></asp:RequiredFieldValidator>
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
                       

                            <asp:GridView ID="_datos" runat="server" AutoGenerateColumns="False" OnRowCommand="_datos_RowCommand"  Width="100%" OnRowDataBound="_datos_RowDataBound" ShowFooter="True" >
                                
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="_eliminarPrenda" runat="server" ImageUrl="~/Content/Imagen/Borrar.png"  CommandName="Eliminar" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Producto.Nombre" HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Prenda%>"  >
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ProductoTalla.Descripcion"  HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Talla%>"  >
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Cantidad" HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Cantidad%>"   ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"  >
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Marca.Descripcion" HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Marca%>"  >
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Color.Descripcion"  HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Color%>" >
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ValorUnitario"  HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Valor_Unitario%>"  DataFormatString="{0:C2}" ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle" >
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ValorTotal" HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Valor_Total%>"   DataFormatString="{0:C2}" ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle" >
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                </Columns>
                                <HeaderStyle CssClass="tableCabecera" ></HeaderStyle>
                                <FooterStyle CssClass="tablePiePagina"></FooterStyle>
                            </asp:GridView>
		
                    </div>    
    
              </div>
        </div>
   
        
        </asp:Panel>
           
        <asp:Panel ID="_panelLavadoMojado" runat="server" Visible="False">
                  <div class="panel-body">
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="_labelPrendaPorLibras" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Prenda%>"></asp:Label>
                        
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="_labelTallaPorLibras" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Talla%>"></asp:Label>
                        
                    </div>    
                    <div class="col-md-3">
                        <asp:Label ID="_labelCantidadPorLibras" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Cantidad%>"></asp:Label>
                        
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="_labelColorPorLibras" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Color%>"></asp:Label>
                        
                        
                    </div>
                    
            </div>
             <div class="row">
                 <div class="col-md-3">
                     <asp:DropDownList ID="_prendaPorLibras" AutoPostBack="True" runat="server" CssClass="form-control" ValidationGroup="GrabarDetalleOrdenTrabajo" DataTextField="Nombre" DataValueField="ProductoId" OnSelectedIndexChanged="_prendaPorLibras_SelectedIndexChanged" ></asp:DropDownList>
                     <asp:RequiredFieldValidator ID="_prendaPorLibrasValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GrabarDetalleOrdenTrabajo" ControlToValidate="_prendaPorLibras" ></asp:RequiredFieldValidator>
                        
                 </div>  
                  <div class="col-md-3">
                      <asp:DropDownList ID="_tallaPorLibras" AutoPostBack="True"  runat="server" CssClass="form-control" ValidationGroup="GrabarDetalleOrdenTrabajo" DataTextField="Descripcion" DataValueField="ProductoTallaId" OnSelectedIndexChanged="_tallaPorLibras_SelectedIndexChanged" ></asp:DropDownList>
                      <asp:RequiredFieldValidator ID="_tallaPorLibrasValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GrabarDetalleOrdenTrabajo" ControlToValidate="_tallaPorLibras" ></asp:RequiredFieldValidator>
                 </div>   
                 <div class="col-md-3">
                     <asp:TextBox ID="_cantidadPorLibras" runat="server" AutoPostBack="True" class="form-control" ValidationGroup="GrabarDetalleOrdenTrabajo" OnTextChanged="_cantidadPorLibras_TextChanged"  ></asp:TextBox>
                      <asp:RequiredFieldValidator ID="_cantidadPorLibrasValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GrabarDetalleOrdenTrabajo" ControlToValidate="_cantidadPorLibras" ></asp:RequiredFieldValidator>

                </div>
                  
                <div class="col-md-3">
                 <asp:DropDownList ID="_colorPorLibras" runat="server" CssClass="form-control" ValidationGroup="GrabarDetalleOrdenTrabajo" DataTextField="Descripcion" DataValueField="ColorId" ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="_colorPorLibrasValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GrabarDetalleOrdenTrabajo" ControlToValidate="_colorPorLibras" ></asp:RequiredFieldValidator>
                </div>
                    
            </div>
            <br>
            <div class="row">
                    <div class="col-md-3">
                            <%--<asp:Label ID="_labelMaterial" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Material%>"></asp:Label>--%>
                        <asp:Label ID="_labelMarcaPorLibras" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Marca%>"></asp:Label>
                    </div>
                    <div class="col-md-3">
                            
                        
                    </div>
                    <div class="col-md-3">
                            <asp:Label ID="_labelValorUnitarioPorLibras" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Valor_Unitario%>"></asp:Label>
                        
                    </div>
                    <div class="col-md-3">
                         <asp:Label ID="_labelValorTotalPorLibras" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Valor_Total%>"></asp:Label>
                        
                    </div>
                    
                    
            </div>
            <div class="row">
                  
                    <div class="col-md-3">
                      <asp:DropDownList ID="_marcaPorLibras" runat="server" CssClass="form-control" ValidationGroup="GrabarDetalleOrdenTrabajo" DataTextField="Descripcion" DataValueField="MarcaId" ></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="_marcaPorLibrasValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GrabarDetalleOrdenTrabajo" ControlToValidate="_marcaPorLibras" ></asp:RequiredFieldValidator>
   
                    </div>   
                 <div class="col-md-3">
                     <asp:Button ID="_crearMarcaPorLibras" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Crear_Marca%>" class="btn btn-primary" OnClick="_crearMarca_Click" Width="100%" />

                    </div>
                    <div class="col-md-3">
                         <asp:TextBox ID="_valorUnitarioPorLibras" runat="server" class="form-control" ValidationGroup="GrabarDetalleOrdenTrabajo" OnTextChanged="_valorUnitarioPorLibras_TextChanged" AutoPostBack="True"  ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="_valorUnitarioPorLibrasValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GrabarDetalleOrdenTrabajo" ControlToValidate="_valorUnitarioPorLibras" ></asp:RequiredFieldValidator>
                         <cc1:MaskedEditExtender ID="_valorUnitarioPorLibrasMascara" runat="server" TargetControlID="_valorUnitarioPorLibras" Mask="999.99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" MaskType="Number" InputDirection="RightToLeft" AcceptNegative="Left" DisplayMoney="Left" ErrorTooltipEnabled="True" />

                    </div>
                    <div class="col-md-3">
                         <asp:TextBox ID="_valorTotalPorLibras" runat="server" class="form-control" ValidationGroup="GrabarDetalleOrdenTrabajo"  ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="_valorTotalPorLibrasValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GrabarDetalleOrdenTrabajo" ControlToValidate="_valorTotalPorLibras" ></asp:RequiredFieldValidator>
                         <cc1:MaskedEditExtender ID="_valorTotalPorLibrasMascara" runat="server" TargetControlID="_valorTotalPorLibras" Mask="999.99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" MaskType="Number" InputDirection="RightToLeft" AcceptNegative="Left" DisplayMoney="Left" ErrorTooltipEnabled="True" />

                    </div>
                    
                    
            </div>
            <br>
             <div class="row">
                   <div class="col-md-3">
                         <asp:Label ID="_labelEstadoPrendaPorLibras" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Estado_Prenda%>"></asp:Label>
                    </div>
                 <div class="col-md-3">
                         <asp:Label ID="_labelTratamientoEspecialPorLibras" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Tratamiento_Especial%>"></asp:Label>
                    </div>
                  <div class="col-md-3">
                         <asp:Label ID="_labelNumeroInternoPorLibras" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Numero_Interno%>"></asp:Label>
                    </div>
                  <div class="col-md-3">
                         <asp:Label ID="_labelInformacionVisualPorLibras" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Informacion_Visual%>"></asp:Label>
                    </div>
              </div> 
             <div class="row">
                   <div class="col-md-3">
                        <asp:TextBox ID="_estadoPrendaPorLibras" runat="server" class="form-control" ValidationGroup="GrabarDetalleOrdenTrabajo"  ></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="_tratamientoEspecialPorLibras" runat="server" class="form-control" ValidationGroup="GrabarDetalleOrdenTrabajo"  ></asp:TextBox>
                    </div>
                  <div class="col-md-3">
                        <asp:TextBox ID="_numeroInternoPorLibras" runat="server" class="form-control" ValidationGroup="GrabarDetalleOrdenTrabajo"  MaxLength="10" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="_numeroInternoPorLibrasValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GrabarDetalleOrdenTrabajo" ControlToValidate="_numeroInternoPorLibras" ></asp:RequiredFieldValidator>
                    </div>
                  <div class="col-md-3">
                        <asp:TextBox ID="_informacionVisualPorLibras" runat="server" class="form-control" ValidationGroup="GrabarDetalleOrdenTrabajo"   ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="_informacionVisualPorLibrasValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GrabarDetalleOrdenTrabajo" ControlToValidate="_informacionVisualPorLibras" ></asp:RequiredFieldValidator>
                    </div>

              </div> 
             <br/>
             <div class="row">
                     <div class="col-md-3">
                         <asp:CheckBox ID="_suavizante" runat="server" class="form-control" Text="<%$ Resources:Web_es_Ec,Label_Suavizante%>"  Visible="False" /> 
                       </div>
                     <div class="col-md-3">
                           <asp:CheckBox ID="_desengrasante" runat="server" class="form-control" Text="<%$ Resources:Web_es_Ec,Label_Desengrasante%>"  Visible="False"/> 
                       </div>
                     <div class="col-md-3">
                           <asp:CheckBox ID="_fijadorColor" runat="server" class="form-control" Text="<%$ Resources:Web_es_Ec,Label_Fijado_Color%>"  Visible="False"/> 
                       </div>
                </div>
             <br>
              <div class="row">
                    <div class="col-md-12" style="text-align: center">
                       

                            <asp:GridView ID="_datosLibras" runat="server" AutoGenerateColumns="False" OnRowCommand="_datos_RowCommand"  Width="100%" OnRowDataBound="_datos_RowDataBound" ShowFooter="True" >
                                
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="_eliminarPrenda" runat="server" ImageUrl="~/Content/Imagen/Borrar.png"  CommandName="Eliminar" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Producto.Nombre" HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Prenda%>" >
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ProductoTalla.Descripcion"  HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Talla%>"  >
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Cantidad" HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Cantidad%>"   ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"  >
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Marca.Descripcion" HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Marca%>"  >
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Color.Descripcion"  HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Color%>" >
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ValorUnitario"  HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Valor_Unitario%>"  DataFormatString="{0:C2}" ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle" >
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ValorTotal" HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Valor_Total%>"   DataFormatString="{0:C2}" ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle" >
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                </Columns>
                                <HeaderStyle CssClass="tableCabecera" ></HeaderStyle>
                                <FooterStyle CssClass="tablePiePagina"></FooterStyle>
                            </asp:GridView>
		
                    </div>    
             </div>
            <br />
             <div class="row">
                    <div class="col-md-3">
                       <asp:Button ID="_agregarRopaPorLibras" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Agregar_Orden_Trabajo%>"  ValidationGroup="GrabarDetalleOrdenTrabajo" class="btn btn-primary" OnClick="_agregarRopaPorLibras_Click" />
                       
                    </div>
                    <div class="col-md-3">
                        <asp:CheckBox ID="_matriz" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Entrega_Matriz%>" CssClass="form-control"  />
                       
                    </div>
                   
                    
            </div>
        </div>
        </asp:Panel>
         </div>
     <br/>
         <div class="panel panel-default" id="_datosFormaPago">
           <div class="panel-heading">
               <asp:Literal ID="_literaldatosPago" runat="server"  Text="<%$ Resources:Web_es_Ec,Literal_Datos_Pago%>"></asp:Literal></div>
        <div class="panel-body">
            <div class="row">
                
                <div class="col-md-3">
                        <asp:Label ID="_labelPromocion" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Aplica_Promocion%>"></asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="_labelValorTotalFinal" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Valor_Total%>"></asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="_labelDescuento" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Valor_Descuento%>"></asp:Label>
                    </div>
                
                    <div class="col-md-3">
                        <asp:Label ID="_labelvalorTotalPagar" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Valor_Total_Pagar%>"></asp:Label>
                    </div>
                    
                   
            </div>
            
            <div class="row">
                 <div class="col-md-3">
                         <asp:DropDownList ID="_promocion" runat="server" CssClass="form-control" ValidationGroup="GuardarOrden" DataTextField="NombreRegla" DataValueField="ReglaId" AutoPostBack="True" OnSelectedIndexChanged="_promocion_SelectedIndexChanged"  ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="_promocionValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GuardarOrden" ControlToValidate="_promocion" ></asp:RequiredFieldValidator>

                 </div>
                 <div class="col-md-3">
                         <asp:TextBox ID="_valorTotalFinal" runat="server" class="form-control" ValidationGroup="GuardarOrden"  ReadOnly="True" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="_valorTotalFinalValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GuardarOrden" ControlToValidate="_valorTotalFinal" ></asp:RequiredFieldValidator>
                         
                 </div>
                
                <div class="col-md-3">
                         <asp:TextBox ID="_descuento" runat="server" class="form-control" ValidationGroup="GuardarOrden" ReadOnly="True" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="_descuentoValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GuardarOrden" ControlToValidate="_descuento" ></asp:RequiredFieldValidator>
                         
                 </div>
                <div class="col-md-3">
                         <asp:TextBox ID="_valorTotalPagar" runat="server" class="form-control" ValidationGroup="GuardarOrden"  ReadOnly="True"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="_valorTotalPagarValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GuardarOrden" ControlToValidate="_valorTotalPagar" ></asp:RequiredFieldValidator>
                         
                 </div>
            </div>
            <div class="row">
                 <div class="col-md-3">
                        <asp:Label ID="_labelNumeroOrdenManual" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Numero_Orden_Manual%>"></asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="_labelEstadoPago" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Estado_Pago%>"></asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="_labelValorPago" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Valor_Abonar%>"></asp:Label>
                    </div>
                   
                
                    
                   
            </div>
             <div class="row">
                 
                  <div class="col-md-3">
                         <asp:TextBox ID="_numeroOrdenManual" runat="server" class="form-control" ValidationGroup="GuardarOrden"  ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="_numeroOrdenManualValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GuardarOrden" ControlToValidate="_numeroOrdenManual" ></asp:RequiredFieldValidator>
                         

                    </div>   
                 <div class="col-md-3">
                         <asp:DropDownList ID="_estadoPago" runat="server" CssClass="form-control" ValidationGroup="GuardarOrden" DataTextField="Descripcion" DataValueField="EstadoPagoId" AutoPostBack="True" OnSelectedIndexChanged="_estadoPago_SelectedIndexChanged" ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="_estadoPagoValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GuardarOrden" ControlToValidate="_estadoPago" ></asp:RequiredFieldValidator>

                    </div>
                    <div class="col-md-3">
                         <asp:TextBox ID="_valorPago" runat="server" class="form-control" ValidationGroup="GuardarOrden"  ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="_valorPagoValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GuardarOrden" ControlToValidate="_valorPago" ></asp:RequiredFieldValidator>
                         <cc1:MaskedEditExtender ID="_valorPagoMascara" runat="server" TargetControlID="_valorPago" Mask="999.99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" MaskType="Number" InputDirection="RightToLeft" AcceptNegative="Left" DisplayMoney="Left" ErrorTooltipEnabled="True" />

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
    
     <div class="row" >
                  <div class="col-md-12" >
                <asp:Button ID="_btnMarca" runat="server" Text="" Visible="false" />
                    <cc1:ModalPopupExtender ID="_btnMarca_ModalPopupExtender" PopupControlID="_panelMarca" runat="server" BehaviorID="_btnMarca_ModalPopupExtender" TargetControlID="_btnMarca" BackgroundCssClass="modal-Backgoround" X="500" OnCancelScript="_cerrarMarca" OnOkScript="_btnGrabarrMarca" Y="300">
                    </cc1:ModalPopupExtender>
                    <asp:Panel ID="_panelMarca" runat="server" Style="display: none; background-color: white; width: 20%; height: auto;align-content:center ">
                        <div class="modal-header">
                            <h4 class="modal-title">
                                <asp:Literal ID="Literal1" runat="server"  Text="<%$ Resources:Web_es_Ec,Panel_Creacion_Marca%>"></asp:Literal></h4>
                        </div>
                        <div class="modal-body">
                             <div class="row">
                               <div class="col-md-12">
                                     <asp:Label ID="_labelNombreMarca" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Marca%>"></asp:Label>
                                   
                                </div>
                             
                          </div> 
                         <div class="row">
                               <div class="col-md-12">
                                    <asp:TextBox ID="_txtMarca" runat="server" class="form-control" ValidationGroup="GrabarMarca"  ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="_txtMarcaValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GrabarMarca" ControlToValidate="_txtMarca" ></asp:RequiredFieldValidator>
                                </div>
                                
                          </div> 
                        </div>
                        <div class="modal-footer">

                            <asp:Button ID="_btnGrabarrMarca" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Grabar_Marca%>" class="btn btn-primary" data-dismiss="modal" OnClick="_btnGrabarrMarca_Click"  ValidationGroup="GrabarMarca"/>
                            <asp:Button ID="_cerrarMarca" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Cancelar%>" class="btn btn-primary" data-dismiss="modal" />
                        </div>
                    </asp:Panel>
     </div>
        </div>
</asp:Content>
