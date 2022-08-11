using System;
using Sextant.XamForms;
using ReactiveUI;
using Xamarin.Forms;

namespace RxApp.Views
{
    public class AppNavigationView : NavigationView, IViewFor
    {
        public AppNavigationView()
            : base(ReactiveUI.RxApp.MainThreadScheduler, ReactiveUI.RxApp.TaskpoolScheduler, ViewLocator.Current)
        {
            BarBackgroundColor = Color.LightSeaGreen;
            BarTextColor = Color.White;
            Title = "Robot Game";
        }

        public object ViewModel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}

