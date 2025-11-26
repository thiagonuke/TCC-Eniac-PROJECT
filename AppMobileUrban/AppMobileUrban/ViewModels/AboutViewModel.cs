using System.Windows.Input;
using Xamarin.Forms;

namespace AppMobileUrban.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public bool IsAdmin { get; set; }

        public ICommand CadastrarProdutoCommand { get; }

        public AboutViewModel()
        {
            if (Application.Current.Properties.ContainsKey("Nome"))
            {
                Name = Application.Current.Properties["Nome"].ToString();
            }

            if (Application.Current.Properties.ContainsKey("Administrador"))
            {
                IsAdmin = (bool)Application.Current.Properties["Administrador"];
            }

            CadastrarProdutoCommand = new Command(OnCadastrarProduto);
        }

        private async void OnCadastrarProduto()
        {
            await Shell.Current.GoToAsync("CadastroProdutoPage");
        }
    }
}
