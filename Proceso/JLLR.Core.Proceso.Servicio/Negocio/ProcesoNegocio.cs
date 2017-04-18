#region using
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using JLLR.Core.FlujoProceso.Servicio.Modelo;
using JLLR.Core.Proceso.Servicio.Modelo;
using JLLR.Core.Proceso.Servicio.ServicioDelegado;
using JLLR.Core.Proceso.Servicio.Transformador;
using JLLR.Core.Venta.Servicio.DTOs;
using JLLR.Core.Venta.Servicio.Modelo;

#endregion
namespace JLLR.Core.Proceso.Servicio.Negocio
{
    public class ProcesoNegocio
    {
        /// <summary>
        /// Declaraciones  e instancias
        /// </summary>
        private readonly ServicioDelegadoFlujoProceso _servicioDelegadoFlujoProceso= new ServicioDelegadoFlujoProceso();
        private readonly  ServicioDelegadoVenta _servicioDelegadoVenta= new ServicioDelegadoVenta();
        private readonly  ProcesoTransformadorNegocio _procesoTransformadorNegocio= new ProcesoTransformadorNegocio();

            

        /// <summary>
        /// Envia  correo masivos para anulaciones, entrega de cliente  y entrega a  franquicia
        /// </summary>
        public void EnvioCorreoMasivo()
        {
               List<HistorialProcesoModelo> _historialProcesos =_servicioDelegadoFlujoProceso.ObtenerHistorialProceso();

            if (_historialProcesos.Count>0)
            { 
                foreach (var objetoHistorialProceso in _historialProcesos)
                {
                    try
                    {
                        List<ConsultaOrdenTrabajoDTOs> _listaConsultaOrdenTrabajoVistaDtOses = _servicioDelegadoVenta.ObtenerOrdenTrabajoPorNumeroOrdenYPuntoVenta(objetoHistorialProceso.NumeroOrden,
               Convert.ToInt32(objetoHistorialProceso.PuntoVentaId));
                        List<DetalleOrdenTrabajoModelo> _lisaDetalleOrdenTrabajoVistaModelos =
                            _servicioDelegadoVenta.ObtenerDetalleOrdenTrabajoPorNumeroOrdenYPuntoVenta(objetoHistorialProceso.NumeroOrden,
                                Convert.ToInt32(objetoHistorialProceso.PuntoVentaId));
                        //Envio de correo al cliente por entrega de  prenddas
                        if (objetoHistorialProceso.EtapaProceso.EtapaProcesoId == 1)
                        {
                            EnvioCorreoEntregaFranquicia(_listaConsultaOrdenTrabajoVistaDtOses,
                                _lisaDetalleOrdenTrabajoVistaModelos);
                        }
                        //Envio de  correo cuando las prendas  ya se encuentran en la franquicia
                        if (objetoHistorialProceso.EtapaProceso.EtapaProcesoId == 7)
                            EnvioCorreoAvisoRetiroPrenda(_listaConsultaOrdenTrabajoVistaDtOses);
                        //Envio de correo  cuando  ya se entrego al cliente las prendas
                        if (objetoHistorialProceso.EtapaProceso.EtapaProcesoId == 8)
                            EnvioCorreoEntregaCliente(_listaConsultaOrdenTrabajoVistaDtOses);

                        //Envio de correo  cuando se anula  la orden
                        if (objetoHistorialProceso.EtapaProceso.EtapaProcesoId == 9)
                            EnvioCorreoAnulacion(_listaConsultaOrdenTrabajoVistaDtOses);

                        objetoHistorialProceso.SeEnvio = true;
                        _servicioDelegadoFlujoProceso.ActualizarHistorialProceso(objetoHistorialProceso);

                        ProcesoModelo proceso = new ProcesoModelo();
                        proceso.PuntoVentaId = objetoHistorialProceso.PuntoVentaId;
                        proceso.EtapaProceso = objetoHistorialProceso.EtapaProceso;
                        proceso.FechaEnvio = DateTime.Now;
                        proceso.Mensaje = "ENVIO EXITOSO";
                        proceso.NumeroOrden = objetoHistorialProceso.NumeroOrden;
                        proceso.SucursalId = objetoHistorialProceso.SucursalId;
                        proceso.SeEnvio = true;
                        _procesoTransformadorNegocio.GrabarProceso(proceso);
                    }
                    catch (Exception)
                    {


                        ProcesoModelo proceso = new ProcesoModelo();
                        proceso.PuntoVentaId = objetoHistorialProceso.PuntoVentaId;
                        proceso.EtapaProceso = objetoHistorialProceso.EtapaProceso;
                        proceso.FechaEnvio = DateTime.Now;
                        proceso.Mensaje = "ERROR EN EL ENVIO";
                        proceso.NumeroOrden = objetoHistorialProceso.NumeroOrden;
                        proceso.SucursalId = objetoHistorialProceso.SucursalId;
                        proceso.SeEnvio = true;
                        _procesoTransformadorNegocio.GrabarProceso(proceso);
                    }
                  

                }
            }



        }
        /// <summary>
        /// Envio de  correo cuando las  prendas  fueran  recibidos por el cliente
        /// </summary>
        /// <param name="_listaConsultaOrdenTrabajoVistaDtOses"></param>
        /// <param name="_lisaDetalleOrdenTrabajoVistaModelos"></param>
        public void EnvioCorreoEntregaFranquicia(List<ConsultaOrdenTrabajoDTOs> _listaConsultaOrdenTrabajoVistaDtOses, List<DetalleOrdenTrabajoModelo> _lisaDetalleOrdenTrabajoVistaModelos)
        {
            
                string cuerpo = "<html><p>Estimad@ " + _listaConsultaOrdenTrabajoVistaDtOses.Select(m => m.NombreCliente).FirstOrDefault() + " </p></br> <p>Adjunto el  detalle de la  Orden de Producción  N°  " + _listaConsultaOrdenTrabajoVistaDtOses.Select(m => m.NumeroOrden).FirstOrDefault() + "</p></br></br> <p>Saludos Cordiales</p><p>La Química</p></html>";
                string direccionArchivo = CreacionPdf(_listaConsultaOrdenTrabajoVistaDtOses, _lisaDetalleOrdenTrabajoVistaModelos);
                EnvioCorreo(_listaConsultaOrdenTrabajoVistaDtOses.Select(m => m.CorreoElectronico).FirstOrDefault(), cuerpo, direccionArchivo, _listaConsultaOrdenTrabajoVistaDtOses.Select(m => m.NumeroOrden).FirstOrDefault());

           
        }

        /// <summary>
        /// Envia  el correo cuando entregan la prenda 
        /// </summary>
        /// <param name="_listaConsultaOrdenTrabajoVistaDtOses"></param>
       
        public void EnvioCorreoAvisoRetiroPrenda(List<ConsultaOrdenTrabajoDTOs> _listaConsultaOrdenTrabajoVistaDtOses)
        {
           
                string cuerpo = "<html><p>Estimad@ " + _listaConsultaOrdenTrabajoVistaDtOses.Select(m => m.NombreCliente).FirstOrDefault() + " </p></br> <p>Las prendas correspondientes Orden de Producción N°   " + _listaConsultaOrdenTrabajoVistaDtOses.Select(m => m.NumeroOrden).FirstOrDefault() + "se encuentran en la sucursal, por  favor retirar</p></br></br> <p>Saludos Cordiales</p><p>La Química</p></html>";
                EnvioCorreo(_listaConsultaOrdenTrabajoVistaDtOses.Select(m => m.CorreoElectronico).FirstOrDefault(), cuerpo, String.Empty, _listaConsultaOrdenTrabajoVistaDtOses.Select(m => m.NumeroOrden).FirstOrDefault());
            
        }

        /// <summary>
        /// Cuando las prendas ya se encuentran en la franquicia
        /// </summary>
        /// <param name="_listaConsultaOrdenTrabajoVistaDtOses"></param>
        public void EnvioCorreoEntregaCliente(List<ConsultaOrdenTrabajoDTOs> _listaConsultaOrdenTrabajoVistaDtOses)
        {
            string cuerpo = "<html><p>Estimad@ " + _listaConsultaOrdenTrabajoVistaDtOses.Select(m => m.NombreCliente).FirstOrDefault() + " </p></br> <p>Se entrego a conformidad  al cliente la Orden de Producción N°  " + _listaConsultaOrdenTrabajoVistaDtOses.Select(m => m.NumeroOrden).FirstOrDefault() + "</p></br></br> <p>Saludos Cordiales</p><p>La Química</p></html>";
            EnvioCorreo(_listaConsultaOrdenTrabajoVistaDtOses.Select(m => m.CorreoElectronico).FirstOrDefault(), cuerpo, String.Empty, _listaConsultaOrdenTrabajoVistaDtOses.Select(m => m.NumeroOrden).FirstOrDefault());
        }

        /// <summary>
        /// Cuando se anulo la transaccion
        /// </summary>
        /// <param name="_listaConsultaOrdenTrabajoVistaDtOses"></param>
        public void EnvioCorreoAnulacion(List<ConsultaOrdenTrabajoDTOs> _listaConsultaOrdenTrabajoVistaDtOses)
        {
            string cuerpo = "<html><p>Estimad@ " + _listaConsultaOrdenTrabajoVistaDtOses.Select(m => m.NombreCliente).FirstOrDefault() + " </p></br> <p>Se ha procedido a la anulación de la  Orden de Producción N°  " + _listaConsultaOrdenTrabajoVistaDtOses.Select(m => m.NumeroOrden).FirstOrDefault() + "</p></br></br> <p>Saludos Cordiales</p><p>La Química</p></html>";
            EnvioCorreo(_listaConsultaOrdenTrabajoVistaDtOses.Select(m => m.CorreoElectronico).FirstOrDefault(), cuerpo, String.Empty, _listaConsultaOrdenTrabajoVistaDtOses.Select(m => m.NumeroOrden).FirstOrDefault());
        }

       

        

        public void EnvioCorreo(string correo,string cuerpo,string archivo,string numeroOrden)
        {
           
                #region ENVIO CORREO

                MailMessage mensaje = new MailMessage();
                mensaje.From = new MailAddress(WebConfigurationManager.AppSettings["Correo"].ToString(), WebConfigurationManager.AppSettings["Sujeto"].ToString(), System.Text.Encoding.UTF8);
                if(correo != string.Empty && Regex.IsMatch(correo, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)) == true)
                mensaje.To.Add(correo);
                mensaje.Subject = numeroOrden;
                mensaje.SubjectEncoding = System.Text.Encoding.UTF8;
                
               
                mensaje.Body = cuerpo;

                mensaje.BodyEncoding = System.Text.Encoding.UTF8;
                mensaje.IsBodyHtml = true;
                if (System.IO.File.Exists(archivo))
                    mensaje.Attachments.Add(new Attachment(archivo));
                SmtpClient client = new SmtpClient(WebConfigurationManager.AppSettings["Smtp"].ToString(),Convert.ToInt32(WebConfigurationManager.AppSettings["Puerto"]));
                client.Credentials = new System.Net.NetworkCredential(WebConfigurationManager.AppSettings["Correo"].ToString(), WebConfigurationManager.AppSettings["Contrasena"].ToString());
                client.EnableSsl = true;
                client.Send(mensaje);
                //if (System.IO.File.Exists(path + "\\" + dt.Rows[i][4].ToString() + ".pdf"))
                //{
                   // System.IO.File.Delete(pathPDF + ".pdf");
                //}
              


                #endregion
           
        }


        /// <summary>
        /// Crea  el pdf para el adjunto de la orden
        /// </summary>
        /// <param name="_listaConsultaOrdenTrabajoVistaDtOses"></param>
        /// <param name="_lisaDetalleOrdenTrabajoVistaModelos"></param>
        /// <returns></returns>
        public string CreacionPdf(List<ConsultaOrdenTrabajoDTOs> _listaConsultaOrdenTrabajoVistaDtOses, List<DetalleOrdenTrabajoModelo> _lisaDetalleOrdenTrabajoVistaModelos)
        {
           
                
               
                string pathPDF = WebConfigurationManager.AppSettings["PathArchivo"].ToString()+ _listaConsultaOrdenTrabajoVistaDtOses.Select(m => m.NombrePuntoVenta).FirstOrDefault() + "_"+ _listaConsultaOrdenTrabajoVistaDtOses.Select(m=>m.NumeroOrden).FirstOrDefault()+"_"+ _listaConsultaOrdenTrabajoVistaDtOses.Select(m => m.NombreCliente).FirstOrDefault() +  ".pdf";
               
                Document document = new Document();
                PdfWriter.GetInstance(document, new FileStream(pathPDF, FileMode.Create));
                document.Open();
                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(WebConfigurationManager.AppSettings["PathImagen"].ToString());
                document.Add(image);

                Paragraph numeroOrden = new Paragraph();
                numeroOrden.Font = FontFactory.GetFont("Arial", 10);
                numeroOrden.Add("Orden Producción Numero: " + _listaConsultaOrdenTrabajoVistaDtOses.Select(m => m.NumeroOrden).FirstOrDefault());
                document.Add(numeroOrden);

                Paragraph fechaIngreso = new Paragraph();
                fechaIngreso.Font = FontFactory.GetFont("Arial", 10);
                fechaIngreso.Add("Fecha: " + _listaConsultaOrdenTrabajoVistaDtOses.Select(m => m.FechaIngreso).FirstOrDefault());
                document.Add(fechaIngreso);

                Paragraph fechaEntrega = new Paragraph();
                fechaEntrega.Font = FontFactory.GetFont("Arial", 10);
                fechaEntrega.Add("Fecha de Entrega: " + _listaConsultaOrdenTrabajoVistaDtOses.Select(m => m.FechaEntrega).FirstOrDefault());
                document.Add(fechaEntrega);

                Paragraph sucursal = new Paragraph();
                sucursal.Font = FontFactory.GetFont("Arial", 10);
                sucursal.Add("Sucursal: " + _listaConsultaOrdenTrabajoVistaDtOses.Select(m => m.NombrePuntoVenta).FirstOrDefault());
                document.Add(sucursal);

                Paragraph cliente = new Paragraph();
                cliente.Font = FontFactory.GetFont("Arial", 10);
                cliente.Add("Cliente: " + _listaConsultaOrdenTrabajoVistaDtOses.Select(m => m.NombreCliente).FirstOrDefault());
                document.Add(cliente);

                Paragraph direccion = new Paragraph();
                direccion.Font = FontFactory.GetFont("Arial", 10);
                direccion.Add("Dirección: " + _listaConsultaOrdenTrabajoVistaDtOses.Select(m => m.Direccion).FirstOrDefault());
                document.Add(direccion);

                Paragraph telefono = new Paragraph();
                telefono.Font = FontFactory.GetFont("Arial", 10);
                telefono.Add("Teléfono: " + _listaConsultaOrdenTrabajoVistaDtOses.Select(m => m.Telefono).FirstOrDefault());
                document.Add(telefono);

                Paragraph usuarioElaborador = new Paragraph();
                usuarioElaborador.Font = FontFactory.GetFont("Arial", 10);
                usuarioElaborador.Add("Usuario Elaborador: " + _listaConsultaOrdenTrabajoVistaDtOses.Select(m => m.NombreUsuario).FirstOrDefault());
                document.Add(usuarioElaborador);


                document.Add(new Paragraph("\n"));

                PdfPTable table = new PdfPTable(7);
                // table.WidthPercentage = 80;
                //table.LockedWidth = true;
                //float[] widths = new float[] { .8f, .8f, .8f, .8f, .8f, .8f, .8f};
                // table.SetWidths(widths);
                PdfPCell CeldaPDF = new PdfPCell(new Paragraph("Prenda", FontFactory.GetFont("Calibri")));
                CeldaPDF.Border = 0;
                //table.HeaderRows(new TableHeaderRow("sadsadasdas"));
                table.AddCell(CeldaPDF);
                table.AddCell(new PdfPCell(new Paragraph("Marca")));
                table.AddCell(new PdfPCell(new Paragraph("Color")));
                table.AddCell(new PdfPCell(new Paragraph("Información Visual")));
                table.AddCell(new PdfPCell(new Paragraph("Numero Interno Prenda")));
                table.AddCell(new PdfPCell(new Paragraph("Tratamiento Especial")));
                table.AddCell(new PdfPCell(new Paragraph("Estado Prenda")));

                foreach (var objetoDTO in _listaConsultaOrdenTrabajoVistaDtOses)
                {
                    
                    table.AddCell(new Paragraph(objetoDTO.Prenda));
                    table.AddCell(new Paragraph(objetoDTO.Marca));
                    table.AddCell(new Paragraph(objetoDTO.Color));
                    table.AddCell(new Paragraph(objetoDTO.InformacionVisual));
                    table.AddCell(new Paragraph(objetoDTO.NumeroInternoPrenda));
                    table.AddCell(new Paragraph(objetoDTO.TratamientoEspecial));
                    table.AddCell(new Paragraph(objetoDTO.EstadoPrenda));
                    

                }
                document.Add(table);
                document.Add(new Paragraph("\n"));
                PdfPTable precios = new PdfPTable(5);
                //table.HeaderRows(new TableHeaderRow("sadsadasdas"));
                precios.AddCell(new PdfPCell(new Paragraph("Cantidad")));
                precios.AddCell(new PdfPCell(new Paragraph("Valor Unitario")));
                precios.AddCell(new PdfPCell(new Paragraph("Valor Total")));
                precios.AddCell(new PdfPCell(new Paragraph("Valor de Descuento")));
                precios.AddCell(new PdfPCell(new Paragraph("Valor Total")));


                foreach (var objetoDetalleOrdenTrabajo in _lisaDetalleOrdenTrabajoVistaModelos)
                {
                    
                    precios.AddCell(new Paragraph(objetoDetalleOrdenTrabajo.Cantidad.ToString()));
                    precios.AddCell(new Paragraph(String.Format("{0:0.00}", objetoDetalleOrdenTrabajo.ValorUnitario)));
                    precios.AddCell(new Paragraph(String.Format("{0:0.00}", objetoDetalleOrdenTrabajo.ValorTotalUnitario)));
                    precios.AddCell(new Paragraph(String.Format("{0:0.00}", objetoDetalleOrdenTrabajo.ValorDescuento)));
                    precios.AddCell(new Paragraph(String.Format("{0:0.00}", objetoDetalleOrdenTrabajo.ValorTotal)));


                }
                document.Add(precios);

                Paragraph piePagina = new Paragraph();
                piePagina.Font = FontFactory.GetFont("Arial", 6);
                piePagina.Add(@"Nota.- La Química no se hace responsable de objetos olvidados en las prendas, decoloramiento, perdida de color, perdida de botones, desprendimiento de esponja o daño de materiales sintéticos. Se reconoce por pérdida o destrucción hasta cinco veces el costo del lavado. Una vez retirada la prenda no se aceptan reclamos.
                                La Química no se hace responsable por la garantía del lavado de las prendas retiradas en un periodo mayor a 60 días a partir de la fecha acordada de retiro por parte del cliente, ya que la calidad del lavado puede verse afectada por manipulación o almacenamiento por periodos largos. Acepto todas las condiciones incluidas en esta nota.");
                document.Add(piePagina);
                document.Close();
                return pathPDF;
          
            
        }


    }
}