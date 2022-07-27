namespace CVinRV;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();

		if (BindingContext is ViewModel vm)
		{
			vm.RefreshCommand?.Execute(null);
		}
	}
}

