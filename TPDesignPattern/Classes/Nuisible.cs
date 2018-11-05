using System;

namespace TPDesignPattern
{
    public abstract class Nuisible
    {
        protected static Random r = new Random();
        public Ecosysteme _ecosysteme { set; get; }
        protected int vitesse { set; get; }
        public Coordonnees _currentCoordonnees { set; get; }
        protected Coordonnees _lastCoordonnees { set; get;  }
        public string etat { set; get; }
        public const string dead = "dead";
        public const string alive = "alive";
        public const string zombified = "zombified";
        public string shortName { get; set; }

        public abstract void Contact(Nuisible nuisibleEncountered);

        public void spawn(Ecosysteme ecosysteme)
        {
            _ecosysteme = ecosysteme;
            int newX = r.Next(_ecosysteme.min, _ecosysteme.max+1);
            int newY = r.Next(_ecosysteme.min, _ecosysteme.max + 1);
            _currentCoordonnees = new Coordonnees(newX, newY);
        }
        
        /// <summary>
        /// Calcule la position après déplacement total. Appelle la fonction de vérification de présence d'un autre nuisible.
        /// </summary>
        public void Deplacement()
        {
            var direction = ChoixDirection();
            MoveOne(direction);
            Nuisible nuisibleEncountered = isPositionEmpty(_currentCoordonnees.X, _currentCoordonnees.Y);
            if(nuisibleEncountered != null && nuisibleEncountered.etat != dead)
            {
                this.Contact(nuisibleEncountered);
            }
        }

        /// <summary>
        /// Calcule la position du Nuisible après un déplacement d'une case. Si il est hors limites, inverse le déplacement.
        /// </summary>
        protected void MoveOne(string direction)
        {
            int newX = _currentCoordonnees.X;
            int newY = _currentCoordonnees.Y;
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
            //reset position
            if (newY > _ecosysteme.max || newY < _ecosysteme.min)
            {
                newY = _currentCoordonnees.Y + (_currentCoordonnees.Y - newY);
            }
            
            if (newX > _ecosysteme.max || newX < _ecosysteme.min)
            {
                newX = _currentCoordonnees.X + (_currentCoordonnees.X - newX);
            }

            _lastCoordonnees = _currentCoordonnees;
            
            _currentCoordonnees.X = newX;
            _currentCoordonnees.Y = newY;
        }

        /// <summary>
        /// Détermine si la nouvelle position est vide ou non
        /// </summary>
        /// <param name="newX">Coordonnée en X</param>
        /// <param name="newY">Coordonnée en Y</param>
        /// <returns></returns>
        public Nuisible isPositionEmpty(int newX, int newY)
        {
            Nuisible nuisibleEncountered = null;
            for (var i = 0; i < _ecosysteme.getListNuisibles().Count; i++)
            {
                if (_ecosysteme.getListNuisibles()[i] == this)
                {
                    var currentNuisibleCoordinates = _ecosysteme.getListNuisibles()[i]._currentCoordonnees;
                    if (currentNuisibleCoordinates.X == newX && currentNuisibleCoordinates.Y == newY)
                    {
                        nuisibleEncountered = _ecosysteme.getListNuisibles()[i];
                    }
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

        public void zombify(Nuisible nuisibleEncountered)
        {
            if (nuisibleEncountered.etat != dead)
            {
                nuisibleEncountered.etat = zombified;
                this.resetPosition();
            }
        }

        protected void resetPosition()
        {
            _currentCoordonnees = _lastCoordonnees;
        }
    }
}