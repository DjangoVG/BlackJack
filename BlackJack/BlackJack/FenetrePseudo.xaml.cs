using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BlackJack
{
    /// <summary>
    /// Logique d'interaction pour FenetrePseudo.xaml
    /// </summary>
    public partial class FenetrePseudo : Window
    {
        public string Pseudo;
        public FenetrePseudo()
        {
            InitializeComponent();
        }

        private void Click_ValiderPseudo(object sender, RoutedEventArgs e)
        {
            Pseudo = BoxPseudo.Text;
            this.Close();
        }

        private void Click_Annuler(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
