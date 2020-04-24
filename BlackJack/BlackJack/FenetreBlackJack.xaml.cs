using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using BlackJackLibrairie;

namespace BlackJack
{
    public partial class FenetreBlackJack : Window, INotifyPropertyChanged
    {
        public Lobby Lobby { get; set; } = new Lobby();
        public int MiseActuelle { get; set; } = 0;
        public string Date { get; set; }

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

        public FenetreBlackJack(Joueur joueur)
        {
            InitializeComponent();
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
            SPInformation.DataContext = Lobby.Joueur;
            SPDate.DataContext = this;
            SPCroupier.DataContext = Lobby;
            SPJoueur.DataContext = Lobby;
            SPInformation.DataContext = Lobby.Joueur;
            BoutonMiser.DataContext = this;
            BoutonReset.DataContext = this;
            IsResetEnable = true;
            IsMiseEnable = true;

            
            // DATE
            Date = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
            ThreadDate threadDate = new ThreadDate(Date); // Démarrage thread Date
            Thread LetsgoDate = new Thread(threadDate.DemarrageDate);
            LetsgoDate.Start(); //Démarrage du thread
            
            Lobby.Joueur = joueur;
            Lobby.Croupier = new Croupier();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void BoutonPlayGame (object sender, EventArgs e)
        {
            MiseActuelle = 1; // A ENLEVER
            if (MiseActuelle != 0)
            {
                this.RectangleCroupier.BorderBrush = new SolidColorBrush(Colors.White);
                this.RectangleJoueur.BorderBrush = new SolidColorBrush(Colors.White);
                Lobby.StartGame();
                IsResetEnable = false;
                IsMiseEnable = false;
                GetValeur(); // Affichage de la valeur de la main du croupier/joueur
            }
            if (Lobby.ValeurDeckJoueur() == 21)
            {
                Lobby.DonneCarteCroupier();
                GetValeur();
                if (Lobby.ValeurDeckCroupier() == 21)
                {
                    this.RectangleCroupier.BorderBrush = new SolidColorBrush(Colors.Orange);
                    this.RectangleJoueur.BorderBrush = new SolidColorBrush(Colors.Orange);
                }
                else
                {
                    this.RectangleCroupier.BorderBrush = new SolidColorBrush(Colors.Red);
                    this.RectangleJoueur.BorderBrush = new SolidColorBrush(Colors.Green);
                }
                IsResetEnable = true;
                IsMiseEnable = true;
            }
        }

        private void BoutonTirer (object sender, EventArgs e)
        {
            Lobby.DonneCarteJoueur();
            GetValeur();
            if (Lobby.ValeurDeckJoueur() > 21)
            {
                this.RectangleCroupier.BorderBrush = new SolidColorBrush(Colors.Green);
                this.RectangleJoueur.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            IsMiseEnable = true;
            IsResetEnable = true;
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
            }
            else if (Lobby.ValeurDeckJoueur() == Lobby.ValeurDeckCroupier()) // PUSH
            {
                this.RectangleCroupier.BorderBrush = new SolidColorBrush(Colors.Orange);
                this.RectangleJoueur.BorderBrush = new SolidColorBrush(Colors.Orange);
            }
            else // JOUEUR WIN
            {
                this.RectangleJoueur.BorderBrush = new SolidColorBrush(Colors.Green);
                this.RectangleCroupier.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            IsMiseEnable = true;
            IsResetEnable = true;
        }

        private void ClickBoutonRetirer(object sender, EventArgs e)
        {

        }

        private void ClickBoutonDeposer(object sender, EventArgs e)
        {

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

        private void MenuExitClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
