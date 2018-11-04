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
        public string type { get; set; }
        
        
        private List<Nuisible> _listNuisibles = new List<Nuisible>();

        public void addNuisible(Nuisible nuisible)
        {
            _listNuisibles.Add(nuisible);
        }

        public List<Nuisible> getListNuisibles()
        {
            return _listNuisibles;
        }

        public Ecosysteme(Coordonnees a1, Coordonnees a2, Coordonnees a3, Coordonnees a4)
        {
            nordEst = a1;
            nordOuest = a2;
            sudEst = a3;
            sudOuest = a4;
        }

        public Ecosysteme()
        {
            nordOuest = new Coordonnees(0, 0);
            nordEst = new Coordonnees(0, 10);
            sudEst = new Coordonnees(10, 10);
            sudOuest = new Coordonnees(10, 0);
        }
    }
}