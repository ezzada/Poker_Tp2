using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker102
{

      // "\u2661"  == coeur
      // "\u2662"  == carreau
      // "\u2664"  == pique
      // "\u2667"  == trefle

    internal class Carte
    {
        public int Sorte { get; set; }
        public int Valeur { get; set; }

        public bool Gagnant { get; set; }
        public int Couleur { get; set; }

        string _tabValeur = "23456789XJQKA";
        char _valTexte = '2';

        public Carte(int s = 0, int v = 0)
        {
            Sorte = s;
            if (Gagnant)
            {
                Sorte = 4;
            }
            Valeur = v;
            convertirVal();
            CouleurDesCartes();
        }

        void convertirVal()
        {
            _valTexte = _tabValeur[Valeur];
        }

        void CouleurDesCartes()
        {
            switch (Sorte)
            {
                case 0:
                case 1:
                    // Si Sorte est 0 ou 1, on affecte 1 à Couleur (qui vaut noir)
                    Couleur = 1;
                    break;  // Sort du switch après avoir traité ce cas
                default:
                    // Sinon on affecte 0 à Couleur (qui vaut Rouge)
                    Couleur = 0;
                    break;
            }
        }
        public void Afficher(int posX, int posY)
        {
            AjusteCouleurSorte();

            Console.SetCursorPosition(2 + posX*(5+1),  2 + (posY*5) +  5);
            Console.Write(_valTexte);
            Console.Write("    ");

            Console.SetCursorPosition(2 + posX * (5+1), 2 + (posY * 5) + 6);
            Console.Write("  ");
            Console.Write($"{SorteGraphique()}");
            Console.Write("  ");


            Console.SetCursorPosition(2 + posX * (5 + 1), 2 + (posY * 5) + 7);
            Console.Write("    ");
            Console.Write(_valTexte);
        }

        char SorteGraphique()
        {
            switch(Sorte)
            {
                case (0):
                    return '\u2664';
                case (1):
                    return '\u2667';
                case (2):
                    return '\u2662';
                case (3):
                    return '\u2661';
            }
            return '\u2664';
        }

        void AjusteCouleurSorte()
        { 
            switch(Sorte)
            {
                case 0:
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 1:
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 2:
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 3:
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 4:
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }
        }

    }
}
