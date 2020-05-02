using BlackJackLibrairie;
using System.Windows;
using System.Windows.Media;

namespace BlackJack
{
    public partial class FenetreOption : Window
    {
        public delegate void OptionsDelegate(FenetreOption OriginWindow);

        public event OptionsDelegate OptionsEvent;

        public event OptionsDelegate OptionsEventWindow;

        public FenetreOption()
        {
            InitializeComponent();
            RectangleFond.Fill = new SolidColorBrush(Colors.DarkGreen);
        }

        private void BoutonFond(object sender, RoutedEventArgs e)
        {
            if (RectangleFond.Fill.ToString() == new SolidColorBrush(Colors.DarkGreen).ToString())
                RectangleFond.Fill = new SolidColorBrush(Colors.Blue);
            else
                RectangleFond.Fill = new SolidColorBrush(Colors.DarkGreen);

            OptionsEvent(this);
        }

        private void BoutonAnnuler(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RBFullscreen_Checked(object sender, RoutedEventArgs e)
        {
            OptionsEventWindow(this);
        }

        private void RBWindowed_Checked(object sender, RoutedEventArgs e)
        {
            OptionsEventWindow(this);
        }
    }
}