using System;
using System.Windows;
using System.Windows.Input;

namespace BingoManager.Control
{
   public class TextBox:System.Windows.Controls.TextBox
    {

        public TextBox()
            : base()
        {
        }
        static TextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TextBox), new FrameworkPropertyMetadata(typeof(TextBox)));
            TextProperty.OverrideMetadata(typeof(TextBox), new FrameworkPropertyMetadata(new PropertyChangedCallback(TextPropertyChanged)));
        }
        static void TextPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            TextBox mTextBox = (TextBox)sender;
            Boolean actualhasText = mTextBox.Text.Length > 0;
            if (actualhasText != mTextBox.hasText)
            {
                mTextBox.SetValue(hasTextPropertyKey, actualhasText);
            }
        }
        public static readonly DependencyProperty InfoTextProperty = DependencyProperty.Register("InfoText", typeof(string), typeof(TextBox), new FrameworkPropertyMetadata(string.Empty));

        public string InfoText
        {
            get { return (string)this.GetValue(InfoTextProperty); }
            set { this.SetValue(InfoTextProperty, value); }
        }

        public static readonly DependencyProperty AcceptNumbersOnlyProperty = DependencyProperty.Register("AcceptNumbersOnly", typeof(Boolean), typeof(TextBox), new FrameworkPropertyMetadata(false));

        public Boolean AcceptNumbersOnly
        {
            get { return (Boolean)this.GetValue(AcceptNumbersOnlyProperty); }
            set { this.SetValue(AcceptNumbersOnlyProperty, value); }
        }

        public Boolean hasText
        {
            get { return (Boolean)this.GetValue(hasTextProperty); }
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            if (AcceptNumbersOnly)
            { this.MaxLength = 6; }
        }

        private static readonly DependencyPropertyKey hasTextPropertyKey = DependencyProperty.RegisterReadOnly("hasText", typeof(Boolean), typeof(TextBox), new UIPropertyMetadata(false));

        public static readonly DependencyProperty hasTextProperty = hasTextPropertyKey.DependencyProperty;

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (AcceptNumbersOnly)
            {
                if (e.Key == Key.D0 || e.Key == Key.D1 || e.Key == Key.D2 || e.Key == Key.D3 || e.Key == Key.D4 || e.Key == Key.D5 || e.Key == Key.D6 || e.Key == Key.D7 || e.Key == Key.D8 || e.Key == Key.D9 || e.Key == Key.NumPad0 || e.Key == Key.NumPad1 || e.Key == Key.NumPad2 || e.Key == Key.NumPad3 || e.Key == Key.NumPad4 || e.Key == Key.NumPad5 || e.Key == Key.NumPad6 || e.Key == Key.NumPad7 || e.Key == Key.NumPad8 || e.Key == Key.NumPad9 ||  e.Key == Key.Tab || e.Key==Key.Enter)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (AcceptNumbersOnly)
            {
                if (e.Key == Key.D0 || e.Key == Key.D1 || e.Key == Key.D2 || e.Key == Key.D3 || e.Key == Key.D4 || e.Key == Key.D5 || e.Key == Key.D6 || e.Key == Key.D7 || e.Key == Key.D8 || e.Key == Key.D9 || e.Key == Key.NumPad0 || e.Key == Key.NumPad1 || e.Key == Key.NumPad2 || e.Key == Key.NumPad3 || e.Key == Key.NumPad4 || e.Key == Key.NumPad5 || e.Key == Key.NumPad6 || e.Key == Key.NumPad7 || e.Key == Key.NumPad8 || e.Key == Key.NumPad9 ||  e.Key == Key.Tab || e.Key == Key.Enter)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }


    }
}
