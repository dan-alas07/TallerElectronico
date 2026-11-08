using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using TallerElectronico.Entities;

namespace TallerElectronico.Desktop.Reportes
{
    public static class CorreoPdf
    {
        //configuracion de credenciales
        private const string CorreoEmisor = "soportetallerelectronico@gmail.com";
        private const string ClaveEmisor = "fyddkffwlvfjoxvq";

        //enviar la orden
        public static void EnviarOrdenPDF(string rutaPdf, ReparacionDTO rep)
        {
            //diseño de cuerpo correo
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(CorreoEmisor, "Taller Electrónico", Encoding.UTF8);
                mail.To.Add(rep.Correo);
                mail.ReplyToList.Add(new MailAddress(CorreoEmisor, "Taller Electrónico"));

                mail.Subject = $"Comprobante de Orden N° {rep.CodigoSeguimiento} - Taller Electrónico";
                mail.SubjectEncoding = Encoding.UTF8;
                mail.BodyEncoding = Encoding.UTF8;
                mail.Priority = MailPriority.Normal;

                mail.IsBodyHtml = true;
                mail.Body = $@"
                    <!DOCTYPE html>
                    <html>
                    <head>
                        <meta charset='utf-8'>
                        <style>
                            body {{ font-family: Arial, sans-serif; color: #333333; line-height: 1.5; margin: 0; padding: 0; }}
                            .wrapper {{ width: 100%; background-color: #f4f6f8; padding: 20px 0; }}
                            .container {{ max-width: 580px; margin: 0 auto; background-color: #ffffff; border: 1px solid #e2e8f0; border-radius: 6px; overflow: hidden; }}
                            .header {{ background-color: #1e293b; color: #ffffff; padding: 18px; text-align: center; }}
                            .content {{ padding: 24px; }}
                            .box {{ background-color: #f8fafc; border-left: 4px solid #1e293b; padding: 14px; margin: 18px 0; }}
                            .footer {{ font-size: 11px; color: #64748b; text-align: center; padding: 16px; background-color: #f1f5f9; }}
                        </style>
                    </head>
                    <body>
                        <div class='wrapper'>
                            <div class='container'>
                                <div class='header'>
                                    <h3 style='margin:0; font-size: 20px;'>Taller Electrónico</h3>
                                </div>
                                <div class='content'>
                                    <p>Estimado/a <strong>{rep.ClienteNombre}</strong>,</p>
                                    <p>Le compartimos el documento PDF con el detalle de su orden de servicio técnico.</p>
                
                                    <div class='box'>
                                        <p style='margin: 3px 0;'><strong>N° Orden:</strong> {rep.CodigoSeguimiento}</p>
                                        <p style='margin: 3px 0;'><strong>Equipo:</strong> {rep.EquipoCompleto}</p>
                                        <p style='margin: 3px 0;'><strong>Estado:</strong> {rep.EstadoNombre}</p>
                                        <p style='margin: 3px 0;'><strong>Total:</strong> $ {rep.TotalReparacion:N2}</p>
                                    </div>
                
                                    <p>Cualquier consulta sobre su equipo puede comunicarse al número <strong>+503 7550-8477</strong>.</p>
                                    <p>Atentamente,<br/><strong>Taller Electrónico</strong></p>
                                </div>
                                <div class='footer'>
                                    <p style='margin:0;'>Sonsonate, El Salvador | Tel: +503 7550-8477</p>
                                </div>
                            </div>
                        </div>
                    </body>
                    </html>";

                // Adjunto
                Attachment adjunto = new Attachment(rutaPdf, "application/pdf");
                mail.Attachments.Add(adjunto);

                //intento de que no sea de tipo spam
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(CorreoEmisor, ClaveEmisor);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
    }
}