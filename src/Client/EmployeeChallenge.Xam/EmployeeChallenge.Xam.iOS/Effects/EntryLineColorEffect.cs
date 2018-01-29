
using EmployeeChallenge.Xam.iOS.Effects;
using Xamarin.Forms;

[assembly: ResolutionGroupName("EmployeeChallenge")]
[assembly: ExportEffect(typeof(EntryLineColorEffect), "EntryLineColorEffect")]
namespace EmployeeChallenge.Xam.iOS.Effects
{
    using System;
    using System.Linq;
    using UIKit;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.iOS;
    using System.ComponentModel;
    using CoreGraphics;
    using CoreAnimation;
    using EmployeeChallenge.Xam.UI.Behaviors;

    public class EntryLineColorEffect : PlatformEffect
    {
        UITextField control;

        protected override void OnAttached()
        {
            try
            {
                control = Control as UITextField;
                UpdateLineColor();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }

        protected override void OnDetached()
        {
            control = null;
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            if (args.PropertyName == LineColorBehavior.LineColorProperty.PropertyName ||
                args.PropertyName == "Height")
            {
                Initialize();
                UpdateLineColor();
            }
        }

        private void Initialize()
        {
            if (Element is Entry entry)
            {
                Control.Bounds = new CGRect(0, 0, entry.Width, entry.Height);
            }
        }

        private void UpdateLineColor()
        {
            BorderLineLayer lineLayer = control.Layer.Sublayers.OfType<BorderLineLayer>()
                                                             .FirstOrDefault();

            if (lineLayer == null)
            {
                lineLayer = new BorderLineLayer()
                {
                    MasksToBounds = true,
                    BorderWidth = 1.0f
                };
                control.Layer.AddSublayer(lineLayer);
                control.BorderStyle = UITextBorderStyle.None;
            }

            lineLayer.Frame = new CGRect(0f, Control.Frame.Height - 1f, Control.Bounds.Width, 1f);
            lineLayer.BorderColor = LineColorBehavior.GetLineColor(Element).ToCGColor();
            control.TintColor = control.TextColor;
        }

        private class BorderLineLayer : CALayer
        {
        }
    }
}