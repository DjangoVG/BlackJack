using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BlackJack
{
    public partial class FenetreOption : Window
    {
        public delegate void OptionsDelegate(FenetreOption OriginWindow);
        public event OptionsDelegate OptionsEvent;
    
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

        private void Option_Appliquer_Click(object sender, RoutedEventArgs e)
        {
            OptionsEvent(this);
        }

        private void Option_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BoutonAnnuler(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
