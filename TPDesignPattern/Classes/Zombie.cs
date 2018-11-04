namespace TPDesignPattern
{
    public class Zombie : Nuisible
    {
        public override void Contact(Nuisible nuisibleEncountered)
        {
            nuisibleEncountered.etat = zombified;
        }

        public Zombie()
        {
            vitesse = 1;
            etat = zombified;
        }
    }
}