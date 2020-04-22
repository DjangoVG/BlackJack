using Microsoft.Win32;
using System;

namespace BlackJackLibrairie
{
    public class JoueurManager
    {
        #region VARIABLES MEMBRES
        private RegistryKey BlackJack;
        #endregion

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
        #endregion

        #region METHODES
        public void LoadRegistryParameter(string email, string motdepasse, string pseudo)
        {
            if (VerifSubkey(BlackJack, email))
            {
                RegistryKey rk = BlackJack.CreateSubKey(email);
                string mdp;
                if ((mdp = rk.GetValue(email) as string) != motdepasse)
                {
                    throw new LoginException("Mot de passe incorrect", CodeException.MdpIncorrect);
                }
                else
                {
                    if (rk.GetValue("pseudo") == null || rk.GetValue("pseudo").Equals(""))
                    {
                        throw new LoginException("", CodeException.PseudoInexistant);
                    }
                    return;
                }
                
            }
            throw new LoginException("Le joueur entré n'existe pas.", CodeException.JoueurNonTrouve);
        }

        public void SaveRegistryPseudo(string email, string password, string pseudo)
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

        public void SaveRegistryParameter(string email, string motdepasse)
        {
            BlackJack.CreateSubKey(email).SetValue(email, motdepasse);
        }

        public void SaveRegistryParameter(string email)
        {
            BlackJack.CreateSubKey(email);
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
        #endregion
    }
}
