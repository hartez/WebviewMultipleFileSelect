using Android.App;
using Android.Content;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Object = Java.Lang.Object;
using Uri = Android.Net.Uri;

namespace WebviewFileSelect.Platforms.Android
{
    public class MultiFileWebChromeClient(IWebViewHandler handler) : MauiWebChromeClient(handler)
	{
		protected override Object ParseResult(Result resultCode, Intent data)
		{
			if (resultCode == Result.Ok && data.ClipData != null)
			{
				// If the HTML file chooser has the "multiple" flag set, then the file URI data is in 
				// the ClipData property. The default result parsing in .NET MAUI doesn't handle this, so 
				// we'll do it here.

				var count = data.ClipData.ItemCount;
				var result = new Uri[count];

				for (int i = 0; i < count; i++)
				{
					result[i] = data.ClipData.GetItemAt(i).Uri;
				}

				return result;
			}

			return base.ParseResult(resultCode, data);
		}
	}
}
