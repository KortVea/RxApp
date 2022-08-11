using ReactiveUI;
using Sextant;

namespace ViewModels
{
    public abstract class ViewModelBase : ReactiveObject, IViewModel, IActivatableViewModel
    {
        public abstract string Id { get; }
    
        protected readonly IViewStackService ViewStackService;

        protected ViewModelBase(IViewStackService? viewStackService)
        {
            this.ViewStackService = viewStackService!;
        }

        public ViewModelActivator Activator => new ViewModelActivator();
    }
}