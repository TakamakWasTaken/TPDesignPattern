namespace TPDesignPattern
{
    public class Zombie : Nuisible
    {
        public Zombie()
        {
            Vitesse = 1;
            Etat = Zombified;
            ShortName = "Z";
        }
        
        /// <summary>
        /// Méthode Contact surchargée pour correspondre au cas du Zombie.
        /// </summary>
        /// <param name="nuisibleEncountered">Le nuisible rencontré</param>
        public override void Contact(Nuisible nuisibleEncountered)
        {
            Zombify(nuisibleEncountered);
            ResetPosition();
        }
    }
}