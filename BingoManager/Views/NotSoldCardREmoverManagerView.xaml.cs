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
using System.Windows.Shapes;

using BingoManager.SystemManager.ViewModel;

namespace BingoManager.Views
{
    /// <summary>
    /// Interaction logic for NotSoldCardREmoverManagerView.xaml
    /// </summary>
    public partial class NotSoldCardREmoverManagerView : Window
    {
        public NotSoldCardREmoverManagerView()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(NotSoldCardREmoverManagerView_Loaded);
        }

        void NotSoldCardREmoverManagerView_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = new AllPlayingCardsViewModel(App.playingcardrepository);
        }
    }
}
