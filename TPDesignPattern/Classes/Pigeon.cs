using System.Collections;
using System.Diagnostics;

namespace TPDesignPattern
{
    public class Pigeon : Nuisible
    {
        public Pigeon()
        {
            shortName = "P";
            vitesse = 3;
            etat = alive;
        }

        public override void Contact(Nuisible nuisibleEncountered)
        {
            if (this.etat == zombified)
            {
                this.zombify(nuisibleEncountered);
            }
            else if (nuisibleEncountered.etat == zombified)
            {
                
                nuisibleEncountered.zombify(this);
            }
            else if (this.etat == alive && nuisibleEncountered.GetType() == typeof(Rat))
            {
                fight(nuisibleEncountered);
            }
            
        }

        protected void fight(Nuisible nuisibleEncountered)
        {
            
            switch (r.Next(0, 2))
            {
                case 0:
                    this.etat = dead;
                    break;
                
                case 1:
                    nuisibleEncountered.etat = dead;
                    break;
            }
        }
    }
}