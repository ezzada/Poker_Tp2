using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pokerTp2;

namespace Poker102
{
    internal class Util
    {
        public static Random rdm = new Random();

        //---------------------------------------------
        //
        //---------------------------------------------
       
        public static void TitrePricipale(string leTitre)
        {
            ViderEcran();
            int decalageY = 5;

            
            string ligne = new string('-', leTitre.Length * 3);
            Console.SetCursorPosition(Ronde.DECALAGE_X - ligne.Length / 2, decalageY + 8);
            Console.Write(ligne);
            Console.SetCursorPosition(Console.WindowWidth / 2 - leTitre.Length / 2, decalageY + 9);
            foreach (char a in leTitre)
            {
                Console.Write(a);
                Thread.Sleep(1);
            }
            Console.SetCursorPosition(Console.WindowWidth / 2 - ligne.Length / 2, decalageY + 10);
            Console.Write(ligne);

        }
        //---------------------------------------------
        //
        //---------------------------------------------
        public static void Titre(string leTitre)
        {
            int decalageY = 5;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            string ligne = new string('-', leTitre.Length * 3);
            string espace = new string(' ', (ligne.Length - leTitre.Length) / 2);
            leTitre = espace + leTitre + espace;
            Console.SetCursorPosition(Ronde.DECALAGE_X - ligne.Length / 2, decalageY);
            Console.WriteLine(ligne);
            Console.SetCursorPosition(Console.WindowWidth / 2 - leTitre.Length / 2, decalageY + 1);
            Console.WriteLine(leTitre);
            Console.SetCursorPosition(Console.WindowWidth / 2 - ligne.Length / 2, decalageY + 2);
            Console.WriteLine(ligne);

        }
        //---------------------------------------------
        //
        //---------------------------------------------
        public static void ViderEcran()
        {
            Console.Clear();
            Console.WriteLine("\x1b[3J");
        }

        //---------------------------------------------
        //
        //---------------------------------------------
        public static char SaisirChar()
        {
            ConsoleKeyInfo cle = Console.ReadKey();
            return cle.KeyChar;
        }


        //---------------------------------------------
        //
        //---------------------------------------------
        public int SaisirEntier()
        {
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int res))
            {
                return res;
            }
            return 0;
        }

        //---------------------------------------------
        //
        //---------------------------------------------
        public double SaisirReel()
        {
            string? input = Console.ReadLine();
            if (double.TryParse(input, out double res))
            {
                return res;
            }
            return 0.0;
        }
        //---------------------------------------------
        //
        //---------------------------------------------
        public static void Pause()
        {
            Console.WriteLine("\n\tAppuyez sur une touche...");
            Console.ReadKey(true);
        }

        //---------------------------------------------
        //
        //---------------------------------------------
        public void Sep(string msg = "")
        {
                Console.WriteLine($"----------{msg}----------");
        }

        public static void SetNoirEttBlanc()
        {
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void InitTapis()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            ViderEcran();
        }


        public static void MessageInvalide()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            TitrePricipale("Frappe Invalide");
            Pause();
            ViderEcran();
            Console.ForegroundColor = ConsoleColor.White;

        }
        public static void Question(ref bool partieNouvelle, string Question)
        {
            bool reposerLaQuestion = true;
            while (reposerLaQuestion)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                TitrePricipale($@"{Question} [O\N]");
                Console.Write("\n\n->");
                char reponse = SaisirChar();
                if (reponse == 'o' || reponse == 'O')
                {
                    partieNouvelle = true;
                    reposerLaQuestion = false;

                }
                else if (reponse == 'n' || reponse == 'N')
                {
                    partieNouvelle = false;
                    reposerLaQuestion = false;
                }
                else
                {
                    MessageInvalide();
                }
                Console.ForegroundColor = ConsoleColor.White;
            }

        }

    }
}
