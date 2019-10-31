using System.Windows;

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Aufruf diverse APIDemo Methoden
            //APIDemo.DemoACreate();
            //APIDemo.DemoACreateKurz();
            //APIDemo.DemoARead();
            //APIDemo.DemoAUpdate();
            //APIDemo.DemoARead();
            //APIDemo.DemoADelete();

            HomeButtons homeSeite = new HomeButtons(placeholder);
            placeholder.Content = homeSeite;
            placeholder.VerticalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Hidden;

        }

        private void BibliothekHomeseite_Loaded(object sender, RoutedEventArgs e)
        {
            HomeButtons homeSeite = new HomeButtons(placeholder);
            placeholder.Content = homeSeite;

        }

        private void NavNutzerErfasssen(object sender, RoutedEventArgs e)
        {
            NutzerErstellenLeer formularEintrag = new NutzerErstellenLeer(placeholder);
            placeholder.Content = formularEintrag;
        }

        private void NavBuecherErfassen(object sender, RoutedEventArgs e)
        {
            BuecherErfassen buecher = new BuecherErfassen(placeholder);
            placeholder.Content = buecher;
        }

        private void NavFaelligeAbgaben(object sender, RoutedEventArgs e)
        {
            FaelligeAbgaben abgaben = new FaelligeAbgaben(placeholder);
            placeholder.Content = abgaben;

        }

        private void NavEinstellungen(object sender, RoutedEventArgs e)
        {
            Einstellungen einstelllungen = new Einstellungen(placeholder);
            placeholder.Content = einstelllungen;

        }

    }
}
