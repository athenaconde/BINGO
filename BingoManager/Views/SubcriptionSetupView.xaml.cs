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

namespace BingoManager.Views
{
    /// <summary>
    /// Interaction logic for SubcriptionSetupView.xaml
    /// </summary>
    public partial class SubcriptionSetupView : Window
    {
        public SubcriptionSetupView()
        {
            InitializeComponent();
            this.OkButton.Click += new RoutedEventHandler(OkButton_Click);
            this.CancelButton.Click += new RoutedEventHandler(CancelButton_Click);
        }

        void OkButton_Click(object sender, RoutedEventArgs e)
        {
            var result = App.PlaycardViewModel.RegisterApplication(KeyTextBox.Text);
            if (result > 0)
            {
                App.Current.MainWindow = new CardsLoaderView();
                App.Current.MainWindow.Show();
                this.Close();
            }
            else 
            
            {
                MessageBox.Show("The subscription key you typed was not correct.\nCheck your subscription key, and type it again.","Invalid subscription key",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
        }

        void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            App.Current.Shutdown();
        }

    
    }
}
