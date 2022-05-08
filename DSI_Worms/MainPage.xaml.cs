using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace DSI_Worms
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            resources.Culture = new CultureInfo("en-US");
            this.InitializeComponent();
        }

        // Sale de la aplicación
        private void On_Exit(object sender, TappedRoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        // Navega al menú de configuración
        private void On_Settings(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Settings));
        }

        // Navega al menú de personalización
        private void On_Customization(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Customization));
        }

        // Navega a la pantalla de juego
        private void On_Play(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Game));
        }
    }
}
