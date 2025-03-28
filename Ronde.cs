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
        
        public static void Algorithme()
        {
       

            Paquet paquet = new Paquet();
            paquet.Brasser();

            for (int i = 0; i < 4; i++)
            {
                joueurs[i] = new MainJoueur(i, paquet.Distribuer(), paquet.Distribuer(), paquet.Distribuer(), paquet.Distribuer(), paquet.Distribuer());
            }

            Ronde.TricherMainsDesJoueurs();

            foreach (MainJoueur joueur in joueurs)
            {
                joueur.Afficher();
            }

        }
        public static void TricherMainsDesJoueurs()
        {
            joueurs[0].Cartes[0] = new Carte(0, 12);
            joueurs[0].Cartes[1] = new Carte(0, 10);
            joueurs[0].Cartes[2] = new Carte(0, 11);
            joueurs[0].Cartes[3] = new Carte(0, 9);
            joueurs[0].Cartes[4] = new Carte(0, 8);

            joueurs[1].Cartes[0] = new Carte(0, 12);
            joueurs[1].Cartes[1] = new Carte(1, 12);
            joueurs[1].Cartes[2] = new Carte(2, 12);
            joueurs[1].Cartes[3] = new Carte(3, 12);
            joueurs[1].Cartes[4] = new Carte(0, 0);

            joueurs[2].Cartes[0] = new Carte(2, 12);
            joueurs[2].Cartes[1] = new Carte(3, 0);
            joueurs[2].Cartes[2] = new Carte(3, 1);
            joueurs[2].Cartes[3] = new Carte(3, 2);
            joueurs[2].Cartes[4] = new Carte(3, 3);

            joueurs[3].Cartes[0] = new Carte(0, 1);
            joueurs[3].Cartes[1] = new Carte(2, 1);
            joueurs[3].Cartes[2] = new Carte(3, 1);
            joueurs[3].Cartes[3] = new Carte(3, 8);
            joueurs[3].Cartes[4] = new Carte(1, 8);
        }
    }
}
