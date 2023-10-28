using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

using BingoManager.SystemManager.Model;
using System.Diagnostics;
using System.Threading;
using BingoManager.Reports;
using BingoManager.ViewModel;


namespace BingoManager.Views
{
    /// <summary>
    /// Interaction logic for WinMain.xaml
    /// </summary>
    public partial class WinMain : Window
    {
        public WinMain()
        {
            InitializeComponent();
        //    App.PlaycardViewModel.GameBalls.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(GameBalls_CollectionChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(WinMain_Closing);
            this.CardsReportMenu.Click += new RoutedEventHandler(CardsReportMenu_Click);
            this.CardsWinnerReportMenu.Click += new RoutedEventHandler(CardsWinnerReportMenu_Click);
           
            DateLabel.Content = System.DateTime.Now.ToLongDateString();
            RemoveCards.Click += new RoutedEventHandler(RemoveCards_Click);
            this.ShowRemoveCardNotSold.Click += new RoutedEventHandler(ShowRemoveCardNotSold_Click);
            
        }

        void ShowRemoveCardNotSold_Click(object sender, RoutedEventArgs e)
        {
            NotSoldCardREmoverManagerView view = new NotSoldCardREmoverManagerView();
            view.ShowDialog();
        }

              

        void WinMain_Closed(object sender, EventArgs e)
        {
            App.PlaycardViewModel.Dispose();
        }


        void AddGameButton_Click(object sender, RoutedEventArgs e)
        {

        }

        void WinMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure to close this application?\n\n Note: If you close this application, you will lost your current play!", "System information", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (result != MessageBoxResult.Yes)
            { e.Cancel = true; }

        }

        void GameBalls_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems.Count != 0)
            {
               
                //Grid _gameBall = (Grid)this.FindResource("BallGameKey");

            }
        }

        private void CloseCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void CreateCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ((WorkspacesViewModel)this.DataContext).CreateGame();
        }

        private void CreateCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                e.CanExecute = ((WorkspacesViewModel)this.DataContext).CanCreateGame(); // .CanExecuteCreate();
            }
        }

              /// <summary>
        /// View the report.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CardsReportMenu_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                ReportGeneratorView generatorReport = new ReportGeneratorView();
                generatorReport.ShowDialog();
            }
            catch (Exception) { }
        }

        private void ResetGame_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute =  true;
        }

        private void ResetGame_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            App.PlaycardViewModel.ResetGames();
        }

        void EnterValueTextBox_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

                void CardsWinnerReportMenu_Click(object sender, RoutedEventArgs e)
        {

            WinningCardsReport reportView = new WinningCardsReport();
            reportView.ShowDialog();
        }

        void ShowReportViewerObject(object obj)

        {
            
        }

        /// <summary>
        /// Lets you remove the cards from the list, that were not sold.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void RemoveCards_Click(object sender, RoutedEventArgs e)
        {
            PlayingCardsRemoverView removecards = new PlayingCardsRemoverView();
            removecards.ShowDialog();
        }

        private void SettingsCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                e.CanExecute = ((WorkspacesViewModel)this.DataContext).CanShowSettingsSetup();
            }
        }

        private void SettingsCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ((WorkspacesViewModel)this.DataContext).ShowSettingsSetup();
        }

        private void PlayHighLow_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void PlayHighLow_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ((WorkspacesViewModel)this.DataContext).PlayHighLowBingo();
        }

       

    }
}
