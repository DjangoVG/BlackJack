using System;
using System.Collections.Generic;

namespace BlackJackLibrairie
{
    internal class CartesComparer : IComparer<Carte> // AS A LA FIN
    {
        public int Compare(Carte x, Carte y)
        {
            int ValeurCarteX = 0, ValeurCarteY = 0;

            if (x.ValeurCarte == ValeurCarte.Valet || x.ValeurCarte == ValeurCarte.Dame || x.ValeurCarte == ValeurCarte.Roi)
                ValeurCarteX = 10;
            else
                ValeurCarteX = Convert.ToInt32(x.ValeurCarte);

            if (y.ValeurCarte == ValeurCarte.Valet || y.ValeurCarte == ValeurCarte.Dame || y.ValeurCarte == ValeurCarte.Roi)
                ValeurCarteY = 10;
            else
                ValeurCarteY = Convert.ToInt32(y.ValeurCarte);

            if (ValeurCarteX > ValeurCarteY)
                return -1;
            else if (ValeurCarteX < ValeurCarteY)
                return 1;
            else
                return 0;
        }
    }
}