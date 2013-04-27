using System;
using System.Collections.ObjectModel;
using WhatIf.Library;
using Windows.UI.ApplicationSettings;
using Windows.UI.Popups;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WhatIf
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            DataContext = new ObservableCollection<Result>();
            InitializeComponent();
            SettingsPane.GetForCurrentView().CommandsRequested += OnCommandsRequested;
        }

        private static void OnCommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
        {
            args.Request.ApplicationCommands.Add(new SettingsCommand("Privacy Policy", "Privacy Policy", ShowPrivacyPolicy));
        }

        private static async void ShowPrivacyPolicy(IUICommand command)
        {
            await new MessageDialog("No data whatsoever will ever be collected! Nothing, nada, jack, zip, zilch!", "Privacy Policy").ShowAsync();
        }

        /// <summary>
        ///     Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">
        ///     Event data that describes how this page was reached.  The Parameter
        ///     property is typically used to configure the page.
        /// </param>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            if (App.HasInternet() == false)
            {
                var messageDialog = new MessageDialog("No internet connection was found. Please check your internet connection and reload the application.");
                await messageDialog.ShowAsync();
                return;
            }

            var tweets = new TweetsCollection();
            DataContext = tweets;
            LoadMoreItemsResult result = await tweets.LoadMoreItemsAsync(20);
        }
    }
}