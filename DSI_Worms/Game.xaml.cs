using System;
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
    public sealed partial class Game : Page
    {
        public Game()
        {
            this.InitializeComponent();

            StorePage.Visibility = Visibility.Collapsed;

            Fuego.Visibility = Visibility.Visible;

            CuerpoaCuerpo.IsChecked = false;
            CaC.Visibility = Visibility.Collapsed;

            Explosivos.IsChecked = false;
            Explos.Visibility = Visibility.Collapsed;
        }

        private void Store_Tapped(object sender, TappedRoutedEventArgs e)
        {
            StorePage.Visibility = Visibility.Visible;
        }
        private void On_Back(object sender, TappedRoutedEventArgs e)
        {
            StorePage.Visibility = Visibility.Collapsed;
        }

        private void Defuego_Checked(object sender, RoutedEventArgs e)
        {
            Fuego.Visibility = Visibility.Visible;

            CuerpoaCuerpo.IsChecked = false;
            CaC.Visibility = Visibility.Collapsed;

            Explosivos.IsChecked = false;
            Explos.Visibility = Visibility.Collapsed;
        }

        private void CuerpoaCuerpo_Checked(object sender, RoutedEventArgs e)
        {
            Defuego.IsChecked = false;
            Fuego.Visibility = Visibility.Collapsed;

            CaC.Visibility = Visibility.Visible;

            Explosivos.IsChecked = false;
            Explos.Visibility = Visibility.Collapsed;
        }

        private void Explosivos_Checked(object sender, RoutedEventArgs e)
        {
            Defuego.IsChecked = false;
            Fuego.Visibility = Visibility.Collapsed;

            CuerpoaCuerpo.IsChecked = false;
            CaC.Visibility = Visibility.Collapsed;

            Explos.Visibility = Visibility.Visible;
        }
    }
}
