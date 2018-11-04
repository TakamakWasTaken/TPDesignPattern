using System;

namespace TPDesignPattern
{
    public abstract class Nuisible
    {
        
        protected Random r = new Random();
        public Ecosysteme _ecosysteme { set; get; }
        protected int vitesse { set; get; }
        protected Coordonnees _currentCoordonnees { set; get; }
        protected Coordonnees _lastCoordonnees { set; get;  }
        protected string etat { set; get; }
        protected const string dead = "dead";
        protected const string alive = "alive";
        protected const string zombified = "zombified";

        public abstract void Contact(Nuisible nuisibleEncountered);

        public void spawn()
        {
            _currentCoordonnees.X = r.Next(_ecosysteme.min, _ecosysteme.max+1);
            _currentCoordonnees.Y = r.Next(_ecosysteme.min, _ecosysteme.max+1);
            
        }
        
        /// <summary>
        /// Calcule la position après déplacement total. Appelle la fonction de vérification de présence d'un autre nuisible.
        /// </summary>
        public void Deplacement()
        {

            MoveOne();
            Nuisible nuisibleEncountered = this.isPositionEmpty(_currentCoordonnees.X, _currentCoordonnees.Y);
            if(nuisibleEncountered != null)
            {
                Contact(nuisibleEncountered);
            }
            
        }

        /// <summary>
        /// Calcule la position du Nuisible après un déplacement d'une case. Si il est hors limites, inverse le déplacement.
        /// </summary>
        protected void MoveOne()
        {
            string direction = ChoixDirection();

            int newX = -1;
            int newY = -1;
            switch (direction)
            {
                case "nord":
                    newY = _currentCoordonnees.Y - 1;
                    break;
                    
                case "sud":
                    newY = _currentCoordonnees.Y + 1;
                    break;
                    
                case "est":
                    newX = _currentCoordonnees.X + 1;
                    break;
                        
                case "ouest":
                    newX = _currentCoordonnees.X - 1;
                    break;
            }
            if (newY > _ecosysteme.max || newY < _ecosysteme.min)
            {
                newY = _currentCoordonnees.Y + (_currentCoordonnees.Y - newY);
            }
            
            if (newX > _ecosysteme.max || newX < _ecosysteme.min)
            {
                newY = _currentCoordonnees.X + (_currentCoordonnees.X - newX);
            }

            _lastCoordonnees = _currentCoordonnees;
            
            _currentCoordonnees.X = newX;

            _currentCoordonnees.Y = newY;
        }

        /// <summary>
        /// Détermine si la nouvelle position est vide ou non
        /// </summary>
        /// <param name="newX">La valeur de la coordonnée X</param>
        /// <param name="newY">La valeur de la coordonnée X</param>
        /// <returns></returns>
        protected Nuisible isPositionEmpty(int newX, int newY)
        {
            Nuisible nuisibleEncountered = null;
            for (var i = 0; i < _ecosysteme.getListNuisibles().Count; i++)
            {
                var currentNuisibleCoordinates = _ecosysteme.getListNuisibles()[i]._currentCoordonnees;
                if (currentNuisibleCoordinates.X == newX && currentNuisibleCoordinates.Y == newY)
                {
                    nuisibleEncountered = _ecosysteme.getListNuisibles()[i];
                }
            }
            return nuisibleEncountered;
        }
        

        /// <summary>
        /// Dértemine aléatoirement la direction du déplacement.
        /// </summary>
        /// <returns>Retourne la direction choisie sous form de string</returns>
        protected string ChoixDirection()
        {
            string direction = "";
            var randomNumber = r.Next(0,4);

            switch (randomNumber)
            {
                case 0:
                    direction = "nord";
                    break;
                    
                case 1:
                    direction = "sud";
                    break;
                    
                case 2:
                    direction = "est";
                    break;
                    
                case 3:
                    direction = "ouest";
                    break;
            }
            
            return direction;
        }

        protected void resetPosition()
        {
            _currentCoordonnees = _lastCoordonnees;
        }
    }
}