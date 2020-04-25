using System.Windows;

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