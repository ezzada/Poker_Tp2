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

        //Va servire a trouver leur etage
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
            string[] valeurTextuelCartes = { "de deux", "de trois", "de quatre", "de cinq", "de six", "de sept", "de huit", "de neuf", "de dix", "de valet", "de reine", "de roi", "d'as" };

            if (QuintCouleur())
            {
                ValeurTextuelle = $"Quint Couleur vers la carte {valeurTextuelCartes[Cartes[0].Valeur]}";
            }
            else if (Carre())
            {
                for (int i = 0; i < nombreDeRecuranceDeChaqueValeur.Count(); i++)
                {
                    if (nombreDeRecuranceDeChaqueValeur[i] == 4)
                    {
                        ValeurTextuelle = $"Carre composer de quatre cartes {valeurTextuelCartes[valeurDesCartes[i]]}";
                    }
                }
            }
            else if (Full())
            {
                int troisRecurence = 0;
                int deuxRecurence = 0;
                for (int i = 0; i < nombreDeRecuranceDeChaqueValeur.Count(); i++)
                {
                    if (nombreDeRecuranceDeChaqueValeur[i] == 3)
                    {
                        troisRecurence = i;
                    }
                    if (nombreDeRecuranceDeChaqueValeur[i] == 2)
                    {
                        deuxRecurence = i;
                    }
                }
                
                ValeurTextuelle = $"Full composé d'un triplet {valeurTextuelCartes[valeurDesCartes[troisRecurence]]} et d'une pair {valeurTextuelCartes[valeurDesCartes[deuxRecurence]]}";
                
            }
            else if (Couleur())
            {
                ValeurTextuelle = $"Même couleur avec une valeur {valeurTextuelCartes[Cartes[0].Valeur]}, {valeurTextuelCartes[Cartes[1].Valeur]}, {valeurTextuelCartes[Cartes[2].Valeur]}, {valeurTextuelCartes[Cartes[3].Valeur]}, {valeurTextuelCartes[Cartes[4].Valeur]}";
            }
            else if (Quint())
            {
                ValeurTextuelle = $"Quint vers la carte {valeurTextuelCartes[Cartes[0].Valeur]}";
            }
            else if (Brelan())
            {
                for (int i = 0; i < nombreDeRecuranceDeChaqueValeur.Count(); i++)
                {
                    if (nombreDeRecuranceDeChaqueValeur[i] == 3)
                    {
                        ValeurTextuelle = $"Brelan composer de trois cartes {valeurTextuelCartes[valeurDesCartes[i]]}";
                    }
                }
            }
            else if (DoublePair())
            {
                List<int> positionDesRécurence = new List<int>();
                for (int i = 0; i < nombreDeRecuranceDeChaqueValeur.Count(); i++)
                {
                    if (nombreDeRecuranceDeChaqueValeur[i] == 2)
                    {
                        positionDesRécurence.Add(i);
                    }
                }
                ValeurTextuelle = $"DoublePair composé d'une pair {valeurTextuelCartes[valeurDesCartes[positionDesRécurence[0]]]} et d'une pair {valeurTextuelCartes[valeurDesCartes[positionDesRécurence[1]]]}";
            }
            else if (IntPair())
            {
                for (int i = 0; i < nombreDeRecuranceDeChaqueValeur.Count(); i++)
                {
                    if (nombreDeRecuranceDeChaqueValeur[i] == 2)
                    {
                        ValeurTextuelle = $"Cartes composer d'une pair {valeurTextuelCartes[valeurDesCartes[i]]}";
                    }
                }
            }
            else
            {
                ValeurTextuelle = $"Main normale composé {valeurTextuelCartes[Cartes[0].Valeur]}, {valeurTextuelCartes[Cartes[1].Valeur]}, {valeurTextuelCartes[Cartes[2].Valeur]}, {valeurTextuelCartes[Cartes[3].Valeur]}, {valeurTextuelCartes[Cartes[4].Valeur]}";
            }
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
            int Recurence2 = 0;
            int Recurence3 = 0;
            for (int i = 0; i < nombreDeRecuranceDeChaqueValeur.Count(); i++)
            {
                if (nombreDeRecuranceDeChaqueValeur[i] == 2)
                {
                    Recurence2++;
                }
                if (nombreDeRecuranceDeChaqueValeur[i] == 3)
                {
                    Recurence3++;
                }
            }
            if (Recurence2 == 1 && Recurence3 == 1)
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
            for (int i = 0; i < nombreDeRecuranceDeChaqueValeur.Count(); i++)
            {
                if (nombreDeRecuranceDeChaqueValeur[i] == 3)
                {
                    return true;
                }
            }
            return false;
        }
        public bool DoublePair()
        {
            int compter = 0;
            for (int i = 0; i < nombreDeRecuranceDeChaqueValeur.Count(); i++)
            {
                if (nombreDeRecuranceDeChaqueValeur[i] == 2)
                {
                    compter++;
                }
            }
            if (compter == 2)
            {
                return true;
            }
            return false;
        }
        public bool IntPair() 
        {
            for (int i = 0; i < nombreDeRecuranceDeChaqueValeur.Count(); i++)
            {
                if (nombreDeRecuranceDeChaqueValeur[i] == 2)
                {
                    return true;
                }
            }
            return false;
        }
        public int valeurCartes()
        {
            return (int)(Math.Pow(Cartes[0].Valeur + 1, 5) + Math.Pow(Cartes[1].Valeur + 1, 4) + Math.Pow(Cartes[2].Valeur + 1, 3) + Math.Pow(Cartes[3] .Valeur + 1, 2) + Math.Pow(Cartes[4].Valeur + 1, 1));
        }
    }
}
