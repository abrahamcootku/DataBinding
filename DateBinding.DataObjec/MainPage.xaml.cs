using DateBinding.DataObjec.Models;

namespace DateBinding.DataObjec
{
    public partial class MainPage : ContentPage
    {
        //_conteo lleva el conteo de la aplicacion
        private Contador contador;

        public MainPage()
        {
            InitializeComponent();
            contador = new Contador();
            BindingContext = contador;
            //ConteoLabel.Text = contador.Conteo.ToString();
        }

        private void OnReiniciarButtonClicked(object sender, EventArgs e)
        {
            contador.Reiniciar();
           // ConteoLabel.Text = contador.Conteo.ToString();
        }

        private void OnLimpiarButtonClicked_1(object sender, EventArgs e)
        {
            contador.contar();
           // ConteoLabel.Text = contador.Conteo.ToString();
        }

    }
}
