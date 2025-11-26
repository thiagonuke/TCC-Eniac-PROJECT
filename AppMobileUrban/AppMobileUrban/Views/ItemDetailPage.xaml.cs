using AppMobileUrban.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AppMobileUrban.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}