using Microsoft.Win32;
using System;

namespace BlackJackLibrairie
{
    public class JoueurManager
    {
        #region VARIABLES MEMBRES

        private RegistryKey BlackJack;

        #endregion VARIABLES MEMBRES

        #region CONSTRUCTEURS

        public JoueurManager()
        {
            BlackJack = Registry.CurrentUser.CreateSubKey("Software").CreateSubKey("BlackJack");
            Console.WriteLine("Contenu BlackJack :");
            foreach (string tmp in BlackJack.GetSubKeyNames())
            {
                Console.WriteLine("\t" + tmp);
            }
        }

        #endregion CONSTRUCTEURS

        #region METHODES

        public void LoadRegistryParameter(Joueur joueur)
        {
            if (VerifSubkey(BlackJack, joueur.Email))
            {
                RegistryKey rk = BlackJack.CreateSubKey(joueur.Email);
                string mdp;
                if ((mdp = rk.GetValue(joueur.Email) as string) != joueur.MotDePasse)
                {
                    throw new LoginException("Mot de passe incorrect", CodeException.MdpIncorrect);
                }
                else
                {
                    if (rk.GetValue("pseudo") == null || rk.GetValue("pseudo").Equals(""))
                    {
                        throw new LoginException("", CodeException.PseudoInexistant);
                    }
                    if (Convert.ToDouble(rk.GetValue("solde")) < 5)
                    {
                        //throw new LoginException("", CodeException.SoldeInsuffisant); A MODIFIER
                    }
                    joueur.Pseudo = rk.GetValue("pseudo") as string;
                    joueur.Solde = Convert.ToDouble(rk.GetValue("solde"));
                    return;
                }
            }
            throw new LoginException("Le joueur entré n'existe pas.", CodeException.JoueurNonTrouve);
        }

        public void SaveRegistryPseudo(string email, string pseudo)
        {
            Console.WriteLine("J'ajoute un pseudo");
            BlackJack.CreateSubKey(email).SetValue("pseudo", pseudo);
            return;
        }

        public void FirstRegistry(string email, string password)
        {
            RegistryKey rk = BlackJack.CreateSubKey(email);
            rk.SetValue(email, password);
        }

        public void SaveRegistryParameter(string email, string motdepasse, double solde)
        {
            RegistryKey rk = BlackJack.CreateSubKey(email);
            rk.SetValue(email, motdepasse);
            rk.SetValue("solde", solde);
        }

        public void SaveRegistrySolde(string email, double solde)
        {
            RegistryKey rk = BlackJack.CreateSubKey(email);
            rk.SetValue("solde", solde);
        }

        private bool VerifSubkey(RegistryKey rk, string subname)
        {
            foreach (string tmp in rk.GetSubKeyNames())
            {
                if (tmp == subname)
                {
                    return true;
                }
            }
            return false;
        }

        public void SetValue(string email, string value)
        {
            BlackJack.SetValue(email, value);
        }

        #endregion METHODES
    }
}