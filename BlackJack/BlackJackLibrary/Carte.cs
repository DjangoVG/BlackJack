using System;

namespace BlackJackLibrary
{
    public class Carte
    {
        private String _nomCarte;
        private String _imageCarte;
        private int _valeurCarte;

        public Carte(String NomCarte, int ValeurCarte, String CheminImage)
        {
            this._nomCarte = NomCarte;
            this._valeurCarte = ValeurCarte;
            this._imageCarte = CheminImage;
        }
         
        public override string ToString()
        {
            return "NomCarte : " + this._nomCarte + " | Valeur de la carte : " + this._valeurCarte;
        }
    }
}
