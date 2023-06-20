using LoL_Champions.ViewModels;

namespace LoL_Champions.Views.Pages;

public partial class AddOrEditSkinPage : ContentPage
{
    private AppVM AppVM => (Application.Current as App).AppVM;

    public AddOrEditSkinPage()
	{
		InitializeComponent();

        BindingContext = AppVM;
    }
}