using DataBindingColeccion.Models;
using System.Collections.ObjectModel;
namespace DataBinding.Coleccion.Views;

public partial class MainPage : ContentPage
{
    public ObservableCollection<OrigenDePaquete> Origenes { get; }
    private OrigenDePaquete? _origenSeleccionado = null;
    private string? _nombreDelOrigen = string.Empty;
    private string? _rutaDelOrigen = string.Empty;
    public OrigenDePaquete? OrigenSeleccionado
    {
        get => _origenSeleccionado;
        set
        {
            if (_origenSeleccionado != value )
            {
                _origenSeleccionado = value;
                OnPropertyChanged(nameof(OrigenSeleccionado));
            }
             
        }

    }

    public string? NombreDelOrigen
    {
        get => _nombreDelOrigen;
        set
        {
            if (_nombreDelOrigen != value) 
            _nombreDelOrigen = value;
            OnPropertyChanged(nameof(NombreDelOrigen));
        }
    }

    public string? RutaDelOrigen
    {
        get => _rutaDelOrigen;
        set { 
        
            if (_rutaDelOrigen != value)
            {
                _rutaDelOrigen = value;
                OnPropertyChanged(nameof(RutaDelOrigen));
            }
        }
        }
    public MainPage()
    {

        InitializeComponent();
        OrigenSeleccionado = null;
        Origenes = new ObservableCollection<OrigenDePaquete>();
        CargarDatos();
        BindingContext = this;
        if (Origenes.Count > 0)
        {
            OrigenSeleccionado = Origenes[0];

        }
       
        //OrigenesListView.ItemsSource = _origenes;
        //OrigenesListView.SelectedItem = origenSeleccionado;
    }

    private void CargarDatos()
    {
        Origenes.Add(new OrigenDePaquete
        {
            Nombre = "nuget.org",
            Origen = "https://api.nuget.org/v3/index.json",
            estaHabilitado = true
        });

        Origenes.Add(new OrigenDePaquete
        {
            Nombre = "Microsoft Visual Studio Offline Packages",
            Origen = @"C:\Program Files (x86)\Microsoft SDKs\NuGetPackages",
            estaHabilitado = false
        });
    }

    private void OnAgregarButtonCliked(object sender, EventArgs e)
    {
        var origen = new OrigenDePaquete
        {
            Nombre = "Origen del paquete",
            Origen = "URL o ruta del origen del paquete",
            estaHabilitado = false
        };
        Origenes.Add(origen);
        OrigenSeleccionado = origen;
       
    }
       
    private void OnDeleteButtonCliked(object sender, EventArgs e)
    {
        //OrigenDePaquete seleccionado =
        //    (OrigenDePaquete)OrigenesListView.SelectedItem;
        //OrigenDePaquete seleccionado = null;
        if (OrigenSeleccionado != null)
        {
            var indice = Origenes.IndexOf(OrigenSeleccionado);
            OrigenDePaquete? nuevoSeleccionado;
            if (Origenes.Count > 1)
            {
                // Hay más de un elemento
                if (indice < Origenes.Count - 1)
                {
                    //El elemento seleccionado no es el último
                    nuevoSeleccionado = Origenes[indice + 1];
                }
                else
                {
                    //El elemento seleccionado es el último
                    nuevoSeleccionado = Origenes[indice - 1];
                }
            }
            else
            {
                // Sólo hay un elemento
                nuevoSeleccionado = null;
            }
            Origenes.Remove(OrigenSeleccionado);
            OrigenSeleccionado = nuevoSeleccionado;
        }
    }

    private void OrigenesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      
        if (OrigenSeleccionado != null)
        {
            NombreDelOrigen = OrigenSeleccionado.Nombre;
            RutaDelOrigen = OrigenSeleccionado.Origen;
        }
        else
        {
           NombreDelOrigen = string.Empty;
           RutaDelOrigen = string.Empty;
        }

    }
    private void OnActualizarButton_Cliked(object sender, EventArgs e)
    {
        if (OrigenSeleccionado != null)
        {
            OrigenSeleccionado.Nombre = NombreDelOrigen;
            OrigenSeleccionado.Origen = RutaDelOrigen;

        }
    }
}
