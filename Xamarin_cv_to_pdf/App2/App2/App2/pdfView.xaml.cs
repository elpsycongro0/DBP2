using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class pdfView : ContentPage
	{
        SmtpClient SmtpServer;
		public MemoryStream pdfstream{get; }
        
        public pdfView (MemoryStream stream)
		{
            InitializeComponent();
            pdfstream = stream;
        }

        protected override void OnAppearing()
        {
            pdfViewerControl.InputFileStream = pdfstream;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                SmtpServer = new SmtpClient("smtp.gmail.com");
                SmtpServer.Port = 587;
                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("angeldeathfake@gmail.com", "pgjzowujjfvtwvkx");

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("angeldeathfake@gmail.com");
                mail.To.Add(email.Text);
                mail.Subject = "cv test";
                mail.Body = "hi";
                var contentType = new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Application.Pdf);
                pdfstream.Position = 0;
                Attachment attachment = new Attachment(pdfstream, contentType);
                attachment.ContentDisposition.FileName = "cv.pdf";

                mail.Attachments.Add(attachment);

                //SmtpServer.SendAsync("angeldeathfake@gmail.com", email.Text, "cv test", "hi", "xyz123d");
                SmtpServer.Send(mail);

                SmtpServer.SendCompleted += emailSendCompleted;

            }
            catch(Exception ex)
            {
                DisplayAlert("Failed", ex.Message, "OK");
            }
        }
        private void emailSendCompleted(Object sender, AsyncCompletedEventArgs e)
        {
            DisplayAlert("Message", "Correo enviado", "OK");
        }
    }
}