using BlackJackLibrairie;
using System;
using System.Windows;

namespace BlackJack
{
    public partial class FenetreLogin : Window
    {
        private Joueur _loginJoueur = new Joueur();

        public Joueur LoginJoueur
        {
            get { return _loginJoueur; }
            set { _loginJoueur = value; }
        }

        private JoueurManager _joueurmanager = new JoueurManager();

        public JoueurManager JoueurManager
        {
            get { return _joueurmanager; }
            set { _joueurmanager = value; }
        }

        public FenetreLogin(Joueur joueur)
        {
            InitializeComponent();
            StackPanelLogin.DataContext = joueur;
        }

        public FenetreLogin()
        {
            InitializeComponent();
            StackPanelLogin.DataContext = LoginJoueur;
        }

        private void Connexion_Click(object sender, RoutedEventArgs e)
        {
            LoginJoueur.MotDePasse = BoxMotDePasse.Password;
            if (LoginJoueur.Email.Length == 0 || LoginJoueur.MotDePasse.Length == 0)
            {
                MessageBox.Show("Veuillez completer tous les champs", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                JoueurManager.LoadRegistryParameter(LoginJoueur);
                var fen = new FenetreBlackJack(LoginJoueur);
                fen.Show();
                this.Close();
            }
            catch (LoginException ex)
            {
                switch (ex.Code)
                {
                    case CodeException.Default:
                        MessageBox.Show(ex.Message, "Erreur");
                        break;

                    case CodeException.MdpIncorrect:
                        MessageBox.Show(ex.Message, "Erreur mot de passe", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;

                    case CodeException.JoueurNonTrouve:
                        if (MessageBox.Show(ex.Message + ". Souhaitez vous l'ajouter ?", "Ajout joueur", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            JoueurManager.SaveRegistryParameter(LoginJoueur.Email, LoginJoueur.MotDePasse, LoginJoueur.Solde);
                            MessageBox.Show("Vous êtes bien inscrit !", "Excellent !", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        break;

                    case CodeException.EmailIncorrect:
                        MessageBox.Show(ex.Message, "Erreur email", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;

                    case CodeException.PseudoInexistant:
                        var fenetrePseudo = new FenetrePseudo();
                        fenetrePseudo.ShowDialog();
                        LoginJoueur.Pseudo = fenetrePseudo.Pseudo;
                        JoueurManager.SaveRegistryPseudo(LoginJoueur.Email, LoginJoueur.Pseudo);
                        JoueurManager.LoadRegistryParameter(LoginJoueur);
                        var fen = new FenetreBlackJack(LoginJoueur);
                        fen.Show();
                        this.Close();
                        break;

                    case CodeException.SoldeInsuffisant:
                        // Rediriger vers le dépot d'argent
                        break;
                }
            }
        }

        private void BoutonQuitterJeu(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}