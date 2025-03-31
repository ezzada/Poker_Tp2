using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker102;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace pokerTp2
{
    internal class Ronde
    {
        public static MainJoueur[] joueurs = new MainJoueur[4];

        public static readonly int DECALAGE_X = Console.WindowWidth / 2;
        public static readonly int DECALAGE_Y = Console.WindowHeight / 2;
        public static void Algorithme()
        {
            Paquet paquet = new Paquet();
            paquet.Brasser();
            for (int i = 0; i < 4; i++)
            {
                joueurs[i] = new MainJoueur(i, paquet.Distribuer(), paquet.Distribuer(), paquet.Distribuer(), paquet.Distribuer(), paquet.Distribuer());
            }
            //Ronde.TricherMainsDesJoueurs();
            trouverLeGagnant();
            foreach (MainJoueur joueur in joueurs)
            {
                joueur.Afficher();
                Console.SetCursorPosition(0, 4 + (joueur._numeroJoueur * 5) + 6);
                Console.WriteLine("Joueur " + (joueur._numeroJoueur + 1) + ": ");
                Console.SetCursorPosition(DECALAGE_X - 13, 4 + (joueur._numeroJoueur * 5) + 6 );
                Console.WriteLine(joueur.valeurEnFrancais());
                
            }
            afficherGagnant();

        }
        public static void afficherGagnant()
        {
            List<int> stockageDesSortesCartes = new();
            foreach ( MainJoueur joueur in joueurs)
            {
                if (joueur.Gagnant)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.Write($"Gagnant: Joueur {joueur._numeroJoueur + 1}");
                    for (int i = 0; i < 5; i++)
                    {
                        foreach (Carte carte in joueur.Cartes)
                        {
                            stockageDesSortesCartes.Add(carte.Sorte);
                            carte.Sorte = 4;
                        }
                        joueur.Afficher();
                        Thread.Sleep(400);
                        for (int j = 0; j < joueur.Cartes.Count(); j++)
                        {
                            joueur.Cartes[j].Sorte = stockageDesSortesCartes[j];
                        }
                        joueur.Afficher();
                        Thread.Sleep(400);
                    }
                    
                }
            }
        }
        
        public static void trouverLeGagnant()
        {
            int valeurDeMAinMaximal = 0;
            foreach (MainJoueur joueur in joueurs)
            {
                if (valeurDeMAinMaximal < joueur.valeur())
                {
                    valeurDeMAinMaximal = joueur.valeur();
                }
            }
            foreach (MainJoueur joueur in joueurs)
            {
                if (valeurDeMAinMaximal == joueur.valeur())
                {
                    joueur.Gagnant = true;
                }
            }

        }
        public static void TricherMainsDesJoueurs()
        {
            joueurs[0].Cartes[0] = new Carte(2, 12);
            joueurs[0].Cartes[1] = new Carte(3, 3);
            joueurs[0].Cartes[2] = new Carte(2, 2);
            joueurs[0].Cartes[3] = new Carte(2, 1);
            joueurs[0].Cartes[4] = new Carte(2, 0);

            joueurs[1].Cartes[0] = new Carte(0, 12);
            joueurs[1].Cartes[1] = new Carte(0, 12);
            joueurs[1].Cartes[2] = new Carte(2, 12);
            joueurs[1].Cartes[3] = new Carte(0, 1);
            joueurs[1].Cartes[4] = new Carte(0, 1);

            joueurs[2].Cartes[0] = new Carte(2, 4);
            joueurs[2].Cartes[1] = new Carte(2, 1);
            joueurs[2].Cartes[2] = new Carte(2, 3);
            joueurs[2].Cartes[3] = new Carte(3, 5);
            joueurs[2].Cartes[4] = new Carte(0, 12);

            joueurs[3].Cartes[0] = new Carte(0, 1);
            joueurs[3].Cartes[1] = new Carte(2, 1);
            joueurs[3].Cartes[2] = new Carte(3, 1);
            joueurs[3].Cartes[3] = new Carte(3, 8);
            joueurs[3].Cartes[4] = new Carte(1, 8);
        }
    }
}
