using System;
namespace BlackJackLibrairie
{
    public enum CodeException
    {
        Default,
        MdpIncorrect,
        EmailIncorrect,
        JoueurNonTrouve,
        PseudoInexistant
    }

    public class LoginException : Exception
    {
        private CodeException _code;
        public CodeException Code
        {
            get { return _code; }
            set { _code = value; }
        }

        public LoginException(string message, CodeException code = CodeException.Default) : base(message)
        {
            Code = code;
        }
    }
}
