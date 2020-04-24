using System;

namespace BlackJackLibrairie
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
        public TypeCarte TypeCarte { get; }
        public ValeurCarte ValeurCarte { get; }
        public String ImageCarte { get; }

        public Carte(TypeCarte NomCarte, ValeurCarte ValeurCarte, String CheminImage)
        {
            this.TypeCarte = NomCarte;
            this.ValeurCarte = ValeurCarte;
            this.ImageCarte = CheminImage;
        }
         
        public override string ToString()
        {
            return "TypeCarte : " + this.TypeCarte + " | Valeur de la carte : " + this.ValeurCarte + " | Image : " + this.ImageCarte;
        }
    }
}
