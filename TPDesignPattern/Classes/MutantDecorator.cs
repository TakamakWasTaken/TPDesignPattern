namespace TPDesignPattern
{
    public class MutantDecorator : Nuisible
    {
        
        protected Nuisible Nuisible;
 
        public MutantDecorator(Nuisible nuisible)
        {
            Nuisible = nuisible;
        }
        
        public override void Contact(Nuisible nuisibleEncountered)
        {
            if (Nuisible != null)
            {
                Nuisible.Contact(nuisibleEncountered);
            }
        }
    }
}