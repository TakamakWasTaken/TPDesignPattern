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
            vitesse = 2;
            etat = alive;
        }
        
        
    }
}