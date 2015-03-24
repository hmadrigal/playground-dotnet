using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace HubTileSampleApp.Controls
{
    [TemplateVisualState(GroupName = "ImageState", Name = "Semiexpanded")]
    [TemplateVisualState(GroupName = "ImageState", Name = "Flipped")]
    [TemplatePart(Name = "NotificationBlock", Type = typeof(TextBlock))]
    [TemplatePart(Name = "MessageBlock", Type = typeof(TextBlock))]
    [TemplatePart(Name = "BackTitleBlock", Type = typeof(TextBlock))]
    [TemplateVisualState(GroupName = "ImageState", Name = "Collapsed")]
    [TemplateVisualState(GroupName = "ImageState", Name = "Expanded")]
    public class HubTile : Control
    {
        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(ImageSource), typeof(HubTile), new PropertyMetadata((PropertyChangedCallback)null));
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(HubTile), new PropertyMetadata((object)string.Empty, new PropertyChangedCallback(HubTile.OnTitleChanged)));
        public static readonly DependencyProperty NotificationProperty = DependencyProperty.Register("Notification", typeof(string), typeof(HubTile), new PropertyMetadata((object)string.Empty, new PropertyChangedCallback(HubTile.OnBackContentChanged)));
        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register("Message", typeof(string), typeof(HubTile), new PropertyMetadata((object)string.Empty, new PropertyChangedCallback(HubTile.OnBackContentChanged)));
        public static readonly DependencyProperty DisplayNotificationProperty = DependencyProperty.Register("DisplayNotification", typeof(bool), typeof(HubTile), new PropertyMetadata((object)false, new PropertyChangedCallback(HubTile.OnBackContentChanged)));
        public static readonly DependencyProperty IsFrozenProperty = DependencyProperty.Register("IsFrozen", typeof(bool), typeof(HubTile), new PropertyMetadata((object)false, new PropertyChangedCallback(HubTile.OnIsFrozenChanged)));
        public static readonly DependencyProperty GroupTagProperty = DependencyProperty.Register("GroupTag", typeof(string), typeof(HubTile), new PropertyMetadata((object)string.Empty));
        private static readonly DependencyProperty StateProperty = DependencyProperty.Register("State", typeof(ImageState), typeof(HubTile), new PropertyMetadata((object)ImageState.Expanded, new PropertyChangedCallback(HubTile.OnImageStateChanged)));
        private const string ImageStates = "ImageState";
        private const string Expanded = "Expanded";
        private const string Semiexpanded = "Semiexpanded";
        private const string Collapsed = "Collapsed";
        private const string Flipped = "Flipped";
        private const string NotificationBlock = "NotificationBlock";
        private const string MessageBlock = "MessageBlock";
        private const string BackTitleBlock = "BackTitleBlock";
        private TextBlock _notificationBlock;
        private TextBlock _messageBlock;
        private TextBlock _backTitleBlock;
        internal int _stallingCounter;
        internal bool _canDrop;
        internal bool _canFlip;

        public ImageSource Source
        {
            get
            {
                return (ImageSource)this.GetValue(HubTile.SourceProperty);
            }
            set
            {
                this.SetValue(HubTile.SourceProperty, (object)value);
            }
        }

        public string Title
        {
            get
            {
                return (string)this.GetValue(HubTile.TitleProperty);
            }
            set
            {
                this.SetValue(HubTile.TitleProperty, (object)value);
            }
        }

        public string Notification
        {
            get
            {
                return (string)this.GetValue(HubTile.NotificationProperty);
            }
            set
            {
                this.SetValue(HubTile.NotificationProperty, (object)value);
            }
        }

        public string Message
        {
            get
            {
                return (string)this.GetValue(HubTile.MessageProperty);
            }
            set
            {
                this.SetValue(HubTile.MessageProperty, (object)value);
            }
        }

        public bool DisplayNotification
        {
            get
            {
                return (bool)this.GetValue(HubTile.DisplayNotificationProperty);
            }
            set
            {
                this.SetValue(HubTile.DisplayNotificationProperty, value);
            }
        }

        public bool IsFrozen
        {
            get
            {
                return (bool)this.GetValue(HubTile.IsFrozenProperty);
            }
            set
            {
                this.SetValue(HubTile.IsFrozenProperty, value);
            }
        }

        public string GroupTag
        {
            get
            {
                return (string)this.GetValue(HubTile.GroupTagProperty);
            }
            set
            {
                this.SetValue(HubTile.GroupTagProperty, (object)value);
            }
        }

        internal ImageState State
        {
            get
            {
                return (ImageState)this.GetValue(HubTile.StateProperty);
            }
            set
            {
                this.SetValue(HubTile.StateProperty, (object)value);
            }
        }

        static HubTile()
        {
        }

        public HubTile()
        {
            this.DefaultStyleKey = (object)typeof(HubTile);
            this.Loaded += new RoutedEventHandler(this.HubTile_Loaded);
            this.Unloaded += new RoutedEventHandler(this.HubTile_Unloaded);
        }

        private static void OnTitleChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            HubTile hubTile = (HubTile)obj;
            if (string.IsNullOrEmpty((string)e.NewValue))
            {
                hubTile._canDrop = false;
                hubTile.State = ImageState.Expanded;
            }
            else
                hubTile._canDrop = true;
        }

        private static void OnBackContentChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            HubTile hubTile = (HubTile)obj;
            if (!string.IsNullOrEmpty(hubTile.Notification) && hubTile.DisplayNotification || !string.IsNullOrEmpty(hubTile.Message) && !hubTile.DisplayNotification)
            {
                hubTile._canFlip = true;
            }
            else
            {
                hubTile._canFlip = false;
                hubTile.State = ImageState.Expanded;
            }
        }

        private static void OnIsFrozenChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            HubTile tile = (HubTile)obj;
            if ((bool)e.NewValue)
                HubTileService.FreezeHubTile(tile);
            else
                HubTileService.UnfreezeHubTile(tile);
        }

        private static void OnImageStateChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            ((HubTile)obj).UpdateVisualState();
        }

        private void UpdateVisualState()
        {
            string stateName;
            switch (this.State)
            {
                case ImageState.Expanded:
                    stateName = "Expanded";
                    break;
                case ImageState.Semiexpanded:
                    stateName = "Semiexpanded";
                    break;
                case ImageState.Collapsed:
                    stateName = "Collapsed";
                    break;
                case ImageState.Flipped:
                    stateName = "Flipped";
                    break;
                default:
                    stateName = "Expanded";
                    break;
            }
            VisualStateManager.GoToState((Control)this, stateName, true);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this._notificationBlock = this.GetTemplateChild("NotificationBlock") as TextBlock;
            this._messageBlock = this.GetTemplateChild("MessageBlock") as TextBlock;
            this._backTitleBlock = this.GetTemplateChild("BackTitleBlock") as TextBlock;
            if (this._notificationBlock != null)
                this._notificationBlock.SetBinding(UIElement.VisibilityProperty, new Binding()
                {
                    Source = (object)this,
                    //Path = new PropertyPath("DisplayNotification", new object[0]),
                    Path = new PropertyPath("DisplayNotification"),
                    Converter = (IValueConverter)new VisibilityConverter(),
                    ConverterParameter = (object)false
                });
            if (this._messageBlock != null)
                this._messageBlock.SetBinding(UIElement.VisibilityProperty, new Binding()
                {
                    Source = (object)this,
                    //Path = new PropertyPath("DisplayNotification", new object[0]),
                    Path = new PropertyPath("DisplayNotification"),
                    Converter = (IValueConverter)new VisibilityConverter(),
                    ConverterParameter = (object)true
                });
            if (this._backTitleBlock != null)
                this._backTitleBlock.SetBinding(TextBlock.TextProperty, new Binding()
                {
                    Source = (object)this,
                    //Path = new PropertyPath("Title", new object[0]),
                    Path = new PropertyPath("Title"),
                    Converter = (IValueConverter)new MultipleToSingleLineStringConverter()
                });
            this.UpdateVisualState();
        }

        private void HubTile_Loaded(object sender, RoutedEventArgs e)
        {
            HubTileService.InitializeReference(this);
        }

        private void HubTile_Unloaded(object sender, RoutedEventArgs e)
        {
            HubTileService.FinalizeReference(this);
        }
    }
}
