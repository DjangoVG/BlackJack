using System;
using System.Windows;

namespace BlackJack
{
    public partial class FenetreBlackJack : Window
    {
        private String EmailJoueur;
        private String PseudoJoueur;

        public FenetreBlackJack()
        {
            InitializeComponent();
            LoadJoueur("");
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

        private void LoadJoueur(String email)
        {
            // Initialise les données du joueur (pseudo, solde actuel, etc)
            this.PseudoJoueur = "Django";
            this.LabelPseudoJoueur.Content = PseudoJoueur;
        }
    }
}
