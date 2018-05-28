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
using Firebase;
using Firebase.Auth;
using Android.Gms.Tasks;
using Java.Lang;
using Android.Views.Animations;

namespace NewApp
{
	[Activity(Label = "NewApp", MainLauncher = true, Icon = "@mipmap/icon", Theme ="@style/MyTheme")]
    public class MainActivity : AppCompatActivity, IOnFailureListener, IOnCompleteListener, TextView.IOnEditorActionListener, View.IOnTouchListener, IOnClickListener
	{

		TextInputEditText txtInputUserName;
		TextInputEditText txtInputPassWord;
		LinearLayout logPageMainLayout;
		RelativeLayout logPage_input_rLayout;
		Button btn_ForgotPassword;
		Button btn_SignIn;

		public static FirebaseApp app;
		FirebaseAuth auth;

        
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it

            
			InitFirebaseAuth();
            
			btn_SignIn = FindViewById<Button>(Resource.Id.logPage_btn_singin);
			txtInputUserName = FindViewById<TextInputEditText>(Resource.Id.logPage_input_edittxt_username);
			txtInputPassWord = FindViewById<TextInputEditText>(Resource.Id.logPage_input_edittxt_pass);
			logPageMainLayout = FindViewById<LinearLayout>(Resource.Id.logPage_mainLayout);
			btn_ForgotPassword = FindViewById<Button>(Resource.Id.logPage_btn_ForgotPass);
			logPage_input_rLayout = FindViewById<RelativeLayout>(Resource.Id.logPage_input_rLayout);



			logPageMainLayout.SetOnTouchListener(this);
			btn_ForgotPassword.SetOnClickListener(this);
			btn_SignIn.SetOnClickListener(this);

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

		private void InitFirebaseAuth()
		{
			var options = new FirebaseOptions.Builder()
			                             .SetApplicationId("1:354570866373:android:f9606ee43f877aa5")
			                             .SetApiKey("AIzaSyCbirgbUNGz5Qv5SuXqEgsfkFiK92yiR4o")
										 .Build();

			if (app == null)
				app = FirebaseApp.InitializeApp(this, options);

			auth = FirebaseAuth.GetInstance(app);
       
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
				case Resource.Id.logPage_btn_ForgotPass:
					StartActivity(new Android.Content.Intent(this, typeof(ForgotPassword)));
					break;
				case Resource.Id.logPage_btn_singin:
					LoginUser(txtInputUserName.Text, txtInputPassWord.Text);

					break;
			}

		}
        
		private void LoginUser(string userName, string userPass)
		{
			if (userName.Length < 6 || userPass.Length < 6)
				return;
			auth.SignInWithEmailAndPassword(userName, userPass)
			    .AddOnCompleteListener(this)
			    .AddOnFailureListener(this);
		}

		public void OnComplete(Task task)
		{
			if(task.IsSuccessful)
			{
				StartActivity(new Android.Content.Intent(this, typeof(Home)));
				Finish();
			}
			else
			{
				Snackbar snackbar = Snackbar.Make(logPageMainLayout, "LOGIN FAILED!", Snackbar.LengthShort);
				snackbar.Show();
			}

		}

		public void OnFailure(Java.Lang.Exception e)
		{
			//Snackbar.Make(logPage_input_rLayout, "LOGIN FAILED!", Snackbar.LengthShort).Show();
		}
	}
}

