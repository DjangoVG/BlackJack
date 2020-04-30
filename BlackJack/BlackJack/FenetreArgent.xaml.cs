using BlackJackLibrairie;
using System;
using System.Windows;

namespace BlackJack
{
    public partial class FenetreArgent : Window
    {
        private string _soldeactuel;

        public string SoldeActuel
        {
            set
            {
                _soldeactuel = value;
            }
            get
            {
                return _soldeactuel;
            }
        }

        private string _retraitdemande;

        public string BoxRetrait
        {
            set
            {
                _retraitdemande = value;
            }
            get
            {
                return _retraitdemande;
            }
        }

        private string _depotdemande;

        public string BoxDepot
        {
            set
            {
                _depotdemande = value;
            }
            get
            {
                return _depotdemande;
            }
        }

        private Joueur joueur { get; set; }

        public FenetreArgent(Joueur joueur)
        {
            InitializeComponent();
            Soldeac.DataContext = this;
            BoxDep.DataContext = this;
            BoxRet.DataContext = this;
            this.joueur = joueur;
            Soldeac.Content = Convert.ToString(joueur.Solde);
            BoxDepot = "";
            BoxRetrait = "";
        }

        private void Click_Confirmer(object sender, EventArgs e)
        {
            if (BoxDepot.Length > 0 && BoxRetrait.Length > 0)
                MessageBox.Show("Une opération à la fois !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                if (BoxDepot.Length > 0)
                {
                    try
                    {
                        if (Convert.ToInt32(BoxDepot) > 0 && Convert.ToInt32(BoxDepot) <= 100000)
                        {
                            joueur.Solde += Convert.ToDouble(BoxDepot);
                            MessageBox.Show("Depot effectué !", "Validé", MessageBoxButton.OK, MessageBoxImage.Information);
                            this.Close();
                        }
                        else
                            MessageBox.Show("Depot doit être entre 0 et 100.000 euros !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    catch (System.FormatException)
                    {
                        MessageBox.Show("Caracteres invalides !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else if (BoxRetrait.Length > 0)
                {
                    try
                    {
                        if (joueur.Solde < Convert.ToDouble(BoxRetrait))
                        {
                            MessageBox.Show("Retrait trop élevé !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            // Ajouter à l'historique le retrait
                            this.joueur.Solde -= Convert.ToDouble(BoxRetrait);
                            MessageBox.Show("Retrait effectué !", "Validé", MessageBoxButton.OK, MessageBoxImage.Information);
                            this.Close();
                        }
                    }
                    catch (System.FormatException)
                    {
                        MessageBox.Show("Caracteres invalides !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void Click_Annuler(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}