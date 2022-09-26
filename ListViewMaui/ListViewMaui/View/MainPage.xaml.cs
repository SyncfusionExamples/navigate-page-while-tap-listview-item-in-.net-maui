
namespace ListViewMaui;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
        BindingContext = new ContactsViewModel(this.Navigation);
    }

}

