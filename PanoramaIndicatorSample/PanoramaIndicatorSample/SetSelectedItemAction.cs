using Microsoft.Phone.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Interactivity;

namespace SamplePanoramaApp
{
    [TypeConstraint(typeof(Selector))]
    public class SetSelectedItemAction : TargetedTriggerAction<ItemsControl>
    {
        private Selector _selector;

        protected override void OnAttached()
        {
            base.OnAttached();

            _selector = AssociatedObject as Selector;
            if (_selector == null)
                return;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            if (_selector == null)
                return;
            _selector = null;
        }

        protected override void Invoke(object parameter)
        {
            if (_selector == null)
                return;

            if (Target is Panorama)
                InvokeOnPanorama(Target as Panorama);
            if (Target is Pivot)
                InvokeOnPivot(Target as Pivot);
            if (Target is Selector)
                InvokeOnSelector(Target as Selector);
        }

        private void InvokeOnSelector(Selector selector)
        {
            if (selector == null)
                return;
            selector.SelectedIndex = _selector.SelectedIndex;
        }

        private void InvokeOnPivot(Pivot pivot)
        {
            if (pivot == null)
                return;
            pivot.SelectedIndex = _selector.SelectedIndex;
        }

        private void InvokeOnPanorama(Panorama panorama)
        {
            if (panorama == null)
                return;
            panorama.DefaultItem = panorama.Items[_selector.SelectedIndex];
        }
    }
}
