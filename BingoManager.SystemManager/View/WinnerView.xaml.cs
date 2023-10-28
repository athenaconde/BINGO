using System.Windows;
using System;

namespace BingoManager.SystemManager.View
{
    /// <summary>
    /// Interaction logic for WinnerView.xaml
    /// </summary>
    public partial class WinnerView : Window
    {
        public WinnerView()
        {
            InitializeComponent();
        }

        public WinnerView(object datacontext)
            : this()
        {
            if (datacontext == null)
            { throw new ArgumentNullException("datacontext"); }
            this.DataContext = datacontext;

        }


    }
}
