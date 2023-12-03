using CommunityToolkit.Mvvm.ComponentModel;

namespace BindingFail.ViewModels.Base
{
    public abstract partial class BaseViewModel : ObservableObject, IDisposable
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;

        [ObservableProperty]
        string title;

        private bool disposedValue;

        public bool IsNotBusy => !IsBusy;

        public BaseViewModel()
        {
            LoadAsync = new(async () =>
            {
                try
                {
                    IsBusy = true; // Start with IsBusy set to false

                    await Task.Run(InitializeAsync).ConfigureAwait(false); // Start the loading task
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    IsBusy = false;
                }
            });
        }

        public Lazy<Task> LoadAsync;

        public abstract Task InitializeAsync();

        #region Dispose

        public virtual void OnDispose()
        {

        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    OnDispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~BaseViewModel()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion Dispose
    }
}
