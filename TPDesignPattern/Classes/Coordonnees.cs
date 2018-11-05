using System;

namespace TPDesignPattern
{
    public class Coordonnees
    {
        public int X { set; get; }
        public int Y { set; get; }

        /// <summary>
        /// Constructeur des coordonnées au sein d'un écosystème.
        /// </summary>
        /// <param name="x">valeur pour l'axe x</param>
        /// <param name="y">valeur pour l'axe des y</param>
        public Coordonnees(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}