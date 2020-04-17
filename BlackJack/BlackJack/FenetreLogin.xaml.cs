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
    /// Logique d'interaction pour FenetreLogin.xaml
    /// </summary>
    public partial class FenetreLogin : Window
    {
        public FenetreLogin()
        {
            InitializeComponent();
        }

        private void Connexion_Click(object sender, RoutedEventArgs e)
        {
            FenetreBlackJack fbj = new FenetreBlackJack();
            fbj.Show();
            this.Close();
        }
    }
}
