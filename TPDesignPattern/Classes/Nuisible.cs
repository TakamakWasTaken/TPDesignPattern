using System;

namespace TPDesignPattern
{
    public abstract class Nuisible
    {
        private Random r = new Random();
        protected Ecosysteme _ecosysteme;
        protected int vitesse;
        protected Coordonnees _coordonnees;
        protected string etat;
        

        protected Nuisible()
        {
            
        }

        public abstract void Contact();

        /// <summary>
        /// Calcule la position après déplacement total. Appelle la fonction de vérification de présence d'un autre nuisible.
        /// </summary>
        public void Deplacement()
        {

            MoveOne();
            isPositionEmpty(_coordonnees.X, _coordonnees.Y);

        }

        /// <summary>
        /// Calcule la position du Nuisible après un déplacement d'une case. Si il est hors limites, inverse le déplacement.
        /// </summary>
        public void MoveOne()
        {
            string direction = ChoixDirection();

            int newX = -1;
            int newY = -1;
            switch (direction)
            {
                    case "nord":
                        newY = _coordonnees.Y - 1;
                        break;
                        
                    case "sud":
                        newY = _coordonnees.Y + 1;
                        break;
                        
                    case "est":
                        newX = _coordonnees.X + 1;
                        break;
                            
                    case "ouest":
                        newX = _coordonnees.X - 1;
                        break;
            }
            if (newY > _ecosysteme.sudOuest.Y || newY < _ecosysteme.nordEst.Y)
            {
                newY = _coordonnees.Y + (_coordonnees.Y - newY);
            }
            
            if (newX > _ecosysteme.sudOuest.X || newX < _ecosysteme.nordEst.X)
            {
                newY = _coordonnees.X + (_coordonnees.X - newX);
            }

            _coordonnees.X = newX;

            _coordonnees.Y = newY;
        }

        /// <summary>
        /// Détermine si la nouvelle position est vide ou non
        /// </summary>
        /// <param name="newX">La valeur de la coordonnée X</param>
        /// <param name="newY">La valeur de la coordonnée X</param>
        /// <returns></returns>
        public bool isPositionEmpty(int newX, int newY)
        {
            bool isEmpty = true;
            for (var i = 0; i < _ecosysteme.getListNuisibles().Count; i++)
            {
                var currentNuisibleCoordinates = _ecosysteme.getListNuisibles()[i]._coordonnees;
                if (currentNuisibleCoordinates.X == newX && currentNuisibleCoordinates.Y == newY)
                {
                    isEmpty = false;
                }
            }
            return isEmpty;
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
    }
}