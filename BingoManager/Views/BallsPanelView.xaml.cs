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
using BingoManager.SystemManager.Model;

namespace BingoManager.Views
{
    /// <summary>
    /// Interaction logic for BallsPanelView.xaml
    /// </summary>
    public partial class BallsPanelView : UserControl
    {
        public BallsPanelView()
        {
            InitializeComponent();
            App.PlaycardViewModel.GameBalls.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(GameBalls_CollectionChanged);
        }

        void GameBalls_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (PlayingModel i in e.NewItems)
                {
                    
                    Grid _gameball = new Grid();
                    _gameball.Margin = new Thickness(5, 0, 0, 0);
                    Ellipse _ellipse = new Ellipse();
                    _ellipse.Fill = (Brush)App.Current.FindResource("OrangeBackgroundBrush");
                    _ellipse.Width = 20;
                    _ellipse.Height = 20;
                    TextBlock textblock = new TextBlock();
                    textblock.Style = (Style)App.Current.FindResource("mediumTextBoxHeaderStyle");
                    textblock.Text = i.B.Number.ToString();
                    _gameball.Children.Add(_ellipse);
                    _gameball.Children.Add(textblock);
                    GameBallsPanel.Children.Add(_gameball);
                }
            }

            if (e.OldItems != null)
            {
                if (e.OldItems.Count > 0)
                {
                    GameBallsPanel.Children.Clear();
                }
            }
        }

               
    }
}
