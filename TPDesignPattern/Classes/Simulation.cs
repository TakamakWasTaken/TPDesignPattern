using System.Collections.Generic;
using System.Threading;

namespace TPDesignPattern
{
    public class Simulation
    {
        public static bool isStarted = false;
        private List<Ecosysteme> listEcosystemes = new List<Ecosysteme>();

        public List<Ecosysteme> getEcosystemeList()
        {
            return listEcosystemes;
        }
        
        public List<Ecosysteme> addEcosysteme(Ecosysteme ecosysteme)
        {
            listEcosystemes.Add(ecosysteme);
            return listEcosystemes;
        }

        public Simulation()
        {
            Simulation.isStarted = true;
        }

    }
}