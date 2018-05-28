using Foundation;
using System;

using UIKit;

namespace testApp
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            string translatedNumber = "";
            //Translate btn
            TranslateButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                translatedNumber = PhoneTranslator.ToNumber(PhoneNumberText.Text);
                //Dismiss the keyboard if text field was tapped
                PhoneNumberText.ResignFirstResponder();
                if (translatedNumber == "")
                {
                    CallButton.SetTitle("Call ", UIControlState.Normal);
                    CallButton.Enabled = false;
                }
                else
                {
                    CallButton.SetTitle("Call " + translatedNumber, UIControlState.Normal);
                    CallButton.Enabled = true;
                }
            };
            //Call btn
            CallButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                //Use URL handler with tel: prefix to invoke Apple's phone app...
                var url = new NSUrl("tel:"+translatedNumber);
                //otherwise show an alert dialog
                if (!UIApplication.SharedApplication.OpenUrl(url)) {
                    var alert = UIAlertController.Create("No supported", "Scheme 'tel:' is not supported on this device", UIAlertControllerStyle.Alert);
                    alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
                    PresentViewController(alert, true, null);
                }
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void CallButton_TouchUpInside(UIButton sender)
        {
        }

        partial void TranslateButton_TouchUpInside(UIButton sender)
        {
        }

    }
}