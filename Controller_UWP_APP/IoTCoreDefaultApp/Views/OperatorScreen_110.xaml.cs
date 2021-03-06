﻿using IoTCoreDefaultApp.Utils;
using System;
using System.Globalization;
using Windows.Networking.Connectivity;
using Windows.Storage;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace IoTCoreDefaultApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OperatorScreen_110 : Page
    {
        private DispatcherTimer DateTimetimer;
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await UpdateDateTime();
            DateTimetimer = new DispatcherTimer();
            DateTimetimer.Tick += DateTime_Tick;
            DateTimetimer.Interval = TimeSpan.FromSeconds(5);
            DateTimetimer.Start();

            await Window.Current.Dispatcher.RunAsync(CoreDispatcherPriority.Low, () =>
            {
                LogoImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Logo.png"));
            });
        }
        protected override async void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            if (DateTimetimer.IsEnabled)
                DateTimetimer.Stop();
            DateTimetimer = null;
        }
        public OperatorScreen_110()
        {
            this.InitializeComponent();
        }

        private async void DateTime_Tick(object sender, object e)
        {
            await UpdateDateTime();
        }

        private async Task UpdateDateTime()
        {
            // Using DateTime.Now is simpler, but the time zone is cached. So, we use a native method insead.
            await Window.Current.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                SYSTEMTIME localTime;
                NativeTimeMethods.GetLocalTime(out localTime);
                DateTime t = localTime.ToDateTime();
                CurrentTime.Text = t.ToString("t", CultureInfo.CurrentCulture) + Environment.NewLine + t.ToString("d", CultureInfo.CurrentCulture);
            });
        }

        private async void LogoffButt_Click(object sender, RoutedEventArgs e)
        {
            await Window.Current.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                NavigationUtils.NavigateToScreen(typeof(LoginScreen_10));
            });
        }

        private async void ReportDamageButt_Click(object sender, RoutedEventArgs e)
        {
            await Window.Current.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                NavigationUtils.NavigateToScreen(typeof(ReportDamage_120));
            });
        }

        private async void ActiaveForkButt_Click(object sender, RoutedEventArgs e)
        {
            await Window.Current.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                NavigationUtils.NavigateToScreen(typeof(ActivateForkLift_121));
            });

        }

        private async void BackButton_Click(object sender, RoutedEventArgs e)
        {
            await Window.Current.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                NavigationUtils.NavigateToScreen(typeof(LogScreen_100));
            });
        }

        private async void PersonalButton_Click(object sender, RoutedEventArgs e)
        {
            await Window.Current.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                NavigationUtils.NavigateToScreen(typeof(PersonalInfo_122));
            });
        }
    }
}
