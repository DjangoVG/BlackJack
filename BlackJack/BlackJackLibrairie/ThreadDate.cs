using System;
using System.Threading;

namespace BlackJackLibrairie
{
    public class ThreadDate
    {
        public string datenow;

        public ThreadDate(String dateNow)
        {
            this.datenow = dateNow;
        }

        public void DemarrageDate()
        {
            while (true)
            {
                Console.WriteLine(datenow.ToString());
                Thread.Sleep(1000);
                this.datenow = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            }
        }
    }
}