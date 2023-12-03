using BindingFail.Models;
using BindingFail.ViewModels.Base;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BindingFail.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        [ObservableProperty]
        ObservableCollection<Tag> models;



        public MainViewModel()
        {
            models = new ObservableCollection<Tag>
            {
                new Tag(){DisplayValue="Button1"},
                new Tag(){DisplayValue="Button2"},
                new Tag(){DisplayValue="Button3"},
                new Tag(){DisplayValue="Button4"},
                new Tag(){DisplayValue="Button5"},
            };
        }
        public override Task InitializeAsync()
        {
            return Task.CompletedTask;
        }


        [RelayCommand]
       async Task Test(Tag tag)
        {
            await Application.Current.MainPage.DisplayAlert("Title", tag.DisplayValue, "Ok").ConfigureAwait(false);
        }
    }
}
