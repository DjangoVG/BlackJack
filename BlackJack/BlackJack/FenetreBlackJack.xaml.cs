using System;
using System.Windows;
using BlackJackLibrairie;

namespace BlackJack
{
    public partial class FenetreBlackJack : Window
    {
        public Joueur Joueur { get; set; }
        public int MiseActuelle { get; set; } = 0;
        public string Date { get; } = DateTime.Now.ToString("dd/MM/yyyy");
        public FenetreBlackJack(Joueur joueur)
        {
            InitializeComponent();
            Joueur = joueur;
            SPInformation.DataContext = Joueur;
            BoxJoueur.DataContext = Joueur;
            SPDate.DataContext = this;
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
    }
}
