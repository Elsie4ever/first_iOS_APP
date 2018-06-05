using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace testApp
{
    public partial class ViewController : UIViewController
    {
        public List<string> PhoneNumbers { get; set; }
        string translatedNumber = "";
        public ViewController(IntPtr handle) : base(handle)
        {
            PhoneNumbers = new List<string>();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            //string translatedNumber = "";
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
                PhoneNumbers.Add(translatedNumber);
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

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);
            var callHistoryController = segue.DestinationViewController as CallHistoryController;
            if(callHistoryController != null){
                callHistoryController.PhoneNumbers = PhoneNumbers;
            }
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

        partial void CallHistoryButton_TouchUpInside(UIButton sender)
        {
        }

    }
}