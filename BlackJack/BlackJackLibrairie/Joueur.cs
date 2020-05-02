using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BlackJackLibrairie
{
    public class Joueur : INotifyPropertyChanged, IEtatActuel
    {
        private string _email;
        private string _nom;
        private string _prenom;
        private string _pseudo;
        private string _motdepasse;
        private double _solde;
        private Boolean _abust;

        #region PROPRIETES

        public bool ABust
        {
            get
            {
                return _abust;
            }
            set
            {
                _abust = value;
            }
        }

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }

        public string MotDePasse
        {
            get { return _motdepasse; }
            set { _motdepasse = value; }
        }

        public string Pseudo
        {
            get { return _pseudo; }
            set { _pseudo = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public double Solde
        {
            get { return _solde; }
            set
            {
                _solde = value;
                NotifyPropertyChanged();
            }
        }

        #endregion PROPRIETES

        public event PropertyChangedEventHandler PropertyChanged;

        #region CONSTRUCTEURS

        public Joueur()
        {
            Nom = "";
            MotDePasse = "";
            Pseudo = "";
            Solde = 0;
        }

        public Joueur(string email, string mdp, string pseudo, int solde)
        {
            Email = email;
            MotDePasse = mdp;
            Pseudo = pseudo;
            Solde = solde;
            ABust = false;
        }

        #endregion CONSTRUCTEURS

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged; //Appel d'un délégué
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        bool IEtatActuel.ABust()
        {
            return ABust;
        }
    }
}