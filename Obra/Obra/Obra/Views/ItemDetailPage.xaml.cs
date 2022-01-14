using Obra.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Obra.Views
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