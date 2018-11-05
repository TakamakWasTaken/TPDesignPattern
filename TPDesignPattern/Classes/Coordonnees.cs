using System;

namespace TPDesignPattern
{
    public class Coordonnees
    {
        public int X { set; get; }
        public int Y { set; get; }

        public void getCoord()
        {
            Console.Write("x: " + this.X + " y : " + this.Y );
        }

        public Coordonnees(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}