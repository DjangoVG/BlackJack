using System;
using System.Collections.Generic;

namespace BlackJackLibrary
{
    public class Sabot
    {
        private List<Carte> _sabot;

        public List<Carte> SabotJeu
        {
            get { return _sabot; }
            set { this._sabot = value; }
        }
        public Sabot()
        {
            _sabot = new List<Carte>();

            #region  J'ajoute au sabot 4 paquets de cartes

            for (int j = 0; j < 4; j++) // Carte de coeur
            {
                _sabot.Add(new Carte("1CoeurRouge", 1, "/Images/Cartes/1CoeurRouge.png"));
                _sabot.Add(new Carte("2CoeurRouge", 2, "/Images/Cartes/2CoeurRouge.png"));
                _sabot.Add(new Carte("3CoeurRouge", 3, "/Images/Cartes/3CoeurRouge.png"));
                _sabot.Add(new Carte("4CoeurRouge", 4, "/Images/Cartes/4CoeurRouge.png"));
                _sabot.Add(new Carte("5CoeurRouge", 5, "/Images/Cartes/5CoeurRouge.png"));
                _sabot.Add(new Carte("6CoeurRouge", 6, "/Images/Cartes/Cartes\\6CoeurRouge.png"));
                _sabot.Add(new Carte("7CoeurRouge", 7, "/Images/Cartes/7CoeurRouge.png"));
                _sabot.Add(new Carte("8CoeurRouge", 8, "/Images/Cartes/8CoeurRouge.png"));
                _sabot.Add(new Carte("9CoeurRouge", 9, "/Images/Cartes/9CoeurRouge.png"));
                _sabot.Add(new Carte("10CoeurRouge", 10, "/Images/Cartes/10CoeurRouge.png"));
                _sabot.Add(new Carte("ValetCoeurRouge", 10, "/Images/Cartes/ValetCoeurRouge.png"));
                _sabot.Add(new Carte("DameCoeurRouge", 10, "/Images/Cartes/DameCoeurRouge.png"));
                _sabot.Add(new Carte("RoiCoeurRouge", 10, "/Images/Cartes/RoiCoeurRouge.png"));
            }

            for (int j = 0; j < 4; j++) // Carte de pique
            {
                _sabot.Add(new Carte("1PiqueNoir", 1, "/Images/Cartes/1PiqueNoir.png"));
                _sabot.Add(new Carte("2PiqueNoir", 2, "/Images/Cartes/2PiqueNoir.png"));
                _sabot.Add(new Carte("3PiqueNoir", 3, "/Images/Cartes/3PiqueNoir.png"));
                _sabot.Add(new Carte("4PiqueNoir", 4, "/Images/Cartes/4PiqueNoir.png"));
                _sabot.Add(new Carte("5PiqueNoir", 5, "/Images/Cartes/5PiqueNoir.png"));
                _sabot.Add(new Carte("6PiqueNoir", 6, "/Images/Cartes/6PiqueNoir.png"));
                _sabot.Add(new Carte("7PiqueNoir", 7, "/Images/Cartes/7PiqueNoir.png"));
                _sabot.Add(new Carte("8PiqueNoir", 8, "/Images/Cartes/8PiqueNoir.png"));
                _sabot.Add(new Carte("9PiqueNoir", 9, "/Images/Cartes/9PiqueNoir.png"));
                _sabot.Add(new Carte("10PiqueNoir", 10, "/Images/Cartes/10PiqueNoir.png"));
                _sabot.Add(new Carte("ValetPiqueNoir", 10, "/Images/Cartes/ValetPiqueNoir.png"));
                _sabot.Add(new Carte("DamePiqueNoir", 10, "/Images/Cartes/DamePiqueNoir.png"));
                _sabot.Add(new Carte("RoiPiqueNoir", 10, "/Images/Cartes/RoiPiqueNoir.png"));
            }

            for (int j = 0; j < 4; j++) // Carte de carreau
            {
                _sabot.Add(new Carte("1CarreauRouge", 1, "/Images/Cartes/1CarreauRouge.png"));
                _sabot.Add(new Carte("2CarreauRouge", 2, "/Images/Cartes/2CarreauRouge.png"));
                _sabot.Add(new Carte("3CarreauRouge", 3, "/Images/Cartes/3CarreauRouge.png"));
                _sabot.Add(new Carte("4CarreauRouge", 4, "/Images/Cartes/4CarreauRouge.png"));
                _sabot.Add(new Carte("5CarreauRouge", 5, "/Images/Cartes/5CarreauRouge.png"));
                _sabot.Add(new Carte("6CarreauRouge", 6, "/Images/Cartes/6CarreauRouge.png"));
                _sabot.Add(new Carte("7CarreauRouge", 7, "/Images/Cartes/7CarreauRouge.png"));
                _sabot.Add(new Carte("8CarreauRouge", 8, "/Images/Cartes/8CarreauRouge.png"));
                _sabot.Add(new Carte("9CarreauRouge", 9, "/Images/Cartes/9CarreauRouge.png"));
                _sabot.Add(new Carte("10CarreauRouge", 10, "/Images/Cartes/10CarreauRouge.png"));
                _sabot.Add(new Carte("ValetCarreauRouge", 10, "/Images/Cartes/ValetCarreauRouge.png"));
                _sabot.Add(new Carte("DameCarreauRouge", 10, "/Images/Cartes/DameCarreauRouge.png"));
                _sabot.Add(new Carte("RoiCarreauRouge", 10, "/Images/Cartes/RoiCarreauRouge.png"));
            }

            for (int j = 0; j < 4; j++) // Carte de trefle
            {
                _sabot.Add(new Carte("1TrefleNoir", 1, "/Images/Cartes/1TrefleNoir.png"));
                _sabot.Add(new Carte("2TrefleNoir", 2, "/Images/Cartes/2TrefleNoir.png"));
                _sabot.Add(new Carte("3TrefleNoir", 3, "/Images/Cartes/3TrefleNoir.png"));
                _sabot.Add(new Carte("4TrefleNoir", 4, "/Images/Cartes/4TrefleNoir.png"));
                _sabot.Add(new Carte("5TrefleNoir", 5, "/Images/Cartes/5TrefleNoir.png"));
                _sabot.Add(new Carte("6TrefleNoir", 6, "/Images/Cartes/6TrefleNoir.png"));
                _sabot.Add(new Carte("7TrefleNoir", 7, "/Images/Cartes/7TrefleNoir.png"));
                _sabot.Add(new Carte("8TrefleNoir", 8, "/Images/Cartes/8TrefleNoir.png"));
                _sabot.Add(new Carte("9TrefleNoir", 9, "/Images/Cartes/9TrefleNoir.png"));
                _sabot.Add(new Carte("10TrefleNoir", 10, "/Images/Cartes/10TrefleNoir.png"));
                _sabot.Add(new Carte("ValetTrefleNoir", 10, "/Images/Cartes/ValetTrefleNoir.png"));
                _sabot.Add(new Carte("DameTrefleNoir", 10, "/Images/Cartes/DameTrefleNoir.png"));
                _sabot.Add(new Carte("RoiTrefleNoir", 10, "/Images/Cartes/RoiTrefleNoir.png"));
            }
            #endregion
            Shuffle(this._sabot); // Je mélange le sabot
        }

        public static void Shuffle(List<Carte> SabotActuel) // Mélange du sabot
        {
            System.Random _random = new System.Random();
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < SabotActuel.Count; j++)
                {
                    Carte temp = SabotActuel[j];
                    int randomIndex = _random.Next(j, SabotActuel.Count);
                    SabotActuel[j] = SabotActuel[randomIndex];
                    SabotActuel[randomIndex] = temp;
                }
            }
        }
    }
}
