using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BingoManager.Views
{
    /// <summary>
    /// Interaction logic for From_To_View.xaml
    /// </summary>
    public partial class From_To_View : UserControl
    {
        public From_To_View()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Gets the [FROM] input.
        /// </summary>
        public string From
        {
            get { return recordfromTextbox.Text; }
        }

        /// <summary>
        /// Gets the [TO] input.
        /// </summary>
        public string To
        {
            get { return recordtoTextbox.Text; }
        }
    }
}
