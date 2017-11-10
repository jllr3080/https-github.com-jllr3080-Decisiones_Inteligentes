<%@ Page Title="<%$ Resources:Web_es_Ec,Titulo_Pagina_Orden_Trabajo%>" Language="C#" MasterPageFile="~/PaginaMaestra/Site.Master" AutoEventWireup="true" CodeBehind="OrdenTrabajoWizard.aspx.cs" Inherits="Web.Venta.OrdenTrabajoWizard" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=16.1.1.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
   <br/>
    <br/>
    <br/>
    <br/>
     <h2>
        <asp:Literal runat="server" ID="_literalTitulo" Text="<%$ Resources:Web_es_Ec,Titulo_Pagina_Orden_Trabajo%>"/>
    </h2>
    <section>
         <div class="row">
             <div class="col-md-12">
              <asp:Wizard ID="_emisionPrenda" runat="server" CssClass="col-md-12" DisplaySideBar="False" ActiveStepIndex="0" OnNextButtonClick="_emisionPrenda_NextButtonClick" OnPreviousButtonClick="_emisionPrenda_PreviousButtonClick" OnFinishButtonClick="_emisionPrenda_FinishButtonClick" >
                  
                     <NavigationButtonStyle CssClass="btn btn-primary" />
                     <StartNextButtonStyle CssClass="btn btn-primary" />
                     <StepNextButtonStyle CssClass="btn btn-primary" />
                     <StepPreviousButtonStyle CssClass="btn btn-primary" />
                  
                     <WizardSteps>
                         
                      <asp:WizardStep runat="server"  StepType="Start" ID="_informacionPersonal"  >
                           <div class="panel panel-default" id="_datosBusquedaCliente">
                               <div class="panel-heading">
                                     <div class="row">
                                        <div class="col-md-3">
                                            <asp:Literal runat="server" ID="_literalDatosPersonales" Text="<%$ Resources:Web_es_Ec,Panel_Cabecera_Datos_Personales%>"/>
                                        </div>
                                          <div class="col-md-3">
                      
                                            <asp:Button ID="_btnCrearCliente" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Crear_Cliente%>"   class="btn btn-primary" OnClick="_btnCrearCliente_OnClick"/>
                                        </div>       
                                     </div>                
                                </div>       

                               
                            <div class="panel-body">
                                <div class="row">
                
                                     <div class="col-md-3">
                                            <asp:Label ID="_labelTipoBusqueda" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Tipo_Busqueda%>"></asp:Label>
                                        </div>
                                     
                                    <div class="col-md-3">
                        
                                            <asp:Label ID="_labelNumeroDocumentoBusqueda" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Parametro_Uno%>"></asp:Label>
                                        </div>
                
                                    <div class="col-md-3">
                        
                                            <asp:Label ID="_labelParametroDos" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Parametro_Dos%>"></asp:Label>
                                        </div>
                    
                                </div>
                                 <div class="row">
                 
                                           <div class="col-md-3">
                                             <asp:DropDownList ID="_tipoBusqueda" runat="server" CssClass="form-control" ValidationGroup="BusquedaCliente" DataTextField="Busqueda" DataValueField="TipoBusquedaId" AutoPostBack="True" OnSelectedIndexChanged="_tipoBusqueda_OnSelectedIndexChanged"></asp:DropDownList>
                                              <asp:RequiredFieldValidator ID="_tipoBusquedaValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="BusquedaCliente" ControlToValidate="_tipoBusqueda" InitialValue="-1" ></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:TextBox ID="_numeroDocumentoBusqueda" runat="server" maxlength="13" class="form-control" ValidationGroup="BusquedaCliente" AutoCompleteType="Disabled"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="_numeroDocumentoBusquedaValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="BusquedaCliente" ControlToValidate="_numeroDocumentoBusqueda" ></asp:RequiredFieldValidator>
                        
                                        </div>
                 
                                     <div class="col-md-3">
                                            <asp:TextBox ID="_parametroDos" runat="server" maxlength="13" class="form-control" ValidationGroup="BusquedaCliente" AutoCompleteType="Disabled"></asp:TextBox>
                        
                        
                                        </div>
                                        <div class="col-md-3">
                                            <asp:Button ID="_btnBusquedaCliente" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Buscar%>"  ValidationGroup="BusquedaCliente" class="btn btn-primary" OnClick="_btnBusquedaCliente_OnClick"/>
                        

                                        </div>
                    
                    
                                </div>
                                
							</div>
                               </div> 
		 
                          <div class="panel panel-default" id="_datosBusquedaCliente">
                               <div class="panel-heading">
                                     <div class="row">
                                        <div class="col-md-3">
                                            <asp:Literal runat="server" ID="_literalEncabezado" Text="<%$ Resources:Web_es_Ec,Panel_Cabecera_Orden_Trabajo%>"/>
                                        </div>       
                                       
                 
                                </div>       

                               </div>
                            <div class="panel-body">
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
                                            <asp:Label ID="_labelTipoEntrega" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Tipo_Entrega%>"></asp:Label>
                        
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
                                             <asp:DropDownList ID="_tipoEntrega" runat="server" CssClass="form-control" ValidationGroup="GuardarOrden" DataTextField="Descripcion" DataValueField="EntregaUrgenciaId" ></asp:DropDownList>
                        
                        
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
                                            <asp:DropDownList ID="_tipoLavado" runat="server" CssClass="form-control" ValidationGroup="GuardarOrden" DataTextField="Descripcion" DataValueField="TipoLavadoId" ></asp:DropDownList>
                         
                                        </div>
                                    </div>
                                    <div class="row">
                                         <div class="col-md-3">
                                          <asp:CheckBox ID="_revisionPrendas" runat="server" CssClass="form-control" Text="<%$ Resources:Web_es_Ec,Label_Revision_Prendas%>" Visible="True"/>
                       
                                        </div>
                                    </div>
                             </div>
                            </div>
                      </asp:WizardStep>
                      
                      <asp:WizardStep runat="server"  StepType="Step" ID="_ingresoPrendas" >
                              <div class="panel panel-default" id="_datosDetalleOrdenTrabajo">
                                    <div class="panel-heading">
            
                                         <div class="row">
                                                <div class="col-md-3">
                                                    <asp:Literal runat="server" ID="_literalDetalleOrdenTrabajo" Text="<%$ Resources:Web_es_Ec,Panel_Detalle_Orden_Trabajo%>"/>            
                                                </div>       
                                                <div class="col-md-3">
                                                <asp:Button ID="_revisarPromocionesVigentes" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Promociones_Vigentes%>"   class="btn btn-primary" OnClick="_revisarPromocionesVigentes_OnClick"/>
                                                </div>
                                             <div class="col-md-3">
                                                 <asp:Button ID="_crearMarca" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Crear_Marca%>" class="btn btn-primary" OnClick="_crearMarca_OnClick" Width="100%" />

                                                </div>
                                        </div>       

                                    </div>

                                    <asp:Panel ID="_panelLavadoSeco" runat="server" >
            
                                    <div class="panel-body">
                                        <div class="row">
                                                <div class="col-md-6">
                                                    <asp:Label ID="_labelPrenda" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Prenda%>"></asp:Label>
                        
                                                </div>
                   
                                            <div class="col-md-3">
                                                    <asp:Label ID="_labelCantidad" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Cantidad%>"></asp:Label>
                        
                                                </div>
                                                  <div class="col-md-3">
                                                        <asp:Label ID="_labelValorUnitario" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Valor_Unitario%>"></asp:Label>
                        
                                                </div>
                    
                                        </div>
                                         <div class="row">
                                             <div class="col-md-6">
                                                 <asp:DropDownList ID="_prenda" AutoPostBack="True" runat="server" CssClass="form-control" ValidationGroup="GrabarDetalleOrdenTrabajo" DataTextField="Nombre" DataValueField="ProductoId" OnSelectedIndexChanged="_prenda_OnSelectedIndexChanged"></asp:DropDownList>
                                                 <asp:RequiredFieldValidator ID="_prendaValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GrabarDetalleOrdenTrabajo" ControlToValidate="_prenda" ></asp:RequiredFieldValidator>
                        
                                             </div>  
                  
                      
                 
                
                                             <div class="col-md-3">
                                                   
                                                  <asp:TextBox ID="_cantidad" runat="server" AutoPostBack="True" class="form-control" ValidationGroup="GrabarDetalleOrdenTrabajo" OnTextChanged="_cantidad_OnTextChanged" TextMode="Number"></asp:TextBox>
                                                  <asp:RequiredFieldValidator ID="_cantidadValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GrabarDetalleOrdenTrabajo" ControlToValidate="_cantidad" ></asp:RequiredFieldValidator>

                                            </div>
                  
                                            <div class="col-md-3">
                                                     <asp:TextBox ID="_valorUnitario" runat="server" class="form-control" ValidationGroup="GrabarDetalleOrdenTrabajo"  ReadOnly="True" ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="_valorUnitarioValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GrabarDetalleOrdenTrabajo" ControlToValidate="_valorUnitario" ></asp:RequiredFieldValidator>
                                                     <cc1:MaskedEditExtender ID="_mascaraValorUnitario" runat="server" TargetControlID="_valorUnitario" Mask="999.99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" MaskType="Number" InputDirection="RightToLeft" AcceptNegative="Left" DisplayMoney="Left" ErrorTooltipEnabled="True" />

                                                </div>
                    
                                        </div>
                                        <br>
                                        <div class="row">
               
                                                <div class="col-md-3">
                                                     <asp:Label ID="_labelValorTotal" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Valor_Total%>"></asp:Label>
                        
                                                </div>
                                              <div class="col-md-3">
                                                    <asp:Label ID="_labelDescuento" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Valor_Descuento%>"></asp:Label>
                                                </div>
                
                                                <div class="col-md-3">
                                                    <asp:Label ID="_labelvalorTotalPagar" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Valor_Total_Pagar%>"></asp:Label>
                                                </div>
                                             <div class="col-md-3">
                            
                                                     <asp:Label ID="_labelPromocionAplicada" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Promocion_Aplicada%>"></asp:Label>
                                                </div>
                                         </div>
                                         <div class="row">
                    
                                                <div class="col-md-3">
                                                     <asp:TextBox ID="_valorTotal" runat="server" class="form-control" ValidationGroup="GrabarDetalleOrdenTrabajo"  ReadOnly="True"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="_valorTotalValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GrabarDetalleOrdenTrabajo" ControlToValidate="_valorTotal" ></asp:RequiredFieldValidator>
                                                     <cc1:MaskedEditExtender ID="_valorTotalMascara" runat="server" TargetControlID="_valorTotal" Mask="999.99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" MaskType="Number" InputDirection="RightToLeft" AcceptNegative="Left" DisplayMoney="Left" ErrorTooltipEnabled="True" />

                                                </div>
                                              <div class="col-md-3">
                                                     <asp:TextBox ID="_descuento" runat="server" class="form-control" ValidationGroup="GuardarOrden" ReadOnly="True" ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="_descuentoValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GrabarDetalleOrdenTrabajo" ControlToValidate="_descuento" ></asp:RequiredFieldValidator>
                         
                                             </div>
                                            <div class="col-md-3">
                                                     <asp:TextBox ID="_valorTotalPagar" runat="server" class="form-control" ValidationGroup="GuardarOrden"  ReadOnly="True"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="_valorTotalPagarValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GrabarDetalleOrdenTrabajo" ControlToValidate="_valorTotalPagar" ></asp:RequiredFieldValidator>
                         
                                             </div>
                                              <div class="col-md-3">
                       
                                                  <asp:TextBox ID="_promocionAplicada" runat="server" class="form-control" ValidationGroup="GuardarOrden" ReadOnly="True"   ForeColor="Red"></asp:TextBox>
                                                    <asp:HiddenField ID="_promocionId" runat="server" />
                                             </div>
                                         </div>
           
                                         <div>
                 


                                        <br>
                                            <div class="row">
               
                                                <div class="col-md-3">
                                                    <asp:CheckBox ID="_suavizante" runat="server" CssClass="form-control" Text="<%$ Resources:Web_es_Ec,Label_Suavizante%>" Visible="False" AutoPostBack="True" OnCheckedChanged="_suavizante_OnCheckedChanged"/>
                         
                        
                                                </div>
                                              <div class="col-md-3">
                                                    <asp:CheckBox ID="_fijadorColor" runat="server" CssClass="form-control" Text="<%$ Resources:Web_es_Ec,Label_Fijado_Color%>" Visible="False" AutoPostBack="True" OnCheckedChanged="_fijadorColor_OnCheckedChanged"/>
                                                </div>
                
                                                <div class="col-md-3">
                                                    <asp:CheckBox ID="_desengrasante" runat="server" CssClass="form-control" Text="<%$ Resources:Web_es_Ec,Label_Desengrasante%>" Visible="False" AutoPostBack="True" OnCheckedChanged="_desengrasante_OnCheckedChanged"/>
                                                </div>
                 
                                         </div>   
                                        <br />
                                           <div class="row">
                   
                                                  <div class="col-md-3">
                                                    <asp:CheckBox ID="_envioMatriz" runat="server" CssClass="form-control" Text="<%$ Resources:Web_es_Ec,Label_Entrega_Matriz%>" Visible="True"/>
                       
                                                </div>
                                              
                
                                                 <div class="col-md-3">
                                                    <asp:CheckBox ID="_soloPlanchado" runat="server" CssClass="form-control" Text="<%$ Resources:Web_es_Ec,Label_Solo_Planchado%>" Visible="True"  OnCheckedChanged="_soloPlanchado_OnCheckedChanged" AutoPostBack="True"/>
                       
                                                </div>
                
                                             <div class="col-md-3">
                                                     <asp:CheckBox ID="_procentajeManchado" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Porcentaje_Manchado%>" Visible="True" CssClass="form-control" OnCheckedChanged="_procentajeManchado_OnCheckedChanged" AutoPostBack="True"/>
                       
                                                </div>
                
                   
                    
                                        </div>     
                                        <br>
            
                                        <div class="row">
                                                <div class="col-md-3">
                                                   <asp:Button ID="_btnAgregarDetalleOrdenTrabajo" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Agregar_Orden_Trabajo%>"  ValidationGroup="GrabarDetalleOrdenTrabajo" class="btn btn-primary" OnClick="_btnAgregarDetalleOrdenTrabajo_OnClick"/>
                       
                                                </div>
                                                
                
                   
                
                   
                    
                                        </div>
                                        <br>
                                          <div class="row">
                                                <div class="col-md-12" style="text-align: center">
                       
                                                    <asp:HiddenField ID="_nombreMarca" runat="server" />
                                                        <asp:GridView ID="_datos" runat="server" AutoGenerateColumns="False" OnRowCommand="_datos_OnRowCommand"  Width="100%" OnRowDataBound="_datos_OnRowDataBound" ShowFooter="True" >
                                
                                                            <Columns>
                                                               
                                                                <asp:BoundField DataField="Producto.Nombre" HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Prenda%>"  >
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                </asp:BoundField>
                                                               <asp:BoundField DataField="PromocionAplicada" HeaderText="<%$ Resources:Web_es_Ec,Label_Codigo_Promocion%>"    ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle" >
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                </asp:BoundField>
                                                                  <asp:BoundField DataField="NombrePromocionAplicada" HeaderText="<%$ Resources:Web_es_Ec,Label_Promocion_Aplicada%>"   DataFormatString="{0:C2}" ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle" >
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                </asp:BoundField>
                                                                 <asp:BoundField DataField="Cantidad" HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Cantidad%>"   ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"  >
                                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="ValorUnitario"  HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Valor_Unitario%>"  DataFormatString="{0:C2}" ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle" >
                                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="ValorTotalUnitario" HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Grid_Valor_Total%>"   DataFormatString="{0:C2}" ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle" >
                                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="ValorDescuento" HeaderText="<%$ Resources:Web_es_Ec,Label_Valor_Descuento%>"   DataFormatString="{0:C2}" ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle" >
                                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                                </asp:BoundField>
                                                                 <asp:BoundField DataField="ValorTotal" HeaderText="<%$ Resources:Web_es_Ec,Label_Valor_Total_Pagar%>"   DataFormatString="{0:C2}" ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle" >
                                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                                </asp:BoundField>
                                                                 <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="_eliminarPrenda" runat="server" ImageUrl="~/Content/Imagen/Borrar.png"  CommandName="Eliminar" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"/>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                 <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="_agregarDetalle" runat="server" ImageUrl="~/Content/Imagen/Nuevo.png"  CommandName="Agregar" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"/>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                 <asp:TemplateField  >
                                                                                <ItemTemplate >
                                                                                    <asp:ImageButton ID="_visualizarDetalle" runat="server" ImageUrl="~/Content/Imagen/mas.jpg"  CommandName="Visualizar" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"/>
                                                                                    <asp:ImageButton ID="_esconderDetalle" runat="server" ImageUrl="~/Content/Imagen/menos.png"  CommandName="EsconderVisualizar" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" />
                                                                                     <tr>
                                                                                        <td colspan="100%" style="text-align: right">
                                                                                        <asp:Panel ID="Detalles" runat="server" Visible="False">
                                                                                        <asp:GridView ID="_detalleCuotas" runat="server" AutoGenerateColumns="false" Width="100%">
                                                                                            <Columns>
                                                                                                  
                                                                                                   <asp:BoundField DataField="NombreColor" HeaderText="<%$ Resources:Web_es_Ec,Label_Color%>"  >
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="NombreMarca" HeaderText="<%$ Resources:Web_es_Ec,Label_Marca%>"  >
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="EstadoPrenda" HeaderText="<%$ Resources:Web_es_Ec,Label_Estado_Prenda%>"  ></asp:BoundField>
                                                                                                  <asp:BoundField DataField="TratamientoEspecial" HeaderText="<%$ Resources:Web_es_Ec,Label_Tratamiento_Especial%>"  ></asp:BoundField>
                                                                                                  <asp:BoundField DataField="NumeroInternoPrenda" HeaderText="<%$ Resources:Web_es_Ec,Label_Numero_Interno%>"  ></asp:BoundField>
                                                                                                  <asp:BoundField DataField="InformacionVisual" HeaderText="<%$ Resources:Web_es_Ec,Label_Informacion_Visual%>"  ></asp:BoundField>
                                                                                                    <asp:TemplateField>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:ImageButton ID="_eliminarDetallePrenda" runat="server" ImageUrl="~/Content/Imagen/Borrar.png"  CommandName="Eliminar" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"/>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                              </Columns>
                                                                                            <HeaderStyle CssClass="tableCabecera"></HeaderStyle>
                                                                                            <RowStyle CssClass="tableItem"></RowStyle>
                                                                                        </asp:GridView>
                                                                                    </asp:Panel>
                                                                                             </td>
                        </tr>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                            </Columns>
                                                            <HeaderStyle CssClass="tableCabeceraIntenso" ></HeaderStyle>
                                                            <RowStyle CssClass="tableItem"></RowStyle>
                                                          <FooterStyle CssClass="tablePiePagina"></FooterStyle>
                                 
                                                        </asp:GridView>
		
                                                </div>    
    
                                          </div>
                                    </div>
                               </div>
        
                                    </asp:Panel>
           
        
                                 </div>
                        </asp:WizardStep>
                         
                     <asp:WizardStep runat="server">
                         <div class="panel panel-default" id="_datosFormaPago">
           <div class="panel-heading">
               <asp:Literal ID="_literaldatosPago" runat="server"  Text="<%$ Resources:Web_es_Ec,Literal_Datos_Pago%>"></asp:Literal></div>
        <div class="panel-body">
            
                
             
            <div class="row">
                  <div class="col-md-3">
                        <asp:Label ID="_labelFechaEntrega" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Fecha_Entrega%>"></asp:Label>
                        
                    </div>
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
                         <asp:TextBox ID="_fechaEntrega" runat="server" class="form-control" ValidationGroup="GuardarOrden" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="_fechaEntregaValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GuardarOrden" ControlToValidate="_fechaEntrega" ></asp:RequiredFieldValidator>
                           <ajaxToolkit:CalendarExtender ID="_fechaEntregaExtensor" runat="server" BehaviorID="_fechaEntrega_CalendarExtender" TargetControlID="_fechaEntrega" Format="dd/MM/yyyy"  />
                        <ajaxToolkit:TextBoxWatermarkExtender id="_fechaEntregaMarcaAgua" runat="server" targetcontrolid="_fechaEntrega" enabled="True" watermarktext="<%$ Resources:Web_es_Ec,Marca_Agua_Fecha%>"></ajaxToolkit:TextBoxWatermarkExtender>  
                        

                    </div>
                  <div class="col-md-3">
                         <asp:TextBox ID="_numeroOrdenManual" runat="server" class="form-control" ValidationGroup="GuardarOrden" TextMode="Number" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="_numeroOrdenManualValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GuardarOrden" ControlToValidate="_numeroOrdenManual" ></asp:RequiredFieldValidator>
                         

                    </div>   
                 <div class="col-md-3">
                         <asp:DropDownList ID="_estadoPago" runat="server" CssClass="form-control" ValidationGroup="GuardarOrden" DataTextField="Descripcion" DataValueField="EstadoPagoId" AutoPostBack="True" OnSelectedIndexChanged="_estadoPago_OnSelectedIndexChanged" ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="_estadoPagoValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GuardarOrden" ControlToValidate="_estadoPago" ></asp:RequiredFieldValidator>

                    </div>
                    <div class="col-md-3">
                         <asp:TextBox ID="_valorPago" runat="server" class="form-control" ValidationGroup="GuardarOrden"  ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="_valorPagoValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GuardarOrden" ControlToValidate="_valorPago" ></asp:RequiredFieldValidator>
                         <cc1:MaskedEditExtender ID="_valorPagoMascara" runat="server" TargetControlID="_valorPago" Mask="999.99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" MaskType="Number" InputDirection="RightToLeft" AcceptNegative="None" DisplayMoney="Left" ErrorTooltipEnabled="True"  />

                    </div>
                  
                 
                       
            </div>
            <br />
              <div class="row">
                  <div class="col-md-3">
                        <asp:Label ID="_labelObjetoOlvidado" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Objeto_Olvidado%>"></asp:Label>
                        
                    </div>
            </div>
             <div class="row">
                   <div class="col-md-3">
                                                    <asp:TextBox ID="_objetoOlvidado" runat="server" CssClass="form-control" ></asp:TextBox>
                       
                     </div>

             </div>
       
         </div>
            </div>
                     </asp:WizardStep>
                        
                   
                    </WizardSteps>
              </asp:Wizard>
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
    
    

    <div class="row" >
                  <div class="col-md-12" >
                <asp:Button ID="_btnCliente" runat="server" Text="" Visible="false" />
                    <cc1:ModalPopupExtender ID="_btnCliente_ModalPopupExtender" PopupControlID="_panelCliente" runat="server" BehaviorID="_btnCliente_ModalPopupExtender" TargetControlID="_btnCliente" BackgroundCssClass="modal-Backgoround" X="200" OnCancelScript="_btnCerrarClientes" Y="150">
                    </cc1:ModalPopupExtender>
                    <asp:Panel ID="_panelCliente" runat="server" Style="display: none; background-color: white; width:60%; height: auto;align-content:center ">
                        <div class="modal-header">
                            <h4 class="modal-title">
                                <asp:Literal ID="Literal4" runat="server"  Text="<%$ Resources:Web_es_Ec,Label_Promociones_Vigentes%>"></asp:Literal></h4>
                        </div>
                        <div class="modal-body">
                            
                         <div class="row">
                               <div class="col-md-12">
                               <asp:GridView ID="_clientes" runat="server" AutoGenerateColumns="False"   Width="100%"  ShowFooter="True" OnRowCommand="_clientes_OnRowCommand" >
                                
                                <Columns>
                                     <asp:BoundField DataField="NumeroDocumento" HeaderText="<%$ Resources:Web_es_Ec,Label_Cabecera_Numero_Documento%>"  >
                                     <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="NombreCompleto" HeaderText="<%$ Resources:Web_es_Ec,Label_Nombre_Completo%>"  >
                                     <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                      <asp:BoundField DataField="DireccionCliente" HeaderText="<%$ Resources:Web_es_Ec,Label_Direccion_Personal%>" DataFormatString="{0:d}"  >
                                          <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" ></ItemStyle>
                                      </asp:BoundField>
                                      <asp:BoundField DataField="TelefonoCliente" HeaderText="<%$ Resources:Web_es_Ec,Label_Telefono_Personal%>"  DataFormatString="{0:d}">
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"  />
                                    </asp:BoundField>
                                      <asp:TemplateField HeaderText="<%$ Resources:Web_es_Ec,Label_Seleccionar%>" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                          
                                        <ItemTemplate >
                                            <asp:ImageButton ID="_seleccionarCliente" runat="server" ImageUrl="~/Content/Imagen/Seleccionar.png"  CommandName="Seleccionar" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="tableCabecera" ></HeaderStyle>
                                <FooterStyle CssClass="tablePiePagina"></FooterStyle>
                            </asp:GridView>
                                   </div> 
                             </div> 
                        </div>
                         <div class="modal-footer">

                            
                            <asp:Button ID="_btnCerrarClientes" runat="server" Text="Cancelar" class="btn btn-primary" data-dismiss="modal" />
                        </div>
                    </asp:Panel>
     </div>
        </div>
    
    

    <div class="row" >
                  <div class="col-md-12" >
                <asp:Button ID="_btnRevisionPromociones" runat="server" Text="" Visible="false" />
                    <cc1:ModalPopupExtender ID="_btnRevisionPromociones_ModalPopupExtender" PopupControlID="_panelPromociones" runat="server" BehaviorID="_btnRevisionPromociones_ModalPopupExtender" TargetControlID="_btnRevisionPromociones" BackgroundCssClass="modal-Backgoround" X="500" OnCancelScript="_btnCerrarPromociones" Y="300">
                    </cc1:ModalPopupExtender>
                    <asp:Panel ID="_panelPromociones" runat="server" Style="display: none; background-color: white; width:60%; height: auto;align-content:center ">
                        <div class="modal-header">
                            <h4 class="modal-title">
                                <asp:Literal ID="Literal2" runat="server"  Text="<%$ Resources:Web_es_Ec,Label_Promociones_Vigentes%>"></asp:Literal></h4>
                        </div>
                        <div class="modal-body">
                            
                                
                         <div class="row">
                               <div class="col-md-12">
                               <asp:GridView ID="_promociones" runat="server" AutoGenerateColumns="False"   Width="100%"  ShowFooter="True" >
                                
                                <Columns>
                                     <asp:BoundField DataField="NombreRegla" HeaderText="<%$ Resources:Web_es_Ec,Label_Promociones_Vigentes%>"  >
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="XX-Small" />
                                    </asp:BoundField>
                                      <asp:BoundField DataField="FechaInicio" HeaderText="<%$ Resources:Web_es_Ec,Label_Fecha_Desde%>" DataFormatString="{0:d}"  >
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="XX-Small" />
                                    </asp:BoundField>
                                      <asp:BoundField DataField="FechaFin" HeaderText="<%$ Resources:Web_es_Ec,Label_Fecha_Hasta%>"  DataFormatString="{0:d}">
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="XX-Small" />
                                    </asp:BoundField>
                                </Columns>
                                <HeaderStyle CssClass="tableCabecera" ></HeaderStyle>
                                <FooterStyle CssClass="tablePiePagina"></FooterStyle>
                            </asp:GridView>
                                   </div> 
                             </div> 
                        </div>
                        <div class="modal-footer">

                            <asp:Button ID="_btnCerrarPromociones" runat="server" Text="Aceptar" class="btn btn-primary" data-dismiss="modal" />
                        </div>
                    </asp:Panel>
     </div>
        </div>
     <%--PANTALLA  DE  CREACION DE MARCA--%>
     
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
                                    <asp:TextBox ID="_txtMarca" runat="server" class="form-control" ValidationGroup="GrabarMarca"  AutoCompleteType="Disabled"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="_txtMarcaValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="GrabarMarca" ControlToValidate="_txtMarca" ></asp:RequiredFieldValidator>
                                </div>
                                
                          </div> 
                        </div>
                        <div class="modal-footer">

                            <asp:Button ID="_btnGrabarMarca" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Grabar_Marca%>" class="btn btn-primary" data-dismiss="modal" OnClick="_btnGrabarMarca_OnClick"  ValidationGroup="GrabarMarca"/>
                            <asp:Button ID="_cerrarMarca" runat="server" Text="<%$ Resources:Web_es_Ec,Boton_Cancelar%>" class="btn btn-primary" data-dismiss="modal" />
                        </div>
                    </asp:Panel>
     </div>
        </div>
    <%--FIN PANTALLA   DE  CREACION DE MARCA--%>
    <%--PANTALLA  DE  DETALLE  DE  PRENDAS--%>
    <div class="row" >
                  <div class="col-md-12" >
                <asp:Button ID="_btnDetalleOrden" runat="server" Text="" Visible="false" />
                    <cc1:ModalPopupExtender ID="_btnDetalleOrden_ModalPopupExtender" PopupControlID="_panelDetalleOrden" runat="server" BehaviorID="_btnDetalleOrden_ModalPopupExtender" TargetControlID="_btnRevisionPromociones" BackgroundCssClass="modal-Backgoround" X="250" OnOkScript="_grabarDetalle" OnCancelScript="_cancelarDetalle" Y="50" >
                    </cc1:ModalPopupExtender>
                    <asp:Panel ID="_panelDetalleOrden" runat="server" Style="display: none; background-color: white; width:60%; height: auto;align-content:center ">
                        <div class="modal-header">
                            <h4 class="modal-title">
                                <asp:Literal ID="Literal3" runat="server"  Text="<%$ Resources:Web_es_Ec,Titulo_Detalle_Orden%>"></asp:Literal></h4>
                        </div>
                        <div class="modal-body">
                            
                              <div class="row">
                               <div class="col-md-4">
                                      <asp:Label ID="_labelTotalPrendas" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Numero_Prendas%>"></asp:Label>
                               </div>
                               <div class="col-md-4">
                                        <asp:Label ID="_numeroPrendas" runat="server"  CssClass="text-danger"></asp:Label>
                               </div>
                                
                            </div>
                            <br />
                            <div class="row">
                               <div class="col-md-4">
                                    <asp:Label ID="_labelColoDetalle" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Color%>"></asp:Label>
                               </div>
                               <div class="col-md-4">
                                    <asp:Label ID="_labelMarcaDetalle" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Marca%>"></asp:Label>
                               </div>
                                <div class="col-md-4">
                                    <asp:Label ID="_labelEstadoPrendaDetalle" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Estado_Prenda%>"></asp:Label>
                               </div>
                            </div>
                             <div class="row">
                               <div class="col-md-4">
                                      <asp:DropDownList ID="_colorDetalle" runat="server" CssClass="form-control" ValidationGroup="DetallePrenda" DataTextField="Descripcion" DataValueField="ColorId" ></asp:DropDownList>
                                      <asp:RequiredFieldValidator ID="_colorDetalleValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="DetallePrenda" ControlToValidate="_colorDetalle" ></asp:RequiredFieldValidator>       
                               </div>
                               <div class="col-md-4">
                                    <asp:DropDownList ID="_marcaDetalle" runat="server" CssClass="form-control" ValidationGroup="DetallePrenda" DataTextField="Descripcion" DataValueField="MarcaId" ></asp:DropDownList>
                                      <asp:RequiredFieldValidator ID="_marcaDetalleValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="DetallePrenda" ControlToValidate="_marcaDetalle" ></asp:RequiredFieldValidator>       
                               </div>
                                <div class="col-md-4">
                                      <asp:TextBox ID="_estadoPrendaDetalle" runat="server" class="form-control" ValidationGroup="DetallePrenda"  AutoCompleteType="Disabled"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="_estadoPrendaDetalleValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="DetallePrenda" ControlToValidate="_estadoPrendaDetalle" ></asp:RequiredFieldValidator>
                               </div>
                            </div>
                            <br/>
                             <div class="row">
                               <div class="col-md-4">
                                    <asp:Label ID="_labelTratamientoEspecialPrenda" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Tratamiento_Especial%>"></asp:Label>
                               </div>
                             
                                <div class="col-md-4">
                                    <asp:Label ID="_labelinformacionVisualPrenda" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Informacion_Visual%>"></asp:Label>
                               </div>
                                 <div class="col-md-4">
                                    <asp:Label ID="_labelObservaciones" runat="server" Text="<%$ Resources:Web_es_Ec,Label_Observacion%>"></asp:Label>
                               </div>
                            </div>
                             <div class="row">
                               <div class="col-md-4">
                                      <asp:TextBox ID="_tratamientoEspecialDetalle" runat="server" class="form-control" ValidationGroup="DetallePrenda"  AutoCompleteType="Disabled"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="_tratamientoEspecialDetalleValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="DetallePrenda" ControlToValidate="_tratamientoEspecialDetalle" ></asp:RequiredFieldValidator>
                               </div>
                              
                                <div class="col-md-4">
                                      <asp:TextBox ID="_informacionVisualDetalle" runat="server" class="form-control" ValidationGroup="DetallePrenda"  AutoCompleteType="Disabled"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="_informacionVisualDetalleValidador" runat="server" CssClass="text-danger" ErrorMessage="<%$ Resources:Web_es_Ec,Mensaje_Obligatorio%>" ValidationGroup="DetallePrenda" ControlToValidate="_informacionVisualDetalle" ></asp:RequiredFieldValidator>
                               </div>
                                  <div class="col-md-4">
                                      <asp:TextBox ID="_observacion" runat="server" class="form-control" ValidationGroup="DetallePrenda"  AutoCompleteType="Disabled"></asp:TextBox>
                                    
                               </div>
                            </div>
                            
                              
                        <div class="modal-footer">

                            <asp:Button ID="_grabarDetalle" runat="server" Text="Agregar Detalle Prenda" class="btn btn-primary" data-dismiss="modal" ValidationGroup="DetallePrenda" OnClick="_grabarDetalle_OnClick"/>
                            <asp:Button ID="_cancelarDetalle" runat="server" Text="Cancelar" class="btn btn-primary" data-dismiss="modal" />
                        </div>
                             </div>
                    </asp:Panel>
                   
        </div>
      </div>
     <%--FIN PANTALLA  DE  DETALLE  DE  PRENDAS--%>
</asp:Content>
