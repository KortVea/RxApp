using System.Reactive.Disposables;
using System.Reactive.Linq;
using ReactiveMarbles.ObservableEvents;
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
                
                
            });
        }
    }
}