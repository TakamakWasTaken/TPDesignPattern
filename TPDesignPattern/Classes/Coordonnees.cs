using System;

namespace TPDesignPattern
{
    public class Coordonnees
    {
        public int X { set; get; }
        public int Y { set; get; }

        public Coordonnees(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}