using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Controls;

namespace Hmadrigal.WpfToolkit
{
    [TemplatePart(Name = PressedStoryboardPartName, Type = typeof(Storyboard))]
    public class QuertyKeyboardButton : Button
    {

        #region PressedStoryboard Template Part
        private const string PressedStoryboardPartName = "PressedStoryboard";
        private Storyboard PressedStoryboardPart;
        #endregion

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            PressedStoryboardPart = this.GetTemplateChild(PressedStoryboardPartName) as Storyboard;
        }

        protected override void OnMouseDown(System.Windows.Input.MouseButtonEventArgs e)
        {
            TryPlayPressedStoryboard();
            base.OnMouseDown(e);
        }

        private void TryPlayPressedStoryboard()
        {
            if (PressedStoryboardPart != null)
            {
                PressedStoryboardPart.Begin();
            }
        }


    }
}
