
using Android.App;
using Android.OS;
using Android.Support.V7.App;

namespace NewApp
{
	[Activity(Label = "Home", Theme = "@style/MyTheme")]
	public class Home : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
			SetContentView(Resource.Layout.Home);

        }
    }
}
