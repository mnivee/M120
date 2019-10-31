﻿using System;
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
    /// Interaktionslogik für HomeButtons.xaml
    /// </summary>
    public partial class HomeButtons : UserControl
    {
        private ScrollViewer placeholder;
        public HomeButtons(ScrollViewer placeholder)
        {
            InitializeComponent();
            this.placeholder = placeholder;

        }

        private void NutzerErfassen(object sender, RoutedEventArgs e)
        {
            NutzerErstellenLeer leereEintrag = new NutzerErstellenLeer(placeholder);
            placeholder.Content = leereEintrag;
        }
        

    }
}
