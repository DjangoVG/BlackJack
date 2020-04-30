using System.Collections.ObjectModel;

namespace BlackJackLibrairie
{
    public enum ValeurProba
    {
        Tirer = 1,
        Stand = 2,
        Split = 3,
        Double = 4
    }

    public class Probabilités
    {
        private Lobby _lobby { get; set; }

        private ObservableCollection<Carte> _carte2 { get; set; }

        public Probabilités(Lobby lobby, ObservableCollection<Carte> Carte2)
        {
            this._lobby = lobby;
            this._carte2 = Carte2;
        }

        public ValeurProba GetProb()
        {
            if (_lobby.MemeValeurCarte())
            {
                if (_lobby.ValeurDeckCroupier() == 2 || _lobby.ValeurDeckCroupier() == 3 || _lobby.ValeurDeckCroupier() == 4) // CROUPIER A 2
                {
                    if (_lobby.ValeurDeckJoueur() == 2 || _lobby.ValeurDeckJoueur() == 4 || _lobby.ValeurDeckJoueur() == 6 || _lobby.ValeurDeckJoueur() == 12 || _lobby.ValeurDeckJoueur() == 14 || _lobby.ValeurDeckJoueur() == 16 || _lobby.ValeurDeckJoueur() == 18)
                        return ValeurProba.Split;

                    if (_lobby.ValeurDeckJoueur() == 8)
                        return ValeurProba.Tirer;

                    if (_lobby.ValeurDeckJoueur() == 10)
                        return ValeurProba.Double;

                    if (_lobby.ValeurDeckJoueur() == 20)
                        return ValeurProba.Stand;
                }
                else if (_lobby.ValeurDeckCroupier() == 5 || _lobby.ValeurDeckCroupier() == 6) // CROUPIER A 5/6
                {
                    if (_lobby.ValeurDeckJoueur() == 2 || _lobby.ValeurDeckJoueur() == 4 || _lobby.ValeurDeckJoueur() == 6 || _lobby.ValeurDeckJoueur() == 8 || _lobby.ValeurDeckJoueur() == 12 || _lobby.ValeurDeckJoueur() == 14 || _lobby.ValeurDeckJoueur() == 16 || _lobby.ValeurDeckJoueur() == 18)
                        return ValeurProba.Split;

                    if (_lobby.ValeurDeckJoueur() == 10)
                        return ValeurProba.Double;

                    if (_lobby.ValeurDeckJoueur() == 20)
                        return ValeurProba.Stand;
                }
                else if (_lobby.ValeurDeckCroupier() == 7) // CROUPIER A 7
                {
                    if (_lobby.ValeurDeckJoueur() == 2 || _lobby.ValeurDeckJoueur() == 4 || _lobby.ValeurDeckJoueur() == 6 || _lobby.ValeurDeckJoueur() == 14 || _lobby.ValeurDeckJoueur() == 16)
                        return ValeurProba.Split;

                    if (_lobby.ValeurDeckJoueur() == 10)
                        return ValeurProba.Double;

                    if (_lobby.ValeurDeckJoueur() == 20 || _lobby.ValeurDeckJoueur() == 18)
                        return ValeurProba.Stand;

                    if (_lobby.ValeurDeckJoueur() == 8 || _lobby.ValeurDeckJoueur() == 12)
                        return ValeurProba.Tirer;
                }
                else if (_lobby.ValeurDeckCroupier() == 8) // CROUPIER A 8
                {
                    if (_lobby.ValeurDeckJoueur() == 2 || _lobby.ValeurDeckJoueur() == 4 || _lobby.ValeurDeckJoueur() == 6 || _lobby.ValeurDeckJoueur() == 14 || _lobby.ValeurDeckJoueur() == 16 || _lobby.ValeurDeckJoueur() == 18)
                        return ValeurProba.Split;

                    if (_lobby.ValeurDeckJoueur() == 10)
                        return ValeurProba.Double;

                    if (_lobby.ValeurDeckJoueur() == 20)
                        return ValeurProba.Stand;

                    if (_lobby.ValeurDeckJoueur() == 8 || _lobby.ValeurDeckJoueur() == 12)
                        return ValeurProba.Tirer;
                }
                else if (_lobby.ValeurDeckCroupier() == 9) // CROUPIER A 9
                {
                    if (_lobby.ValeurDeckJoueur() == 2 || _lobby.ValeurDeckJoueur() == 4 || _lobby.ValeurDeckJoueur() == 6 || _lobby.ValeurDeckJoueur() == 16 || _lobby.ValeurDeckJoueur() == 18)
                        return ValeurProba.Split;

                    if (_lobby.ValeurDeckJoueur() == 10)
                        return ValeurProba.Double;

                    if (_lobby.ValeurDeckJoueur() == 20)
                        return ValeurProba.Stand;

                    if (_lobby.ValeurDeckJoueur() == 8 || _lobby.ValeurDeckJoueur() == 12 || _lobby.ValeurDeckJoueur() == 14)
                        return ValeurProba.Tirer;
                }
                else if (_lobby.ValeurDeckCroupier() == 10 || _lobby.ValeurDeckCroupier() == 11) // CROUPIER A 10/11
                {
                    if (_lobby.ValeurDeckJoueur() == 2 || _lobby.ValeurDeckJoueur() == 4 || _lobby.ValeurDeckJoueur() == 6 || _lobby.ValeurDeckJoueur() == 16)
                        return ValeurProba.Split;

                    if (_lobby.ValeurDeckJoueur() == 20 || _lobby.ValeurDeckJoueur() == 18)
                        return ValeurProba.Stand;

                    if (_lobby.ValeurDeckJoueur() == 8 || _lobby.ValeurDeckJoueur() == 12 || _lobby.ValeurDeckJoueur() == 14 || _lobby.ValeurDeckJoueur() == 10)
                        return ValeurProba.Tirer;
                }
            }
            else
            {
                if (_lobby.ValeurDeckCroupier() == 2) // CROUPIER A 2
                {
                    if ((_lobby.ValeurDeckJoueur() >= 2 && _lobby.ValeurDeckJoueur() <= 9) || _lobby.ValeurDeckJoueur() == 12)
                        return ValeurProba.Tirer;

                    if (_lobby.ValeurDeckJoueur() == 10 || _lobby.ValeurDeckJoueur() == 11)
                        return ValeurProba.Double;

                    if (_lobby.ValeurDeckJoueur() >= 13 && _lobby.ValeurDeckJoueur() <= 20)
                        return ValeurProba.Stand;
                }
                else if (_lobby.ValeurDeckCroupier() == 3) // CROUPIER A 3
                {
                    if ((_lobby.ValeurDeckJoueur() >= 2 && _lobby.ValeurDeckJoueur() <= 8) || _lobby.ValeurDeckJoueur() == 12)
                        return ValeurProba.Tirer;

                    if ((_lobby.ValeurDeckJoueur() == 10 || _lobby.ValeurDeckJoueur() == 11) || _lobby.ValeurDeckJoueur() == 9)
                        return ValeurProba.Double;

                    if (_lobby.ValeurDeckJoueur() >= 13 && _lobby.ValeurDeckJoueur() <= 20)
                        return ValeurProba.Stand;
                }
                else if (_lobby.ValeurDeckCroupier() == 4 || _lobby.ValeurDeckCroupier() == 5 || _lobby.ValeurDeckCroupier() == 6) // CROUPIER A 4/5/6
                {
                    if ((_lobby.ValeurDeckJoueur() >= 2 && _lobby.ValeurDeckJoueur() <= 8) || _lobby.ValeurDeckJoueur() == 12)
                        return ValeurProba.Tirer;

                    if ((_lobby.ValeurDeckJoueur() == 10 || _lobby.ValeurDeckJoueur() == 11) || _lobby.ValeurDeckJoueur() == 9)
                        return ValeurProba.Double;

                    if (_lobby.ValeurDeckJoueur() >= 12 && _lobby.ValeurDeckJoueur() <= 20)
                        return ValeurProba.Stand;
                }
                else if (_lobby.ValeurDeckCroupier() == 7 || _lobby.ValeurDeckCroupier() == 8 || _lobby.ValeurDeckCroupier() == 9) // CROUPIER A 7/8/9
                {
                    if ((_lobby.ValeurDeckJoueur() >= 2 && _lobby.ValeurDeckJoueur() <= 9) || (_lobby.ValeurDeckJoueur() >= 12 && _lobby.ValeurDeckJoueur() < 17))
                        return ValeurProba.Tirer;

                    if ((_lobby.ValeurDeckJoueur() == 10 || _lobby.ValeurDeckJoueur() == 11))
                        return ValeurProba.Double;

                    if (_lobby.ValeurDeckJoueur() >= 17 && _lobby.ValeurDeckJoueur() <= 20)
                        return ValeurProba.Stand;
                }
                else if (_lobby.ValeurDeckCroupier() == 10) // CROUPIER A 10
                {
                    if ((_lobby.ValeurDeckJoueur() >= 2 && _lobby.ValeurDeckJoueur() <= 10) || (_lobby.ValeurDeckJoueur() >= 12 && _lobby.ValeurDeckJoueur() < 17))
                        return ValeurProba.Tirer;

                    if (_lobby.ValeurDeckJoueur() == 11)
                        return ValeurProba.Double;

                    if (_lobby.ValeurDeckJoueur() >= 17 && _lobby.ValeurDeckJoueur() <= 20)
                        return ValeurProba.Stand;
                }
                else if (_lobby.ValeurDeckCroupier() == 11) // CROUPIER A 11
                {
                    if ((_lobby.ValeurDeckJoueur() >= 2 && _lobby.ValeurDeckJoueur() <= 16))
                        return ValeurProba.Tirer;

                    if (_lobby.ValeurDeckJoueur() >= 17 && _lobby.ValeurDeckJoueur() <= 20)
                        return ValeurProba.Stand;
                }
            }

            return ValeurProba.Stand;
        }

        public ValeurProba GetProbDeck2()
        {
            if (_lobby.ValeurDeckCroupier() == 2) // CROUPIER A 2
            {
                if ((_lobby.ValeurDeckJoueur2(_carte2) >= 2 && _lobby.ValeurDeckJoueur2(_carte2) <= 9) || _lobby.ValeurDeckJoueur2(_carte2) == 12)
                    return ValeurProba.Tirer;

                if (_lobby.ValeurDeckJoueur2(_carte2) == 10 || _lobby.ValeurDeckJoueur2(_carte2) == 11)
                    return ValeurProba.Double;

                if (_lobby.ValeurDeckJoueur2(_carte2) >= 13 && _lobby.ValeurDeckJoueur2(_carte2) <= 20)
                    return ValeurProba.Stand;
            }
            else if (_lobby.ValeurDeckCroupier() == 3) // CROUPIER A 3
            {
                if ((_lobby.ValeurDeckJoueur2(_carte2) >= 2 && _lobby.ValeurDeckJoueur2(_carte2) <= 8) || _lobby.ValeurDeckJoueur2(_carte2) == 12)
                    return ValeurProba.Tirer;

                if ((_lobby.ValeurDeckJoueur2(_carte2) == 10 || _lobby.ValeurDeckJoueur2(_carte2) == 11) || _lobby.ValeurDeckJoueur2(_carte2) == 9)
                    return ValeurProba.Double;

                if (_lobby.ValeurDeckJoueur2(_carte2) >= 13 && _lobby.ValeurDeckJoueur2(_carte2) <= 20)
                    return ValeurProba.Stand;
            }
            else if (_lobby.ValeurDeckCroupier() == 4 || _lobby.ValeurDeckCroupier() == 5 || _lobby.ValeurDeckCroupier() == 6) // CROUPIER A 4/5/6
            {
                if ((_lobby.ValeurDeckJoueur2(_carte2) >= 2 && _lobby.ValeurDeckJoueur2(_carte2) <= 8) || _lobby.ValeurDeckJoueur2(_carte2) == 12)
                    return ValeurProba.Tirer;

                if ((_lobby.ValeurDeckJoueur2(_carte2) == 10 || _lobby.ValeurDeckJoueur2(_carte2) == 11) || _lobby.ValeurDeckJoueur2(_carte2) == 9)
                    return ValeurProba.Double;

                if (_lobby.ValeurDeckJoueur2(_carte2) >= 12 && _lobby.ValeurDeckJoueur2(_carte2) <= 20)
                    return ValeurProba.Stand;
            }
            else if (_lobby.ValeurDeckCroupier() == 7 || _lobby.ValeurDeckCroupier() == 8 || _lobby.ValeurDeckCroupier() == 9) // CROUPIER A 7/8/9
            {
                if ((_lobby.ValeurDeckJoueur2(_carte2) >= 2 && _lobby.ValeurDeckJoueur2(_carte2) <= 9) || (_lobby.ValeurDeckJoueur2(_carte2) >= 12 && _lobby.ValeurDeckJoueur2(_carte2) < 17))
                    return ValeurProba.Tirer;

                if ((_lobby.ValeurDeckJoueur2(_carte2) == 10 || _lobby.ValeurDeckJoueur2(_carte2) == 11))
                    return ValeurProba.Double;

                if (_lobby.ValeurDeckJoueur2(_carte2) >= 17 && _lobby.ValeurDeckJoueur2(_carte2) <= 20)
                    return ValeurProba.Stand;
            }
            else if (_lobby.ValeurDeckCroupier() == 10) // CROUPIER A 10
            {
                if ((_lobby.ValeurDeckJoueur2(_carte2) >= 2 && _lobby.ValeurDeckJoueur2(_carte2) <= 10) || (_lobby.ValeurDeckJoueur2(_carte2) >= 12 && _lobby.ValeurDeckJoueur2(_carte2) < 17))
                    return ValeurProba.Tirer;

                if (_lobby.ValeurDeckJoueur2(_carte2) == 11)
                    return ValeurProba.Double;

                if (_lobby.ValeurDeckJoueur2(_carte2) >= 17 && _lobby.ValeurDeckJoueur2(_carte2) <= 20)
                    return ValeurProba.Stand;
            }
            else if (_lobby.ValeurDeckCroupier() == 11) // CROUPIER A 11
            {
                if ((_lobby.ValeurDeckJoueur2(_carte2) >= 2 && _lobby.ValeurDeckJoueur2(_carte2) <= 16))
                    return ValeurProba.Tirer;

                if (_lobby.ValeurDeckJoueur2(_carte2) >= 17 && _lobby.ValeurDeckJoueur2(_carte2) <= 20)
                    return ValeurProba.Stand;
            }
            return ValeurProba.Stand;
        }
    }
}