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
using System.Windows.Markup;

using BingoManager.SystemManager.Repository;
using BingoManager.SystemManager.Model;

namespace BingoManager.Reports
{
    /// <summary>
    /// Interaction logic for WinningCardsReport.xaml
    /// </summary>
    public partial class WinningCardsReport : Window
    {
        public WinningCardsReport()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(WinningCardsReport_Loaded);
            this.Closing += new System.ComponentModel.CancelEventHandler(WinningCardsReport_Closing);
        }

        void WinningCardsReport_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DialogResult = true;
        }

        void WinningCardsReport_Loaded(object sender, RoutedEventArgs e)
        {
            StackPanel panel = null;
            int ctr = 1; int pagecount = 1;
            var winningcardsOderedQuery = from wc in WinningCardsRepository.Cards orderby wc.CardNumber select wc;
            var groupquery = from i in winningcardsOderedQuery
                             group i by i.GameName into grps
                             orderby grps.Key
                             select grps;
            foreach (var winningcard in groupquery)
            {
                if (panel == null)
                {
                    panel = GetPanelInstance();
                }
                TextBlock _textGame = new TextBlock();
                _textGame.Margin = new Thickness(96 * 0.02,0,0,0);
                _textGame.Width = 200;
                _textGame.FontSize = 20; _textGame.FontWeight = FontWeights.DemiBold;
                _textGame.Text = winningcard.Key;
                panel.Children.Add(_textGame);
                WrapPanel childdetailpanel = new WrapPanel() { Orientation = Orientation.Horizontal, Width = document.DocumentPaginator.PageSize.Width - 96 };
               
                foreach (var wc in winningcard)
                {
                                       
                   
                    TextBlock _textCardNum = new TextBlock();
                    //  _textCardNum.Margin = new Thickness(96 * 0.2);
                    _textCardNum.Width = 100;
                    _textCardNum.FontSize = 18;
                  //  TextBlock _textGame = new TextBlock();
                    // _textGame.Margin = new Thickness(96 * 0.2);
                  //  _textGame.Width = 200;
                    //_textGame.FontSize = 20;
                    //TextBlock _textPrize = new TextBlock();
                    //// _textPrice.Margin = new Thickness(96 * 0.2);
                    //_textPrize.Width = 150;
                    //_textPrize.FontSize = 20;
                    _textCardNum.Text = Microsoft.VisualBasic.Strings.Format(wc.CardNumber, "000000");
                   // _textGame.Text = wc.GameName;
                    //_textPrize.Text = Microsoft.VisualBasic.Strings.FormatCurrency(wc.Prize);
                    if (childdetailpanel == null)
                    {
                        childdetailpanel = new WrapPanel() { Orientation = Orientation.Horizontal, Width = document.DocumentPaginator.PageSize.Width - 96};//, Height = document.DocumentPaginator.PageSize.Height - 96*2 };
                       
                    }
                    childdetailpanel.Children.Add(_textCardNum);// childdetailpanel.Children.Add(_textGame); //childdetailpanel.Children.Add(_textPrize);
                    if (panel == null)
                    {
                        panel = GetPanelInstance();

                    }
                    
                    ctr++;
                    if (ctr == 260)
                    {
                        panel.Children.Add(childdetailpanel);
                        FixedPage fixedpage = new FixedPage();
                        TextBlock pagenumberText = new TextBlock() { Text = "Page " + pagecount.ToString(), Margin = new Thickness(document.DocumentPaginator.PageSize.Width - 70, 15, 15, 0), FontStyle = FontStyles.Italic, Foreground = Brushes.LightGray };
                        fixedpage.Children.Add(pagenumberText);
                        fixedpage.Children.Add(panel);
                        PageContent page = new PageContent();
                        ((IAddChild)page).AddChild(fixedpage);
                        document.Pages.Add(page);
                        panel = null;
                        childdetailpanel = null;
                        ctr = 1;
                        pagecount++;
                    }

                }
               
          
                 if (panel != null && ctr > 1)
                    {
                        panel.Children.Add(childdetailpanel);
                        TextBlock line = new TextBlock() { Text = "---------------------------------------------------------------------------------------------------------------------" };
                        TextBlock lineText = new TextBlock() { Text = "Total ticket count:" };

                        StackPanel footerpanel = new StackPanel() { Orientation = Orientation.Horizontal };
                        // TextBlock prizeText = new TextBlock() { Text = Microsoft.VisualBasic.Strings.FormatCurrency(winningcard.First().Prize), FontSize = 20, HorizontalAlignment = System.Windows.HorizontalAlignment.Right, Margin = new Thickness(96 * 0.05, 96 * 0.2, 96 * 0.2, 96 * 0.2) };
                        TextBlock countText = new TextBlock() { Text = Microsoft.VisualBasic.Strings.FormatNumber(winningcard.Count(), 0), HorizontalAlignment = System.Windows.HorizontalAlignment.Left, Margin = new Thickness(96 * 1, 0, 0, 0) };
                        footerpanel.Children.Add(lineText);
                        footerpanel.Children.Add(countText); //
                        panel.Children.Add(line);
                        panel.Children.Add(footerpanel);
                     FixedPage fixedpage = new FixedPage();
                        TextBlock pagenumberText = new TextBlock() { Text = "Page " + pagecount.ToString(), Margin = new Thickness(document.DocumentPaginator.PageSize.Width - 70, 15, 15, 0), FontStyle = FontStyles.Italic, Foreground = Brushes.LightGray };
                        fixedpage.Children.Add(pagenumberText);

                        fixedpage.Children.Add(panel);
                        PageContent page = new PageContent();
                        ((IAddChild)page).AddChild(fixedpage);
                        document.Pages.Add(page);
                        panel = null;
                    }
                 if (panel != null)
                 {
                    
                 }
            }
           

        }

        StackPanel GetPanelInstance()
        {
          StackPanel  panel = new StackPanel() { Orientation = Orientation.Vertical, Margin = new Thickness(96 * 0.5, 96 * 0.3, 96 * 0.5, 96 * .5) };
            TextBlock headerText = new TextBlock() { Text = "List of winning card(s)", FontSize = 30, Foreground = System.Windows.Media.Brushes.Blue, Width = document.DocumentPaginator.PageSize.Width  -96 ,TextAlignment = TextAlignment.Center};
            TextBlock dateText = new TextBlock() { Text = System.DateTime.Now.ToString("MMM. dd, yyyy"), Width=document.DocumentPaginator.PageSize.Width -96, FontSize = 18, Foreground = System.Windows.Media.Brushes.Gray, TextAlignment = TextAlignment.Center };
            panel.Children.Add(headerText);
            panel.Children.Add(dateText);
            //StackPanel stack = new StackPanel();
            //TextBlock gamenameText = new TextBlock() { Text = winningcard.Key.ToString() };
            //gamenameText.FontSize = 20; gamenameText.FontWeight = FontWeights.DemiBold;
            //stack.Children.Add(gamenameText);
            //panel.Children.Add(stack);

           // StackPanel childpanel = new StackPanel();
           // childpanel.Orientation = Orientation.Horizontal;
           // //childpanel.Margin = new Thickness(96);
           // TextBlock cardheader = new TextBlock() { Text = "Card Number"};
           // TextBlock cardgame = new TextBlock() { Text = "Game" };
           //// TextBlock cardprize = new TextBlock() { Text = "Prize" };
           // cardheader.Margin = new Thickness(96 * 0.05, 96 * 0.2, 96 * 0.2, 96 * 0.2);
           // cardheader.Width = 121;
           // cardheader.FontSize = 20; //cardheader.FontWeight = FontWeights.DemiBold;
           // cardgame.Margin = new Thickness(96 * 0.05, 96 * 0.2, 96 * 0.2, 96 * 0.2);
           // cardgame.Width = 200;
           // cardgame.FontSize = 20; //cardgame.FontWeight = FontWeights.DemiBold;
           //// cardprize.Margin = new Thickness(96 * 0.05, 96 * 0.2, 96 * 0.2, 96 * 0.2);
           //// cardprize.Width = 120;
           //// cardprize.FontSize = 20; //cardprice.FontWeight = FontWeights.DemiBold;
           // childpanel.Children.Add(cardheader); childpanel.Children.Add(cardgame);// childpanel.Children.Add(cardprize);
           // panel.Children.Add(childpanel);
            return panel;
        }
    }
}
