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

        /// <summary>
        /// Méthode modifiant le comportement du Nuisible lors d'une rencontre.
        /// </summary>
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