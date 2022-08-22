using System;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using ReactiveUI;
using Sextant;

namespace ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private double sliderValue = 0;
        private string entryValue = string.Empty;
        
        public MainViewModel(IViewStackService viewStackService, IScheduler mainScheduler) : base(viewStackService)
        {
            this
                .WhenAnyValue(x => x.SliderValue)
                .Throttle(TimeSpan.FromSeconds(0.5))
                .Subscribe(Console.WriteLine);

            this
                .WhenAnyValue(x => x.EntryValue)
                .Subscribe(Console.WriteLine);
            
            

            this.ButtonClickedCommand =
                ReactiveCommand
                    .CreateFromObservable(
                        execute: () => ViewStackService.PushPage<ResultModalViewModel>(), 
                        canExecute: Observable.Return(true),
                        outputScheduler: mainScheduler);
            
        }        
        
        public override string Id => nameof(MainViewModel);
        
        public ReactiveCommand<Unit, Unit> ButtonClickedCommand { get; set; }

        public double SliderValue
        {
            get => this.sliderValue;
            set => this.RaiseAndSetIfChanged(ref this.sliderValue, value);
        }
        
        public string EntryValue
        {
            get => this.entryValue;
            set => this.RaiseAndSetIfChanged(ref this.entryValue, value);
        }
    }
}