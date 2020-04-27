using BlackJackLibrairie;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;

namespace BlackJack
{
    /// <summary>
    /// Logique d'interaction pour FenetreHistorique.xaml
    /// </summary>
    public partial class FenetreHistorique : Window, INotifyPropertyChanged
    {
        private Game game { get; set; }
        private ObservableCollection<Game> _listgames;
        public ObservableCollection<Game> ListGame 
        {
            get
            {
                return _listgames;
            }
            set
            {
                _listgames = value;
                NotifyPropertyChanged();
            }
        }
        public FenetreHistorique(Joueur j)
        {
            InitializeComponent();
            HistoriqueJeux.DataContext = ListGame;
            XmlDocument FichierHistorique = new XmlDocument();
            FichierHistorique.Load("/Historique/" + j.Email + ".xml");
            XmlNodeList ListeGame = FichierHistorique.GetElementsByTagName("Game");
            foreach (XmlNode n in ListeGame)
            {
                Game game = new Game(n.Attributes[0].Value, n.Attributes[1].Value, Convert.ToInt32(n.Attributes[2].Value), Convert.ToInt32(n.Attributes[3].Value), n.Attributes[4].Value, n.Attributes[5].Value);
                ListGame.Add(game);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged; //Appel d'un délégué
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void BoutonValider(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
