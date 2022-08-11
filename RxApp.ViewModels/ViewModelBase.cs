using ReactiveUI;
using Sextant;
using Splat;

namespace ViewModels
{
    public abstract class ViewModelBase : ReactiveObject, IViewModel
    {
        public abstract string Id { get; }
    
        protected readonly IViewStackService ViewStackService;

        protected ViewModelBase()
        {
            this.ViewStackService = Locator.Current.GetService<IViewStackService>()!;
        }
    }
}