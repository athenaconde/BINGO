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
using BingoManager.SystemManager.Repository;

namespace BingoManager.Views
{
    /// <summary>
    /// Interaction logic for BingoGamingControlView.xaml
    /// </summary>
    public partial class BingoGamingControlView : UserControl
    {
        public BingoGamingControlView()
        {
            InitializeComponent();
           // EnterValueTextBox.KeyDown += new KeyEventHandler(EnterValueTextBox_KeyDown);
            this.FindCardTextbox.KeyDown += new KeyEventHandler(FindCardTextbox_KeyDown);
        }

        void FindCardTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    var query = from pc in App.playingcardrepository.Cards where pc.SerialNumber == System.Convert.ToInt32(FindCardTextbox.Text) select pc;
                    if (query.Any())
                    {
                        var oldIndex = App.playingcardrepository.Cards.IndexOf(query.First());
                        App.playingcardrepository.Cards.Move(oldIndex, 0);
                    }
                }
                catch (Exception) { }
            }
        }

        void EnterValueTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Key == Key.Enter)
            //{
            //    try
            //    {
            //        App.PlaycardViewModel.SetBall(System.Convert.ToInt32(EnterValueTextBox.Text));
            //        EnterValueTextBox.Text = string.Empty;
            //    }
            //    catch (Exception) { }
            //}
        }

        private void SetBallCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = App.PlaycardViewModel.canSetBall(e.Parameter);
        }

        private void SetBallCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            App.PlaycardViewModel.SetBall(e.Parameter);
        }


        private void CreateCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = App.PlaycardViewModel.CanExecuteCreate();
        }

        private void CreateCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            App.PlaycardViewModel.CreateGame();
        }

        private void SaveNewGame_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = App.PlaycardViewModel.CanSaveGame();
        }

        private void SaveNewGame_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            App.PlaycardViewModel.SaveGameCard();
        }

        private void RemoveGame_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = App.PlaycardViewModel.canExecuteRemovingGamecard();
        }

        private void RemoveGame_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            App.PlaycardViewModel.RemovegameCard();
        }
    }
}
