﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace BlackJackLibrairie
{
    public class Joueur : IEtatActuel
    {
        [XmlAttribute]
        private string _email;
        [XmlAttribute]
        private string _nom;
        [XmlAttribute]
        private string _prenom;
        [XmlAttribute]
        private string _pseudo;
        [XmlAttribute]
        private string _motdepasse;

        #region PROPRIETES
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
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
        #endregion

        #region CONSTRUCTEURS
        public Joueur()
        {
            Nom = "";
            MotDePasse = "";
            Pseudo = "";
        }

        public Joueur(string email, string mdp, string pseudo)
        {
            Email = email;
            MotDePasse = mdp;
            Pseudo = pseudo;
        }
        #endregion

        #region METHODES
        public void SaveXML(string path)
        {
            XmlSerializer xmlformat = new XmlSerializer(typeof(Joueur));
            StreamWriter fstream = new StreamWriter(path, false);
            xmlformat.Serialize(fstream, this);
        }

        public static Joueur OpenXML(string path)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(Joueur));
            Stream fStream = File.OpenRead(path);
            return xmlFormat.Deserialize(fStream) as Joueur;
        }
        #endregion

        public bool ABust => throw new NotImplementedException();
    }
}