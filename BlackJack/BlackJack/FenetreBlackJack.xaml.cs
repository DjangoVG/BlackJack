using BlackJackLibrairie;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Xml;

namespace BlackJack
{
    public partial class FenetreBlackJack : Window, INotifyPropertyChanged
    {
        #region PROPRIETES

        public Lobby Lobby { get; set; } = new Lobby();
        private int _mise;
        private Probabilités Proba { get; set; }

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

        public string _date;

        public string Date
        {
            set
            {
                _date = value;
                NotifyPropertyChanged();
            }
            get
            {
                return _date;
            }
        }

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

        #endregion PROPRIETES

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

        private Boolean _isTirerProba;

        public Boolean IsTirerProba
        {
            get
            {
                return _isTirerProba;
            }
            set
            {
                _isTirerProba = value;
                NotifyPropertyChanged();
            }
        }

        private Boolean _isResterProba;

        public Boolean IsResterProba
        {
            get
            {
                return _isResterProba;
            }
            set
            {
                _isResterProba = value;
                NotifyPropertyChanged();
            }
        }

        private Boolean _isSplitProba;

        public Boolean IsSplitProba
        {
            get
            {
                return _isSplitProba;
            }
            set
            {
                _isSplitProba = value;
                NotifyPropertyChanged();
            }
        }

        private Boolean _isDoubleProba;

        public Boolean IsDoubleProba
        {
            get
            {
                return _isDoubleProba;
            }
            set
            {
                _isDoubleProba = value;
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

        private Boolean _isCoEnable;

        public Boolean IsEnableConnecter
        {
            get
            {
                return _isCoEnable;
            }
            set
            {
                _isCoEnable = value;
                NotifyPropertyChanged();
            }
        }

        private Boolean _isDecoEnable;

        public Boolean IsEnableDeconnecter
        {
            get
            {
                return _isDecoEnable;
            }
            set
            {
                _isDecoEnable = value;
                NotifyPropertyChanged();
            }
        }

        public StreamWriter fstream { get; private set; }

        public bool CouleurFond { get; set; }

        #endregion Boolean ENABLE

        public FenetreBlackJack(Joueur joueur)
        {
            InitializeComponent();

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
            MenuJoueur.DataContext = this;
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
            IsEnableConnecter = false;
            IsEnableDeconnecter = true;
            ResetProba();

            Is5Enable = true;
            Is10Enable = true;
            Is50Enable = true;
            Is100Enable = true;
            Is200Enable = true;

            FinishDeck1 = false;

            // DATE
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

            CouleurFond = true;

            Lobby.Joueur = joueur;
            CheckJetonSolde();
            Lobby.Croupier = new Croupier();

            string filepath = @"C:\Users\Regis\Bureau\RegisServer\1. Info. de Gestion\2ème Année\C#\Laboratoire\labo-phase-3-DjangoVG\BlackJack\BlackJack\Historique\" + Lobby.Joueur.Email + ".xml";
            if (!File.Exists(filepath))
            {
                XmlTextWriter xml = new XmlTextWriter(filepath, System.Text.Encoding.UTF8);
                xml.WriteStartDocument();
                xml.WriteStartElement("HistoriqueJeux");
                xml.WriteEndElement();
                xml.Flush();
                xml.Close();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void timer_Tick(object sender, EventArgs e)
        {
            Date = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
        }

        private void BoutonPlayGame(object sender, EventArgs e)
        {
            ResetProba();
            FinishDeck1 = false;
            if (MiseActuelle != 0)
            {
                if (RectangleJoueur2.Visibility == Visibility.Visible)
                    ResetFrontEnd();

                Is5Enable = false;
                Is10Enable = false;
                Is50Enable = false;
                Is100Enable = false;
                Is200Enable = false;
                this.RectangleCroupier.BorderBrush = new SolidColorBrush(Colors.White);
                this.RectangleJoueur.BorderBrush = new SolidColorBrush(Colors.White);
                Lobby.StartGame();
                GetValeur(); // Affichage de la valeur de la main du croupier/joueur

                if (MiseActuelle <= Lobby.Joueur.Solde)
                {
                    IsDoubleEnable = true;
                    if (Lobby.MemeValeurCarte())
                        IsSplitEnable = true;
                    else
                        IsSplitEnable = false;
                }
                else
                {
                    IsDoubleEnable = false;
                    IsSplitEnable = false;
                }

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
                        WinBJ();
                    }
                    FinDuGame();
                }
                else
                {
                    IsResetEnable = false;
                    IsMiseEnable = false;
                    IsTirerEnable = true;
                    IsResterEnable = true;
                }
            }
        }

        private void BoutonTirer(object sender, EventArgs e)
        {
            ResetProba();
            IsDoubleEnable = false;
            if (RectangleJoueur2.Visibility == Visibility.Visible) // Joueur a SPLIT
            {
                if (!FinishDeck1) // Je suis sur le deck 1
                {
                    Lobby.DonneCarteJoueur();
                    GetValeur();
                    if (Lobby.ValeurDeckJoueur() > 21)
                    {
                        RectangleJoueur.BorderBrush = new SolidColorBrush(Colors.Red);
                        RectangleJoueur2.BorderBrush = new SolidColorBrush(Colors.Blue);
                        FinishDeck1 = true;
                        GetValeurDeck2();
                    }
                    else if (Lobby.ValeurDeckJoueur() == 21)
                    {
                        FinishDeck1 = true;
                        RectangleJoueur2.BorderBrush = new SolidColorBrush(Colors.Blue);
                        GetValeurDeck2();
                    }
                }
                else // Je suis sur le deck 2
                {
                    Lobby.DonneCarteJoueurDeck2(Carte2);
                    GetValeurDeck2();
                    if (Lobby.ValeurDeckJoueur2(Carte2) > 21)
                    {
                        RectangleJoueur2.BorderBrush = new SolidColorBrush(Colors.Red);

                        if (Lobby.ValeurDeckJoueur() > 21)
                            RectangleCroupier.BorderBrush = new SolidColorBrush(Colors.Green);
                        else
                        {
                            while (Lobby.ValeurDeckCroupier() < 17)
                            {
                                Lobby.DonneCarteCroupier();
                                GetValeur();
                            }
                        }
                        VerifGagnant();
                    }
                    else if (Lobby.ValeurDeckJoueur2(Carte2) == 21)
                    {
                        while (Lobby.ValeurDeckCroupier() < 17)
                        {
                            Lobby.DonneCarteCroupier();
                            GetValeur();
                        }
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
                else if (Lobby.ValeurDeckJoueur() == 21)
                {
                    while (Lobby.ValeurDeckCroupier() < 17)
                    {
                        Lobby.DonneCarteCroupier();
                        GetValeur();
                    }
                    VerifGagnant();
                }
            }
        }

        private void BoutonStand(object sender, EventArgs e)
        {
            ResetProba();
            if (RectangleJoueur2.Visibility == Visibility.Visible)
            {
                if (!FinishDeck1) // Je suis sur le deck 1
                {
                    FinishDeck1 = true;

                    if (Lobby.ValeurDeckJoueur2(Carte2) == 21)
                    {
                        GetValeurDeck2();
                        while (Lobby.ValeurDeckCroupier() < 17)
                        {
                            Lobby.DonneCarteCroupier();
                            GetValeur();
                        }
                        VerifGagnant();
                    }
                    else
                    {
                        RectangleJoueur2.BorderBrush = new SolidColorBrush(Colors.Blue);
                        RectangleJoueur.BorderBrush = new SolidColorBrush(Colors.White);
                    }
                    GetValeurDeck2();
                }
                else // Je suis sur le deck 2
                {
                    while (Lobby.ValeurDeckCroupier() < 17)
                    {
                        Lobby.DonneCarteCroupier();
                        GetValeur();
                    }
                    VerifGagnant();
                }
            }
            else // Game normal sans SPLIT
            {
                while (Lobby.ValeurDeckCroupier() < 17)
                {
                    Lobby.DonneCarteCroupier();
                    GetValeur();
                }
                VerifGagnant();
            }
        }

        private void BoutonDouble(object sender, EventArgs e)
        {
            ResetProba();
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
            ResetProba();
            IsSplitEnable = false;
            IsDoubleEnable = false;
            Lobby.Joueur.Solde -= MiseActuelle;
            MiseActuelle += MiseActuelle;
            System.Windows.Controls.ColumnDefinition newColumn = new System.Windows.Controls.ColumnDefinition();
            GridJoueur.ColumnDefinitions.Add(newColumn);

            RectangleJoueur.Margin = new Thickness(0, 0, 10, 0);
            RectangleJoueur2.Visibility = Visibility.Visible;

            Carte2 = new ObservableCollection<Carte>();
            Carte2.Add(Lobby.CartesJoueur[1]);
            Lobby.CartesJoueur.RemoveAt(1);
            Lobby.DonneCarteJoueur();
            Lobby.DonneCarteJoueurDeck2(Carte2);

            if (Lobby.ValeurDeckJoueur() == 21)
            {
                if (Lobby.ValeurDeckJoueur2(Carte2) == 21)
                {
                    FinishDeck1 = true;
                    RectangleJoueur.BorderBrush = new SolidColorBrush(Colors.White);
                    RectangleJoueur2.BorderBrush = new SolidColorBrush(Colors.White);
                    GetValeur();
                    while (Lobby.ValeurDeckCroupier() < 17)
                    {
                        Lobby.DonneCarteCroupier();
                        GetValeur();
                    }
                    VerifGagnant();
                }
                else
                {
                    RectangleJoueur.BorderBrush = new SolidColorBrush(Colors.White);
                    RectangleJoueur2.BorderBrush = new SolidColorBrush(Colors.Blue);
                    GetValeurDeck2();
                }
            }
            else
            {
                RectangleJoueur.BorderBrush = new SolidColorBrush(Colors.Blue);
                GetValeur();
            }
        }

        private void ClickBoutonRetirerDeposer(object sender, EventArgs e)
        {
            var fen = new FenetreArgent(Lobby.Joueur);
            fen.ShowDialog();
            CheckJetonSolde();
        }

        private void ClickBoutonSeDeco(object sender, EventArgs e)
        {
            JoueurManager jm = new JoueurManager();
            jm.SaveRegistrySolde(Lobby.Joueur.Email, Lobby.Joueur.Solde);

            var Fen = new FenetreLogin();
            Fen.Show();
            this.Close();
        }

        private void ResetFrontEnd()
        {
            GridJoueur.ColumnDefinitions.RemoveAt(1);
            RectangleJoueur2.Visibility = Visibility.Hidden;
            RectangleJoueur.Margin = new Thickness(0, 0, 0, 0);
            RectangleJoueur2.BorderBrush = new SolidColorBrush(Colors.White);
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

        #endregion BOUTONS JETONS

        private void GetValeur()
        {
            ValeurCroupier.Content = Lobby.ValeurDeckCroupier();
            ValeurJoueur.Content = Lobby.ValeurDeckJoueur();
        }

        private void GetValeurDeck2()
        {
            ValeurJoueur.Content = Lobby.ValeurDeckJoueur2(Carte2);
        }

        private void VerifGagnant()
        {
            bool win = false;
            bool push = false;

            if (Lobby.ValeurDeckCroupier() > 21)
                Lobby.Croupier.ABust = true;
            else
                Lobby.Croupier.ABust = false;

            if (RectangleJoueur2.Visibility == Visibility.Hidden)
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
            else
            {
                if (Lobby.ValeurDeckJoueur2(Carte2) > 21)
                {
                    this.RectangleJoueur2.BorderBrush = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    if (Lobby.ValeurDeckCroupier() > Lobby.ValeurDeckJoueur2(Carte2) && !Lobby.Croupier.ABust) // CROUPIER WIN DECK 2
                        this.RectangleJoueur2.BorderBrush = new SolidColorBrush(Colors.Red);
                    else if (Lobby.ValeurDeckJoueur2(Carte2) == Lobby.ValeurDeckCroupier()) // PUSH DECK 2
                        this.RectangleJoueur2.BorderBrush = new SolidColorBrush(Colors.Orange);
                    else
                        this.RectangleJoueur2.BorderBrush = new SolidColorBrush(Colors.Green);
                }

                if (Lobby.ValeurDeckJoueur() > 21)
                {
                    this.RectangleJoueur.BorderBrush = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    if (Lobby.ValeurDeckCroupier() > Lobby.ValeurDeckJoueur() && !Lobby.Croupier.ABust) // CROUPIER WIN DECK 1
                        this.RectangleJoueur.BorderBrush = new SolidColorBrush(Colors.Red);
                    else if (Lobby.ValeurDeckJoueur() == Lobby.ValeurDeckCroupier()) // PUSH DECK 1
                        this.RectangleJoueur.BorderBrush = new SolidColorBrush(Colors.Orange);
                    else
                        this.RectangleJoueur.BorderBrush = new SolidColorBrush(Colors.Green);
                }

                if (RectangleJoueur.BorderBrush.ToString() == new SolidColorBrush(Colors.Green).ToString() && RectangleJoueur2.BorderBrush.ToString() == new SolidColorBrush(Colors.Green).ToString()) // SI 2 VERTS -> CROUPIER A PERDU
                    this.RectangleCroupier.BorderBrush = new SolidColorBrush(Colors.Red);
                else if ((RectangleJoueur.BorderBrush.ToString() == new SolidColorBrush(Colors.Red).ToString() && RectangleJoueur2.BorderBrush.ToString() == new SolidColorBrush(Colors.Green).ToString()) || (RectangleJoueur2.BorderBrush.ToString() == new SolidColorBrush(Colors.Red).ToString() && RectangleJoueur.BorderBrush.ToString() == new SolidColorBrush(Colors.Green).ToString())) // SI 1 ROUGE 1 VERT -> CROUPIER PUSH
                    this.RectangleCroupier.BorderBrush = new SolidColorBrush(Colors.Orange);
                else // 2 ROUGES OU 1 ORANGE/ 1 ROUGE -> CROUPIER GAGNE
                    this.RectangleCroupier.BorderBrush = new SolidColorBrush(Colors.Green);

                CheckDoubleWin();
            }
            FinDuGame();
        }

        private void ResetProba()
        {
            IsTirerProba = false;
            IsResterProba = false;
            IsSplitProba = false;
            IsDoubleProba = false;
        }

        private void EnregistrementGame(Game g)
        {
            Console.WriteLine("ENREGISTREMENT GAME");
            string path = @"C:\Users\Regis\Bureau\RegisServer\1. Info. de Gestion\2ème Année\C#\Laboratoire\labo-phase-3-DjangoVG\BlackJack\BlackJack\Historique\" + Lobby.Joueur.Email + ".xml";
            Game.SaveInXML(g, path);
        }

        private void CheckDoubleWin()
        {
            if (RectangleJoueur.BorderBrush.ToString() == new SolidColorBrush(Colors.Green).ToString())
            {
                Game game = new Game(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"), Convert.ToString(MiseActuelle / 2), Lobby.ValeurDeckCroupier(), Lobby.ValeurDeckJoueur(), "+ " + Convert.ToString(MiseActuelle / 2) + "€", "0€");
                EnregistrementGame(game);
                Lobby.Joueur.Solde += MiseActuelle;
            }
            if (RectangleJoueur2.BorderBrush.ToString() == new SolidColorBrush(Colors.Green).ToString())
            {
                Game game = new Game(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"), Convert.ToString(MiseActuelle / 2), Lobby.ValeurDeckCroupier(), Lobby.ValeurDeckJoueur2(Carte2), "+ " + Convert.ToString(MiseActuelle / 2) + "€", "0€");
                EnregistrementGame(game);
                Lobby.Joueur.Solde += MiseActuelle;
            }
            if (RectangleJoueur.BorderBrush.ToString() == new SolidColorBrush(Colors.Orange).ToString())
            {
                Game game = new Game(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"), Convert.ToString(MiseActuelle / 2), Lobby.ValeurDeckCroupier(), Lobby.ValeurDeckJoueur(), "0€", "0€");
                EnregistrementGame(game);
                int Push = MiseActuelle / 2;
                Lobby.Joueur.Solde += Push;
            }
            if (RectangleJoueur2.BorderBrush.ToString() == new SolidColorBrush(Colors.Orange).ToString())
            {
                Game game = new Game(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"), Convert.ToString(MiseActuelle / 2), Lobby.ValeurDeckCroupier(), Lobby.ValeurDeckJoueur2(Carte2), "0€", "0€");
                EnregistrementGame(game);
                int Push = MiseActuelle / 2;
                Lobby.Joueur.Solde += Push;
            }
            if (RectangleJoueur.BorderBrush.ToString() == new SolidColorBrush(Colors.Red).ToString())
            {
                Game game = new Game(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"), Convert.ToString(MiseActuelle / 2), Lobby.ValeurDeckCroupier(), Lobby.ValeurDeckJoueur2(Carte2), "0€", "- " + Convert.ToString(MiseActuelle / 2) + "€");
                EnregistrementGame(game);
            }
            if (RectangleJoueur2.BorderBrush.ToString() == new SolidColorBrush(Colors.Red).ToString())
            {
                Game game = new Game(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"), Convert.ToString(MiseActuelle / 2), Lobby.ValeurDeckCroupier(), Lobby.ValeurDeckJoueur2(Carte2), "0€", "- " + Convert.ToString(MiseActuelle / 2) + "€");
                EnregistrementGame(game);
            }
            MiseActuelle = 0;
            FinDuGame();
        }

        private void FinDuGame()
        {
            IsMiseEnable = true;
            IsResetEnable = true;
            IsTirerEnable = false;
            IsResterEnable = false;
            IsSplitEnable = false;
            IsDoubleEnable = false;
            CheckJetonSolde();
        }

        private void Win()
        {
            Game game = new Game(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"), Convert.ToString(MiseActuelle), Lobby.ValeurDeckCroupier(), Lobby.ValeurDeckJoueur(), "+ " + Convert.ToString(MiseActuelle) + "€", "0€");
            EnregistrementGame(game);
            int Win = MiseActuelle * 2;
            Lobby.Joueur.Solde += Win;
            MiseActuelle = 0;
            CheckJetonSolde();
        }

        private void WinBJ()
        {
            double Mise = Convert.ToDouble(MiseActuelle);
            double Win = (Mise * 2) + (Mise / 2);
            Game game = new Game(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"), Convert.ToString(MiseActuelle), Lobby.ValeurDeckCroupier(), Lobby.ValeurDeckJoueur(), "(BJ) + " + Convert.ToString(Win) + "€", "0€");
            EnregistrementGame(game);
            Lobby.Joueur.Solde += Win;
            MiseActuelle = 0;
            CheckJetonSolde();
        }

        private void Lose()
        {
            Game game = new Game(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"), Convert.ToString(MiseActuelle), Lobby.ValeurDeckCroupier(), Lobby.ValeurDeckJoueur(), "0€", "- " + Convert.ToString(MiseActuelle) + "€");
            EnregistrementGame(game);
            MiseActuelle = 0;
            CheckJetonSolde();
        }

        private void Push()
        {
            Game game = new Game(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"), Convert.ToString(MiseActuelle), Lobby.ValeurDeckCroupier(), Lobby.ValeurDeckJoueur(), "0€", "0€");
            EnregistrementGame(game);
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
            JoueurManager jm = new JoueurManager();
            jm.SaveRegistrySolde(Lobby.Joueur.Email, Lobby.Joueur.Solde);

            Environment.Exit(0);
        }

        private void BoutonHistorique(object sender, RoutedEventArgs e)
        {
            FenetreHistorique fen = new FenetreHistorique(Lobby.Joueur);
            fen.ShowDialog();
        }

        private void BoutonProbabilités(object sender, RoutedEventArgs e)
        {
            ResetProba();
            Proba = new Probabilités(Lobby, Carte2);
            if (RectangleJoueur2.Visibility == Visibility.Visible)
            {
                if (RectangleJoueur2.BorderBrush.ToString() == new SolidColorBrush(Colors.Blue).ToString())
                {
                    if (Proba.GetProbDeck2().ToString().Equals("Tirer"))
                        IsTirerProba = true;
                    else if (Proba.GetProbDeck2().ToString().Equals("Stand"))
                        IsResterProba = true;
                }
                else
                {
                    if (Proba.GetProb().ToString().Equals("Tirer"))
                        IsTirerProba = true;
                    else if (Proba.GetProb().ToString().Equals("Stand"))
                        IsResterProba = true;
                }
            }
            else
            {
                if (Lobby.ValeurDeckJoueur() > 0)
                {
                    if (Proba.GetProb().ToString().Equals("Tirer"))
                        IsTirerProba = true;
                    else if (Proba.GetProb().ToString().Equals("Stand"))
                        IsResterProba = true;
                    else if (Proba.GetProb().ToString().Equals("Split"))
                        IsSplitProba = true;
                    else
                        IsDoubleProba = true;
                }
            }
        }

        private void BoutonDate(object sender, RoutedEventArgs e)
        {

        }

        private void BoutonOption(object sender, RoutedEventArgs e)
        {
            var Option = new FenetreOption();
            Option.Owner = this;
            Option.Show();

            Option.OptionsEvent += OptionsApplyClick;
        }

        private void OptionsApplyClick(FenetreOption fen)
        {
            if (fen.RectangleFond.Fill.ToString() == new SolidColorBrush(Colors.DarkGreen).ToString())
            {
                BitmapImage glowIcon = new BitmapImage();
                glowIcon.BeginInit();
                glowIcon.UriSource = new Uri("../../Images/Autres/FondVert.jpeg", UriKind.Relative);
                glowIcon.EndInit();
                FondSP.ImageSource = glowIcon;
            }

            else
            {
                BitmapImage glowIcon = new BitmapImage();
                glowIcon.BeginInit();
                glowIcon.UriSource = new Uri("../../Images/Autres/FondBleu.jpg", UriKind.Relative);
                glowIcon.EndInit();
                FondSP.ImageSource = glowIcon;
            }
                
        }
    }
}