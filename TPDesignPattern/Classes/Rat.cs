using System.Security.Cryptography.X509Certificates;

namespace TPDesignPattern
{
    public class Rat : Nuisible
    {
        
        public override void Contact(Nuisible nuisibleEncountered)
        {
            
            if (etat == zombified)
            {
                zombify(nuisibleEncountered);
            }
            else if (nuisibleEncountered.etat == zombified)
            {
                nuisibleEncountered.zombify(this);
            }
            else if (this.etat == alive && nuisibleEncountered.GetType() == typeof(Pigeon))
            {
                fight(nuisibleEncountered);
            }
        }

        public Rat()
        {
            shortName = "R";
            vitesse = 2;
            etat = alive;
        }

        private void fight(Nuisible nuisibleEncountered)
        {
            
            switch (r.Next(0, 2))
            {
                case 0:
                    //this.etat = dead;
                    break;
                
                case 1:
                    nuisibleEncountered.etat = dead;
                    break;
            }
        }
        
    }
}