using System;
using Android.App;
using Android.Runtime;
using Calligraphy;

namespace NewApp
{
	// Use this to override the entire app font and typeface
    [Application]
	public class Font:Application
    {
		
		public Font(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
        {
			
        }
        
		public override void OnCreate()
        {
            base.OnCreate();
            CalligraphyConfig.InitDefault(
              new CalligraphyConfig.Builder()
				.SetDefaultFontPath("DidactGothic_Regular.ttf")
                .SetFontAttrId(Resource.Attribute.fontPath)
                .Build()
            );
        }
    }
}
