using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace TPDesignPattern
{
    public class Ecosysteme
    {
        public Coordonnees nordOuest { get; }
        public Coordonnees nordEst { get; }
        public Coordonnees sudEst { get; }
        public Coordonnees sudOuest { get; }
        public string type { get; }
        
        private List<Nuisible> _listNuisibles = new List<Nuisible>();

        public Ecosysteme(Coordonnees a1, Coordonnees a2, Coordonnees a3, Coordonnees a4)
        {
            nordEst = a1;
            nordOuest = a2;
            sudEst = a3;
            sudOuest = a4;
        }

        public void addNuisible(Nuisible nuisible)
        {
            _listNuisibles.Add(nuisible);
        }

        public List<Nuisible> getListNuisibles()
        {
            return _listNuisibles;
        }
        
    }
}