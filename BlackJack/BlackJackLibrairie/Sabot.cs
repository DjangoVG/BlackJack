using System;
using System.Collections.Generic;

namespace BlackJackLibrairie
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
                _sabot.Add(new Carte(TypeCarte.Coeur, ValeurCarte.As, "/Images/Cartes/1CoeurRouge.png"));
                _sabot.Add(new Carte(TypeCarte.Coeur, ValeurCarte.Deux, "/Images/Cartes/2CoeurRouge.png"));
                _sabot.Add(new Carte(TypeCarte.Coeur, ValeurCarte.Trois, "/Images/Cartes/3CoeurRouge.png"));
                _sabot.Add(new Carte(TypeCarte.Coeur, ValeurCarte.Quatre, "/Images/Cartes/4CoeurRouge.png"));
                _sabot.Add(new Carte(TypeCarte.Coeur, ValeurCarte.Cinq, "/Images/Cartes/5CoeurRouge.png"));
                _sabot.Add(new Carte(TypeCarte.Coeur, ValeurCarte.Six, "/Images/Cartes/6CoeurRouge.png"));
                _sabot.Add(new Carte(TypeCarte.Coeur, ValeurCarte.Sept, "/Images/Cartes/7CoeurRouge.png"));
                _sabot.Add(new Carte(TypeCarte.Coeur, ValeurCarte.Huit, "/Images/Cartes/8CoeurRouge.png"));
                _sabot.Add(new Carte(TypeCarte.Coeur, ValeurCarte.Neuf, "/Images/Cartes/9CoeurRouge.png"));
                _sabot.Add(new Carte(TypeCarte.Coeur, ValeurCarte.Dix, "/Images/Cartes/10CoeurRouge.png"));
                _sabot.Add(new Carte(TypeCarte.Coeur, ValeurCarte.Valet, "/Images/Cartes/ValetCoeurRouge.png"));
                _sabot.Add(new Carte(TypeCarte.Coeur, ValeurCarte.Dame, "/Images/Cartes/DameCoeurRouge.png"));
                _sabot.Add(new Carte(TypeCarte.Coeur, ValeurCarte.Roi, "/Images/Cartes/RoiCoeurRouge.png"));
            }

            for (int j = 0; j < 4; j++) // Carte de pique
            {
                _sabot.Add(new Carte(TypeCarte.Pique, ValeurCarte.As, "/Images/Cartes/1PiqueNoir.png"));
                _sabot.Add(new Carte(TypeCarte.Pique, ValeurCarte.Deux, "/Images/Cartes/2PiqueNoir.png"));
                _sabot.Add(new Carte(TypeCarte.Pique, ValeurCarte.Trois, "/Images/Cartes/3PiqueNoir.png"));
                _sabot.Add(new Carte(TypeCarte.Pique, ValeurCarte.Quatre, "/Images/Cartes/4PiqueNoir.png"));
                _sabot.Add(new Carte(TypeCarte.Pique, ValeurCarte.Cinq, "/Images/Cartes/5PiqueNoir.png"));
                _sabot.Add(new Carte(TypeCarte.Pique, ValeurCarte.Six, "/Images/Cartes/6PiqueNoir.png"));
                _sabot.Add(new Carte(TypeCarte.Pique, ValeurCarte.Sept, "/Images/Cartes/7PiqueNoir.png"));
                _sabot.Add(new Carte(TypeCarte.Pique, ValeurCarte.Huit, "/Images/Cartes/8PiqueNoir.png"));
                _sabot.Add(new Carte(TypeCarte.Pique, ValeurCarte.Neuf, "/Images/Cartes/9PiqueNoir.png"));
                _sabot.Add(new Carte(TypeCarte.Pique, ValeurCarte.Dix, "/Images/Cartes/10PiqueNoir.png"));
                _sabot.Add(new Carte(TypeCarte.Pique, ValeurCarte.Valet, "/Images/Cartes/ValetPiqueNoir.png"));
                _sabot.Add(new Carte(TypeCarte.Pique, ValeurCarte.Dame, "/Images/Cartes/DamePiqueNoir.png"));
                _sabot.Add(new Carte(TypeCarte.Pique, ValeurCarte.Roi, "/Images/Cartes/RoiPiqueNoir.png"));
            }

            for (int j = 0; j < 4; j++) // Carte de carreau
            {
                _sabot.Add(new Carte(TypeCarte.Carreau, ValeurCarte.As, "/Images/Cartes/1CarreauRouge.png"));
                _sabot.Add(new Carte(TypeCarte.Carreau, ValeurCarte.Deux, "/Images/Cartes/2CarreauRouge.png"));
                _sabot.Add(new Carte(TypeCarte.Carreau, ValeurCarte.Trois, "/Images/Cartes/3CarreauRouge.png"));
                _sabot.Add(new Carte(TypeCarte.Carreau, ValeurCarte.Quatre, "/Images/Cartes/4CarreauRouge.png"));
                _sabot.Add(new Carte(TypeCarte.Carreau, ValeurCarte.Cinq, "/Images/Cartes/5CarreauRouge.png"));
                _sabot.Add(new Carte(TypeCarte.Carreau, ValeurCarte.Six, "/Images/Cartes/6CarreauRouge.png"));
                _sabot.Add(new Carte(TypeCarte.Carreau, ValeurCarte.Sept, "/Images/Cartes/7CarreauRouge.png"));
                _sabot.Add(new Carte(TypeCarte.Carreau, ValeurCarte.Huit, "/Images/Cartes/8CarreauRouge.png"));
                _sabot.Add(new Carte(TypeCarte.Carreau, ValeurCarte.Neuf, "/Images/Cartes/9CarreauRouge.png"));
                _sabot.Add(new Carte(TypeCarte.Carreau, ValeurCarte.Dix, "/Images/Cartes/10CarreauRouge.png"));
                _sabot.Add(new Carte(TypeCarte.Carreau, ValeurCarte.Valet, "/Images/Cartes/ValetCarreauRouge.png"));
                _sabot.Add(new Carte(TypeCarte.Carreau, ValeurCarte.Dame, "/Images/Cartes/DameCarreauRouge.png"));
                _sabot.Add(new Carte(TypeCarte.Carreau, ValeurCarte.Roi, "/Images/Cartes/RoiCarreauRouge.png"));
            }

            for (int j = 0; j < 4; j++) // Carte de trefle
            {
                _sabot.Add(new Carte(TypeCarte.Trefle, ValeurCarte.As, "/Images/Cartes/1TrefleNoir.png"));
                _sabot.Add(new Carte(TypeCarte.Trefle, ValeurCarte.Deux, "/Images/Cartes/2TrefleNoir.png"));
                _sabot.Add(new Carte(TypeCarte.Trefle, ValeurCarte.Trois, "/Images/Cartes/3TrefleNoir.png"));
                _sabot.Add(new Carte(TypeCarte.Trefle, ValeurCarte.Quatre, "/Images/Cartes/4TrefleNoir.png"));
                _sabot.Add(new Carte(TypeCarte.Trefle, ValeurCarte.Cinq, "/Images/Cartes/5TrefleNoir.png"));
                _sabot.Add(new Carte(TypeCarte.Trefle, ValeurCarte.Six, "/Images/Cartes/6TrefleNoir.png"));
                _sabot.Add(new Carte(TypeCarte.Trefle, ValeurCarte.Sept, "/Images/Cartes/7TrefleNoir.png"));
                _sabot.Add(new Carte(TypeCarte.Trefle, ValeurCarte.Huit, "/Images/Cartes/8TrefleNoir.png"));
                _sabot.Add(new Carte(TypeCarte.Trefle, ValeurCarte.Neuf, "/Images/Cartes/9TrefleNoir.png"));
                _sabot.Add(new Carte(TypeCarte.Trefle, ValeurCarte.Dix, "/Images/Cartes/10TrefleNoir.png"));
                _sabot.Add(new Carte(TypeCarte.Trefle, ValeurCarte.Valet, "/Images/Cartes/ValetTrefleNoir.png"));
                _sabot.Add(new Carte(TypeCarte.Trefle, ValeurCarte.Dame, "/Images/Cartes/DameTrefleNoir.png"));
                _sabot.Add(new Carte(TypeCarte.Trefle, ValeurCarte.Roi, "/Images/Cartes/RoiTrefleNoir.png"));
            }
            #endregion
            Shuffle(this._sabot); // Je mélange le sabot
        }

        public static void Shuffle(List<Carte> SabotActuel) // Mélange du sabot
        {
            Random _random = new Random();
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
