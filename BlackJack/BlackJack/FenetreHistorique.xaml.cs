using BlackJackLibrairie;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Xml;
using System.Xml.Linq;

namespace BlackJack
{
    public partial class FenetreHistorique : Window, INotifyPropertyChanged
    {
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
            ListGame = new ObservableCollection<Game>();
            HistoriqueJeuxData.DataContext = this;

            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Users\Regis\Bureau\RegisServer\1. Info. de Gestion\2ème Année\C#\Laboratoire\labo-phase-3-DjangoVG\BlackJack\BlackJack\Historique\" + j.Email + ".xml");
            XmlNode nodes = doc.DocumentElement.SelectSingleNode("/HistoriqueJeux");

            string dategame = null;
            string miseactuelle = null;
            int maincroupier = 0;
            int mainjoueur = 0;
            string gain = null;
            string perte = null;


            foreach (XmlNode node in nodes.ChildNodes)
            {
                foreach (XmlNode nod in node.ChildNodes)
                {
                    if (nod.Name.Equals("DateGame"))
                        dategame = nod.InnerText;
                    if (nod.Name.Equals("MiseActuelle"))
                        miseactuelle = nod.InnerText;
                    if (nod.Name.Equals("MainCroupier"))
                        maincroupier = Convert.ToInt32(nod.InnerText);
                    if (nod.Name.Equals("MainJoueur"))
                        mainjoueur = Convert.ToInt32(nod.InnerText);
                    if (nod.Name.Equals("Gain"))
                        gain = nod.InnerText;
                    if (nod.Name.Equals("Perte"))
                        perte = nod.InnerText;
                }
                Game game = new Game(dategame, miseactuelle, maincroupier, mainjoueur, gain, perte);
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
