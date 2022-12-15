using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace App2
{
    public partial class MainPage : ContentPage
    {
        public Command OnGenerateCv { get; }
        public Command OnSaveIdioma { get; }
        public Command OnSaveLenguajeProg { get; }
        public Command OnSaveExperiencia { get; }


        Dictionary<string, string> formdata = new Dictionary<string, string>();
        private string _name;
        public string SelectedName
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        
        private string _date;
        public string SelectedDate
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }
        private string _nationality;
        public string Nationality
        {
            get { return _nationality; }
            set
            {
                _nationality = value;
                OnPropertyChanged();
            }
        }
        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
        private string _idiomaEntry;
        public string IdiomaEntry
        {
            get { return _idiomaEntry; }
            set
            {
                _idiomaEntry = value;
                OnPropertyChanged();
            }
        }
        private string _idiomaEntryNivel;
        public string IdiomaEntryNivel
        {
            get { return _idiomaEntryNivel; }
            set
            {
                _idiomaEntryNivel = value;
                OnPropertyChanged();
            }
        }
        private string _lenguaje;
        public string Lenguaje
        {
            get { return _lenguaje; }
            set
            {
                _lenguaje = value;
                OnPropertyChanged();
            }
        }
        private string _cargo;
        public string Cargo
        {
            get { return _cargo; }
            set
            {
                _cargo = value;
                OnPropertyChanged();
            }
        }
        private string _lugar;
        public string Lugar
        {
            get { return _lugar; }
            set
            {
                _lugar = value;
                OnPropertyChanged();
            }
        }
        private string _periodo;
        public string Periodo
        {
            get { return _periodo; }
            set
            {
                _periodo = value;
                OnPropertyChanged();
            }
        }
        private string _perfil;
        public string Perfil
        {
            get { return _perfil; }
            set
            {
                _perfil = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<string> _namesListObsv = new ObservableCollection<string>();
        public ObservableCollection<string> NamesListObsv
        {
            get
            {
                return _namesListObsv;
            }
            set
            {
                if (_namesListObsv != value)
                {
                    _namesListObsv = value;
                    OnPropertyChanged();
                }
            }
        }
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
        public MainPage()
        {
            InitializeComponent();
            OnGenerateCv = new Command(ShowCV);
            OnSaveIdioma = new Command(SaveIdiomaEntry);
            OnSaveLenguajeProg = new Command(SaveLenguajeProg);
            OnSaveExperiencia = new Command(SaveExperiencia);
            _name = "";
            _date = "12/12/2000 00:00:00";
            _email = "";
            _nationality = "Peruano";
            _perfil = "";
            _namesListObsv.Add("Peruano");
            _namesListObsv.Add("Peruano p");
            this.BindingContext = this;
        }

        private async void ShowCV(object obj)
        {

            formdata["name"] = _name;
            formdata["date"] = _date;
            formdata["email"] = _email;
            formdata["nationality"] = _nationality;
            formdata["perfil"] = _perfil;


            await Navigation.PushAsync(new Page1(formdata, _idiomasListObsv, _lenguajesProgListObsv, _experienciaProgListObsv));
        }
        private void SaveIdiomaEntry(object obj)
        {
            _idiomasListObsv.Add(_idiomaEntry + ": " + _idiomaEntryNivel);
        }
        private void SaveLenguajeProg(object obj)
        {
            _lenguajesProgListObsv.Add(_lenguaje);
        }
        private void SaveExperiencia(object obj)
        {
            string text = _cargo + "@" + _lugar + "| " + _periodo;
            text = text.Replace("@", System.Environment.NewLine);
            _experienciaProgListObsv.Add(text);
        }
    }
}
