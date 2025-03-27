using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pokerTp2;

namespace Poker102
{
    internal class MainJoueur
    {



        public Carte[] Cartes { get; set; } = new Carte[5];

        public int ValeurMainFinnal { get; set; }

        public int _numeroJoueur;
        public string ValeurMainFinnalText { get; set; }

        Evaluateur evaluateur;
        public MainJoueur(int nj, Carte c0, Carte c1, Carte c2, Carte c3, Carte c4)
        {
            _numeroJoueur = nj;
            Cartes[0] = c0;
            Cartes[1] = c1;
            Cartes[2] = c2;
            Cartes[3] = c3;
            Cartes[4] = c4;
            //evaluateur = new Evaluateur();
        }

        public void Valeur()
        {

        }
        public void Afficher()
        {

                                            

            for (int i = 0; i < 5; i++)
            {
                Cartes[i].Afficher(i, _numeroJoueur);
            }
        }





    }
}
