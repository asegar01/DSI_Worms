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
using Windows.Gaming.Input;
using Windows.System;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace DSI_Worms
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Settings : Page
    {

        public bool general;
        public bool video;
        public bool audio;

        public Settings()
        {
            this.InitializeComponent();
            general = true;
            General.IsChecked = true;

            VideoSettings.Visibility = Visibility.Collapsed;
            AudioSettings.Visibility = Visibility.Collapsed;

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            General.Focus(FocusState.Keyboard);
        }


        // Navega al menú de inicio
        private void On_Back(object sender, TappedRoutedEventArgs e)
        {
            if (Frame.CanGoBack) Frame.GoBack();
        }

        private void General_Checked(object sender, RoutedEventArgs e)
        {
            general = true;
            GeneralSettings.Visibility = Visibility.Visible;

            video = false;
            Video.IsChecked = false;
            VideoSettings.Visibility = Visibility.Collapsed;

            audio = false;
            Audio.IsChecked = false;
            AudioSettings.Visibility = Visibility.Collapsed;
        }

        private void Video_Checked(object sender, RoutedEventArgs e)
        {
            general = false;
            General.IsChecked = false;
            GeneralSettings.Visibility = Visibility.Collapsed;

            video = true;
            VideoSettings.Visibility = Visibility.Visible;

            audio = false;
            Audio.IsChecked = false;
            AudioSettings.Visibility = Visibility.Collapsed;
        }

        private void Audio_Checked(object sender, RoutedEventArgs e)
        {
            general = false;
            General.IsChecked = false;
            GeneralSettings.Visibility = Visibility.Collapsed;

            video = false;
            Video.IsChecked = false;
            VideoSettings.Visibility = Visibility.Collapsed;

            audio = true;
            AudioSettings.Visibility = Visibility.Visible;
        }

        private void Viewbox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            switch (e.Key) 
            {
                case VirtualKey.Escape: On_Back(null, null); break;
                case VirtualKey.GamepadB: On_Back(null, null); break;
                case VirtualKey.GamepadLeftShoulder:
                    if (general)
                    {
                        Audio.Focus(FocusState.Keyboard);
                        Audio.IsChecked = true; Audio_Checked(null, null);
                    }
                    else if (video)
                    {
                        General.Focus(FocusState.Keyboard);
                        General.IsChecked = true; General_Checked(null, null);
                    }
                    else
                    {
                        Video.Focus(FocusState.Keyboard);
                        Video.IsChecked = true; Video_Checked(null, null);
                    }
                    break;
                case VirtualKey.GamepadRightShoulder:
                    if (general)
                    {
                        Video.Focus(FocusState.Keyboard);
                        Video.IsChecked = true; Video_Checked(null, null);
                    }
                    else if (video)
                    {
                        Audio.Focus(FocusState.Keyboard);
                        Audio.IsChecked = true; Audio_Checked(null, null);
                    }
                    else
                    {
                        General.Focus(FocusState.Keyboard);
                        General.IsChecked = true; General_Checked(null, null);
                    }
                    break;
            }
        }
    }
}