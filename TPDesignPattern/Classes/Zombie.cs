namespace TPDesignPattern
{
    public class Zombie : Nuisible
    {
        public override void Contact(Nuisible nuisibleEncountered)
        {
            this.zombify(nuisibleEncountered);
            this.resetPosition();
        }

        public Zombie()
        {
            vitesse = 1;
            etat = zombified;
            shortName = "Z";
        }
    }
}