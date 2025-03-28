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
        
        

        
        public int ValeurMain { get; set; }
        public string ValeurTextuelle { get; set; }


        //Va servire a trouver leur étage
        private List<int> valeurDesCartes = new List<int>();
        private List<int> nombreDeRecuranceDeChaqueValeur = new List<int>();
        public Evaluateur(Carte[] cartes)
        {
            Cartes = cartes;
        }
        public void TrouverLesSorteLeurNombreDeRecurence()
        {
            int recurence = 1;
            for (int i = 0; i < Cartes.Length; i++)
            {
                int positionTMP = i + 1;
                if (positionTMP < Cartes.Length)
                {
                    if (Cartes[i].Valeur != Cartes[positionTMP].Valeur)
                    {
                        valeurDesCartes.Add(Cartes[i].Valeur);
                        nombreDeRecuranceDeChaqueValeur.Add(recurence);
                        recurence = 1;
                    }
                    else
                    {
                        recurence++;
                    }
                }
                else
                {
                    valeurDesCartes.Add(Cartes[i].Valeur);
                    nombreDeRecuranceDeChaqueValeur.Add(recurence);
                }
            }
        }
        public string ConvetirValeurEnFrancais(int valeurMain)
        {
            return ValeurTextuelle;
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
        public int IntPair() 
        {
            return 4;
        }

        

    }
}
