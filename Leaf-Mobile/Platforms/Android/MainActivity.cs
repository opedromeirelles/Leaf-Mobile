using Android.App;
using Android.Content.PM;
using Android.OS;

namespace Leaf_Mobile
{
	[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
	public class MainActivity : MauiAppCompatActivity
	{
		/*
		protected override void OnCreate(Bundle? savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Definir a cor da barra de status
			SetStatusBarColor(Android.Graphics.Color.ParseColor("#33752a")); // cor barra de tarefas
		}

		private void SetStatusBarColor(Android.Graphics.Color color)
		{
			if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
			{
				Window?.SetStatusBarColor(color);
			}
		}

		*/
	}

}
