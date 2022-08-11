using System;
using RxApp.Common;
using RxApp.Views;
using Sextant;
using Sextant.XamForms;
using Splat;
using ViewModels;

namespace RxApp
{
    public class CompositionRoot
    {
        private readonly Lazy<MainViewModel> mainViewModel;

        public App CreateApp() => new App(this.mainViewModel.Value);

        protected CompositionRoot()
        {
            this.MvvmRegister();
            
            this.mainViewModel = new Lazy<MainViewModel>(this.CreateMainViewModel);
            
        }

        private MainViewModel CreateMainViewModel() => new MainViewModel();

        private void MvvmRegister()
        {
            ReactiveUI.RxApp.DefaultExceptionHandler = new SextantDefaultExceptionHandler();
            
            Sextant.Sextant.Instance.InitializeForms();
            
            Locator
                .CurrentMutable
                .RegisterViewForNavigation(() => new MainView(), this.CreateMainViewModel)
                .RegisterNavigationView(() => new AppNavigationView());
        }
    }
}