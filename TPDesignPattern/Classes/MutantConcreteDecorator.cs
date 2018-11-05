using System;

namespace TPDesignPattern
{
    class MutantConcreteDecorator : MutantDecorator
    {
        
        public MutantConcreteDecorator(Nuisible nuisible)
            : base(nuisible)
        {
        }
        
        public override void Contact(Nuisible nuisibleEncountered)
        {
            base.Contact(nuisibleEncountered);
            BloodLust(nuisibleEncountered);
           
        }

        void BloodLust(Nuisible nuisibleEncountered)
        {
            if (Etat == Dead && nuisibleEncountered.GetType() == typeof(Rat))
            {
                Etat = Alive;
                nuisibleEncountered.Etat = Dead;
            }
        }
    }
}