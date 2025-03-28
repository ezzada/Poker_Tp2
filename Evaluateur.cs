using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
            
            if (QuintCouleur())
            {
                ValeurMain = 8000000;
            }
            else if(Carre())
            {
                ValeurMain = 7000000;
            }
            else if (Full())
            {
                ValeurMain = 6000000;
            }
            else if (Couleur())
            {
                ValeurMain = 5000000;
            }
            else if (Quint())
            {
                ValeurMain = 4000000;
            }
            else if (Brelan())
            {
                ValeurMain = 3000000;
            }
            else if (DoublePair())
            {
                ValeurMain = 2000000;
            }
            else if (IntPair())
            {
                ValeurMain = 1000000;
            }
            else
            {
                ValeurMain = 0;
            }

            ValeurMain += valeurCartes();
            return ValeurMain;
        }
        public bool QuintCouleur()
        {
            for (int i = 0; i < Cartes.Length; i++)
            {
                int positionTMP = i + 1;
                if (positionTMP < Cartes.Length)
                {
                    //Si la valeur de l'as est de zéro  
                    if (Cartes[i].Valeur == 12 && Cartes[positionTMP].Valeur == 3)
                    {
                        continue;
                    }

                    if (Cartes[positionTMP].Valeur != Cartes[i].Valeur - 1 || Cartes[positionTMP].Couleur != Cartes[i].Couleur)
                    {
                        return false;
                    }
                        
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
                int positionTMP = i + 1;
                if (positionTMP < Cartes.Length)
                { 
                    
                    if (Cartes[positionTMP].Couleur != Cartes[i].Couleur)
                    {
                        return false;
                    }

                }
            }
            return true;
        }
        public bool Quint()
        {
            for (int i = 0; i < Cartes.Length; i++)
            {
                int positionTMP = i + 1;
                if (positionTMP < Cartes.Length)
                {
                    //Si la valeur de l'as est de zéro  
                    if (Cartes[i].Valeur == 12 && Cartes[positionTMP].Valeur == 3)
                    {
                        continue;
                    }

                    if (Cartes[positionTMP].Valeur != Cartes[i].Valeur - 1)
                    {
                        return false;
                    }

                }

            }
            return true;
        }
        public bool Brelan()
        {
            int compteur = 1;
            for (int i = 0; i < Cartes.Length; i++)
            {
                int positionTMP = i + 1;
                if (positionTMP < Cartes.Length)
                {
                    //Si la valeur de l'as est de 

                    if (Cartes[positionTMP].Valeur != Cartes[i].Valeur)
                    {
                        compteur = 0;
                    }
                    else
                    {
                        compteur ++;
                    }

                }
                if (compteur == 3)
                {
                    return true;
                }

            }
            return false;
        }
        public bool DoublePair()
        {

            int compteur = 1;
            int doubleTest = 0;
            for (int i = 0; i < Cartes.Length; i += 2)
            {
                int positionTMP = i + 1;
                if (positionTMP < Cartes.Length)
                {
                    if (Cartes[positionTMP].Valeur != Cartes[i].Valeur)
                    {
                        compteur = 0;
                    }
                    else
                    {
                        compteur++;
                    }
                }
                if (compteur == 2)
                {
                    compteur = 1;
                    doubleTest++;
                }
                if (doubleTest == 2)
                {
                    return true;
                }
            }
            return false;
        }
        public bool IntPair() 
        {
            int compteur = 1;
            for (int i = 0; i < Cartes.Length; i++)
            {
                int positionTMP = i + 1;
                if (positionTMP < Cartes.Length)
                {
                    //Si la valeur de l'as est de 

                    if (Cartes[positionTMP].Valeur != Cartes[i].Valeur)
                    {
                        compteur = 0;
                    }
                    else
                    {
                        compteur++;
                    }

                }
                if (compteur == 2)
                {
                    return true;
                }

            }
            return false;
        }

        public int valeurCartes()
        {
            return (int)(Math.Pow(Cartes[0].Valeur, 5) + Math.Pow(Cartes[1].Valeur, 4) + Math.Pow(Cartes[2].Valeur, 3) + Math.Pow(Cartes[3].Valeur, 2) + Math.Pow(Cartes[4].Valeur, 1));
        }
        

    }
}
