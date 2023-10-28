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
using BingoManager.SystemManager.ViewModel;

namespace BingoManager.Views
{
    /// <summary>
    /// Interaction logic for CardsListView.xaml
    /// </summary>
    public partial class CardsListView : UserControl
    {
        public CardsListView()
        {
            InitializeComponent();
        }

        private void RmoveSelected_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((AllPlayingCardsViewModel)this.DataContext).CanRemoveCard(e.Parameter);
        }

        private void RmoveSelected_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ((AllPlayingCardsViewModel)this.DataContext).RemoveCard(e.Parameter);
        }
    }
}
