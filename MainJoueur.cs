using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pokerTp2;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Poker102
{
    internal class MainJoueur
    {

        public Carte[] Cartes { get; set; } = new Carte[5];

        public int _numeroJoueur;
        public bool Gagnant { get; set; }
        // Instance de l'évaluateur pour analyser la main du joueur
        private Evaluateur evaluateur;

        // Constructeur qui prend les cartes et crée un évaluateur
        public MainJoueur(int numeroJoueur, Carte c0, Carte c1, Carte c2, Carte c3, Carte c4)
        {
            _numeroJoueur = numeroJoueur;
            Cartes[0] = c0;
            Cartes[1] = c1;
            Cartes[2] = c2;
            Cartes[3] = c3;
            Cartes[4] = c4;

            TrierMain();

            // Créer un évaluateur avec les cartes du joueur
            evaluateur = new Evaluateur(Cartes);
            

        }

        // Méthode pour obtenir la valeur de la main du joueur
        public int valeur()
        {
            // L'évaluateur va calculer la valeur de la main
            return evaluateur.getValeur();
        }

        public string valeurEnFrancais()
        {
            return evaluateur.ConvetirValeurEnFrancais(evaluateur.getValeur());
        }

        // Méthode pour afficher les cartes du joueur
        public void Afficher()
        {
            TrierMain();
            for (int i = 0; i < 5; i++)
            {
                
                Cartes[i].Afficher(i, _numeroJoueur); 

            }
        }
        public void TrierMain()
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
