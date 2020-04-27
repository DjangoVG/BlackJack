using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace BlackJackLibrairie
{
    public class Game
    {
        [XmlAttribute]
        private string _datenowstring;

        public string DateGame
        {
            get
            {
                return _datenowstring;
            }
            set
            {
                _datenowstring = value;
            }
        }

        [XmlAttribute]
        private string _miseactuelle;

        public string MiseActuelle
        {
            get
            {
                return _miseactuelle;
            }
            set
            {
                _miseactuelle = value;
            }
        }

        [XmlAttribute]
        private int _maincroupier;

        public int MainCroupier
        {
            get
            {
                return _maincroupier;
            }
            set
            {
                _maincroupier = value;
            }
        }

        [XmlAttribute]
        private int _mainjoueur;

        public int MainJoueur
        {
            get
            {
                return _mainjoueur;
            }
            set
            {
                _mainjoueur = value;
            }
        }

        [XmlAttribute]
        private string _gain;

        public string Gain
        {
            get
            {
                return _gain;
            }
            set
            {
                _gain = value;
            }
        }

        [XmlAttribute]
        private string _perte;

        public string Perte
        {
            get
            {
                return _perte;
            }
            set
            {
                _perte = value;
            }
        }

        public static StreamWriter fstream { get; private set; }

        public Game()
        {
            DateGame = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
            MiseActuelle = null;
            MainCroupier = 0;
            MainJoueur = 0;
            Gain = null;
            Perte = null;
        }

        public Game (string d, String Mise, int mainCroupier, int mainJoueur, string gain, string perte)
        {
            DateGame = d;
            MiseActuelle = Mise;
            MainCroupier = mainCroupier;
            MainJoueur = mainJoueur;
            Gain = gain;
            Perte = perte;
        }

        public override string ToString()
        {
            return DateGame + ";" + MiseActuelle + ";" + Convert.ToString(MainCroupier) + ";" + Convert.ToString(MainJoueur) + ";" + Gain + ";" + Perte;
        }

        public static void SaveInXML(Game g, string path)
        {
            XDocument doc = XDocument.Load(path);
            XElement HistoriqueJeux = doc.Element("HistoriqueJeux");

            HistoriqueJeux.Add(new XElement("Game"));
            IEnumerable<XElement> rows = HistoriqueJeux.Descendants("Game");

            XElement Game = rows.Last();

            Game.Add(new XElement("DateGame", g.DateGame), new XElement("MiseActuelle", g.MiseActuelle), new XElement("MainCroupier", g.MainCroupier), new XElement("MainJoueur", g.MainJoueur), new XElement("Gain", g.Gain), new XElement("Perte", g.Perte));
            doc.Save(path);
        }
    }
}
