using System.Security.Cryptography.X509Certificates;

namespace TPDesignPattern
{
    public class Rat : Nuisible
    {
        public Rat()
        {
            ShortName = "R";
            Vitesse = 2;
            Etat = Alive;
        }
        
        /// <summary>
        /// Méthode Contact surchargée pour correspondre au cas du Rat.
        /// </summary>
        /// <param name="nuisibleEncountered">Le nuisible rencontré</param>
        public override void Contact(Nuisible nuisibleEncountered)
        {
            
            if (Etat == Zombified)
            {
                Zombify(nuisibleEncountered);
            }
            else if (nuisibleEncountered.Etat == Zombified)
            {
                nuisibleEncountered.Zombify(this);
            }
            else if (Etat == Alive && nuisibleEncountered.GetType() == typeof(Pigeon))
            {
                switch (R.Next(0, 2))
                {
                    case 0:
                        Etat = Dead;
                        break;
                    
                    case 1:
                        nuisibleEncountered.Etat = Dead;
                        break;
                }
            }
        }
    }
}