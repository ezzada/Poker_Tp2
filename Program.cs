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
            bool continuerPartie = true;
            bool commencerPartie = true;
            Util.Question(ref commencerPartie, "Voulez-vous commencer une partie?");
            while (continuerPartie && commencerPartie)
            {
                Util.InitTapis();
                Util.Titre("Tp2 Poker");
                Ronde.Algorithme();
                Console.SetCursorPosition(Console.WindowWidth - 1, 3);
                Util.Pause();
                Util.Question( ref continuerPartie,"Voulez-vous refaire une partie?");
            }
            Util.ViderEcran();
            Util.Titre("Projet Réaliser par Adam Ezzahiri");
            
        }

        
    }
}
