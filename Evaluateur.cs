using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pokerTp2;

namespace Poker102
{
    internal class Evaluateur
    {

        Carte[] Cartes { get; set; } = new Carte[5];
        public int _numeroJoueur;
        public int ValeurMain { get; set; }

        public string[] _tabValeur = { "Deux", "Trois", "Quatre", "Cinq", "Six", "Sept", "Huit", "Neuf", "Dix", "Valet", "Reine", "Roi", "l'As" };
        public Evaluateur(int nj, Carte c0, Carte c1, Carte c2, Carte c3, Carte c4)
        {
            _numeroJoueur = nj;
            Cartes[0] = c0;
            Cartes[1] = c1;
            Cartes[2] = c2;
            Cartes[3] = c3;
            Cartes[4] = c4;
            TrierMain();
            //evaluateur = new Evaluateur();
        }

        void TrierMain()
        {
            Array.Sort(Cartes, ComparerCarte);
        }

        int ComparerCarte(Carte cA, Carte cB)
        {
            if (cA.Valeur < cB.Valeur)
                return 1;
            if (cA.Valeur > cB.Valeur)
                return -1;
            return 0;
        }
        public int getValeur()
        {
           
            if (true)
            {

            }

            return ValeurMain;
        }
        public bool QuintCouleur()
        {
            for (int i = 0; i < Cartes.Length; i++)
            {
                if (i < Cartes.Length)
                {
                    //Si la valeur de l'as est de zéro  
                    if (Cartes[i].Valeur == 13 && Cartes[i + 1].Valeur == 4)
                    {
                        continue;
                    }

                    if (Cartes[i].Valeur != Cartes[i + 1].Valeur - 1 || Cartes[i].Couleur != Cartes[i + 1].Couleur)
                        return false;
                }

            }
            return true;
        }
        public bool Carre()
        {

            for (int i = 0; i < Cartes.Length; i++)
            {
                int compteur = 0;
                for (int j = 0; j < Cartes.Length; j++)
                {
                    if (Cartes[i].Valeur == Cartes[j].Valeur)
                    {
                        compteur++;
                    }

                    if (compteur == 4)
                    {
                        return true;
                    }

                }
            }
            return false;
        }

        public bool Full()
        {
            if (((Cartes[0].Valeur == Cartes[1].Valeur && Cartes[0].Valeur == Cartes[2].Valeur) || (Cartes[0].Valeur == Cartes[1].Valeur)) &&
                ((Cartes[4].Valeur == Cartes[3].Valeur && Cartes[4].Valeur == Cartes[2].Valeur) || ((Cartes[4].Valeur == Cartes[3].Valeur))))
            {
                return true;
            }
            return false;
        }
        public bool Couleur()
        {
            for (int i = 0; i < Cartes.Length; i++)
            {
                if (Cartes[i].Couleur != Cartes[i - 1].Couleur)
                    return false;
            }
            return true;
        }
        public bool Quint()
        {
            for (int i = 0; i < Cartes.Length; i++)
            {
                if (i < Cartes.Length)
                {
                    //Si la valeur de l'as est de zéro  
                    if (Cartes[i].Valeur == 13 && Cartes[i + 1].Valeur == 4)
                    {
                        continue;
                    }

                    if (Cartes[i].Valeur != Cartes[i + 1].Valeur - 1)
                        return false;
                }

            }
            return true;
        }
        public bool Brelan()
        {
            
            for (int i = 0; i < Cartes.Length - 2; i++)
            {
                if (Cartes[i].Valeur == Cartes[i + 1].Valeur);

            }
            return true;
        }
        public int DoublePair()
        {




            return 3;
        }

        
    }
}
