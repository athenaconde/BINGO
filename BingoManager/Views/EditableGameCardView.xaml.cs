using System.Windows.Controls;

namespace BingoManager.Views
{
    /// <summary>
    /// Interaction logic for EditableGameCardView.xaml
    /// </summary>
    public partial class EditableGameCardView : UserControl
    {
        public EditableGameCardView()
        {
            InitializeComponent();
        }

        private void MarkNumber_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = App.PlaycardViewModel.canExecuteBlackenedCommand(e.Parameter);
        }

        private void MarkNumber_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            App.PlaycardViewModel.BlackenedNumber(e.Parameter);
        }
    }
}
