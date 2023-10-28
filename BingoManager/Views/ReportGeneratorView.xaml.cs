using System;
using System.Windows;
using BingoManager.Reports;

namespace BingoManager.Views
{
    /// <summary>
    /// Interaction logic for ReportGeneratorView.xaml
    /// </summary>
    public partial class ReportGeneratorView : Window
    {
        public ReportGeneratorView()
        {
            InitializeComponent();
            this.FirstBatchButton.Click += new RoutedEventHandler(FirstBatchButtton_Click);
            this.SecondBatchButton.Click += new RoutedEventHandler(SecondBatchButton_Click);
            this.ThirdBatchButton.Click += new RoutedEventHandler(ThirdBatchButton_Click);
            this.FourthBatchButton.Click += new RoutedEventHandler(FourthBatchButton_Click);
            this.FifthBatchButton.Click += new RoutedEventHandler(FifthBatchButton_Click);
            this.SixBatchButton.Click += new RoutedEventHandler(SixBatchButton_Click);
            this.SevenBatchButton.Click += new RoutedEventHandler(SevenBatchButton_Click);
            this.EightBatchButton.Click += new RoutedEventHandler(EightBatchButton_Click);
            this.NineBatchButton.Click += new RoutedEventHandler(NineBatchButton_Click);
            this.TenBatchButton.Click += new RoutedEventHandler(TenBatchButton_Click);
        }

        void TenBatchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OnButtonClick(1250, 13750, 26250, 38750, 51250, 63750, 76250, 88750, 101250, 113750, 126250, 138750);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
        }

        void NineBatchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OnButtonClick(2500, 15000, 27500, 40000, 52500, 65000, 77500, 90000, 102500, 115000, 127500, 140000);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
        }

        void EightBatchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OnButtonClick(3750, 16250, 28750, 41250, 53750, 66250, 78750, 91250, 103750, 116250, 128750, 141250);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
        }

        void SevenBatchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OnButtonClick(5000, 17500, 30000, 42500, 55000, 67500, 80000, 92500, 105000, 117500, 13000, 142500);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
        }

        void SixBatchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OnButtonClick(6200, 18750, 31250, 43750, 56250, 68750, 81250, 93750, 106250, 118750, 131250, 143750);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
              
        }

        void FifthBatchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OnButtonClick(7500, 20000, 32500, 45000, 57500, 70000, 82500, 95000, 107500, 120000, 132500, 145000);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
              
        }


        void FirstBatchButtton_Click(object sender, RoutedEventArgs e)
        {
             try
                {
                    OnButtonClick(12500, 25000, 37500, 50000, 62500, 75000, 87500, 100000, 112500, 125000, 137500, 150000);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,ex.Source);
                }
              
               
            }


        void SecondBatchButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                OnButtonClick(11250, 23750, 36250, 48750, 61250, 73750, 86250, 98750, 111250, 123750, 136250, 148750);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
        }

        void ThirdBatchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OnButtonClick(10000, 22250, 35000, 47500, 60000, 72500, 85000, 97500, 110000, 122500, 135000, 147500);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
        }


        void FourthBatchButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                OnButtonClick(8750, 21250, 33750, 46250, 58750, 71250, 83750, 96250, 108750, 121250, 133750, 146250);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
        }

       
       
        /// <summary>
        /// Generate the printable cards view.
        /// </summary>
        void OnButtonClick(long card1PageStart, long card2PageStart, long card3PageStart, long card4PageStart, long card5PageStart
                            , long card6PageStart, long card7PageStart, long card8PageStart, long card9PageStart, long card10PageStart
                            , long card11PageStart, long card12PageStart)
        {
            ReportView reportView = new ReportView() 
                            { Card1StartPage = card1PageStart, Card2StartPage = card2PageStart, Card3StartPage = card3PageStart
                             , Card4StartPage= card4PageStart, Card5StartPage = card5PageStart, Card6StartPage = card6PageStart
                            , Card7StartPage =card7PageStart, Card8StartPage = card8PageStart, Card9StartPage =card9PageStart
                            ,  Card10StartPage = card10PageStart, Card11StartPage =card11PageStart , Card12StartPage =card12PageStart};
            reportView.Show();
            DialogResult = true;
            this.Close();
        }
    }

        
}
