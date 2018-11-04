using System.Collections.Generic;

namespace TPDesignPattern
{
    public class Simulation
    {
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

        public void start()
        {
            
        }
        public void start(string type)
        {
            
        }
    }
}