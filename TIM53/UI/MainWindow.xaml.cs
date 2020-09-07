using Common.CommunicationBus;
using Common.Model;
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

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringToJSONConverter converter = new StringToJSONConverter();
            Zahtev z = converter.Convert(txt_box_request.Text);
            if(z == null)
            {
                MessageBox.Show("Molimo unesite ispravan zahtev.");
                return;
            }
            else
            {

            }
        }
    }
}
