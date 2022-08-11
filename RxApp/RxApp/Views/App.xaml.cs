using System;
using Sextant;
using Sextant.XamForms;
using Splat;
using ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace RxApp.Views
{
    public partial class App : Application
    {
        public App(MainViewModel mainViewModel)
        {
            InitializeComponent();

            Locator
                .Current
                .GetService<IViewStackService>()!
                .PushPage(mainViewModel, null, true, false)
                .Subscribe();

            MainPage = Locator.Current.GetNavigationView();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}