namespace TPDesignPattern
{
    public class Zombie : Nuisible
    {
        public override void Contact()
        {
            throw new System.NotImplementedException();
        }

        public Zombie()
        {
            vitesse = 1;
            etat = "zombified";
        }
    }
}