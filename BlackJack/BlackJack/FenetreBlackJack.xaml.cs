using System;
using System.Threading;
using System.Windows;
using BlackJackLibrairie;

namespace BlackJack
{
    public partial class FenetreBlackJack : Window
    {
        public Joueur Joueur { get; set; }
        public int MiseActuelle { get; set; } = 0;
        public string Date { get; set; }
        public FenetreBlackJack(Joueur joueur)
        {
            InitializeComponent();
            Joueur = joueur;
            SPInformation.DataContext = Joueur;
            BoxJoueur.DataContext = Joueur;
            SPDate.DataContext = this;
            Date = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
            ThreadDate threadDate = new ThreadDate(Date); // Démarrage thread Date
            Thread LetsgoDate = new Thread(new ThreadStart(threadDate.DemarrageDate));
            LetsgoDate.Start(); //Démarrage du thread

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
