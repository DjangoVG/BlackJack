using System;

namespace BlackJackLibrary
{
    // Le numéro associé est la valeu
    public enum ValeurCarte
    {
        As = 1,
        Deux = 2,
        Trois = 3,
        Quatre = 4,
        Cinq = 5,
        Six = 6,
        Sept = 7,
        Huit = 8,
        Neuf = 9,
        Dix = 10,
        Valet = 11,
        Dame = 12,
        Roi = 13
    }

    public enum TypeCarte
    {
        Carreau,
        Coeur,
        Pique,
        Trefle
    }
    public class Carte
    {
        private TypeCarte _typeCarte;
        private ValeurCarte _valeurCarte;
        private String _imageCarte;

        public Carte(TypeCarte NomCarte, ValeurCarte ValeurCarte, String CheminImage)
        {
            this._typeCarte = NomCarte;
            this._valeurCarte = ValeurCarte;
            this._imageCarte = CheminImage;
        }
         
        public override string ToString()
        {
            return "TypeCarte : " + this._typeCarte + " | Valeur de la carte : " + this._valeurCarte + " | Image : " + this._imageCarte;
        }
    }
}
