﻿using System;
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
    /// Interaction logic for LowBingoView.xaml
    /// </summary>
    public partial class LowBingoView : UserControl
    {
        public LowBingoView()
        {
            InitializeComponent();
        }

        private void SetLoingoCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ((HighLowBingo)this.DataContext).SetballLow(e.Parameter);
        }
    }
}