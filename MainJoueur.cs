using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker102
{
    internal class MainJoueur
    {
        public Carte[] Cartes = new Carte[5];
        public int ValeurMain { get; set; }

        int _numeroJoueur;


        public MainJoueur(int nj, Carte c0, Carte c1, Carte c2, Carte c3, Carte c4)
        {
            _numeroJoueur = nj;
            Cartes[0] = c0;
            Cartes[1] = c1;
            Cartes[2] = c2;
            Cartes[3] = c3;
            Cartes[4] = c4;

            Trier();
        }

        public void CalculeValueDuneMain()
        {
            int cestQuoi = 0;
            cestQuoi = QuintCouleur();
            switch (cestQuoi)
            {
                case 8:

                default:
                    ValeurMain += 0;
                    break;
            }
        }
        public int QuintCouleur()
        {
            for (int i = 0; i < Cartes.Length; i++)
            {
                if (i < Cartes.Length)
                {
                    //Si la valeur de l'as est de zéro  
                    if (Cartes[i].Valeur == 13 && Cartes[i+1].Valeur == 4)
                    {
                        continue;
                    }

                    if (Cartes[i].Valeur != Cartes[i + 1].Valeur - 1 || Cartes[i].Couleur != Cartes[i + 1].Couleur)
                        return 0;
                }
                
            }
            return 8;
        }
        public int Carre()
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
                        return 7;
                    }
                    
                }
            }
            return 0;
        }

        public int Full()
        {
            if (((Cartes[0].Valeur == Cartes[1].Valeur && Cartes[0].Valeur == Cartes[2].Valeur) || (Cartes[0].Valeur == Cartes[1].Valeur)) && 
                ((Cartes[4].Valeur == Cartes[3].Valeur && Cartes[4].Valeur == Cartes[2].Valeur) || ((Cartes[4].Valeur == Cartes[3].Valeur))))
            {
                return 6;
            }
            return 0; 
        }
        public int Couleur()
        {
            for (int i = 0; i < Cartes.Length; i++)
            {
                if (Cartes[i].Couleur != Cartes[i - 1].Couleur)
                    return 1;
            }
            return 5;
        }
        public int Quint()
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
                        return 0;
                }

            }
            return 4;
        }
        public int Brelan()
        {
            bool test = true;
            for (int i = 0; i < Cartes.Length - 2; i++)
            {
                if (Cartes[i].Valeur == Cartes[i + 1].Valeur) ;
                    
            }
            return 3;
        }
        public int DoublePair()
        {
            
            
               
            
            return 3;
        }

        public void Afficher()
        {
            Trier();
            for(int i = 0;i<5; i++)
            {
                Cartes[i].Afficher(i, _numeroJoueur);
            }
        }

        void Trier()
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
    }
}
