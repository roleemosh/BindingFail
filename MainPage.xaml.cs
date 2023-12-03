using BindingFail.ViewModels;

namespace BindingFail
{
    public partial class MainPage : ContentPage
    {
        public MainViewModel ViewModel { get; set; }
        public MainPage()
        {
            BindingContext = ViewModel = new MainViewModel();

            InitializeComponent();
        }
    }
}
