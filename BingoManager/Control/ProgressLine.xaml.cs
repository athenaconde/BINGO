using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace BingoManager.Control
{
    /// <summary>
    /// Interaction logic for ProgressLine.xaml
    /// </summary>
    public partial class ProgressLine : UserControl
    {
        public ProgressLine()
        {
            InitializeComponent();
       
        }
           public void Start()
           {
            Storyboard board  = (Storyboard)GradientLine.FindResource("Animation");
            board.Begin();
           }

            public void Stop()
            {
                    Storyboard board= (Storyboard)GradientLine.FindResource("Animation");
                    board.Stop();
            }
    }
}
