using System;
using System.Reactive.Concurrency;
using System.Reflection;
using System.Threading;
using ReactiveUI;
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
        private readonly Lazy<IScheduler> mainScheduler;
        private readonly Lazy<IScheduler> backgroundScheduler;
        private readonly Lazy<MainViewModel> mainViewModel;
        
        private IViewStackService viewStackService => Locator.Current.GetService<IViewStackService>()!;

        public App CreateApp() => new App(this.mainViewModel.Value);

        protected CompositionRoot()
        {
            this.MvvmRegister();
            this.mainScheduler = new Lazy<IScheduler>(this.CreateMainScheduler);
            this.backgroundScheduler = new Lazy<IScheduler>(this.CreateBackgroundScheduler);
            this.mainViewModel = new Lazy<MainViewModel>(this.CreateMainViewModel);
        }

        private MainViewModel CreateMainViewModel() => new MainViewModel(this.viewStackService, this.mainScheduler.Value);
        private ResultModalViewModel CreateResultModalViewModel() => new ResultModalViewModel(this.viewStackService, this.mainScheduler.Value, this.backgroundScheduler.Value);
        private IScheduler CreateMainScheduler() => new SynchronizationContextScheduler(SynchronizationContext.Current);
        private IScheduler CreateBackgroundScheduler() => new EventLoopScheduler();
        
        private void MvvmRegister()
        {
            ReactiveUI.RxApp.DefaultExceptionHandler = new SextantDefaultExceptionHandler();
            
            Sextant.Sextant.Instance.InitializeForms();
            
            Locator
                .CurrentMutable
                .RegisterViewForNavigation(() => new MainView(), this.CreateMainViewModel)
                .RegisterNavigationView(() => new AppNavigationView())
                .RegisterViewModel(this.CreateResultModalViewModel)
                .RegisterViewsForViewModels(Assembly.GetExecutingAssembly());
        }
    }
}