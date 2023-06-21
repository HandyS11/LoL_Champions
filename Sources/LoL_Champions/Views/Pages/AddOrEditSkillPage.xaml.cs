using LoL_Champions.ViewModels;

namespace LoL_Champions.Views.Pages;

public partial class AddOrEditSkillPage : ContentPage
{
    private AppVM AppVM => (Application.Current as App).AppVM;

    public AddOrEditSkillPage()
	{
		InitializeComponent();

		BindingContext = AppVM;
	}
}
