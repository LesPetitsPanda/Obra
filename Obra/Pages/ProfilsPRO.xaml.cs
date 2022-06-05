using Microsoft.Win32;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Windows.PdfViewer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
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
    /// Logique d'interaction pour CVCreatorPage.xaml
    /// </summary>
    public partial class ProfilsPRO : Page
    {
        public ProfilsPRO()
        {
            InitializeComponent();
            ComboBoxSize.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            ComboBoxColor.ItemsSource = typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static);
                      ;

            ComboBoxFont.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
        }
        private void SettingsPart_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Pages/SettingsPro.xaml", UriKind.Relative));
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Pages/MainPagePro.xaml", UriKind.Relative));
        }
        private void Message_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Pages/MessageManager.xaml", UriKind.Relative));
        }
        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Pages/ProfilsPRO.xaml", UriKind.Relative));
        }
        private void Message(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Pages/MessageManager.xaml", UriKind.Relative));
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("You will loose all of your work, Are you Sure?", "Warning", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                rtb_editor.Document.Blocks.Clear();
            }
           
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "*.rtf";
            saveFileDialog.Filter = "RTF Files|*.rtf";
            Nullable<bool> myResult = saveFileDialog.ShowDialog();

            if (myResult == true)
            { 
                rtb_editor.SelectAll();
                rtb_editor.Selection.Save(new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate,FileAccess.Write ), DataFormats.Rtf);
            }
        }
        private void Load_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "c:\\";
            dlg.Filter = "RTF Files|*.rtf";
            dlg.RestoreDirectory = true;
            if(dlg.ShowDialog() == true)
            {
                rtb_editor.SelectAll();
                rtb_editor.Selection.Load(new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read), DataFormats.Rtf);
            }
        }
        private void Export_Click(object sender, RoutedEventArgs e)
        {
            rtb_editor.SelectAll();
            using (var stream = new FileStream("TempExport.rtf", FileMode.OpenOrCreate, FileAccess.Write)) {
                rtb_editor.Selection.Save(stream, DataFormats.Rtf);
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "*.pdf";
            saveFileDialog.Filter = "*.pdf|All Files (*.*)";
            if(saveFileDialog.ShowDialog() == true)
            {
                using (Syncfusion.DocIO.DLS.WordDocument wordDoc = new Syncfusion.DocIO.DLS.WordDocument("TempExport.rtf"))
                {
                    Syncfusion.DocToPDFConverter.DocToPDFConverter converter = new Syncfusion.DocToPDFConverter.DocToPDFConverter();
                    PdfDocument pdfDoc = converter.ConvertToPDF(wordDoc);
                    pdfDoc.Save(saveFileDialog.FileName);
                }
                File.Delete("TempExport.rtf");
            }
        }

        private void rtb_editor_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
        private void ComboBoxFont_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxFont.SelectedItem != null)
            {
                rtb_editor.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, ComboBoxFont.SelectedItem);
            }
        }

        private void ComboBoxColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextRange tr = new TextRange(rtb_editor.Selection.Start, rtb_editor.Selection.End);
            if (!tr.IsEmpty && ComboBoxColor.SelectedItem != null)
            {
                Color color = (Color)((PropertyInfo)ComboBoxColor.SelectedItem).GetValue(null, null);
                SolidColorBrush brush = new SolidColorBrush(color);
                tr.ApplyPropertyValue(TextElement.ForegroundProperty, brush);
            }
        }

        private void ComboBoxSize_SelectionChanged(object sender, TextChangedEventArgs e)
        {
            var TextRange = new TextRange(rtb_editor.Selection.Start, rtb_editor.Selection.End);
            TextRange.ApplyPropertyValue(Inline.FontSizeProperty, ComboBoxSize.Text);
        }

        private void Publish_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure you want to publish your CV ?", "Warning", MessageBoxButton.YesNo);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                
                using (var stream = new FileStream("TempExport.rtf", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    rtb_editor.SelectAll();
                    rtb_editor.Selection.Save(stream, DataFormats.Rtf);
                }
                using (Syncfusion.DocIO.DLS.WordDocument wordDoc = new Syncfusion.DocIO.DLS.WordDocument("TempExport.rtf"))
                {
                    PdfViewerControl pdfViewerControl = new();
                    
                        Syncfusion.DocToPDFConverter.DocToPDFConverter converter = new Syncfusion.DocToPDFConverter.DocToPDFConverter();
                        PdfDocument doc = converter.ConvertToPDF(wordDoc);
                        MemoryStream pdfGenerated = new MemoryStream();
                        doc.Form.Flatten = true;
                        doc.Save(pdfGenerated);
                        PdfLoadedDocument ldDoc = new PdfLoadedDocument(pdfGenerated);
                        pdfViewerControl.Load(ldDoc);
                        BitmapSource image = pdfViewerControl.ExportAsImage(0);
                        if (image != null)
                        {
                            BitmapEncoder encoder = new JpegBitmapEncoder();
                            encoder.Frames.Add(BitmapFrame.Create(image));
                            using (FileStream stream = new FileStream("tempo.jpg", FileMode.Create))
                            {
                                encoder.Save(stream);
                            }
                        }   
                }
                App.ProfileCV.SavePicture("tempo.jpg");
                File.Delete("TempExport.rtf");
            }
        }
    }
}
