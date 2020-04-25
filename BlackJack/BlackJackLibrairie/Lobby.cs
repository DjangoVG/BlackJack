using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BlackJackLibrairie
{
    public class Lobby : INotifyPropertyChanged
    {
        public Joueur Joueur { get; set; }
        public Croupier Croupier { get; set; }
        private ObservableCollection<Carte> _carteJoueur;

        public ObservableCollection<Carte> CartesJoueur
        {
            get
            {
                return _carteJoueur;
            }
            set
            {
                _carteJoueur = value;
                NotifyPropertyChanged();
            }
        }

        private ObservableCollection<Carte> _carteCroupier;

        public ObservableCollection<Carte> CartesCroupier
        {
            get
            {
                return _carteCroupier;
            }
            set
            {
                _carteCroupier = value;
                NotifyPropertyChanged();
            }
        }

        public Sabot Sabot { get; set; } = new Sabot();

        public event PropertyChangedEventHandler PropertyChanged;

        public Lobby()
        {
            CartesCroupier = new ObservableCollection<Carte>();
            CartesJoueur = new ObservableCollection<Carte>();
            Sabot.Shuffle(Sabot.SabotJeu);
        }

        public void StartGame() // Démarrage de la game
        {
            if (Sabot.SabotJeu.Count < 15)
                Sabot = new Sabot();
            int NbrCarte = CartesCroupier.Count;
            for (int i = 0; i < NbrCarte; i++) // Je vide les mains
                CartesCroupier.Remove(CartesCroupier[0]);
            NbrCarte = CartesJoueur.Count;
            for (int i = 0; i < NbrCarte; i++)
                CartesJoueur.Remove(CartesJoueur[0]);

            // Distribution des cartes
            for (int i = 0; i < 3; i++)
            {
                if (i == 0 || i == 2) // 2 cartes au joueur
                {
                    CartesJoueur.Add(Sabot.SabotJeu[0]);
                    Sabot.SabotJeu.RemoveAt(0);
                }
                else // 1 carte au croupier
                {
                    CartesCroupier.Add(Sabot.SabotJeu[0]);
                    Sabot.SabotJeu.RemoveAt(0);
                }
            }
        }

        public void DonneCarteJoueur()
        {
            CartesJoueur.Add(Sabot.SabotJeu[0]);
            Sabot.SabotJeu.RemoveAt(0);
        }

        public void DonneCarteCroupier()
        {
            CartesCroupier.Add(Sabot.SabotJeu[0]);
            Sabot.SabotJeu.RemoveAt(0);
        }

        public int ValeurDeckCroupier()
        {
            int ValeurDeck = 0;

            List<Carte> listCroupier = new List<Carte>();
            foreach (Carte c in CartesCroupier)
                listCroupier.Add(c);

            CartesComparer cc = new CartesComparer();
            listCroupier.Sort(cc);


            foreach (Carte c in listCroupier)
            {
                if (c.ValeurCarte == ValeurCarte.Valet || c.ValeurCarte == ValeurCarte.Dame || c.ValeurCarte == ValeurCarte.Roi)
                    ValeurDeck += 10;
                else if (c.ValeurCarte == ValeurCarte.As)
                {
                    if (ValeurDeck + 11 <= 21)
                        ValeurDeck += 11;
                    else
                        ValeurDeck += 1;
                }
                else
                    ValeurDeck += Convert.ToInt32(c.ValeurCarte);
            }
            return ValeurDeck;
        }

        public int ValeurDeckJoueur()
        {
            int ValeurDeck = 0;

            List<Carte> listJoueur = new List<Carte>();
            foreach (Carte c in CartesJoueur)
                listJoueur.Add(c);

            CartesComparer cc = new CartesComparer();
            listJoueur.Sort(cc);

            foreach (Carte c in listJoueur)
            {
                Console.WriteLine("Carte : " + c.ValeurCarte);
                if (c.ValeurCarte == ValeurCarte.Valet || c.ValeurCarte == ValeurCarte.Dame || c.ValeurCarte == ValeurCarte.Roi)
                    ValeurDeck += 10;
                else if (c.ValeurCarte == ValeurCarte.As)
                {
                    if (ValeurDeck + 11 <= 21)
                        ValeurDeck += 11;
                    else
                        ValeurDeck += 1;
                }
                else
                    ValeurDeck += Convert.ToInt32(c.ValeurCarte);
            }
            return ValeurDeck;
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged; //Appel d'un délégué
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}