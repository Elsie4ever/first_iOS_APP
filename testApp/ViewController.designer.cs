﻿// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace testApp
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton CallButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField PhoneNumberText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton TranslateButton { get; set; }

        [Action ("CallButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void CallButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("TranslateButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void TranslateButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (CallButton != null) {
                CallButton.Dispose ();
                CallButton = null;
            }

            if (PhoneNumberText != null) {
                PhoneNumberText.Dispose ();
                PhoneNumberText = null;
            }

            if (TranslateButton != null) {
                TranslateButton.Dispose ();
                TranslateButton = null;
            }
        }
    }
}