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
    /// Interaction logic for PlayingCardsRemoverView.xaml
    /// </summary>
    public partial class PlayingCardsRemoverView : Window
    {
        public PlayingCardsRemoverView()
        {
            InitializeComponent();
            this.OkButton.Click += new RoutedEventHandler(OkButton_Click);
            this.CancelButton.Click += new RoutedEventHandler(CancelButton_Click);
        }

        void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        void OkButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.PlaycardViewModel.RemoveExcessCards(System.Convert.ToInt32(Inputs.From), System.Convert.ToInt32(Inputs.To));
            }
            catch (Exception)
            { 
                
            }
        }
    }
}
