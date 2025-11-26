using AppMobileUrban.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;


namespace AppMobileUrban.Views
{
    public partial class PedidosPage : ContentPage
    {
        private PedidosViewModel viewModel;
        public PedidosPage()
        {
            InitializeComponent();
            viewModel = new PedidosViewModel(); 
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.CarregarPedidosAsync(); 
        }
    }
}