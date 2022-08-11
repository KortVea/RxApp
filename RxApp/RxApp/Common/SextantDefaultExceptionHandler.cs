using System.Diagnostics;
using System.Reactive.Concurrency;
using System;

namespace RxApp.Common
{
    
    public class SextantDefaultExceptionHandler: IObserver<Exception>
    {
        public void OnNext(Exception ex)
        {
            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }

            ReactiveUI.RxApp.MainThreadScheduler.Schedule(() => throw ex);
        }

        public void OnError(Exception ex)
        {
            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }
            
            ReactiveUI.RxApp.MainThreadScheduler.Schedule(() => throw ex);
        }

        public void OnCompleted()
        {
            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }

            ReactiveUI.RxApp.MainThreadScheduler.Schedule(() => throw new NotImplementedException());
        }
    }
}

