﻿using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using System;

namespace NewApp
{
	[Activity(Label = "NewApp", MainLauncher = true, Icon = "@mipmap/icon", Theme ="@style/MyTheme")]
    public class MainActivity : AppCompatActivity
    {
        int count = 1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
            // and attach an event to it
            



            var builder = new Android.Support.V7.App.AlertDialog.Builder(this);

            builder.SetTitle("Hello Dialog")
                   .SetMessage("This is Alert Message")
                   .SetPositiveButton("Yes", delegate { Console.WriteLine("Yes"); })
                   .SetNegativeButton("No", delegate  { Console.WriteLine("No"); });


                    
        }
    }
}

