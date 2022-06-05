using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Obra.Pages
{
    /// <summary>
    /// Logique d'interaction pour FocusImage.xaml
    /// </summary>
    public partial class FocusImage : Page
    {
        private BitmapImage image;
        public BitmapImage Image
        {
            get { return image; }
            set { image = value; }
        }
        public FocusImage()
        {
            InitializeComponent();
            Loaded += FocusImage_Loaded;
        }

        private void FocusImage_Loaded(object sender, RoutedEventArgs e)
        {
            img.Source = image;
        }
    }
}
