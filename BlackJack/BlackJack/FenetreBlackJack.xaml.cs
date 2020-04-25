using BlackJackLibrairie;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Media;

namespace BlackJack
{
    public partial class FenetreBlackJack : Window, INotifyPropertyChanged
    {
        #region PROPRIETES
        public Lobby Lobby { get; set; } = new Lobby();
        private int _mise;

        public int MiseActuelle
        {
            set
            {
                _mise = value;
                NotifyPropertyChanged();
            }
            get
            {
                return _mise;
            }
        }

        public string Date { get; set; }

        private ObservableCollection<Carte> _carte1;
        public ObservableCollection<Carte> Carte1
        {
            set
            {
                _carte1 = value;
                NotifyPropertyChanged();
            }
            get
            {
                return _carte1;
            }
        }

        private ObservableCollection<Carte> _Carte2;
        public ObservableCollection<Carte> Carte2
        {
            set
            {
                _Carte2 = value;
                NotifyPropertyChanged();
            }
            get
            {
                return _Carte2;
            }
        }

        private Boolean FinishDeck1;

        #endregion

        #region Boolean ENABLE

        private Boolean _isMiseEnable;

        public Boolean IsMiseEnable
        {
            get
            {
                return _isMiseEnable;
            }
            set
            {
                _isMiseEnable = value;
                NotifyPropertyChanged();
            }
        }

        private Boolean _isResetEnable;

        public Boolean IsResetEnable
        {
            get
            {
                return _isResetEnable;
            }
            set
            {
                _isResetEnable = value;
                NotifyPropertyChanged();
            }
        }

        private Boolean _isTirerEnable;

        public Boolean IsTirerEnable
        {
            get
            {
                return _isTirerEnable;
            }
            set
            {
                _isTirerEnable = value;
                NotifyPropertyChanged();
            }
        }

        private Boolean _isResterEnable;

        public Boolean IsResterEnable
        {
            get
            {
                return _isResterEnable;
            }
            set
            {
                _isResterEnable = value;
                NotifyPropertyChanged();
            }
        }

        private Boolean _isSplitEnable;

        public Boolean IsSplitEnable
        {
            get
            {
                return _isSplitEnable;
            }
            set
            {
                _isSplitEnable = value;
                NotifyPropertyChanged();
            }
        }

        private Boolean _isDoubleEnable;

        public Boolean IsDoubleEnable
        {
            get
            {
                return _isDoubleEnable;
            }
            set
            {
                _isDoubleEnable = value;
                NotifyPropertyChanged();
            }
        }

        private Boolean _is5Enable;

        public Boolean Is5Enable
        {
            get
            {
                return _is5Enable;
            }
            set
            {
                _is5Enable = value;
                NotifyPropertyChanged();
            }
        }

        private Boolean _is10Enable;

        public Boolean Is10Enable
        {
            get
            {
                return _is10Enable;
            }
            set
            {
                _is10Enable = value;
                NotifyPropertyChanged();
            }
        }

        private Boolean _is50Enable;

        public Boolean Is50Enable
        {
            get
            {
                return _is50Enable;
            }
            set
            {
                _is50Enable = value;
                NotifyPropertyChanged();
            }
        }

        private Boolean _is100Enable;

        public Boolean Is100Enable
        {
            get
            {
                return _is100Enable;
            }
            set
            {
                _is100Enable = value;
                NotifyPropertyChanged();
            }
        }

        private Boolean _is200Enable;

        public Boolean Is200Enable
        {
            get
            {
                return _is200Enable;
            }
            set
            {
                _is200Enable = value;
                NotifyPropertyChanged();
            }
        }

        #endregion Boolean ENABLE

        public FenetreBlackJack(Joueur joueur)
        {
            InitializeComponent();
            Application.Current.MainWindow.WindowState = WindowState.Maximized;

            #region DataContext

            SoldeN.DataContext = Lobby;
            SPCroupier.DataContext = Lobby;
            SPJoueur.DataContext = Lobby;
            SPDate.DataContext = this;
            MiseN.DataContext = this;
            BoutonMiser.DataContext = this;
            BoutonReset.DataContext = this;
            BoutonTirerN.DataContext = this;
            BoutonResterN.DataContext = this;
            BoutonSplitN.DataContext = this;
            BoutonDoubleN.DataContext = this;
            RectangleJoueur2.DataContext = this;
            Jeton5N.DataContext = this;
            Jeton10N.DataContext = this;
            Jeton50N.DataContext = this;
            Jeton100N.DataContext = this;
            Jeton200N.DataContext = this;

            #endregion DataContext

            IsResetEnable = false;
            IsMiseEnable = false;
            IsTirerEnable = false;
            IsResterEnable = false;
            IsSplitEnable = false;
            IsDoubleEnable = false;

            Is5Enable = true;
            Is10Enable = true;
            Is50Enable = true;
            Is100Enable = true;
            Is200Enable = true;

            FinishDeck1 = false;

            // DATE
            Date = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
            ThreadDate threadDate = new ThreadDate(Date); // Démarrage thread Date
            Thread LetsgoDate = new Thread(threadDate.DemarrageDate);
            LetsgoDate.Start(); //Démarrage du thread

            Lobby.Joueur = joueur;
            CheckJetonSolde();
            Lobby.Croupier = new Croupier();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void BoutonPlayGame(object sender, EventArgs e)
        {
            if (MiseActuelle != 0)
            {
                if (RectangleJoueur2.Visibility == Visibility.Visible)
                    ResetFrontEnd();

                if (MiseActuelle > Lobby.Joueur.Solde)
                    IsDoubleEnable = false;
                else
                    IsDoubleEnable = true;

                Is5Enable = false;
                Is10Enable = false;
                Is50Enable = false;
                Is100Enable = false;
                Is200Enable = false;
                this.RectangleCroupier.BorderBrush = new SolidColorBrush(Colors.White);
                this.RectangleJoueur.BorderBrush = new SolidColorBrush(Colors.White);
                Lobby.StartGame();
                GetValeur(); // Affichage de la valeur de la main du croupier/joueur

                if (Lobby.ValeurDeckJoueur() == 21)
                {
                    Lobby.DonneCarteCroupier();
                    GetValeur();
                    if (Lobby.ValeurDeckCroupier() == 21)
                    {
                        this.RectangleCroupier.BorderBrush = new SolidColorBrush(Colors.Orange);
                        this.RectangleJoueur.BorderBrush = new SolidColorBrush(Colors.Orange);
                        Push();
                    }
                    else
                    {
                        this.RectangleCroupier.BorderBrush = new SolidColorBrush(Colors.Red);
                        this.RectangleJoueur.BorderBrush = new SolidColorBrush(Colors.Green);
                        Win();
                    }
                    FinDuGame();
                }
                else
                {
                    IsResetEnable = false;
                    IsMiseEnable = false;
                    IsTirerEnable = true;
                    IsResterEnable = true;
                    IsSplitEnable = true;
                }
            }
        }

        private void BoutonTirer(object sender, EventArgs e)
        {
            if (RectangleJoueur2.Visibility == Visibility.Visible) // Joueur a SPLIT
            {
                if (!FinishDeck1) // Je suis sur le deck 1
                {
                    Lobby.DonneCarteJoueur();
                    GetValeur();
                    if (Lobby.ValeurDeckJoueur() > 21)
                    {
                        this.RectangleJoueur.BorderBrush = new SolidColorBrush(Colors.Red);
                        FinishDeck1 = true;
                        GetValeurDeck2();
                    }
                        
                }
                else // Je suis sur le deck 2
                {
                    Lobby.DonneCarteJoueurDeck2(Carte2);
                    GetValeurDeck2();
                    if (Lobby.ValeurDeckJoueur2(Carte2) > 21)
                    {
                        this.RectangleJoueur2.BorderBrush = new SolidColorBrush(Colors.Red);
                        VerifGagnant();
                    }

                }

            }
            else // Game normal sans SPLIT
            {
                Lobby.DonneCarteJoueur();
                GetValeur();
                if (Lobby.ValeurDeckJoueur() > 21)
                {
                    this.RectangleCroupier.BorderBrush = new SolidColorBrush(Colors.Green);
                    this.RectangleJoueur.BorderBrush = new SolidColorBrush(Colors.Red);
                    Lose();
                    FinDuGame();
                }
            }
        }

        private void BoutonStand(object sender, EventArgs e)
        {
            if (RectangleJoueur2.Visibility == Visibility.Visible)
            {
                if (!FinishDeck1) // Je suis sur le deck 1
                {
                    FinishDeck1 = true;
                    GetValeurDeck2();
                }
                else // Je suis sur le deck 2
                {
                    while (Lobby.ValeurDeckCroupier() < 17)
                    {
                        Lobby.DonneCarteCroupier();
                        GetValeur();
                        /* PAUSE */
                    }
                    FinDuGame();
                }
            }
            else
            {
                while (Lobby.ValeurDeckCroupier() < 17)
                {
                
                    Lobby.DonneCarteCroupier();
                    GetValeur();
                    /* PAUSE */
                }
                VerifGagnant();
                FinDuGame();
            }
           
        }

        private void BoutonDouble(object sender, EventArgs e)
        {
            Lobby.Joueur.Solde -= MiseActuelle;
            MiseActuelle += MiseActuelle;
            Lobby.DonneCarteJoueur();
            GetValeur();

            if (Lobby.ValeurDeckJoueur() <= 21)
            {
                while (Lobby.ValeurDeckCroupier() < 17)
                {
                    Lobby.DonneCarteCroupier();
                    GetValeur();
                    /* PAUSE */
                }
                VerifGagnant();
            }
            else
            {
                this.RectangleCroupier.BorderBrush = new SolidColorBrush(Colors.Green);
                this.RectangleJoueur.BorderBrush = new SolidColorBrush(Colors.Red);
                Lose();
            }
            FinDuGame();
        }

        private void BoutonSplit(object sender, EventArgs e)
        {
            System.Windows.Controls.ColumnDefinition newColumn = new System.Windows.Controls.ColumnDefinition();
            GridJoueur.ColumnDefinitions.Add(newColumn);

            RectangleJoueur.Margin = new Thickness(0, 0, 10, 0);
            RectangleJoueur2.Visibility = Visibility.Visible;

            
            Carte2 = new ObservableCollection<Carte>();
            Carte2.Add(Lobby.CartesJoueur[1]);
            Lobby.CartesJoueur.RemoveAt(1);
            Lobby.DonneCarteJoueur();
            Lobby.DonneCarteJoueurDeck2(Carte2);
            GetValeur();
        }

        private void ClickBoutonRetirer(object sender, EventArgs e)
        {
        }

        private void ClickBoutonDeposer(object sender, EventArgs e)
        {
        }

        private void ResetFrontEnd()
        {
            GridJoueur.ColumnDefinitions.RemoveAt(1);
            RectangleJoueur2.Visibility = Visibility.Hidden;
            RectangleJoueur.Margin = new Thickness(0, 0, 0, 0);
        }

        private void CheckJetonSolde()
        {
            if (Lobby.Joueur.Solde >= 200)
            {
                Is5Enable = true;
                Is10Enable = true;
                Is50Enable = true;
                Is100Enable = true;
                Is200Enable = true;
            }
            else if (Lobby.Joueur.Solde >= 100)
            {
                Is5Enable = true;
                Is10Enable = true;
                Is50Enable = true;
                Is100Enable = true;
                Is200Enable = false;
            }
            else if (Lobby.Joueur.Solde >= 50)
            {
                Is5Enable = true;
                Is10Enable = true;
                Is50Enable = true;
                Is100Enable = false;
                Is200Enable = false;
            }
            else if (Lobby.Joueur.Solde >= 10)
            {
                Is5Enable = true;
                Is10Enable = true;
                Is50Enable = false;
                Is100Enable = false;
                Is200Enable = false;
            }
            else if (Lobby.Joueur.Solde >= 5)
            {
                Is5Enable = true;
                Is10Enable = false;
                Is50Enable = false;
                Is100Enable = false;
                Is200Enable = false;
            }
            else
            {
                Is5Enable = false;
                Is10Enable = false;
                Is50Enable = false;
                Is100Enable = false;
                Is200Enable = false;
            }
        }

        private void BoutonResetJeton(object sender, EventArgs e)
        {
            Lobby.Joueur.Solde += MiseActuelle;
            MiseActuelle = 0;
            CheckJetonSolde();
        }

        #region BOUTONS JETONS
        private void Ajout5euros(object sender, EventArgs e)
        {
            MiseActuelle += 5;
            Lobby.Joueur.Solde -= 5;
            CheckJetonSolde();
            IsMiseEnable = true;
            IsResetEnable = true;
        }

        private void Ajout10euros(object sender, EventArgs e)
        {
            MiseActuelle += 10;
            Lobby.Joueur.Solde -= 10;
            CheckJetonSolde();
            IsMiseEnable = true;
            IsResetEnable = true;
        }

        private void Ajout50euros(object sender, EventArgs e)
        {
            MiseActuelle += 50;
            Lobby.Joueur.Solde -= 50;
            CheckJetonSolde();
            IsMiseEnable = true;
            IsResetEnable = true;
        }

        private void Ajout100euros(object sender, EventArgs e)
        {
            MiseActuelle += 100;
            Lobby.Joueur.Solde -= 100;
            CheckJetonSolde();
            IsMiseEnable = true;
            IsResetEnable = true;
        }

        private void Ajout200euros(object sender, EventArgs e)
        {
            MiseActuelle += 200;
            Lobby.Joueur.Solde -= 200;
            CheckJetonSolde();
            IsMiseEnable = true;
            IsResetEnable = true;
        }

        #endregion

        private void GetValeur()
        {
            ValeurCroupier.Content = Lobby.ValeurDeckCroupier();
            ValeurJoueur.Content = Lobby.ValeurDeckJoueur();
        }
        private void GetValeurDeck2()
        {
            ValeurJoueur.Content = Lobby.ValeurDeckJoueur2(Carte2);
        }

        private void GetValeurJeu2(ObservableCollection<Carte> Carte2)
        {
            ValeurJoueur.Content = Lobby.ValeurDeckJoueur2(Carte2);
        }

        private void VerifGagnant()
        {
            if (Lobby.ValeurDeckCroupier() > 21)
                Lobby.Croupier.ABust = true;
            else
                Lobby.Croupier.ABust = false;

            if (RectangleJoueur2.Visibility == Visibility.Visible)
            {
                if (Lobby.ValeurDeckCroupier() > Lobby.ValeurDeckJoueur() && !Lobby.Croupier.ABust) // CROUPIER WIN DECK 1
                {
                    this.RectangleCroupier.BorderBrush = new SolidColorBrush(Colors.Green);
                    this.RectangleJoueur.BorderBrush = new SolidColorBrush(Colors.Red);
                }
                if (Lobby.ValeurDeckCroupier() > Lobby.ValeurDeckJoueur2(Carte2) && !Lobby.Croupier.ABust) // CROUPIER WIN DECK 2
                {
                    this.RectangleCroupier.BorderBrush = new SolidColorBrush(Colors.Green);
                    this.RectangleJoueur2.BorderBrush = new SolidColorBrush(Colors.Red);
                }

                if (Lobby.ValeurDeckJoueur() == Lobby.ValeurDeckCroupier()) // PUSH DECK 1
                {
                    this.RectangleCroupier.BorderBrush = new SolidColorBrush(Colors.Orange);
                    this.RectangleJoueur.BorderBrush = new SolidColorBrush(Colors.Orange);
                }
                if (Lobby.ValeurDeckJoueur2(Carte2) == Lobby.ValeurDeckCroupier()) // PUSH DECK 2
                {
                    this.RectangleCroupier.BorderBrush = new SolidColorBrush(Colors.Orange);
                    this.RectangleJoueur2.BorderBrush = new SolidColorBrush(Colors.Orange);
                }

                if (Lobby.ValeurDeckCroupier() < Lobby.ValeurDeckJoueur()) // WIN DECK 1
                {
                    this.RectangleJoueur.BorderBrush = new SolidColorBrush(Colors.Green);
                    this.RectangleCroupier.BorderBrush = new SolidColorBrush(Colors.Red);
                }
                if (Lobby.ValeurDeckCroupier() < Lobby.ValeurDeckJoueur2(Carte2)) // WIN DECK 2
                {
                    this.RectangleJoueur2.BorderBrush = new SolidColorBrush(Colors.Green);
                    this.RectangleCroupier.BorderBrush = new SolidColorBrush(Colors.Red);
                }
            }
            else
            {
                if (Lobby.ValeurDeckCroupier() > 21)
                    Lobby.Croupier.ABust = true;
                else
                    Lobby.Croupier.ABust = false;

                if (Lobby.ValeurDeckCroupier() > Lobby.ValeurDeckJoueur() && !Lobby.Croupier.ABust) // CROUPIER WIN
                {
                    this.RectangleCroupier.BorderBrush = new SolidColorBrush(Colors.Green);
                    this.RectangleJoueur.BorderBrush = new SolidColorBrush(Colors.Red);
                    Lose();
                }
                else if (Lobby.ValeurDeckJoueur() == Lobby.ValeurDeckCroupier()) // PUSH
                {
                    this.RectangleCroupier.BorderBrush = new SolidColorBrush(Colors.Orange);
                    this.RectangleJoueur.BorderBrush = new SolidColorBrush(Colors.Orange);
                    Push();
                }
                else // JOUEUR WIN
                {
                    this.RectangleJoueur.BorderBrush = new SolidColorBrush(Colors.Green);
                    this.RectangleCroupier.BorderBrush = new SolidColorBrush(Colors.Red);
                    Win();
                }
            }
        }

        private void FinDuGame()
        {
            IsMiseEnable = true;
            IsResetEnable = true;
            IsTirerEnable = false;
            IsResterEnable = false;
            IsSplitEnable = false;
            IsDoubleEnable = false;
        }

        private void Win()
        {
            int Win = MiseActuelle * 2;
            Lobby.Joueur.Solde += Win;
            MiseActuelle = 0;
            CheckJetonSolde();
        }

        private void Lose()
        {
            MiseActuelle = 0;
            CheckJetonSolde();
        }

        private void Push()
        {
            Lobby.Joueur.Solde += MiseActuelle;
            MiseActuelle = 0;
            CheckJetonSolde();
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged; //Appel d'un délégué
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void MenuExitClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}