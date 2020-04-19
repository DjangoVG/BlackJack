using System.Windows;

namespace BlackJack
{
    /// <summary>
    /// Logique d'interaction pour FenetreLogin.xaml
    /// </summary>
    public partial class FenetreLogin : Window
    {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public FenetreLogin()
        {
            InitializeComponent();
            StackPanelLogin.DataContext = this;
        }

        private void Connexion_Click(object sender, RoutedEventArgs e)
        {
            FenetreBlackJack fbj = new FenetreBlackJack();
            fbj.Show();
            this.Close();
        }
    }
}
