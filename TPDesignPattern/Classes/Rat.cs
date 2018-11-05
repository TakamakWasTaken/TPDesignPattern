using System.Security.Cryptography.X509Certificates;

namespace TPDesignPattern
{
    public class Rat : Nuisible
    {
        
        public override void Contact(Nuisible nuisibleEncountered)
        {
            throw new System.NotImplementedException();
            
        }

        public Rat()
        {
            shortName = "R";
            vitesse = 2;
            etat = alive;
        }
        
        
    }
}