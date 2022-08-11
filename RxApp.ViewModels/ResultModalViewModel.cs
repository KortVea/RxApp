using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using ReactiveUI;
using Sextant;

namespace ViewModels
{
    public class ResultModalViewModel : ViewModelBase
    {
        public override string Id => nameof(ResultModalViewModel);

        public ResultModalViewModel(IViewStackService viewStackService, IScheduler mainScheduler, IScheduler backgroundScheduler) : base(viewStackService)
        {
            this.TapCommand =
                ReactiveCommand
                    .CreateFromObservable(
                        () => ViewStackService.PopPage(),
                        outputScheduler: mainScheduler);

            this
                .WhenActivated((CompositeDisposable d) =>
                {
                    
                });
            
        }
        
        public ReactiveCommand<Unit, Unit> TapCommand { get; set; }
    }
}