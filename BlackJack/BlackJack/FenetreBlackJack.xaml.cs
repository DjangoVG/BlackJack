using System;
using System.Windows;
using BlackJackLibrairie;

namespace BlackJack
{
    public partial class FenetreBlackJack : Window
    {

        public FenetreBlackJack(Joueur joueur)
        {
            InitializeComponent();
            LoadJoueur(joueur.Pseudo, joueur.Solde);
        }

        private void ClickBoutonRetirer(object sender, EventArgs e)
        {

        }

        private void ClickBoutonDeposer(object sender, EventArgs e)
        {

        }

        private void MenuExitClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadJoueur(String Pseudo, int SoldeActuel)
        {
            this.LabelPseudoJoueur.Content = Pseudo;
            this.LabelSolde.Content = SoldeActuel;
        }
    }
}
