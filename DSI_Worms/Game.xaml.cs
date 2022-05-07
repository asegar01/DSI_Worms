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
using Windows.System;
using Windows.Gaming.Input;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace DSI_Worms
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    /// 


    public sealed partial class Game : Page
    {

        private int moving = 0;
        DispatcherTimer timer;

        public Game()
        {
            this.InitializeComponent();

            StorePage.Visibility = Visibility.Collapsed;

            FuegoButt.IsChecked = true;
            Fuego.Visibility = Visibility.Visible;

            CuerpoButt.IsChecked = false;
            CaC.Visibility = Visibility.Collapsed;

            ExplosivoButt.IsChecked = false;
            Explos.Visibility = Visibility.Collapsed;

            timer = new DispatcherTimer();
            timer.Tick += Update;
            timer.Interval = new TimeSpan(100000);
            timer.Start();
        }

        private void Store_Tapped(object sender, TappedRoutedEventArgs e)
        {
            StorePage.Visibility = Visibility.Visible;
            Pause.Visibility = Visibility.Collapsed;
        }
        private void On_Back(object sender, TappedRoutedEventArgs e)
        {
            StorePage.Visibility = Visibility.Collapsed;
            Pause.Visibility = Visibility.Visible;
        }

        private void Defuego_Checked(object sender, RoutedEventArgs e)
        {
            Fuego.Visibility = Visibility.Visible;

            CuerpoButt.IsChecked = false;
            CaC.Visibility = Visibility.Collapsed;

            ExplosivoButt.IsChecked = false;
            Explos.Visibility = Visibility.Collapsed;
        }

        private void CuerpoaCuerpo_Checked(object sender, RoutedEventArgs e)
        {
            FuegoButt.IsChecked = false;
            Fuego.Visibility = Visibility.Collapsed;

            CaC.Visibility = Visibility.Visible;

            ExplosivoButt.IsChecked = false;
            Explos.Visibility = Visibility.Collapsed;
        }

        private void Explosivos_Checked(object sender, RoutedEventArgs e)
        {
            FuegoButt.IsChecked = false;
            Fuego.Visibility = Visibility.Collapsed;

            CuerpoButt.IsChecked = false;
            CaC.Visibility = Visibility.Collapsed;

            Explos.Visibility = Visibility.Visible;
        }

        private void On_Pause(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(PauseMenu));
        }

        private void Store_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            switch (e.Key)
            {
                case VirtualKey.Escape: On_Back(null, null); break;
                case VirtualKey.GamepadB: On_Back(null, null); break;
                case VirtualKey.GamepadLeftShoulder:
                    if (FuegoButt.IsChecked.Value)
                    {
                        ExplosivoButt.Focus(FocusState.Keyboard);
                        ExplosivoButt.IsChecked = true; Explosivos_Checked(null, null);
                    }
                    else if (ExplosivoButt.IsChecked.Value)
                    {
                        CuerpoButt.Focus(FocusState.Keyboard);
                        CuerpoButt.IsChecked = true; CuerpoaCuerpo_Checked(null, null);
                    }
                    else
                    {
                        FuegoButt.Focus(FocusState.Keyboard);
                        FuegoButt.IsChecked = true; Defuego_Checked(null, null);
                    }
                    break;
                case VirtualKey.GamepadRightShoulder:
                    if (CuerpoButt.IsChecked.Value)
                    {
                        ExplosivoButt.Focus(FocusState.Keyboard);
                        ExplosivoButt.IsChecked = true; Explosivos_Checked(null, null);
                    }
                    else if (FuegoButt.IsChecked.Value)
                    {
                        CuerpoButt.Focus(FocusState.Keyboard);
                        CuerpoButt.IsChecked = true; CuerpoaCuerpo_Checked(null, null);
                    }
                    else
                    {
                        FuegoButt.Focus(FocusState.Keyboard);
                        FuegoButt.IsChecked = true; Defuego_Checked(null, null);
                    }
                    break;
            }
        }

        private void Update(object sender, object e)
        {
            Player.Translation = System.Numerics.Vector3.UnitX * (Player.Translation.X + moving);
        }

        private void Player_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            switch(e.Key)
            {
                case VirtualKey.A:
                case VirtualKey.Left:
                    moving = -1;
                    PlayerScale.ScaleX = 1;
                    break;
                case VirtualKey.D:
                case VirtualKey.Right:
                    moving = 1;
                    PlayerScale.ScaleX = -1;
                    break;
            }
        }

        private void Player_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            moving = 0;
        }

        private void MoveLeft(object sender, PointerRoutedEventArgs e)
        {
            moving = -1;
            PlayerScale.ScaleX = 1;
        }
        private void MoveRight(object sender, PointerRoutedEventArgs e)
        {
            moving = 1;
            PlayerScale.ScaleX = -1;
        }

        private void Image_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            moving = 0;
        }
    }
}
