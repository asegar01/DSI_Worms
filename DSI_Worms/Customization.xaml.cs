﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace DSI_Worms
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Customization : Page
    {
        public Customization()
        {
            this.InitializeComponent();
        }

        // Navega al menú de inicio
        private void On_Back(object sender, TappedRoutedEventArgs e)
        {
            if (Frame.CanGoBack) Frame.GoBack();
        }

        private void Ropa_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Sombreros_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Camuflaje_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
