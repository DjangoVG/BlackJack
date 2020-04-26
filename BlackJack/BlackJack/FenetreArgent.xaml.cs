﻿using BlackJackLibrairie;
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

        private void Click_Confirmer (object sender, EventArgs e)
        {
            if (BoxDepot.Length > 0 && BoxRetrait.Length > 0)
                MessageBox.Show("Une opération à la fois !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                if (BoxDepot.Length > 0)
                {
                    if (Convert.ToInt32(BoxDepot) > 0 && Convert.ToInt32(BoxDepot) < 100000)
                    {
                        joueur.Solde += Convert.ToInt32(BoxDepot);
                        MessageBox.Show("Depot effectué !", "Validé", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    else
                        MessageBox.Show("Depot doit être entre 0 et 100.000 euros !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                else if (BoxRetrait.Length > 0)
                {
                    if (joueur.Solde < Convert.ToInt32(BoxRetrait))
                    {
                        MessageBox.Show("Retrait trop élevé !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        // Ajouter à l'historique le retrait
                        this.joueur.Solde -= Convert.ToInt32(BoxRetrait);
                        MessageBox.Show("Retrait effectué !", "Validé", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                }
            }
        }

        private void Click_Annuler (object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
