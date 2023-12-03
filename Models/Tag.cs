using CommunityToolkit.Mvvm.ComponentModel;

namespace BindingFail.Models
{
    public partial class Tag : ObservableObject
    {
        [ObservableProperty]
        bool isChecked;
        public string DisplayValue { get; set; }
    }
}
