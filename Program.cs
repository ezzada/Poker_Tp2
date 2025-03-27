using Microsoft.VisualBasic;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Claims;
using System.Text;
using System;
using pokerTp2;

namespace Poker102
{
    internal class Program
    {

        Ronde analyseDesMains = new Ronde();
        static void Main(string[] args)
        {

            
            Util.InitTapis();

            Util.Titre("Poker 102!");

            Ronde.Algorithme();

            Util.Pause();

            Util.SetNoirEttBlanc();
        }

        
    }
}
