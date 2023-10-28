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

using System.Collections.ObjectModel;
using System.Windows.Markup;

using BingoManager.SystemManager.Model;
using BingoManager.SystemManager.Common;

namespace BingoManager.Reports
{
    /// <summary>
    /// Interaction logic for ReportView.xaml
    /// </summary>
    public partial class ReportView : Window
    {
        public ReportView()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(ReportView_Loaded);
        }

        public long Card1StartPage
        { get; set; }

        public long Card2StartPage
        { get; set; }

        public long Card3StartPage
        { get; set; }

        public long Card4StartPage
        { get; set; }

        public long Card5StartPage
        { get; set; }

        public long Card6StartPage
        { get; set; }

        public long Card7StartPage
        { get; set; }

        public long Card8StartPage
        { get; set; }

        public long Card9StartPage
        { get; set; }

        public long Card10StartPage
        { get; set; }

        public long Card11StartPage
        { get; set; }

        public long Card12StartPage
        { get; set; }

        void ReportView_Loaded(object sender, RoutedEventArgs e)
        {
            FixedPage page = null;
            StackPanel panel = null;
            ReportPages.DocumentPaginator.PageSize = new Size(96 * 16.54, 96 * 11.69);
            int countdown;
            for (countdown = 0; countdown <= 1249; countdown++)
            {
                var query = from i in App.PlaycardViewModel.PlayingCards where i.SerialNumber == Card1StartPage - countdown select i;

                foreach (PlayingCard pc in query)
                {
                    if (page == null)
                    { page = new FixedPage() { Width = ReportPages.DocumentPaginator.PageSize.Width, Height = ReportPages.DocumentPaginator.PageSize.Height }; }
                    int i;
                    for (i = 0; i <= 4; i++)
                    {
                        if (panel == null)
                        {


                            panel = new StackPanel() { Orientation = Orientation.Vertical, Margin = new Thickness(5, 5, 65, 35), Width=96*4, Height=96*3.8};
                            //StackPanel panelChild = new StackPanel() { Orientation = Orientation.Horizontal };
                            //TextBlock Btext = new TextBlock() { Text = "B", Width = 75, FontSize = 70, FontWeight = FontWeights.Bold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                            //TextBlock Itext = new TextBlock() { Text = "I", Width = 70, FontSize = 70, FontWeight = FontWeights.Bold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                            //Grid grid = new Grid();
                            //TextBlock Ntext = new TextBlock() { Text = "N", Width = 70, FontSize = 70, FontWeight = FontWeights.Bold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                            //grid.Children.Add(Ntext);
                            TextBlock cNumbertext = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.SerialNumber, "000000"), Background = Brushes.White, Width = 95, Height = 40, FontSize = 25, Foreground = Brushes.Red, VerticalAlignment = System.Windows.VerticalAlignment.Center, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.TicketNumberFont) };
                            //grid.Children.Add(cNumbertext);
                            //TextBlock Gtext = new TextBlock() { Text = "G", Width = 75, FontSize = 70, FontWeight = FontWeights.Bold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                            //TextBlock Otext = new TextBlock() { Text = "O", Width = 75, FontSize = 70, FontWeight = FontWeights.Bold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                            //panelChild.Children.Add(Btext); panelChild.Children.Add(Itext); panelChild.Children.Add(grid); panelChild.Children.Add(Gtext); panelChild.Children.Add(Otext);
                            panel.Children.Add(cNumbertext);
                        }
                        StackPanel numberpanel = new StackPanel() { Orientation = Orientation.Horizontal, HorizontalAlignment= System.Windows.HorizontalAlignment.Center };
                        TextBlock Bnumber = new TextBlock() { TextAlignment = System.Windows.TextAlignment.Center, Text = Microsoft.VisualBasic.Strings.Format(pc.B[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        TextBlock Inumber = new TextBlock() { TextAlignment = System.Windows.TextAlignment.Center, Text = Microsoft.VisualBasic.Strings.Format(pc.I[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        TextBlock Nnumber = new TextBlock() { TextAlignment = System.Windows.TextAlignment.Center, Text = Microsoft.VisualBasic.Strings.Format(pc.N[i].Number, "00"), Width = 80, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };

                        TextBlock Gnumber = new TextBlock() { TextAlignment = System.Windows.TextAlignment.Center, Text = Microsoft.VisualBasic.Strings.Format(pc.G[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        TextBlock Onumber = new TextBlock() { TextAlignment = System.Windows.TextAlignment.Center, Text = Microsoft.VisualBasic.Strings.Format(pc.O[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        numberpanel.Children.Add(Bnumber); numberpanel.Children.Add(Inumber);
                        if (pc.N[i].Number == 0)
                        {
                            TextBlock highBingoText = new TextBlock() { Text = pc.HighBingo.Number.ToString(), FontWeight = FontWeights.Bold, FontSize = 30, FontStyle = FontStyles.Oblique, HorizontalAlignment = System.Windows.HorizontalAlignment.Left, VerticalAlignment = System.Windows.VerticalAlignment.Top, Margin= new Thickness(10,0,0,0) };
                            TextBlock lowBingoText = new TextBlock() { Text = pc.LowBingo.Number.ToString(), FontWeight = FontWeights.Bold, FontSize = 30, FontStyle = FontStyles.Oblique, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, VerticalAlignment= System.Windows.VerticalAlignment.Bottom, TextAlignment =TextAlignment.Left };
                            TextBlock freeText = new TextBlock() { Text = "FREE" , Foreground = Brushes.LightGray, FontWeight = FontWeights.DemiBold, FontSize = 29, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, VerticalAlignment = System.Windows.VerticalAlignment.Center, TextAlignment = TextAlignment.Center };
                            Border border = new Border() { Height = 60, Width = 60, Margin = new Thickness(0, 0, 10, 0), CornerRadius = new CornerRadius(30), Background = Brushes.LightSkyBlue, HorizontalAlignment = System.Windows.HorizontalAlignment.Center };
                            Grid inpanel = new Grid();
                            inpanel.Children.Add(freeText);
                            inpanel.Children.Add(highBingoText);
                            inpanel.Children.Add(lowBingoText);
                            border.Child = inpanel;

                            numberpanel.Children.Add(border);
                        }
                        else
                        {
                            numberpanel.Children.Add(Nnumber);
                        }

                        numberpanel.Children.Add(Gnumber); numberpanel.Children.Add(Onumber);
                        panel.Children.Add(numberpanel);
                        if (i == 4)
                        {
                            TextBlock controlnumber = new TextBlock() { Text = pc.ControlCardNumber.ToString(), Margin = new Thickness(0,0,45,0), HorizontalAlignment = System.Windows.HorizontalAlignment.Right, FontWeight = FontWeights.Bold, FontSize = 20, FontFamily = new FontFamily(AppSettings.TicketNumberFont) };
                            panel.Children.Add(controlnumber);
                            page.Children.Add(panel); panel = null;
                        }
                       

                    }
                }
                var query2 = from i2 in App.PlaycardViewModel.PlayingCards where i2.SerialNumber == Card2StartPage - countdown select i2;

                foreach (PlayingCard pc in query2)
                {
                    int i;
                    for (i = 0; i <= 4; i++)
                    {
                        if (panel == null)
                        {
                            panel = new StackPanel() { Orientation = Orientation.Vertical, Margin = new Thickness(96*4 +5, 5, 65, 35), Width = 96 * 4, Height = 96 * 3.8 };
                            //StackPanel panelChild = new StackPanel() { Orientation = Orientation.Horizontal };
                            //TextBlock Btext = new TextBlock() { Text = "B", Width = 75, FontSize = 70, FontWeight = FontWeights.Bold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                            //TextBlock Itext = new TextBlock() { Text = "I", Width = 70, FontSize = 70, FontWeight = FontWeights.Bold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                            //Grid grid = new Grid();
                            //TextBlock Ntext = new TextBlock() { Text = "N", Width = 70, FontSize = 70, FontWeight = FontWeights.Bold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                            //grid.Children.Add(Ntext);
                            TextBlock cNumbertext = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.SerialNumber, "000000"), Background = Brushes.White, Width = 95, Height = 40, FontSize = 25, Foreground = Brushes.Red, VerticalAlignment = System.Windows.VerticalAlignment.Center, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.TicketNumberFont) };
                            //grid.Children.Add(cNumbertext);
                            //TextBlock Gtext = new TextBlock() { Text = "G", Width = 75, FontSize = 70, FontWeight = FontWeights.Bold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                            //TextBlock Otext = new TextBlock() { Text = "O", Width = 75, FontSize = 70, FontWeight = FontWeights.Bold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                            //panelChild.Children.Add(Btext); panelChild.Children.Add(Itext); panelChild.Children.Add(grid); panelChild.Children.Add(Gtext); panelChild.Children.Add(Otext);
                            panel.Children.Add(cNumbertext);
                        }
                        StackPanel numberpanel = new StackPanel() { Orientation = Orientation.Horizontal, HorizontalAlignment = System.Windows.HorizontalAlignment.Center };
                        TextBlock Bnumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.B[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        TextBlock Inumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.I[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        TextBlock Nnumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.N[i].Number, "00"), Width = 80, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };

                        TextBlock Gnumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.G[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        TextBlock Onumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.O[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        numberpanel.Children.Add(Bnumber); numberpanel.Children.Add(Inumber);
                        if (pc.N[i].Number == 0)
                        {
                            TextBlock highBingoText = new TextBlock() { Text = pc.HighBingo.Number.ToString(), FontWeight = FontWeights.Bold, FontSize = 30, FontStyle = FontStyles.Oblique, HorizontalAlignment = System.Windows.HorizontalAlignment.Left, VerticalAlignment = System.Windows.VerticalAlignment.Top, Margin = new Thickness(10, 0, 0, 0) };
                            TextBlock lowBingoText = new TextBlock() { Text = pc.LowBingo.Number.ToString(), FontWeight = FontWeights.Bold, FontSize = 30, FontStyle = FontStyles.Oblique, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, VerticalAlignment = System.Windows.VerticalAlignment.Bottom, TextAlignment = TextAlignment.Left };
                            TextBlock freeText = new TextBlock() { Text = "FREE", Foreground = Brushes.LightGray, FontWeight = FontWeights.DemiBold, FontSize = 29, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, VerticalAlignment = System.Windows.VerticalAlignment.Center, TextAlignment = TextAlignment.Center };
                            Border border = new Border() { Height = 60, Width = 60, Margin = new Thickness(0, 0, 10, 0), CornerRadius = new CornerRadius(30), Background = Brushes.LightSkyBlue, HorizontalAlignment = System.Windows.HorizontalAlignment.Center };
                            Grid inpanel = new Grid();
                            inpanel.Children.Add(freeText);
                            inpanel.Children.Add(highBingoText);
                            inpanel.Children.Add(lowBingoText);
                            border.Child = inpanel;

                            numberpanel.Children.Add(border);
                        }
                        else
                        {
                            numberpanel.Children.Add(Nnumber);
                        }

                        numberpanel.Children.Add(Gnumber); numberpanel.Children.Add(Onumber);
                        panel.Children.Add(numberpanel);
                        if (i == 4)
                        {
                            TextBlock controlnumber = new TextBlock() { Text = pc.ControlCardNumber.ToString(), Margin = new Thickness(0, 0, 45, 0), HorizontalAlignment = System.Windows.HorizontalAlignment.Right, FontWeight = FontWeights.Bold, FontSize = 20, FontFamily = new FontFamily(AppSettings.TicketNumberFont) };
                            panel.Children.Add(controlnumber);
                            page.Children.Add(panel); panel = null;
                        }
                       
                    }
                }

                var query3 = from i3 in App.PlaycardViewModel.PlayingCards where i3.SerialNumber == Card3StartPage - countdown select i3;

                foreach (PlayingCard pc in query3)
                {
                    int i;
                    for (i = 0; i <= 4; i++)
                    {
                        if (panel == null)
                        {
                            panel = new StackPanel() { Orientation = Orientation.Vertical, Margin = new Thickness((96 * 4 *2) + 5, 5, 65, 35), Width = 96 * 4, Height = 96 * 3.8 };
                            //StackPanel panelChild = new StackPanel() { Orientation = Orientation.Horizontal };
                            //TextBlock Btext = new TextBlock() { Text = "B", Width = 75, FontSize = 70, FontWeight = FontWeights.Bold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily("Century Gothic") };
                            //TextBlock Itext = new TextBlock() { Text = "I", Width = 70, FontSize = 70, FontWeight = FontWeights.Bold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily("Century Gothic") };
                            //Grid grid = new Grid();
                            //TextBlock Ntext = new TextBlock() { Text = "N", Width = 70, FontSize = 70, FontWeight = FontWeights.Bold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily("Century Gothic") };
                            //grid.Children.Add(Ntext);
                            TextBlock cNumbertext = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.SerialNumber, "000000"), Background = Brushes.White, Width = 95, Height = 40, FontSize = 25, Foreground = Brushes.Red, VerticalAlignment = System.Windows.VerticalAlignment.Center, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.TicketNumberFont) };
                            //grid.Children.Add(cNumbertext);
                            //TextBlock Gtext = new TextBlock() { Text = "G", Width = 75, FontSize = 70, FontWeight = FontWeights.Bold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily("Century Gothic") };
                            //TextBlock Otext = new TextBlock() { Text = "O", Width = 75, FontSize = 70, FontWeight = FontWeights.Bold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily("Century Gothic") };
                            //panelChild.Children.Add(Btext); panelChild.Children.Add(Itext); panelChild.Children.Add(grid); panelChild.Children.Add(Gtext); panelChild.Children.Add(Otext);
                            panel.Children.Add(cNumbertext);
                        }
                        StackPanel numberpanel = new StackPanel() { Orientation = Orientation.Horizontal, HorizontalAlignment = System.Windows.HorizontalAlignment.Center };
                        TextBlock Bnumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.B[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        TextBlock Inumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.I[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        TextBlock Nnumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.N[i].Number, "00"), Width = 80, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };

                        TextBlock Gnumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.G[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        TextBlock Onumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.O[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        numberpanel.Children.Add(Bnumber); numberpanel.Children.Add(Inumber);
                        if (pc.N[i].Number == 0)
                        {
                            TextBlock highBingoText = new TextBlock() { Text = pc.HighBingo.Number.ToString(), FontWeight = FontWeights.Bold, FontSize = 30, FontStyle = FontStyles.Oblique, HorizontalAlignment = System.Windows.HorizontalAlignment.Left, VerticalAlignment = System.Windows.VerticalAlignment.Top, Margin = new Thickness(10, 0, 0, 0) };
                            TextBlock lowBingoText = new TextBlock() { Text = pc.LowBingo.Number.ToString(), FontWeight = FontWeights.Bold, FontSize = 30, FontStyle = FontStyles.Oblique, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, VerticalAlignment = System.Windows.VerticalAlignment.Bottom, TextAlignment = TextAlignment.Left };
                            TextBlock freeText = new TextBlock() { Text = "FREE", Foreground = Brushes.LightGray, FontWeight = FontWeights.DemiBold, FontSize = 29, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, VerticalAlignment = System.Windows.VerticalAlignment.Center, TextAlignment = TextAlignment.Center };
                            Border border = new Border() { Height = 60, Width = 60, Margin = new Thickness(0, 0, 10, 0), CornerRadius = new CornerRadius(30), Background = Brushes.LightSkyBlue, HorizontalAlignment = System.Windows.HorizontalAlignment.Center };
                            Grid inpanel = new Grid();
                            inpanel.Children.Add(freeText);
                            inpanel.Children.Add(highBingoText);
                            inpanel.Children.Add(lowBingoText);
                            border.Child = inpanel;

                            numberpanel.Children.Add(border);
                        }
                        else
                        {
                            numberpanel.Children.Add(Nnumber);
                        }

                        numberpanel.Children.Add(Gnumber); numberpanel.Children.Add(Onumber);
                        panel.Children.Add(numberpanel);
                        if (i == 4)
                        {
                            TextBlock controlnumber = new TextBlock() { Text = pc.ControlCardNumber.ToString(), Margin = new Thickness(0, 0, 45, 0), HorizontalAlignment = System.Windows.HorizontalAlignment.Right, FontWeight = FontWeights.Bold, FontSize = 20, FontFamily = new FontFamily(AppSettings.TicketNumberFont) };
                            panel.Children.Add(controlnumber);
                            page.Children.Add(panel); panel = null;
                        }
                        
                    }
                }
                var query4 = from i4 in App.PlaycardViewModel.PlayingCards where i4.SerialNumber == Card4StartPage - countdown select i4;

                foreach (PlayingCard pc in query4)
                {
                    int i;
                    for (i = 0; i <= 4; i++)
                    {
                        if (panel == null)
                        {
                            panel = new StackPanel() { Orientation = Orientation.Vertical, Margin = new Thickness((96 * 4 *3) + 5, 5, 65, 35), Width = 96 * 4, Height = 96 * 3.8 };
                            //StackPanel panelChild = new StackPanel() { Orientation = Orientation.Horizontal };
                            //TextBlock Btext = new TextBlock() { Text = "B", Width = 75, FontSize = 70, FontWeight = FontWeights.Bold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily("Century Gothic") };
                            //TextBlock Itext = new TextBlock() { Text = "I", Width = 70, FontSize = 70, FontWeight = FontWeights.Bold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily("Century Gothic") };
                            //Grid grid = new Grid();
                            //TextBlock Ntext = new TextBlock() { Text = "N", Width = 70, FontSize = 70, FontWeight = FontWeights.Bold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily("Century Gothic") };
                            //grid.Children.Add(Ntext);
                            TextBlock cNumbertext = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.SerialNumber, "000000"), Background = Brushes.White, Width = 95, Height = 40, FontSize = 25, Foreground = Brushes.Red, VerticalAlignment = System.Windows.VerticalAlignment.Center, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.TicketNumberFont) };
                            //grid.Children.Add(cNumbertext);
                            //TextBlock Gtext = new TextBlock() { Text = "G", Width = 75, FontSize = 70, FontWeight = FontWeights.Bold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily("Century Gothic") };
                            //TextBlock Otext = new TextBlock() { Text = "O", Width = 75, FontSize = 70, FontWeight = FontWeights.Bold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily("Century Gothic") };
                            //panelChild.Children.Add(Btext); panelChild.Children.Add(Itext); panelChild.Children.Add(grid); panelChild.Children.Add(Gtext); panelChild.Children.Add(Otext);
                            panel.Children.Add(cNumbertext);
                        }
                        StackPanel numberpanel = new StackPanel() { Orientation = Orientation.Horizontal, HorizontalAlignment = System.Windows.HorizontalAlignment.Center };
                        TextBlock Bnumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.B[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        TextBlock Inumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.I[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        TextBlock Nnumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.N[i].Number, "00"), Width = 80, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };

                        TextBlock Gnumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.G[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        TextBlock Onumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.O[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        numberpanel.Children.Add(Bnumber); numberpanel.Children.Add(Inumber);
                        if (pc.N[i].Number == 0)
                        {
                            TextBlock highBingoText = new TextBlock() { Text = pc.HighBingo.Number.ToString(), FontWeight = FontWeights.Bold, FontSize = 30, FontStyle = FontStyles.Oblique, HorizontalAlignment = System.Windows.HorizontalAlignment.Left, VerticalAlignment = System.Windows.VerticalAlignment.Top, Margin = new Thickness(10, 0, 0, 0) };
                            TextBlock lowBingoText = new TextBlock() { Text = pc.LowBingo.Number.ToString(), FontWeight = FontWeights.Bold, FontSize = 30, FontStyle = FontStyles.Oblique, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, VerticalAlignment = System.Windows.VerticalAlignment.Bottom, TextAlignment = TextAlignment.Left };
                            TextBlock freeText = new TextBlock() { Text = "FREE", Foreground = Brushes.LightGray, FontWeight = FontWeights.DemiBold, FontSize = 29, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, VerticalAlignment = System.Windows.VerticalAlignment.Center, TextAlignment = TextAlignment.Center };
                            Border border = new Border() { Height = 60, Width = 60, Margin = new Thickness(0, 0, 10, 0), CornerRadius = new CornerRadius(30), Background = Brushes.LightSkyBlue, HorizontalAlignment = System.Windows.HorizontalAlignment.Center };
                            Grid inpanel = new Grid();
                            inpanel.Children.Add(freeText);
                            inpanel.Children.Add(highBingoText);
                            inpanel.Children.Add(lowBingoText);
                            border.Child = inpanel;

                            numberpanel.Children.Add(border);
                        }
                        else
                        {
                            numberpanel.Children.Add(Nnumber);
                        }

                        numberpanel.Children.Add(Gnumber); numberpanel.Children.Add(Onumber);
                        panel.Children.Add(numberpanel);
                        if (i == 4)
                        {
                            TextBlock controlnumber = new TextBlock() { Text = pc.ControlCardNumber.ToString(), Margin = new Thickness(0, 0, 45, 0), HorizontalAlignment = System.Windows.HorizontalAlignment.Right, FontWeight = FontWeights.Bold, FontSize = 20, FontFamily = new FontFamily(AppSettings.TicketNumberFont) };
                            panel.Children.Add(controlnumber);
                            page.Children.Add(panel); panel = null;
                        }
                      
                    }
                }
                var query5 = from i in App.PlaycardViewModel.PlayingCards where i.SerialNumber == Card5StartPage - countdown select i;

                foreach (PlayingCard pc in query5)
                {
                    int i;
                    for (i = 0; i <= 4; i++)
                    {
                        if (panel == null)
                        {

                            panel = new StackPanel() { Orientation = Orientation.Vertical, Margin = new Thickness(5 , (96*3.8)+5, 65, 35), Width = 96 * 4, Height = 96 * 3.8 };
                            TextBlock cNumbertext = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.SerialNumber, "000000"), Background = Brushes.White, Width = 95, Height = 40, FontSize = 25, Foreground = Brushes.Red, VerticalAlignment = System.Windows.VerticalAlignment.Center, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.TicketNumberFont) };
                            panel.Children.Add(cNumbertext);

                        }
                        StackPanel numberpanel = new StackPanel() { Orientation = Orientation.Horizontal, HorizontalAlignment = System.Windows.HorizontalAlignment.Center };
                        TextBlock Bnumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.B[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        TextBlock Inumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.I[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        TextBlock Nnumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.N[i].Number, "00"), Width = 80, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };

                        TextBlock Gnumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.G[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        TextBlock Onumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.O[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        numberpanel.Children.Add(Bnumber); numberpanel.Children.Add(Inumber);
                        if (pc.N[i].Number == 0)
                        {
                            TextBlock highBingoText = new TextBlock() { Text = pc.HighBingo.Number.ToString(), FontWeight = FontWeights.Bold, FontSize = 30, FontStyle = FontStyles.Oblique, HorizontalAlignment = System.Windows.HorizontalAlignment.Left, VerticalAlignment = System.Windows.VerticalAlignment.Top, Margin = new Thickness(10, 0, 0, 0) };
                            TextBlock lowBingoText = new TextBlock() { Text = pc.LowBingo.Number.ToString(), FontWeight = FontWeights.Bold, FontSize = 30, FontStyle = FontStyles.Oblique, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, VerticalAlignment = System.Windows.VerticalAlignment.Bottom, TextAlignment = TextAlignment.Left };
                            TextBlock freeText = new TextBlock() { Text = "FREE", Foreground = Brushes.LightGray, FontWeight = FontWeights.DemiBold, FontSize = 29, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, VerticalAlignment = System.Windows.VerticalAlignment.Center, TextAlignment = TextAlignment.Center };
                            Border border = new Border() { Height = 60, Width = 60, Margin = new Thickness(0, 0, 10, 0), CornerRadius = new CornerRadius(30), Background = Brushes.LightSkyBlue, HorizontalAlignment = System.Windows.HorizontalAlignment.Center };
                            Grid inpanel = new Grid();
                            inpanel.Children.Add(freeText);
                            inpanel.Children.Add(highBingoText);
                            inpanel.Children.Add(lowBingoText);
                            border.Child = inpanel;

                            numberpanel.Children.Add(border);
                        }
                        else
                        {
                            numberpanel.Children.Add(Nnumber);
                        }

                        numberpanel.Children.Add(Gnumber); numberpanel.Children.Add(Onumber);
                        panel.Children.Add(numberpanel);
                        if (i == 4)
                        {
                            TextBlock controlnumber = new TextBlock() { Text = pc.ControlCardNumber.ToString(), Margin = new Thickness(0, 0, 45, 0), HorizontalAlignment = System.Windows.HorizontalAlignment.Right, FontWeight = FontWeights.Bold, FontSize = 20, FontFamily = new FontFamily(AppSettings.TicketNumberFont) };
                            panel.Children.Add(controlnumber);
                            page.Children.Add(panel); panel = null;
                        }
                        
                    }
                }

                var query6 = from i in App.PlaycardViewModel.PlayingCards where i.SerialNumber == Card6StartPage - countdown select i;

                foreach (PlayingCard pc in query6)
                {
                    int i;
                    for (i = 0; i <= 4; i++)
                    {
                        if (panel == null)
                        {
                            panel = new StackPanel() { Orientation = Orientation.Vertical, Margin = new Thickness((96*4)+5, (96*3.8) + 5, 65, 35), Width = 96 * 4, Height = 96 * 3.8 };
                            TextBlock cNumbertext = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.SerialNumber, "000000"), Background = Brushes.White, Width = 95, Height = 40, FontSize = 25, Foreground = Brushes.Red, VerticalAlignment = System.Windows.VerticalAlignment.Center, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.TicketNumberFont) };
                            panel.Children.Add(cNumbertext);
                        }
                        StackPanel numberpanel = new StackPanel() { Orientation = Orientation.Horizontal, HorizontalAlignment = System.Windows.HorizontalAlignment.Center };
                        TextBlock Bnumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.B[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        TextBlock Inumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.I[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        TextBlock Nnumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.N[i].Number, "00"), Width = 80, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };

                        TextBlock Gnumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.G[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        TextBlock Onumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.O[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        numberpanel.Children.Add(Bnumber); numberpanel.Children.Add(Inumber);
                        if (pc.N[i].Number == 0)
                        {
                            TextBlock highBingoText = new TextBlock() { Text = pc.HighBingo.Number.ToString(), FontWeight = FontWeights.Bold, FontSize = 30, FontStyle = FontStyles.Oblique, HorizontalAlignment = System.Windows.HorizontalAlignment.Left, VerticalAlignment = System.Windows.VerticalAlignment.Top, Margin = new Thickness(10, 0, 0, 0) };
                            TextBlock lowBingoText = new TextBlock() { Text = pc.LowBingo.Number.ToString(), FontWeight = FontWeights.Bold, FontSize = 30, FontStyle = FontStyles.Oblique, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, VerticalAlignment = System.Windows.VerticalAlignment.Bottom, TextAlignment = TextAlignment.Left };
                            TextBlock freeText = new TextBlock() { Text = "FREE", Foreground = Brushes.LightGray, FontWeight = FontWeights.DemiBold, FontSize = 29, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, VerticalAlignment = System.Windows.VerticalAlignment.Center, TextAlignment = TextAlignment.Center };
                            Border border = new Border() { Height = 60, Width = 60, Margin = new Thickness(0, 0, 10, 0), CornerRadius = new CornerRadius(30), Background = Brushes.LightSkyBlue, HorizontalAlignment = System.Windows.HorizontalAlignment.Center };
                            Grid inpanel = new Grid();
                            inpanel.Children.Add(freeText);
                            inpanel.Children.Add(highBingoText);
                            inpanel.Children.Add(lowBingoText);
                            border.Child = inpanel;

                            numberpanel.Children.Add(border);
                        }
                        else
                        {
                            numberpanel.Children.Add(Nnumber);
                        }

                        numberpanel.Children.Add(Gnumber); numberpanel.Children.Add(Onumber);
                        panel.Children.Add(numberpanel);
                        if (i == 4)
                        {
                            TextBlock controlnumber = new TextBlock() { Text = pc.ControlCardNumber.ToString(), Margin = new Thickness(0, 0, 45, 0), HorizontalAlignment = System.Windows.HorizontalAlignment.Right, FontWeight = FontWeights.Bold, FontSize = 20, FontFamily = new FontFamily(AppSettings.TicketNumberFont) };
                            panel.Children.Add(controlnumber);
                            page.Children.Add(panel); panel = null;
                        }
                       
                    }
                }

                var query7 = from i in App.PlaycardViewModel.PlayingCards where i.SerialNumber == Card7StartPage - countdown select i;

                foreach (PlayingCard pc in query7)
                {
                    int i;
                    for (i = 0; i <= 4; i++)
                    {
                        if (panel == null)
                        {

                          panel = new StackPanel() { Orientation = Orientation.Vertical, Margin = new Thickness((96*4*2)+5, (96 * 3.8) + 5, 65, 35), Width = 96 * 4, Height = 96 * 3.8 };
                          TextBlock cNumbertext = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.SerialNumber, "000000"), Background = Brushes.White, Width = 95, Height = 40, FontSize = 25, Foreground = Brushes.Red, VerticalAlignment = System.Windows.VerticalAlignment.Center, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.TicketNumberFont) };
                          panel.Children.Add(cNumbertext);
                        }
                        StackPanel numberpanel = new StackPanel() { Orientation = Orientation.Horizontal, HorizontalAlignment = System.Windows.HorizontalAlignment.Center };
                        TextBlock Bnumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.B[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        TextBlock Inumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.I[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        TextBlock Nnumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.N[i].Number, "00"), Width = 80, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };

                        TextBlock Gnumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.G[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        TextBlock Onumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.O[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        numberpanel.Children.Add(Bnumber); numberpanel.Children.Add(Inumber);
                        if (pc.N[i].Number == 0)
                        {
                            TextBlock highBingoText = new TextBlock() { Text = pc.HighBingo.Number.ToString(), FontWeight = FontWeights.Bold, FontSize = 30, FontStyle = FontStyles.Oblique, HorizontalAlignment = System.Windows.HorizontalAlignment.Left, VerticalAlignment = System.Windows.VerticalAlignment.Top, Margin = new Thickness(10, 0, 0, 0) };
                            TextBlock lowBingoText = new TextBlock() { Text = pc.LowBingo.Number.ToString(), FontWeight = FontWeights.Bold, FontSize = 30, FontStyle = FontStyles.Oblique, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, VerticalAlignment = System.Windows.VerticalAlignment.Bottom, TextAlignment = TextAlignment.Left };
                            TextBlock freeText = new TextBlock() { Text = "FREE", Foreground = Brushes.LightGray, FontWeight = FontWeights.DemiBold, FontSize = 29, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, VerticalAlignment = System.Windows.VerticalAlignment.Center, TextAlignment = TextAlignment.Center };
                            Border border = new Border() { Height = 60, Width = 60, Margin = new Thickness(0, 0, 10, 0), CornerRadius = new CornerRadius(30), Background = Brushes.LightSkyBlue, HorizontalAlignment = System.Windows.HorizontalAlignment.Center };
                            Grid inpanel = new Grid();
                            inpanel.Children.Add(freeText);
                            inpanel.Children.Add(highBingoText);
                            inpanel.Children.Add(lowBingoText);
                            border.Child = inpanel;

                            numberpanel.Children.Add(border);
                        }
                        else
                        {
                            numberpanel.Children.Add(Nnumber);
                        }

                        numberpanel.Children.Add(Gnumber); numberpanel.Children.Add(Onumber);
                        panel.Children.Add(numberpanel);
                        if (i == 4)
                        {
                            TextBlock controlnumber = new TextBlock() { Text = pc.ControlCardNumber.ToString(), Margin = new Thickness(0, 0, 45, 0), HorizontalAlignment = System.Windows.HorizontalAlignment.Right, FontWeight = FontWeights.Bold, FontSize = 20, FontFamily = new FontFamily(AppSettings.TicketNumberFont) };
                            panel.Children.Add(controlnumber);
                            page.Children.Add(panel); panel = null;
                        }
                        
                    }
                }

                var query8 = from i in App.PlaycardViewModel.PlayingCards where i.SerialNumber == Card8StartPage - countdown select i;

                foreach (PlayingCard pc in query8)
                {
                    int i;
                    for (i = 0; i <= 4; i++)
                    {
                        if (panel == null)
                        {
                              panel = new StackPanel() { Orientation = Orientation.Vertical, Margin = new Thickness((96*4*3)+5, (96 * 3.8) + 5, 65, 35), Width = 96 * 4, Height = 96 * 3.8 };
                              TextBlock cNumbertext = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.SerialNumber, "000000"), Background = Brushes.White, Width = 95, Height = 40, FontSize = 25, Foreground = Brushes.Red, VerticalAlignment = System.Windows.VerticalAlignment.Center, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.TicketNumberFont) };
                              panel.Children.Add(cNumbertext);
                        }
                        StackPanel numberpanel = new StackPanel() { Orientation = Orientation.Horizontal, HorizontalAlignment = System.Windows.HorizontalAlignment.Center };
                        TextBlock Bnumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.B[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        TextBlock Inumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.I[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        TextBlock Nnumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.N[i].Number, "00"), Width = 80, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };

                        TextBlock Gnumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.G[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        TextBlock Onumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.O[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        numberpanel.Children.Add(Bnumber); numberpanel.Children.Add(Inumber);
                        if (pc.N[i].Number == 0)
                        {
                            TextBlock highBingoText = new TextBlock() { Text = pc.HighBingo.Number.ToString(), FontWeight = FontWeights.Bold, FontSize = 30, FontStyle = FontStyles.Oblique, HorizontalAlignment = System.Windows.HorizontalAlignment.Left, VerticalAlignment = System.Windows.VerticalAlignment.Top, Margin = new Thickness(10, 0, 0, 0) };
                            TextBlock lowBingoText = new TextBlock() { Text = pc.LowBingo.Number.ToString(), FontWeight = FontWeights.Bold, FontSize = 30, FontStyle = FontStyles.Oblique, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, VerticalAlignment = System.Windows.VerticalAlignment.Bottom, TextAlignment = TextAlignment.Left };
                            TextBlock freeText = new TextBlock() { Text = "FREE", Foreground = Brushes.LightGray, FontWeight = FontWeights.DemiBold, FontSize = 29, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, VerticalAlignment = System.Windows.VerticalAlignment.Center, TextAlignment = TextAlignment.Center };
                            Border border = new Border() { Height = 60, Width = 60, Margin = new Thickness(0, 0, 10, 0), CornerRadius = new CornerRadius(30), Background = Brushes.LightSkyBlue, HorizontalAlignment = System.Windows.HorizontalAlignment.Center };
                            Grid inpanel = new Grid();
                            inpanel.Children.Add(freeText);
                            inpanel.Children.Add(highBingoText);
                            inpanel.Children.Add(lowBingoText);
                            border.Child = inpanel;

                            numberpanel.Children.Add(border);
                        }
                        else
                        {
                            numberpanel.Children.Add(Nnumber);
                        }

                        numberpanel.Children.Add(Gnumber); numberpanel.Children.Add(Onumber);
                        panel.Children.Add(numberpanel);
                        if (i == 4)
                        {
                            TextBlock controlnumber = new TextBlock() { Text = pc.ControlCardNumber.ToString(), Margin = new Thickness(0, 0, 45, 0), HorizontalAlignment = System.Windows.HorizontalAlignment.Right, FontWeight = FontWeights.Bold, FontSize = 20, FontFamily = new FontFamily(AppSettings.TicketNumberFont) };
                            panel.Children.Add(controlnumber);
                            page.Children.Add(panel); panel = null;
                        }
                       
                    }
                }

                var query9 = from i in App.PlaycardViewModel.PlayingCards where i.SerialNumber == Card9StartPage - countdown select i;

                foreach (PlayingCard pc in query9)
                {
                    int i;
                    for (i = 0; i <= 4; i++)
                    {
                        if (panel == null)
                        {
                             panel = new StackPanel() { Orientation = Orientation.Vertical, Margin = new Thickness(5, (96 * 3.8 * 2) + 5, 65, 35), Width = 96 * 4, Height = 96 * 3.8 };
                             TextBlock cNumbertext = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.SerialNumber, "000000"), Background = Brushes.White, Width = 95, Height = 40, FontSize = 25, Foreground = Brushes.Red, VerticalAlignment = System.Windows.VerticalAlignment.Center, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.TicketNumberFont) };
                             panel.Children.Add(cNumbertext);
                        }
                        StackPanel numberpanel = new StackPanel() { Orientation = Orientation.Horizontal, HorizontalAlignment = System.Windows.HorizontalAlignment.Center };
                        TextBlock Bnumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.B[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        TextBlock Inumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.I[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        TextBlock Nnumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.N[i].Number, "00"), Width = 80, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };

                        TextBlock Gnumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.G[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        TextBlock Onumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.O[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        numberpanel.Children.Add(Bnumber); numberpanel.Children.Add(Inumber);
                        if (pc.N[i].Number == 0)
                        {
                            TextBlock highBingoText = new TextBlock() { Text = pc.HighBingo.Number.ToString(), FontWeight = FontWeights.Bold, FontSize = 30, FontStyle = FontStyles.Oblique, HorizontalAlignment = System.Windows.HorizontalAlignment.Left, VerticalAlignment = System.Windows.VerticalAlignment.Top, Margin = new Thickness(10, 0, 0, 0) };
                            TextBlock lowBingoText = new TextBlock() { Text = pc.LowBingo.Number.ToString(), FontWeight = FontWeights.Bold, FontSize = 30, FontStyle = FontStyles.Oblique, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, VerticalAlignment = System.Windows.VerticalAlignment.Bottom, TextAlignment = TextAlignment.Left };
                            TextBlock freeText = new TextBlock() { Text = "FREE", Foreground = Brushes.LightGray, FontWeight = FontWeights.DemiBold, FontSize = 29, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, VerticalAlignment = System.Windows.VerticalAlignment.Center, TextAlignment = TextAlignment.Center };
                            Border border = new Border() { Height = 60, Width = 60, Margin = new Thickness(0, 0, 10, 0), CornerRadius = new CornerRadius(30), Background = Brushes.LightSkyBlue, HorizontalAlignment = System.Windows.HorizontalAlignment.Center };
                            Grid inpanel = new Grid();
                            inpanel.Children.Add(freeText);
                            inpanel.Children.Add(highBingoText);
                            inpanel.Children.Add(lowBingoText);
                            border.Child = inpanel;

                            numberpanel.Children.Add(border);
                        }
                        else
                        {
                            numberpanel.Children.Add(Nnumber);
                        }

                        numberpanel.Children.Add(Gnumber); numberpanel.Children.Add(Onumber);
                        panel.Children.Add(numberpanel);
                        if (i == 4)
                        {
                            TextBlock controlnumber = new TextBlock() { Text = pc.ControlCardNumber.ToString(), Margin = new Thickness(0, 0, 45, 0), HorizontalAlignment = System.Windows.HorizontalAlignment.Right, FontWeight = FontWeights.Bold, FontSize = 20, FontFamily = new FontFamily(AppSettings.TicketNumberFont) };
                            panel.Children.Add(controlnumber);
                            page.Children.Add(panel); panel = null;
                        }
                       
                    }
                }
                //card#9
                var query10 = from i in App.PlaycardViewModel.PlayingCards where i.SerialNumber == Card10StartPage - countdown select i;

                foreach (PlayingCard pc in query10)
                {
                    int i;
                    for (i = 0; i <= 4; i++)
                    {
                        if (panel == null)
                        {
                              panel = new StackPanel() { Orientation = Orientation.Vertical, Margin = new Thickness((96*4)+5, (96 * 3.8 *2) + 5, 65, 35), Width = 96 * 4, Height = 96 * 3.8 };
                              TextBlock cNumbertext = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.SerialNumber, "000000"), Background = Brushes.White, Width = 95, Height = 40, FontSize = 25, Foreground = Brushes.Red, VerticalAlignment = System.Windows.VerticalAlignment.Center, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.TicketNumberFont) };
                              panel.Children.Add(cNumbertext);
                        }
                        StackPanel numberpanel = new StackPanel() { Orientation = Orientation.Horizontal, HorizontalAlignment = System.Windows.HorizontalAlignment.Center };
                        TextBlock Bnumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.B[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        TextBlock Inumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.I[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        TextBlock Nnumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.N[i].Number, "00"), Width = 80, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };

                        TextBlock Gnumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.G[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        TextBlock Onumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.O[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        numberpanel.Children.Add(Bnumber); numberpanel.Children.Add(Inumber);
                        if (pc.N[i].Number == 0)
                        {
                            TextBlock highBingoText = new TextBlock() { Text = pc.HighBingo.Number.ToString(), FontWeight = FontWeights.Bold, FontSize = 30, FontStyle = FontStyles.Oblique, HorizontalAlignment = System.Windows.HorizontalAlignment.Left, VerticalAlignment = System.Windows.VerticalAlignment.Top, Margin = new Thickness(10, 0, 0, 0) };
                            TextBlock lowBingoText = new TextBlock() { Text = pc.LowBingo.Number.ToString(), FontWeight = FontWeights.Bold, FontSize = 30, FontStyle = FontStyles.Oblique, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, VerticalAlignment = System.Windows.VerticalAlignment.Bottom, TextAlignment = TextAlignment.Left };
                            TextBlock freeText = new TextBlock() { Text = "FREE", Foreground = Brushes.LightGray, FontWeight = FontWeights.DemiBold, FontSize = 29, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, VerticalAlignment = System.Windows.VerticalAlignment.Center, TextAlignment = TextAlignment.Center };
                            Border border = new Border() { Height = 60, Width = 60, Margin = new Thickness(0, 0, 10, 0), CornerRadius = new CornerRadius(30), Background = Brushes.LightSkyBlue, HorizontalAlignment = System.Windows.HorizontalAlignment.Center };
                            Grid inpanel = new Grid();
                            inpanel.Children.Add(freeText);
                            inpanel.Children.Add(highBingoText);
                            inpanel.Children.Add(lowBingoText);
                            border.Child = inpanel;

                            numberpanel.Children.Add(border);
                        }
                        else
                        {
                            numberpanel.Children.Add(Nnumber);
                        }

                        numberpanel.Children.Add(Gnumber); numberpanel.Children.Add(Onumber);
                        panel.Children.Add(numberpanel);
                        if (i == 4)
                        {
                            TextBlock controlnumber = new TextBlock() { Text = pc.ControlCardNumber.ToString(), Margin = new Thickness(0, 0, 45, 0), HorizontalAlignment = System.Windows.HorizontalAlignment.Right, FontWeight = FontWeights.Bold, FontSize = 20, FontFamily = new FontFamily(AppSettings.TicketNumberFont) };
                            panel.Children.Add(controlnumber);
                            page.Children.Add(panel); panel = null;
                        }
                       
                    }
                }

                var query11 = from i in App.PlaycardViewModel.PlayingCards where i.SerialNumber == Card11StartPage - countdown select i;

                foreach (PlayingCard pc in query11)
                {
                    int i;
                    for (i = 0; i <= 4; i++)
                    {
                        if (panel == null)
                        {
                         panel = new StackPanel() { Orientation = Orientation.Vertical, Margin = new Thickness((96 * 4 *2) + 5, (96 * 3.8*2) + 5, 65, 35), Width = 96 * 4, Height = 96 * 3.8 };
                         TextBlock cNumbertext = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.SerialNumber, "000000"), Background = Brushes.White, Width = 95, Height = 40, FontSize = 25, Foreground = Brushes.Red, VerticalAlignment = System.Windows.VerticalAlignment.Center, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.TicketNumberFont) };
                         panel.Children.Add(cNumbertext);
                        }
                        StackPanel numberpanel = new StackPanel() { Orientation = Orientation.Horizontal, HorizontalAlignment = System.Windows.HorizontalAlignment.Center };
                        TextBlock Bnumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.B[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        TextBlock Inumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.I[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        TextBlock Nnumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.N[i].Number, "00"), Width = 80, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };

                        TextBlock Gnumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.G[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        TextBlock Onumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.O[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        numberpanel.Children.Add(Bnumber); numberpanel.Children.Add(Inumber);
                        if (pc.N[i].Number == 0)
                        {
                            TextBlock highBingoText = new TextBlock() { Text = pc.HighBingo.Number.ToString(), FontWeight = FontWeights.Bold, FontSize = 30, FontStyle = FontStyles.Oblique, HorizontalAlignment = System.Windows.HorizontalAlignment.Left, VerticalAlignment = System.Windows.VerticalAlignment.Top, Margin = new Thickness(10, 0, 0, 0) };
                            TextBlock lowBingoText = new TextBlock() { Text = pc.LowBingo.Number.ToString(), FontWeight = FontWeights.Bold, FontSize = 30, FontStyle = FontStyles.Oblique, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, VerticalAlignment = System.Windows.VerticalAlignment.Bottom, TextAlignment = TextAlignment.Left };
                            TextBlock freeText = new TextBlock() { Text = "FREE", Foreground = Brushes.LightGray, FontWeight = FontWeights.DemiBold, FontSize = 29, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, VerticalAlignment = System.Windows.VerticalAlignment.Center, TextAlignment = TextAlignment.Center };
                            Border border = new Border() { Height = 60, Width = 60, Margin = new Thickness(0, 0, 10, 0), CornerRadius = new CornerRadius(30), Background = Brushes.LightSkyBlue, HorizontalAlignment = System.Windows.HorizontalAlignment.Center };
                            Grid inpanel = new Grid();
                            inpanel.Children.Add(freeText);
                            inpanel.Children.Add(highBingoText);
                            inpanel.Children.Add(lowBingoText);
                            border.Child = inpanel;

                            numberpanel.Children.Add(border);
                        }
                        else
                        {
                            numberpanel.Children.Add(Nnumber);
                        }

                        numberpanel.Children.Add(Gnumber); numberpanel.Children.Add(Onumber);
                        panel.Children.Add(numberpanel);
                        if (i == 4)
                        {
                            TextBlock controlnumber = new TextBlock() { Text = pc.ControlCardNumber.ToString(), Margin = new Thickness(0, 0, 45, 0), HorizontalAlignment = System.Windows.HorizontalAlignment.Right, FontWeight = FontWeights.Bold, FontSize = 20, FontFamily = new FontFamily(AppSettings.TicketNumberFont) };
                            panel.Children.Add(controlnumber);
                            page.Children.Add(panel); panel = null;
                        }
                        
                    }
                }

                var query12 = from i in App.PlaycardViewModel.PlayingCards where i.SerialNumber == Card12StartPage - countdown select i;

                foreach (PlayingCard pc in query12)
                {
                    int i;
                    for (i = 0; i <= 4; i++)
                    {
                        if (panel == null)
                        {
                             panel = new StackPanel() { Orientation = Orientation.Vertical, Margin = new Thickness((96 * 4 *3) + 5, (96 * 3.8*2) + 5, 65, 35), Width = 96 * 4, Height = 96 * 3.8 };
                             TextBlock cNumbertext = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.SerialNumber, "000000"), Background = Brushes.White, Width = 95, Height = 40, FontSize = 25, Foreground = Brushes.Red, VerticalAlignment = System.Windows.VerticalAlignment.Center, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.TicketNumberFont) };
                             panel.Children.Add(cNumbertext);
                        }
                        StackPanel numberpanel = new StackPanel() { Orientation = Orientation.Horizontal, HorizontalAlignment = System.Windows.HorizontalAlignment.Center };
                        TextBlock Bnumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.B[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        TextBlock Inumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.I[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        TextBlock Nnumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.N[i].Number, "00"), Width = 80, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };

                        TextBlock Gnumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.G[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        TextBlock Onumber = new TextBlock() { Text = Microsoft.VisualBasic.Strings.Format(pc.O[i].Number, "00"), Width = 75, FontSize = 50, FontWeight = FontWeights.DemiBold, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, FontFamily = new FontFamily(AppSettings.DefaultFont) };
                        numberpanel.Children.Add(Bnumber); numberpanel.Children.Add(Inumber);
                        if (pc.N[i].Number == 0)
                        {
                            TextBlock highBingoText = new TextBlock() { Text = pc.HighBingo.Number.ToString(), FontWeight = FontWeights.Bold, FontSize = 30, FontStyle = FontStyles.Oblique, HorizontalAlignment = System.Windows.HorizontalAlignment.Left, VerticalAlignment = System.Windows.VerticalAlignment.Top, Margin = new Thickness(10, 0, 0, 0) };
                            TextBlock lowBingoText = new TextBlock() { Text = pc.LowBingo.Number.ToString(), FontWeight = FontWeights.Bold, FontSize = 30, FontStyle = FontStyles.Oblique, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, VerticalAlignment = System.Windows.VerticalAlignment.Bottom, TextAlignment = TextAlignment.Left };
                            TextBlock freeText = new TextBlock() { Text = "FREE", Foreground = Brushes.LightGray, FontWeight = FontWeights.DemiBold, FontSize = 29, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, VerticalAlignment = System.Windows.VerticalAlignment.Center, TextAlignment = TextAlignment.Center };
                            Border border = new Border() { Height = 60, Width = 60, Margin = new Thickness(0, 0, 10, 0), CornerRadius = new CornerRadius(30), Background = Brushes.LightSkyBlue, HorizontalAlignment = System.Windows.HorizontalAlignment.Center };
                            Grid inpanel = new Grid();
                            inpanel.Children.Add(freeText);
                            inpanel.Children.Add(highBingoText);
                            inpanel.Children.Add(lowBingoText);
                            border.Child = inpanel;

                            numberpanel.Children.Add(border);
                        }
                        else
                        {
                            numberpanel.Children.Add(Nnumber);
                        }

                        numberpanel.Children.Add(Gnumber); numberpanel.Children.Add(Onumber);
                        panel.Children.Add(numberpanel);
                        if (i == 4)
                        {
                            TextBlock controlnumber = new TextBlock() { Text = pc.ControlCardNumber.ToString(), Margin = new Thickness(0, 0, 45, 0), HorizontalAlignment = System.Windows.HorizontalAlignment.Right, FontWeight = FontWeights.Bold, FontSize = 20, FontFamily = new FontFamily(AppSettings.TicketNumberFont) };
                            panel.Children.Add(controlnumber);
                            page.Children.Add(panel); panel = null;
                        }
                    }
                }


                PageContent pagecontent = new PageContent();
                ((IAddChild)pagecontent).AddChild(page);
                ReportPages.Pages.Add(pagecontent);
                page = null;
                
            
            }
        }
    }
}