using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using System.Collections.ObjectModel;
using ImageFromXamarinUI;
using Syncfusion.Drawing;
using System.IO;

namespace App2
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
		Dictionary<string, string> openWith;
		public string name { get; }
        public string date { get; }
        public string email { get; }
        public string nationality { get; }
        public string perfil { get; }

        private ObservableCollection<string> _idiomasListObsv = new ObservableCollection<string>();
        public ObservableCollection<string> IdiomasListObsv
        {
            get
            {
                return _idiomasListObsv;
            }
        }
        private ObservableCollection<string> _lenguajesProgListObsv = new ObservableCollection<string>();
        public ObservableCollection<string> LenguajesProgListObsv
        {
            get
            {
                return _lenguajesProgListObsv;
            }
        }
        private ObservableCollection<string> _experienciaProgListObsv = new ObservableCollection<string>();
        public ObservableCollection<string> ExperienciaProgListObsv
        {
            get
            {
                return _experienciaProgListObsv;
            }
        }

        public Page1 (Dictionary<string, string> _openWith, ObservableCollection<string> _idiomas, ObservableCollection<string> _lenguajesProg, ObservableCollection<string> _experiendia)
		{
			InitializeComponent ();
            var asString = string.Join(Environment.NewLine, _openWith);
            Console.WriteLine(asString);
            name = _openWith["name"];
            date = _openWith["date"].Substring(0, 10);
            nationality = _openWith["nationality"];
            email = _openWith["email"];
            perfil = _openWith["perfil"];
            _idiomasListObsv = new ObservableCollection<string>(_idiomas);
            _lenguajesProgListObsv = new ObservableCollection<string>(_lenguajesProg);
            _experienciaProgListObsv = new ObservableCollection<string>(_experiendia);

            this.BindingContext = this;
        }

        async void toPdfClicked(object sender, EventArgs e)
        {
            var imageStream = await root.CaptureImageAsync();
            //Creates a new PDF document
            PdfDocument document = new PdfDocument();
            //Adds page settings
            document.PageSettings.Orientation = PdfPageOrientation.Portrait;
            document.PageSettings.Margins.All = 0;
            //Adds a page to the document
            PdfPage page = document.Pages.Add();
            PdfGraphics graphics = page.Graphics;

            RectangleF bounds = new RectangleF(0, 0, 600, 800);
            PdfImage image = PdfImage.FromStream(imageStream);
            page.Graphics.DrawImage(image, bounds);

            MemoryStream stream = new MemoryStream();
            document.Save(stream);
            //Close the document.
            document.Close(true);

            //Save the stream as a file in the device and invoke it for viewing
            //pdfViewerControl.InputFileStream = stream;
            await Navigation.PushAsync(new pdfView(stream));

        }
    }
}