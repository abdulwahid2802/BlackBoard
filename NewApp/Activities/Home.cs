
using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using static Android.Views.View;

namespace NewApp
{
	[Activity(Label = "Home",  Theme = "@style/MyTheme")]
	public class Home : AppCompatActivity, IOnClickListener
    {

		private Button home_btn_HW;
		private Button home_btn_LP;
		private Button home_btn_BB;
		private Button home_btn_SNS;
		private Button home_btn_N;
		private Button home_btn_MR;
        
		private CardView home_card_HW;
		private CardView home_card_LP;
		private CardView home_card_BB;
		private CardView home_card_SNS;
		private CardView home_card_N;
		private CardView home_card_MR;




        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Home);

			InitValues();         

        }

		private void InitValues()
		{
			home_btn_N = FindViewById<Button>(Resource.Id.home_btn_N);
			home_btn_SNS = FindViewById<Button>(Resource.Id.home_btn_SNS);
			home_btn_LP = FindViewById<Button>(Resource.Id.home_btn_LP);
			home_btn_MR = FindViewById<Button>(Resource.Id.home_btn_MR);
			home_btn_BB = FindViewById<Button>(Resource.Id.home_btn_BB);
			home_btn_HW = FindViewById<Button>(Resource.Id.home_btn_HW);

			home_card_N = FindViewById<CardView>(Resource.Id.home_card_N);
			home_card_SNS = FindViewById<CardView>(Resource.Id.home_card_SNS);
			home_card_LP = FindViewById<CardView>(Resource.Id.home_card_LP);
			home_card_MR = FindViewById<CardView>(Resource.Id.home_card_MR);
			home_card_BB = FindViewById<CardView>(Resource.Id.home_card_BB);
			home_card_HW = FindViewById<CardView>(Resource.Id.home_card_HW);

			home_btn_N.SetOnClickListener(this);
			home_btn_HW.SetOnClickListener(this);
			home_btn_LP.SetOnClickListener(this);
			home_btn_MR.SetOnClickListener(this);
			home_btn_BB.SetOnClickListener(this);
			home_btn_SNS.SetOnClickListener(this);

			home_card_N.SetOnClickListener(this);
			home_card_HW.SetOnClickListener(this);
			home_card_LP.SetOnClickListener(this);
			home_card_MR.SetOnClickListener(this);
			home_card_BB.SetOnClickListener(this);
			home_card_SNS.SetOnClickListener(this);   

		}

		public void OnClick(View v)
		{
			int id = v.Id;

			switch(id)
			{
				/*case Resource.Id.home_btn_N:
				case Resource.Id.home_btn_LP:
				case Resource.Id.home_btn_MR:
				case Resource.Id.home_btn_SNS:
				case Resource.Id.home_btn_BB:
				case Resource.Id.home_btn_HW:*/
				case Resource.Id.home_card_N:
				case Resource.Id.home_card_LP:
				case Resource.Id.home_card_MR:
				case Resource.Id.home_card_SNS:
				case Resource.Id.home_card_BB:
				case Resource.Id.home_card_HW:
                    v.Elevation = 0;               
					break;

			}
		}
    }
}
