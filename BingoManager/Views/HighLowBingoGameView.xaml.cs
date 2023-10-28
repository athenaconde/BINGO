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
    /// Interaction logic for HighLowBingoGameView.xaml
    /// </summary>
    public partial class HighLowBingoGameView : UserControl
    {
        public HighLowBingoGameView()
        {
            InitializeComponent();
            this.LoadWinners.Click += new RoutedEventHandler(LoadWinners_Click);

        }

        void LoadWinners_Click(object sender, RoutedEventArgs e)
        {
            ((HighLowBingo)this.DataContext).MoveWonGame();
        }

        private void SetHighBingoCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ((HighLowBingo)this.DataContext).SetballHigh(e.Parameter);
        }

        private void SetHighBingoCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((HighLowBingo)this.DataContext).CanSetBall(e.Parameter);
           
        }
    }
}
