namespace TPDesignPattern
{
    public class Pigeon : Nuisible
    {
        public override void Contact(Nuisible nuisibleEncountered)
        {
            throw new System.NotImplementedException();
        }

        public Pigeon()
        {
            vitesse = 3;
            etat = alive;
        }
    }
}