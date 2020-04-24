﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackLibrairie
{
    public class Croupier
    {
        public string Pseudo { get; } = "Croupier";
        private Boolean _abust;

        public bool ABust
        {
            get
            {
                return _abust;
            }
            set
            {
                _abust = value;
            }
        }

        public Croupier()
        {
            ABust = false;
        }
    }
}
