using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using ReactiveUI;
using Xamarin.Forms;

namespace RxApp.Views
{
    public partial class MainView
    {
        public MainView()
        {
            InitializeComponent();
            
            this.WhenActivated(d =>
            {
                this.Title = "Page 1";    
                
                Observable
                    .FromEventPattern<TextChangedEventArgs>(
                        h => this.Entry.TextChanged += h,
                        h => this.Entry.TextChanged -= h)
                    .Select(arg => arg.EventArgs.NewTextValue)
                    .BindTo(this.ViewModel, vm => vm.EntryValue)
                    .DisposeWith(d);

                this
                    .Bind(this.ViewModel, vm => vm.SliderValue, v => v.Slider.Value)
                    .DisposeWith(d);

                this
                    .Bind(this.ViewModel, vm => vm.SwitchValue, v => v.Switch.IsToggled)
                    .DisposeWith(d);

                Observable
                    .FromEventPattern(
                        h => this.Button.Clicked += h,
                        h => this.Button.Clicked -= h)
                    .Select(_ => Unit.Default)
                    .InvokeCommand(this.ViewModel, vm => vm.ButtonClickedCommand)
                    .DisposeWith(d);

                this
                    .OneWayBind(this.ViewModel, vm => vm.CommandRecords, v => v.Records.ItemsSource)
                    .DisposeWith(d);
            });
        }
    }
}