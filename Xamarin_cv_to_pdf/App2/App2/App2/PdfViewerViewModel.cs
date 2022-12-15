using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LoadPDFFromURL
{
    class PdfViewerViewModel : INotifyPropertyChanged
    {
        private Stream pdfDocumentStream;
        public event PropertyChangedEventHandler PropertyChanged;
        string URL = "https://www.syncfusion.com/downloads/support/directtrac/general/pd/GIS_Succinctly353717706.pdf";
        public Stream PdfDocumentStream
        {
            get { return pdfDocumentStream; }
            set
            {
                //Check the value whether it is the same as the currently loaded stream
                if (value != pdfDocumentStream)
                {
                    pdfDocumentStream = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("PdfDocumentStream"));
                }
            }
        }

        public PdfViewerViewModel()
        {
            SetStreamAsync();

        }

        private async void SetStreamAsync()
        {
            PdfDocumentStream = await DownloadPdfStream(URL);
        }

        private async Task<Stream> DownloadPdfStream(string URL)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(URL);
            //Check whether redirection is needed
            if((int)response.StatusCode == 302)
            {
                //The URL to redirect is in the header location of the response message
                HttpResponseMessage redirectedResponse = await httpClient.GetAsync(response.Headers.Location.AbsoluteUri);
                return await redirectedResponse.Content.ReadAsStreamAsync();
            }
            return await response.Content.ReadAsStreamAsync();
        }
    }
}
