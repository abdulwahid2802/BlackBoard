using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using System;
using Android.Content;
using Calligraphy;
using Android.Support.Design.Widget;
using Android.Runtime;
using Android.Views;
using Android.Views.InputMethods;
using static Android.Views.View;

namespace NewApp
{
	[Activity(Label = "NewApp", MainLauncher = true, Icon = "@mipmap/icon", Theme ="@style/MyTheme")]
    public class MainActivity : AppCompatActivity, TextView.IOnEditorActionListener, View.IOnTouchListener, IOnClickListener
	{

		TextInputEditText txtInputUserName;
		TextInputEditText txtInputPassWord;
		LinearLayout logPageMainLayout;
		TextView txtForgotPassword;



        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it

            
			var btnSignIn = FindViewById<Button>(Resource.Id.logPage_btn_singin);
			txtInputUserName = FindViewById<TextInputEditText>(Resource.Id.logPage_input_edittxt_username);
			txtInputPassWord = FindViewById<TextInputEditText>(Resource.Id.logPage_input_edittxt_pass);
			logPageMainLayout = FindViewById<LinearLayout>(Resource.Id.logPage_mainLayout);
			txtForgotPassword = FindViewById<TextView>(Resource.Id.logPage_txtForgotPass);

			logPageMainLayout.SetOnTouchListener(this);
			txtForgotPassword.SetOnClickListener(this);

			// ++++++ //
			txtInputUserName.ImeOptions = ImeAction.Next;
			txtInputPassWord.ImeOptions = ImeAction.Done;         
			txtInputUserName.SetOnEditorActionListener(this);
			txtInputPassWord.SetOnEditorActionListener(this);



            /*var builder = new Android.Support.V7.App.AlertDialog.Builder(this);

            builder.SetTitle("Hello Dialog")
                   .SetMessage("This is Alert Message")
                   .SetPositiveButton("Yes", delegate { Console.WriteLine("Yes"); })
                   .SetNegativeButton("No", delegate  { Console.WriteLine("No"); });
           

            btnSignIn.Click+=delegate {

				builder.Create().Show();

			};*/


                    
        }

		public bool OnEditorAction(TextView v, [GeneratedEnum] ImeAction actionId, KeyEvent e)
        {
            switch(actionId)
			{
				case ImeAction.Next:
					txtInputPassWord.RequestFocus();
					Console.WriteLine(actionId.ToString() + " ImeAction");
					break;

				case ImeAction.Done:
					// Hides the Keyboard
					Console.WriteLine(actionId.ToString() + " ImeAction");
					InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
					imm.HideSoftInputFromWindow(txtInputPassWord.WindowToken, Android.Views.InputMethods.HideSoftInputFlags.None);
					break;

			}

			return false;
        }

		public bool OnTouch(View v, MotionEvent e)
		{
            InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
            imm.HideSoftInputFromWindow(txtInputPassWord.WindowToken, Android.Views.InputMethods.HideSoftInputFlags.None);

			return false;
		}

		protected override void AttachBaseContext(Context newBase)
        {
            base.AttachBaseContext(CalligraphyContextWrapper.Wrap(newBase));
        }

		public void OnClick(View v)
		{
			int id = v.Id;

            switch(id)
			{
				case Resource.Id.logPage_txtForgotPass:
					v.Elevation = 20;
					break;
			}
		}
	}
}

