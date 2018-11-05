using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace TPDesignPattern
{
    public class Ecosysteme
    {
        public Coordonnees nordOuest { get; set; }
        public Coordonnees nordEst { get; set; }
        public Coordonnees sudEst { get; set; }
        public Coordonnees sudOuest { get; set; }
        public int min { get; set; }
        public int max { get; set; }
        public string type { get; set; }
        
        
        private List<Nuisible> _listNuisibles = new List<Nuisible>();

        public void addNuisible(Nuisible nuisible)
        {
            nuisible.spawn(this);
            _listNuisibles.Add(nuisible);
        }

        public List<Nuisible> getListNuisibles()
        {
            return _listNuisibles;
        }

        public Ecosysteme(Coordonnees a1, Coordonnees a2, Coordonnees a3, Coordonnees a4, int min, int max)
        {
            nordEst = a1;
            nordOuest = a2;
            sudEst = a3;
            sudOuest = a4;
            this.min = min;
            this.max = max;
        }

        public Ecosysteme()
        {
            nordOuest = new Coordonnees(1, 1);
            nordEst = new Coordonnees(1, 10);
            sudEst = new Coordonnees(10, 10);
            sudOuest = new Coordonnees(10, 1);
            min = 1;
            max = 10;
        }

        public void UpdatePositions()
        {
            for (var i = 0; i < getListNuisibles().Count; i++)
            {
                var currentNuisible = getListNuisibles()[i];
                if (currentNuisible.etat != Nuisible.dead)
                {
                    currentNuisible.Deplacement();
                }
            }
        }
    }
}