using BlackJackLibrairie;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Media;

namespace BlackJack
{
    public partial class FenetreBlackJack : Window, INotifyPropertyChanged
    {
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

        private void CheckJetonSolde()
        {
            Console.WriteLine("Solde du joueur : " + Lobby.Joueur.Solde);
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

        private void BoutonPlayGame(object sender, EventArgs e)
        {
            if (MiseActuelle != 0)
            {
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
                    IsDoubleEnable = true;
                }
            }
        }

        private void BoutonResetJeton(object sender, EventArgs e)
        {
            Lobby.Joueur.Solde += MiseActuelle;
            MiseActuelle = 0;
            CheckJetonSolde();
        }

        private void BoutonTirer(object sender, EventArgs e)
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

        private void BoutonStand(object sender, EventArgs e)
        {
            while (Lobby.ValeurDeckCroupier() < 17)
            {
                Lobby.DonneCarteCroupier();
                GetValeur();
            }
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
            FinDuGame();
        }

        private void ClickBoutonRetirer(object sender, EventArgs e)
        {
        }

        private void ClickBoutonDeposer(object sender, EventArgs e)
        {
        }

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

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged; //Appel d'un délégué
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void GetValeur()
        {
            ValeurCroupier.Content = Lobby.ValeurDeckCroupier();
            ValeurJoueur.Content = Lobby.ValeurDeckJoueur();
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

        private void MenuExitClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}