namespace LoL_Champions.Views.Parts;

public partial class RadioButtonClassView : StackLayout
{
	private string _image;
	public string Image
	{
		get => _image;
		set
		{
			_image = value;
			imageClass.Source = value;
		}
	}

	private string _text;
	public string Text
	{
		get => _text;
		set
		{
			_text = value;
			textClass.Text = value;
		}
	}

	public RadioButtonClassView()
	{
		InitializeComponent();
	}
}