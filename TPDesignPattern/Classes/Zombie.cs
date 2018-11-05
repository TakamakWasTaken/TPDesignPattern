namespace TPDesignPattern
{
    public class Zombie : Nuisible
    {
        public override void Contact(Nuisible nuisibleEncountered)
        {
            Zombify(nuisibleEncountered);
            ResetPosition();
        }

        public Zombie()
        {
            Vitesse = 1;
            Etat = Zombified;
            ShortName = "Z";
        }
    }
}