using Leaf_Mobile.Views;
using Xamarin.Google.Crypto.Tink.Subtle;

namespace Leaf_Mobile
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			MainPage = new LoginPage();
		}
	}
}
