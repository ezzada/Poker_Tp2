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
                if (Cartes[i].Valeur != Cartes[i + 1].Valeur - 1 || Cartes[i].Couleur != Cartes[i + 1].Couleur) 
                    return 1;
            }
            return 8;
        }
        public int Carre()
        {
            for (int i = 0; i < Cartes.Length - 1 ; i++)
            {
                if (Cartes[i].Valeur != Cartes[i + 1].Valeur)
                    return 1;
            }
            return 7;
        }

        public int Full()
        {
            for (int i = 0; i < Cartes.Length - 2; i++)
            {
                if (Cartes[i].Valeur != Cartes[i - 1].Valeur)
                    return 1;
            }
            for (int i = 3; i < Cartes.Length; i++)
            {
                if (Cartes[i].Valeur != Cartes[i - 1].Valeur)
                    return 1;
            }
            return 6;
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
                if (Cartes[i].Valeur != Cartes[i - 1].Valeur - 1)
                    return 1;
            }
            return 4;
        }
        public int Brelan()
        {
            bool test = true;
            for (int i = 0; i < Cartes.Length - 2; i++)
            {
                if (Cartes[i].Valeur == Cartes[i + 1].Valeur)
                    
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
