using System.Collections.Generic;

namespace TPDesignPattern
{
    public class Simulation
    {
        private List<Ecosysteme> listEcosystemes = new List<Ecosysteme>();

        /// <summary>
        /// Renvoie la liste des ecosystèmes stockés.
        /// </summary>
        public List<Ecosysteme> GetEcosystemeList()
        {
            return listEcosystemes;
        }
        
        /// <summary>
        /// Ajoute un écosystème à la liste.
        /// </summary>
        public void AddEcosysteme(Ecosysteme ecosysteme)
        {
            listEcosystemes.Add(ecosysteme);
        }
    }
}