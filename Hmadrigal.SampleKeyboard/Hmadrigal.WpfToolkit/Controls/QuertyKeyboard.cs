namespace Hmadrigal.WpfToolkit
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Input;
    using Hmadrigal.Services.VirtualKeyboard;

	[TemplatePart(Name = ElementLetterQName, Type = typeof(Button))]
	[TemplatePart(Name = ElementLetterWName, Type = typeof(Button))]
	[TemplatePart(Name = ElementLetterEName, Type = typeof(Button))]
	[TemplatePart(Name = ElementLetterRName, Type = typeof(Button))]
	[TemplatePart(Name = ElementLetterTName, Type = typeof(Button))]
	[TemplatePart(Name = ElementLetterYName, Type = typeof(Button))]
	[TemplatePart(Name = ElementLetterUName, Type = typeof(Button))]
	[TemplatePart(Name = ElementLetterIName, Type = typeof(Button))]
	[TemplatePart(Name = ElementLetterOName, Type = typeof(Button))]
	[TemplatePart(Name = ElementLetterPName, Type = typeof(Button))]
	[TemplatePart(Name = ElementLetterAName, Type = typeof(Button))]
	[TemplatePart(Name = ElementLetterSName, Type = typeof(Button))]
	[TemplatePart(Name = ElementLetterDName, Type = typeof(Button))]
	[TemplatePart(Name = ElementLetterFName, Type = typeof(Button))]
	[TemplatePart(Name = ElementLetterGName, Type = typeof(Button))]
	[TemplatePart(Name = ElementLetterHName, Type = typeof(Button))]
	[TemplatePart(Name = ElementLetterJName, Type = typeof(Button))]
	[TemplatePart(Name = ElementLetterKName, Type = typeof(Button))]
	[TemplatePart(Name = ElementLetterLName, Type = typeof(Button))]
	[TemplatePart(Name = ElementShiftKeyName, Type = typeof(Button))]
	[TemplatePart(Name = ElementLetterZName, Type = typeof(Button))]
	[TemplatePart(Name = ElementLetterXName, Type = typeof(Button))]
	[TemplatePart(Name = ElementLetterCName, Type = typeof(Button))]
	[TemplatePart(Name = ElementLetterVName, Type = typeof(Button))]
	[TemplatePart(Name = ElementLetterBName, Type = typeof(Button))]
	[TemplatePart(Name = ElementLetterNName, Type = typeof(Button))]
	[TemplatePart(Name = ElementLetterMName, Type = typeof(Button))]
	[TemplatePart(Name = ElementCurlyKeyName, Type = typeof(Button))]
	[TemplatePart(Name = ElementNumber1Name, Type = typeof(Button))]
	[TemplatePart(Name = ElementNumber2Name, Type = typeof(Button))]
	[TemplatePart(Name = ElementNumber3Name, Type = typeof(Button))]
	[TemplatePart(Name = ElementNumber4Name, Type = typeof(Button))]
	[TemplatePart(Name = ElementNumber5Name, Type = typeof(Button))]
	[TemplatePart(Name = ElementNumber6Name, Type = typeof(Button))]
	[TemplatePart(Name = ElementNumber7Name, Type = typeof(Button))]
	[TemplatePart(Name = ElementNumber8Name, Type = typeof(Button))]
	[TemplatePart(Name = ElementNumber9Name, Type = typeof(Button))]
	[TemplatePart(Name = ElementNumber0Name, Type = typeof(Button))]
	[TemplatePart(Name = ElementNumberSignName, Type = typeof(Button))]
	[TemplatePart(Name = ElementDollarSignName, Type = typeof(Button))]
	[TemplatePart(Name = ElementPercentSignName, Type = typeof(Button))]
	[TemplatePart(Name = ElementAmpersandName, Type = typeof(Button))]
	[TemplatePart(Name = ElementAsterixSignName, Type = typeof(Button))]
	[TemplatePart(Name = ElementEqualSignName, Type = typeof(Button))]
	[TemplatePart(Name = ElementPlusSignName, Type = typeof(Button))]
	[TemplatePart(Name = ElementMinusSignName, Type = typeof(Button))]
	[TemplatePart(Name = ElementColonName, Type = typeof(Button))]
	[TemplatePart(Name = ElementSemicolonName, Type = typeof(Button))]
	[TemplatePart(Name = ElementSingleQuotesName, Type = typeof(Button))]
	[TemplatePart(Name = ElementDoubleQuotesName, Type = typeof(Button))]
	[TemplatePart(Name = ElementDivideSignName, Type = typeof(Button))]
	[TemplatePart(Name = ElementOpenParenthesisName, Type = typeof(Button))]
	[TemplatePart(Name = ElementCloseParenthesisName, Type = typeof(Button))]
	[TemplatePart(Name = ElementOpenBracketName, Type = typeof(Button))]
	[TemplatePart(Name = ElementCloseBracketName, Type = typeof(Button))]
	[TemplatePart(Name = ElementBackspaceName, Type = typeof(Button))]
	[TemplatePart(Name = ElementBracketLessName, Type = typeof(Button))]
	[TemplatePart(Name = ElementBracketMoreName, Type = typeof(Button))]
	[TemplatePart(Name = ElementPeriodName, Type = typeof(Button))]
	[TemplatePart(Name = ElementReturnName, Type = typeof(Button))]
	[TemplatePart(Name = ElementExclamationMarkName, Type = typeof(Button))]
	[TemplatePart(Name = ElementQuestionMarkName, Type = typeof(Button))]
	[TemplatePart(Name = ElementCommaName, Type = typeof(Button))]
	[TemplatePart(Name = ElementArrowUpKeyName, Type = typeof(Button))]
	[TemplatePart(Name = ElementNumericSwitchName, Type = typeof(Button))]
	[TemplatePart(Name = ElementDashKeyName, Type = typeof(Button))]
	[TemplatePart(Name = ElementAtSignName, Type = typeof(Button))]
	[TemplatePart(Name = ElementSpacebarName, Type = typeof(Button))]
	[TemplatePart(Name = ElementDotComKeyName, Type = typeof(Button))]
	[TemplatePart(Name = ElementArrowLeftKeyName, Type = typeof(Button))]
	[TemplatePart(Name = ElementArrowRightKeyName, Type = typeof(Button))]
	[TemplatePart(Name = ElementArrowDownKeyName, Type = typeof(Button))]
    [TemplatePart(Name = ElementCircumflexName, Type = typeof(Button))]
	[TemplateVisualState(Name = VisualStateQuertyName, GroupName = VisualStateGroupKeyboardLayoutName)]
	[TemplateVisualState(Name = VisualStateNumericName, GroupName = VisualStateGroupKeyboardLayoutName)]
	public class QuertyKeyboard : Control
	{
		#region Template Parts

		private const String ElementLetterQName = "LetterQ";
		private const String ElementLetterWName = "LetterW";
		private const String ElementLetterEName = "LetterE";
		private const String ElementLetterRName = "LetterR";
		private const String ElementLetterTName = "LetterT";
		private const String ElementLetterYName = "LetterY";
		private const String ElementLetterUName = "LetterU";
		private const String ElementLetterIName = "LetterI";
		private const String ElementLetterOName = "LetterO";
		private const String ElementLetterPName = "LetterP";
		private const String ElementLetterAName = "LetterA";
		private const String ElementLetterSName = "LetterS";
		private const String ElementLetterDName = "LetterD";
		private const String ElementLetterFName = "LetterF";
		private const String ElementLetterGName = "LetterG";
		private const String ElementLetterHName = "LetterH";
		private const String ElementLetterJName = "LetterJ";
		private const String ElementLetterKName = "LetterK";
		private const String ElementLetterLName = "LetterL";
		private const String ElementShiftKeyName = "ShiftKey";
		private const String ElementLetterZName = "LetterZ";
		private const String ElementLetterXName = "LetterX";
		private const String ElementLetterCName = "LetterC";
		private const String ElementLetterVName = "LetterV";
		private const String ElementLetterBName = "LetterB";
		private const String ElementLetterNName = "LetterN";
		private const String ElementLetterMName = "LetterM";
		private const String ElementCurlyKeyName = "CurlyKey";
		private const String ElementNumber1Name = "Number1";
		private const String ElementNumber2Name = "Number2";
		private const String ElementNumber3Name = "Number3";
		private const String ElementNumber4Name = "Number4";
		private const String ElementNumber5Name = "Number5";
		private const String ElementNumber6Name = "Number6";
		private const String ElementNumber7Name = "Number7";
		private const String ElementNumber8Name = "Number8";
		private const String ElementNumber9Name = "Number9";
		private const String ElementNumber0Name = "Number0";
		private const String ElementNumberSignName = "NumberSign";
		private const String ElementDollarSignName = "DollarSign";
		private const String ElementPercentSignName = "PercentSign";
		private const String ElementAmpersandName = "Ampersand";
		private const String ElementAsterixSignName = "AsterixSign";
		private const String ElementEqualSignName = "EqualSign";
		private const String ElementPlusSignName = "PlusSign";
		private const String ElementMinusSignName = "MinusSign";
		private const String ElementColonName = "Colon";
		private const String ElementSemicolonName = "SemiColon";
		private const String ElementSingleQuotesName = "SingleQuotes";
		private const String ElementDoubleQuotesName = "DoubleQuotes";
		private const String ElementDivideSignName = "DivideSign";
		private const String ElementOpenParenthesisName = "OpenParenthesis";
		private const String ElementCloseParenthesisName = "CloseParenthesis";
		private const String ElementOpenBracketName = "OpenBracket";
		private const String ElementCloseBracketName = "CloseBracket";
		private const String ElementBackspaceName = "Backspace";
		private const String ElementBracketLessName = "BracketLess";
		private const String ElementBracketMoreName = "BracketMore";
		private const String ElementPeriodName = "Period";
		private const String ElementReturnName = "Return";
		private const String ElementExclamationMarkName = "ExclamationMark";
		private const String ElementQuestionMarkName = "QuestionMark";
		private const String ElementCommaName = "Comma";
		private const String ElementArrowUpKeyName = "ArrowUpKey";
		private const String ElementNumericSwitchName = "NumericSwitch";
		private const String ElementDashKeyName = "DashKey";
		private const String ElementAtSignName = "AtSign";
		private const String ElementSpacebarName = "Spacebar";
		private const String ElementDotComKeyName = "DotComKey";
		private const String ElementArrowLeftKeyName = "ArrowLeftKey";
		private const String ElementArrowRightKeyName = "ArrowRightKey";
		private const String ElementArrowDownKeyName = "ArrowDownKey";
        private const String ElementCircumflexName = "Circumflex";

		private static Dictionary<String, KeyStats> TemplatePartNames = new Dictionary<String, KeyStats>();
		private bool isShiftPressed = false;

		public bool IsShiftPressed
		{
			get { return isShiftPressed; }
			set
			{
				if (isShiftPressed != value)
				{
					isShiftPressed = value;
					OnShiftPressed();
				}
			}
		}

        #region ShowCapitalize

        /// <summary>
        /// ShowCapitalize Dependency Property
        /// </summary>
        public static readonly DependencyProperty ShowCapitalizeProperty =
            DependencyProperty.Register("ShowCapitalize", typeof(bool?), typeof(QuertyKeyboard),
                new FrameworkPropertyMetadata(null,
                    new PropertyChangedCallback(OnShowCapitalizeChanged)));

        /// <summary>
        /// Gets or sets the ShowCapitalize property.  This dependency property 
        /// indicates ....
        /// </summary>
        public bool? ShowCapitalize
        {
            get { return (bool?)GetValue(ShowCapitalizeProperty); }
            set { SetValue(ShowCapitalizeProperty, value); }
        }

        /// <summary>
        /// Handles changes to the ShowCapitalize property.
        /// </summary>
        private static void OnShowCapitalizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((QuertyKeyboard)d).OnShowCapitalizeChanged(e);
        }

        /// <summary>
        /// Provides derived classes an opportunity to handle changes to the ShowCapitalize property.
        /// </summary>
        protected virtual void OnShowCapitalizeChanged(DependencyPropertyChangedEventArgs e)
        {
            var showCapitalize = e.OldValue as bool?;
            var value = e.NewValue as bool?;
            if (showCapitalize != value)
            {
                OnShowCapitalize();
            }
        }

        #endregion

        

		#endregion Template Parts

		#region Visual states

		private const String VisualStateGroupKeyboardLayoutName = "KeyboardLayoutStates";
		private const String VisualStateQuertyName = "QuertyState";
		private const String VisualStateNumericName = "NumericState";

		private VisualStateGroup KeyboardLayoutVisualStateGroup;
		private VisualState QuertyVisualState;
		private VisualState NumericVisualState;

		#endregion Visual states

		#region KeyboardLayout

		/// <summary>
		/// KeyboardLayout Dependency Property
		/// </summary>
		public static readonly DependencyProperty KeyboardLayoutProperty =
			DependencyProperty.Register("KeyboardLayout", typeof(KeyboardLayout), typeof(QuertyKeyboard),
				new FrameworkPropertyMetadata((KeyboardLayout.QuertyState),
					new PropertyChangedCallback(OnKeyboardLayoutChanged)));

		/// <summary>
		/// Gets or sets the KeyboardLayout property.  This dependency property
		/// indicates the current layout of the on-screen Stringboard.
		/// </summary>
		public KeyboardLayout KeyboardLayout
		{
			get { return (KeyboardLayout)GetValue(KeyboardLayoutProperty); }
			set { SetValue(KeyboardLayoutProperty, value); }
		}

		/// <summary>
		/// Handles changes to the KeyboardLayout property.
		/// </summary>
		private static void OnKeyboardLayoutChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((QuertyKeyboard)d).OnKeyboardLayoutChanged(e);
		}

		/// <summary>
		/// Provides derived classes an opportunity to handle changes to the KeyboardLayout property.
		/// </summary>
		protected virtual void OnKeyboardLayoutChanged(DependencyPropertyChangedEventArgs e)
		{
			VisualStateManager.GoToState(this, e.NewValue.ToString(), true);
		}

		#endregion KeyboardLayout

		#region DisabledKeys

		/// <summary>
		/// DisabledKeys Dependency Property
		/// </summary>
		public static readonly DependencyProperty DisabledKeysProperty =
			DependencyProperty.Register("DisabledKeys", typeof(ObservableCollection<String>), typeof(QuertyKeyboard),
				new FrameworkPropertyMetadata(null,
					new PropertyChangedCallback(OnDisabledKeysChanged)));

		/// <summary>
		/// Gets or sets the DisabledKeys property.  This dependency property
		/// indicates the observable collection of Strings that have been disabled on the Stringboard.
		/// </summary>
		public ObservableCollection<String> DisabledKeys
		{
			get { return (ObservableCollection<String>)GetValue(DisabledKeysProperty); }
			set { SetValue(DisabledKeysProperty, value); }
		}

		/// <summary>
		/// Handles changes to the DisabledKeys property.
		/// </summary>
		private static void OnDisabledKeysChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((QuertyKeyboard)d).OnDisabledKeysChanged(e);
		}

		/// <summary>
		/// Provides derived classes an opportunity to handle changes to the DisabledKeys property.
		/// </summary>
		protected virtual void OnDisabledKeysChanged(DependencyPropertyChangedEventArgs e)
		{
			var DisabledKeys = e.OldValue as ObservableCollection<String>;
			if (DisabledKeys != null)
			{
				DisabledKeys.CollectionChanged -= new System.Collections.Specialized.NotifyCollectionChangedEventHandler(DisabledKeys_CollectionChanged);
			}
			DisabledKeys = e.NewValue as ObservableCollection<String>;
			if (DisabledKeys != null)
			{
				DisabledKeys.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(DisabledKeys_CollectionChanged);
			}
		}

		#endregion DisabledKeys

		#region KeyStrokeCommand

		/// <summary>
		/// KeyStrokeCommand Dependency Property
		/// </summary>
		public static readonly DependencyProperty KeyStrokeCommandProperty =
			DependencyProperty.Register("KeyStrokeCommand", typeof(ICommand), typeof(QuertyKeyboard),
				new FrameworkPropertyMetadata((ICommand)null,
					new PropertyChangedCallback(OnKeyStrokeCommandChanged)));

		/// <summary>
		/// Gets or sets the KeyStrokeCommand property.  This dependency property
		/// indicates the command to execute when a key stroke happens.
		/// </summary>
		public ICommand KeyStrokeCommand
		{
			get { return (ICommand)GetValue(KeyStrokeCommandProperty); }
			set { SetValue(KeyStrokeCommandProperty, value); }
		}

		/// <summary>
		/// Handles changes to the KeyStrokeCommand property.
		/// </summary>
		private static void OnKeyStrokeCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((QuertyKeyboard)d).OnKeyStrokeCommandChanged(e);
		}

		/// <summary>
		/// Provides derived classes an opportunity to handle changes to the KeyStrokeCommand property.
		/// </summary>
		protected virtual void OnKeyStrokeCommandChanged(DependencyPropertyChangedEventArgs e)
		{
		}

		#endregion KeyStrokeCommand

		#region Text

		/// <summary>
		/// Text Dependency Property
		/// </summary>
		public static readonly DependencyProperty TextProperty =
			DependencyProperty.Register("Text", typeof(String), typeof(QuertyKeyboard),
				new FrameworkPropertyMetadata(String.Empty,
					new PropertyChangedCallback(OnTextChanged)));

		/// <summary>
		/// Gets or sets the Text property.  This dependency property
		/// indicates the text entered by the user with the on-screen Stringboard.
		/// </summary>
		public String Text
		{
			get { return (String)GetValue(TextProperty); }
			set { SetValue(TextProperty, value); }
		}

		/// <summary>
		/// Handles changes to the Text property.
		/// </summary>
		private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((QuertyKeyboard)d).OnTextChanged(e);
		}

		/// <summary>
		/// Provides derived classes an opportunity to handle changes to the Text property.
		/// </summary>
		protected virtual void OnTextChanged(DependencyPropertyChangedEventArgs e)
		{
		}

		#endregion Text

		public int MaxLength
		{
			get { return maxLength; }
			set { maxLength = value; }
		}

		int maxLength = int.MaxValue;

		public KeyboardKeyStrokeHandler KeyStrokeHandler
		{
			get { return keyStrokeHandler; }
			set { keyStrokeHandler = value; }
		}

		KeyboardKeyStrokeHandler keyStrokeHandler = KeyboardKeyStrokeHandler.VirtualKeyboardBased;

        private static string[] shiftEnabledPartNames;
        private static string[] capEnabledPartNames;

		static QuertyKeyboard()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(QuertyKeyboard), new FrameworkPropertyMetadata(typeof(QuertyKeyboard)));
			InitializeTemplatePartNames();
			InitializeShiftEnabledKeys();
            InitializeCapEnabledKeys();
            Application.Current.Exit += new ExitEventHandler(Application_Exit);
		}

        static void Application_Exit(object sender, ExitEventArgs e)
        {
            VirtualKeyboardService.Instance.ReleaseStickyKeys();
        }
        private static void InitializeCapEnabledKeys()
        {
            capEnabledPartNames = new string[]{	ElementLetterQName,
			    ElementLetterWName,
			    ElementLetterEName,
			    ElementLetterRName,
			    ElementLetterTName,
			    ElementLetterYName,
			    ElementLetterUName,
			    ElementLetterIName,
			    ElementLetterOName,
			    ElementLetterPName,
			    ElementLetterAName,
			    ElementLetterSName,
			    ElementLetterDName,
			    ElementLetterFName,
			    ElementLetterGName,
			    ElementLetterHName,
			    ElementLetterJName,
			    ElementLetterKName,
			    ElementLetterLName,
			    ElementLetterZName,
			    ElementLetterXName,
			    ElementLetterCName,
			    ElementLetterVName,
			    ElementLetterBName,
			    ElementLetterNName,
			    ElementLetterMName,
            };
        }
		private static void InitializeShiftEnabledKeys()
		{
			shiftEnabledPartNames = new string[]{	ElementLetterQName,
			    ElementLetterWName,
			    ElementLetterEName,
			    ElementLetterRName,
			    ElementLetterTName,
			    ElementLetterYName,
			    ElementLetterUName,
			    ElementLetterIName,
			    ElementLetterOName,
			    ElementLetterPName,
			    ElementLetterAName,
			    ElementLetterSName,
			    ElementLetterDName,
			    ElementLetterFName,
			    ElementLetterGName,
			    ElementLetterHName,
			    ElementLetterJName,
			    ElementLetterKName,
			    ElementLetterLName,
			    ElementLetterZName,
			    ElementLetterXName,
			    ElementLetterCName,
			    ElementLetterVName,
			    ElementLetterBName,
			    ElementLetterNName,
			    ElementLetterMName,
                ElementDotComKeyName
            };
		}

		private void DisabledKeys_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			if (KeyStrokeCommand != null)
			{
				KeyStrokeCommand.CanExecute(DisabledKeys.ToArray());
			}
			var disabledKeyArray = (from String disabledKey in e.NewItems
									select disabledKey).ToArray();
			var enabledKeyArray = (from String enabledKey in e.OldItems
								   select enabledKey).ToArray();
			switch (e.Action)
			{
				case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
					OnNewDisabledKeys(disabledKeyArray);
					break;
				case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
				case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
					OnNewEnabledKeys(enabledKeyArray);
					break;
				case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
					OnNewDisabledKeys(disabledKeyArray);
					OnNewEnabledKeys(enabledKeyArray);
					break;
				default:
				case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
					break;
			}
		}

		private void OnNewEnabledKeys(string[] enabledKeyArray)
		{
			foreach (var enabledKey in enabledKeyArray)
			{
				var partName = (from keyValuePair in TemplatePartNames
								where keyValuePair.Value.Name == enabledKey
								select keyValuePair.Key).FirstOrDefault();
				if (!String.IsNullOrEmpty(partName))
				{
					var element = GetTemplateChild(partName) as Button;
					element.IsEnabled = true;
				}
			}
		}

		private void OnNewDisabledKeys(string[] disabledKeyArray)
		{
			foreach (var disabledKey in disabledKeyArray)
			{
				var partName = (from keyValuePair in TemplatePartNames
								where keyValuePair.Value.Name == disabledKey
								select keyValuePair.Key).FirstOrDefault();
				if (!String.IsNullOrEmpty(partName))
				{
					var element = GetTemplateChild(partName) as Button;
					element.IsEnabled = false;
				}
			}
		}

		private static void InitializeTemplatePartNames()
		{
			TemplatePartNames.Add(ElementLetterQName, new KeyStats("Q", KeysEx.VK_Q));
			TemplatePartNames.Add(ElementLetterWName, new KeyStats("W", KeysEx.VK_W));
			TemplatePartNames.Add(ElementLetterEName, new KeyStats("E", KeysEx.VK_E));
			TemplatePartNames.Add(ElementLetterRName, new KeyStats("R", KeysEx.VK_R));
			TemplatePartNames.Add(ElementLetterTName, new KeyStats("T", KeysEx.VK_T));
			TemplatePartNames.Add(ElementLetterYName, new KeyStats("Y", KeysEx.VK_Y));
			TemplatePartNames.Add(ElementLetterUName, new KeyStats("U", KeysEx.VK_U));
			TemplatePartNames.Add(ElementLetterIName, new KeyStats("I", KeysEx.VK_I));
			TemplatePartNames.Add(ElementLetterOName, new KeyStats("O", KeysEx.VK_O));
			TemplatePartNames.Add(ElementLetterPName, new KeyStats("P", KeysEx.VK_P));
			TemplatePartNames.Add(ElementLetterAName, new KeyStats("A", KeysEx.VK_A));
			TemplatePartNames.Add(ElementLetterSName, new KeyStats("S", KeysEx.VK_S));
			TemplatePartNames.Add(ElementLetterDName, new KeyStats("D", KeysEx.VK_D));
			TemplatePartNames.Add(ElementLetterFName, new KeyStats("F", KeysEx.VK_F));
			TemplatePartNames.Add(ElementLetterGName, new KeyStats("G", KeysEx.VK_G));
			TemplatePartNames.Add(ElementLetterHName, new KeyStats("H", KeysEx.VK_H));
			TemplatePartNames.Add(ElementLetterJName, new KeyStats("J", KeysEx.VK_J));
			TemplatePartNames.Add(ElementLetterKName, new KeyStats("K", KeysEx.VK_K));
			TemplatePartNames.Add(ElementLetterLName, new KeyStats("L", KeysEx.VK_L));
			TemplatePartNames.Add(ElementShiftKeyName, new KeyStats("Shift", KeysEx.VK_SHIFT));
			TemplatePartNames.Add(ElementLetterZName, new KeyStats("Z", KeysEx.VK_Z));
			TemplatePartNames.Add(ElementLetterXName, new KeyStats("X", KeysEx.VK_X));
			TemplatePartNames.Add(ElementLetterCName, new KeyStats("C", KeysEx.VK_C));
			TemplatePartNames.Add(ElementLetterVName, new KeyStats("V", KeysEx.VK_V));
			TemplatePartNames.Add(ElementLetterBName, new KeyStats("B", KeysEx.VK_B));
			TemplatePartNames.Add(ElementLetterNName, new KeyStats("N", KeysEx.VK_N));
			TemplatePartNames.Add(ElementLetterMName, new KeyStats("M", KeysEx.VK_M));
			TemplatePartNames.Add(ElementCurlyKeyName, new KeyStats("~", KeysEx.VK_OEM_3, true));
			TemplatePartNames.Add(ElementNumber1Name, new KeyStats("1", KeysEx.VK_NUMPAD1));
			TemplatePartNames.Add(ElementNumber2Name, new KeyStats("2", KeysEx.VK_NUMPAD2));
			TemplatePartNames.Add(ElementNumber3Name, new KeyStats("3", KeysEx.VK_NUMPAD3));
			TemplatePartNames.Add(ElementNumber4Name, new KeyStats("4", KeysEx.VK_NUMPAD4));
			TemplatePartNames.Add(ElementNumber5Name, new KeyStats("5", KeysEx.VK_NUMPAD5));
			TemplatePartNames.Add(ElementNumber6Name, new KeyStats("6", KeysEx.VK_NUMPAD6));
			TemplatePartNames.Add(ElementNumber7Name, new KeyStats("7", KeysEx.VK_NUMPAD7));
			TemplatePartNames.Add(ElementNumber8Name, new KeyStats("8", KeysEx.VK_NUMPAD8));
			TemplatePartNames.Add(ElementNumber9Name, new KeyStats("9", KeysEx.VK_NUMPAD9));
			TemplatePartNames.Add(ElementNumber0Name, new KeyStats("0", KeysEx.VK_NUMPAD0));
			TemplatePartNames.Add(ElementAsterixSignName, new KeyStats("*", KeysEx.VK_MULTIPLY));
			TemplatePartNames.Add(ElementEqualSignName, new KeyStats("=", KeysEx.VK_OEM_PLUS));
			TemplatePartNames.Add(ElementPlusSignName, new KeyStats("+", KeysEx.VK_OEM_PLUS, true));
			TemplatePartNames.Add(ElementMinusSignName, new KeyStats("-", KeysEx.VK_OEM_MINUS));
			TemplatePartNames.Add(ElementColonName, new KeyStats(":", KeysEx.VK_OEM_1, true));
			TemplatePartNames.Add(ElementSemicolonName, new KeyStats(";", KeysEx.VK_OEM_1));
			TemplatePartNames.Add(ElementSingleQuotesName, new KeyStats("'", KeysEx.VK_OEM_7));
			TemplatePartNames.Add(ElementDoubleQuotesName, new KeyStats("\"", KeysEx.VK_OEM_7, true));
			TemplatePartNames.Add(ElementDivideSignName, new KeyStats("/", KeysEx.VK_DIVIDE));
			TemplatePartNames.Add(ElementOpenBracketName, new KeyStats("[", KeysEx.VK_OEM_4));
			TemplatePartNames.Add(ElementCloseBracketName, new KeyStats("]", KeysEx.VK_OEM_6));
			TemplatePartNames.Add(ElementBackspaceName, new KeyStats("Backspace", KeysEx.VK_BACK));
			TemplatePartNames.Add(ElementBracketLessName, new KeyStats("<", KeysEx.VK_OEM_COMMA, true));
			TemplatePartNames.Add(ElementBracketMoreName, new KeyStats(">", KeysEx.VK_OEM_PERIOD, true));
			TemplatePartNames.Add(ElementPeriodName, new KeyStats(".", KeysEx.VK_OEM_PERIOD));
			TemplatePartNames.Add(ElementReturnName, new KeyStats("\r\n", KeysEx.VK_RETURN));
			TemplatePartNames.Add(ElementQuestionMarkName, new KeyStats("?", KeysEx.VK_OEM_2, true));
			TemplatePartNames.Add(ElementCommaName, new KeyStats(",", KeysEx.VK_OEM_COMMA));
			TemplatePartNames.Add(ElementArrowUpKeyName, new KeyStats("Up", KeysEx.VK_HOME));
			TemplatePartNames.Add(ElementNumericSwitchName, new KeyStats("NumLock", KeysEx.VK_NUMLOCK));
			TemplatePartNames.Add(ElementDashKeyName, new KeyStats("_", KeysEx.VK_OEM_MINUS, true));
			TemplatePartNames.Add(ElementSpacebarName, new KeyStats(" ", KeysEx.VK_SPACE));
			TemplatePartNames.Add(ElementDotComKeyName, new KeyStats(".COM", KeysEx.None));
			TemplatePartNames.Add(ElementArrowLeftKeyName, new KeyStats("Left", KeysEx.VK_LEFT));
			TemplatePartNames.Add(ElementArrowRightKeyName, new KeyStats("Right", KeysEx.VK_RIGHT));
			TemplatePartNames.Add(ElementArrowDownKeyName, new KeyStats("Down", KeysEx.VK_END));
			TemplatePartNames.Add(ElementCircumflexName, new KeyStats("^", KeysEx.VK_CIRCUMFLEX,true));
            TemplatePartNames.Add(ElementNumberSignName, new KeyStats("#", KeysEx.VK_NUMBERSIGN, true));
			TemplatePartNames.Add(ElementDollarSignName, new KeyStats("$", KeysEx.VK_DOLLAR, true));
			TemplatePartNames.Add(ElementPercentSignName, new KeyStats("%", KeysEx.VK_PERCENTAGE, true));
			TemplatePartNames.Add(ElementAmpersandName, new KeyStats("&", KeysEx.VK_AMPERSAND, true));
			TemplatePartNames.Add(ElementOpenParenthesisName, new KeyStats("(", KeysEx.VK_LPARENTHESES, true));
			TemplatePartNames.Add(ElementCloseParenthesisName, new KeyStats(")", KeysEx.VK_RPARENTHESES, true));
			TemplatePartNames.Add(ElementExclamationMarkName, new KeyStats("!", KeysEx.VK_EXCLAMATION, true));
			TemplatePartNames.Add(ElementAtSignName, new KeyStats("@", KeysEx.VK_AT, true));
		}

		private void OnExecuteStringStroke(String partName, KeyStats keyStats)
		{
			var key = keyStats.Name;
			if (!OnCanExecuteStringStroke(key)) { return; }
			switch (key)
			{
				case "NumLock":
					KeyboardLayout = (KeyboardLayout == KeyboardLayout.QuertyState ? KeyboardLayout.NumericState : KeyboardLayout.QuertyState);
					break;
				case "Backspace":
					if (!String.IsNullOrEmpty(Text))
					{
						// a quick hack to remove both \r AND \n
						Text =
							Text.EndsWith("\r\n")
								? Text.Remove(Text.Length - 2)
								: Text.Remove(Text.Length - 1);
					}
					break;
				case "Shift":
					IsShiftPressed = !IsShiftPressed;
					break;
				case "Up":
				case "Left":
				case "Right":
				case "Down":
					break;
				default:
					if (Text != null && Text.Length >= MaxLength)
					{
						return;
					}
					Text += IsShiftPressed ? keyStats.Name : keyStats.ShiftName;
					IsShiftPressed = false;
					break;
			}
		}

		private void OnExecuteVirtualKeyStroke(string partName, KeyStats keyStats)
		{
			if (!OnCanExecuteStringStroke(keyStats.Name)) { return; }
			switch (keyStats.KeyCode)
			{
				case KeysEx.VK_NUMLOCK:
					KeyboardLayout = (KeyboardLayout == KeyboardLayout.QuertyState ? KeyboardLayout.NumericState : KeyboardLayout.QuertyState);
					break;
				case KeysEx.VK_SHIFT:
					IsShiftPressed = !IsShiftPressed;
					break;
				case KeysEx.None:
					OnExecuteCustomKeyStroke(partName, keyStats);
					break;
				default:
					if (!keyStats.UseShift && !shiftEnabledPartNames.Contains(partName))
					{
						VirtualKeyboardService.Instance.ReleaseStickyKeys();
					}
					if (keyStats.UseShift)
					{
						VirtualKeyboardService.Instance.PressAndHold(KeysEx.VK_LSHIFT);
					}
					VirtualKeyboardService.Instance.PressAndRelease(keyStats.KeyCode);
					IsShiftPressed = false;
					break;
			}
		}

		private void OnExecuteCustomKeyStroke(string partName, KeyStats keyStats)
		{
			switch (keyStats.Name)
			{
				case ".COM":
					VirtualKeyboardService.Instance.PressKey(KeysEx.VK_DECIMAL);
					VirtualKeyboardService.Instance.PressKey(KeysEx.VK_C);
					VirtualKeyboardService.Instance.PressKey(KeysEx.VK_O);
					VirtualKeyboardService.Instance.PressKey(KeysEx.VK_M);
					IsShiftPressed = false;
					VirtualKeyboardService.Instance.ReleaseStickyKeys();
					break;
				default:
					break;
			}
		}

		private void OnExecuteKeyStrokeCommand(object p)
		{
			if (KeyStrokeCommand == null) { return; }
			if (!KeyStrokeCommand.CanExecute(p)) { return; }
			KeyStrokeCommand.Execute(p);
		}

		private void OnShiftPressed()
		{
            if (ShowCapitalize.HasValue && ShowCapitalize.Value)
                return;
			var availablePartNames = shiftEnabledPartNames
									.Where(name => TemplatePartNames.ContainsKey(name))
									;
			foreach (var partName in availablePartNames)
			{
				var element = GetTemplateChild(partName) as Button;
				element.Content = IsShiftPressed ? TemplatePartNames[partName].Name : TemplatePartNames[partName].ShiftName;
			}

            if (KeyStrokeHandler == KeyboardKeyStrokeHandler.VirtualKeyboardBased)
            {
                if (IsShiftPressed)
                {
                    VirtualKeyboardService.Instance.PressAndHold(KeysEx.VK_LSHIFT);
                }
                else
                {
                    VirtualKeyboardService.Instance.Shift =  false;
                } 
            }
		}

        private void OnShowCapitalize()
        {
            var availablePartNames = capEnabledPartNames
                                    .Where(name => TemplatePartNames.ContainsKey(name))
                                    ;
            foreach (var partName in availablePartNames)
            {
                var element = GetTemplateChild(partName) as Button;
                if (element==null)
                    continue;
                element.Content =
                    ShowCapitalize.HasValue && ShowCapitalize.Value ? TemplatePartNames[partName].CapName :
                    (IsShiftPressed ? TemplatePartNames[partName].Name : TemplatePartNames[partName].ShiftName);
            }
        }

		private bool OnCanExecuteStringStroke(String String)
		{
			if (DisabledKeys == null) { return true; }
			return !DisabledKeys.Contains(String);
		}

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			KeyboardLayoutVisualStateGroup = GetTemplateChild(VisualStateGroupKeyboardLayoutName) as VisualStateGroup;
			QuertyVisualState = GetTemplateChild(VisualStateQuertyName) as VisualState;
			NumericVisualState = GetTemplateChild(VisualStateNumericName) as VisualState;

			foreach (var partName in TemplatePartNames.Keys)
			{
				var element = GetTemplateChild(partName) as Button;
				if (element != null)
				{
					element.Command = KeyStrokeCommand;
					element.CommandParameter = TemplatePartNames[partName];

					//element.TouchUp += new EventHandler<TouchEventArgs>(Button_TouchUp);
					var touchUpEventListener = new WeakEventListener<QuertyKeyboard, object, TouchEventArgs>(this);
					touchUpEventListener.OnEventAction = (instance, source, eventArgs) =>
						instance.Button_TouchUp(source, eventArgs);
					touchUpEventListener.OnDetachAction = (weakEventListenerParameter) =>
						element.TouchUp -= weakEventListenerParameter.OnEvent;
					element.TouchUp += touchUpEventListener.OnEvent;

					//element.Click += new RoutedEventHandler(Button_Click);
					var clickEventListener = new WeakEventListener<QuertyKeyboard, object, RoutedEventArgs>(this);
					clickEventListener.OnEventAction = (instance, source, eventArgs) =>
						instance.Button_Click(source, eventArgs);
					clickEventListener.OnDetachAction = (weakEventListenerParameter) =>
						element.Click -= weakEventListenerParameter.OnEvent;
					element.Click += clickEventListener.OnEvent;
				}
#if DEBUG
                else
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("Part not found: {0}", partName));
                }
#endif
                OnShowCapitalize();
				//OnShiftPressed();
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			var button = sender as Button;
			var keyStroke = (KeyStats)button.CommandParameter;
            var keyName = button.Name;
			OnExecuteKeyStrokeCommand(button.CommandParameter);
            SendKeyStroke(keyName, keyStroke);
		}
        public void SendKeyStroke(string keyName)
        {
            SendKeyStroke(keyName,TemplatePartNames[keyName]);
        }
        private void SendKeyStroke(string keyName, KeyStats keyStroke)
        {
            switch (KeyStrokeHandler)
            {
                case KeyboardKeyStrokeHandler.VirtualKeyboardBased:
                    OnExecuteVirtualKeyStroke(keyName, keyStroke);
                    break;
                case KeyboardKeyStrokeHandler.StringBased:
                    OnExecuteStringStroke(keyName, keyStroke);
                    break;
            }
        }
        
		private void Button_TouchUp(object sender, TouchEventArgs e)
		{
			// I dont even think this needs to be here at all...
			//var button = sender as Button;
			//var keyStroke = button.CommandParameter as String;
			//OnExecuteVirtualKeyStroke ( keyStroke );
		}

        public void ReleaseKeys()
        {
            VirtualKeyboardService.Instance.ReleaseStickyKeys();
        }
    }

	public struct KeyStats
	{
		public Boolean UseShift;

		public KeysEx KeyCode;

		public string Name;
		public string ShiftName;
        public string CapName;

		public KeyStats(string name, KeysEx keyCode, bool useShift = false, string capName= null)
		{
			Name = name;
			KeyCode = keyCode;
			UseShift = useShift;
			ShiftName = string.Empty;
            CapName = string.Empty;
            if (!string.IsNullOrEmpty(Name))
			{
				ShiftName = Name.ToLowerInvariant();
                CapName = Name.ToUpperInvariant();
			}
		}
	}

	public enum KeyboardLayout
	{
		QuertyState,
		NumericState,
	}

	public enum KeyboardKeyStrokeHandler
	{
		VirtualKeyboardBased,
		StringBased
	}
}