using System.Collections.Generic;

namespace TPDesignPattern
{
    public class Simulation
    {
        private List<Ecosysteme> listEcosystemes = new List<Ecosysteme>();

        public List<Ecosysteme> GetEcosystemeList()
        {
            return listEcosystemes;
        }
        
        public void AddEcosysteme(Ecosysteme ecosysteme)
        {
            listEcosystemes.Add(ecosysteme);
        }
    }
}