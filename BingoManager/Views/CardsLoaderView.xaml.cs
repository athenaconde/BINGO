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
using System.ComponentModel;
using BingoManager.SystemManager.Repository;
using BingoManager.SystemManager.Engine;

namespace BingoManager.Views
{
    /// <summary>
    /// Interaction logic for CardsLoaderView.xaml
    /// </summary>
    public partial class CardsLoaderView : Window
    {
        public CardsLoaderView()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(CardsLoaderView_Loaded);
            bworker = new BackgroundWorker();
            bworker.DoWork += new DoWorkEventHandler(bworker_DoWork);
            bworker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bworker_RunWorkerCompleted);
            bworker.ProgressChanged += new ProgressChangedEventHandler(bworker_ProgressChanged);
            bworker.WorkerReportsProgress = true;
            //bworker2 = new BackgroundWorker();
            //bworker2.DoWork += new DoWorkEventHandler(bworker2_DoWork);
            //bworker2.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bworker2_RunWorkerCompleted);
            //this.Closing += new CancelEventHandler(CardsLoaderView_Closing);
        }

        void CardsLoaderView_Closing(object sender, CancelEventArgs e)
        {
             bworker.Dispose(); 
            //bworker2.Dispose()
        }

        void bworker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           
        }

        //void bworker2_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    e.Result = App.PlaycardViewModel.Col2Cards.Count();
        //}
        BackgroundWorker bworker;
    //    BackgroundWorker bworker2;
        void CardsLoaderView_Loaded(object sender, RoutedEventArgs e)
        {
            
            bworker.RunWorkerAsync();
            progressLine.Start();
        }

        void bworker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        void bworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // progressLine.Stop();
            App.Current.MainWindow = new WinMain();
            App.Current.MainWindow.DataContext = new ViewModel.WorkspacesViewModel();
            App.Current.MainWindow.Show();
            //   progressLine.Stop();
            this.Close();
        }

        void bworker_DoWork(object sender, DoWorkEventArgs e)
        {
           
            //   bworker.ReportProgress(1,App.PlaycardViewModel);
            e.Result = App.playingcardrepository.Cards;
            
        }
        
    }
}
