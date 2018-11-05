using System.Collections;
using System.Diagnostics;

namespace TPDesignPattern
{
    public class Pigeon : Nuisible
    {
        public Pigeon()
        {
            IsMutant = false;
            ShortName = "P";
            Vitesse = 3;
            Etat = Alive;
        }

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
            else if (Etat == Alive && nuisibleEncountered.GetType() == typeof(Rat))
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
                if (IsMutant)
                {
                    MutantConcreteDecorator mutant = new MutantConcreteDecorator(this);
                    mutant.Contact(nuisibleEncountered);
                }
            }
        }
    }
}