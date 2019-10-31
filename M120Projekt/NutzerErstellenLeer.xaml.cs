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

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für NutzerErstellenLeer.xaml
    /// </summary>
    public partial class NutzerErstellenLeer : UserControl
    {
        private ScrollViewer placeholder;
        public NutzerErstellenLeer(ScrollViewer placeholder)
        {

            InitializeComponent();
            this.placeholder = placeholder;
        }

        private void NutzerErfassen(object sender, RoutedEventArgs e)
        {
            NutzerErstellen formulareintrag = new NutzerErstellen(placeholder);
            placeholder.Content = formulareintrag;

        }
    }
}
