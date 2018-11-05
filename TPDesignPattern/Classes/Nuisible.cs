using System;
using System.Net.NetworkInformation;

namespace TPDesignPattern
{
    public abstract class Nuisible
    {
        protected static readonly Random R = new Random();
        public Ecosysteme Ecosysteme { set; get; }
        protected int Vitesse { set; get; }
        public Coordonnees CurrentCoordonnees { set; get; }
        protected Coordonnees LastCoordonnees { set; get;  }
        public string Etat { set; get; }
        public const string Dead = "dead";
        public const string Alive = "alive";
        public const string Zombified = "zombified";
        public string ShortName { get; set; }
        public bool IsMutant = false;

        public abstract void Contact(Nuisible nuisibleEncountered);

        public void Spawn(Ecosysteme ecosysteme)
        {
            Ecosysteme = ecosysteme;
            int newX = R.Next(Ecosysteme.Min, Ecosysteme.Max+1);
            int newY = R.Next(Ecosysteme.Min, Ecosysteme.Max + 1);
            CurrentCoordonnees = new Coordonnees(newX, newY);
        }
        
        /// <summary>
        /// Calcule la position après déplacement total. Appelle la fonction de vérification de présence d'un autre nuisible.
        /// </summary>
        public void Deplacement()
        {
            for (var i = 0; i < Vitesse; i++)
            {
                var direction = ChoixDirection();
                MoveOne(direction);
                Nuisible nuisibleEncountered = IsPositionEmpty(CurrentCoordonnees.X, CurrentCoordonnees.Y);
                if(nuisibleEncountered != null && nuisibleEncountered.Etat != Dead)
                {
                    Contact(nuisibleEncountered);
                }
            }
        }

        /// <summary>
        /// Calcule la position du Nuisible après un déplacement d'une case. Si il est hors limites, inverse le déplacement.
        /// </summary>
        protected void MoveOne(string direction)
        {
            int newX = CurrentCoordonnees.X;
            int newY = CurrentCoordonnees.Y;
            switch (direction)
            {
                case "nord":
                    newY = CurrentCoordonnees.Y - 1;
                    break;
                    
                case "sud":
                    newY = CurrentCoordonnees.Y + 1;
                    break;
                    
                case "est":
                    newX = CurrentCoordonnees.X + 1;
                    break;
                        
                case "ouest":
                    newX = CurrentCoordonnees.X - 1;
                    break;
            }
            //reset position
            if (newY > Ecosysteme.Max || newY < Ecosysteme.Min)
            {
                newY = CurrentCoordonnees.Y + (CurrentCoordonnees.Y - newY);
            }
            
            if (newX > Ecosysteme.Max || newX < Ecosysteme.Min)
            {
                newX = CurrentCoordonnees.X + (CurrentCoordonnees.X - newX);
            }

            LastCoordonnees = CurrentCoordonnees;
            
            CurrentCoordonnees.X = newX;
            CurrentCoordonnees.Y = newY;
        }

        /// <summary>
        /// Détermine si la nouvelle position est vide ou non
        /// </summary>
        /// <param name="newX">Coordonnée en X</param>
        /// <param name="newY">Coordonnée en Y</param>
        /// <returns></returns>
        public Nuisible IsPositionEmpty(int newX, int newY)
        {
            Nuisible nuisibleEncountered = null;
            for (var i = 0; i < Ecosysteme.GetListNuisibles().Count; i++)
            {
                if (Ecosysteme.GetListNuisibles()[i] != this)
                {
                    var currentNuisibleCoordinates = Ecosysteme.GetListNuisibles()[i].CurrentCoordonnees;
                    if (currentNuisibleCoordinates.X == newX && currentNuisibleCoordinates.Y == newY)
                    {
                        nuisibleEncountered = Ecosysteme.GetListNuisibles()[i];
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
            var randomNumber = R.Next(0,4);

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

        public void Zombify(Nuisible nuisibleEncountered)
        {
            if (nuisibleEncountered.Etat != Dead)
            {
                nuisibleEncountered.Etat = Zombified;
                ResetPosition();
            }
        }

        protected void ResetPosition()
        {
            CurrentCoordonnees = LastCoordonnees;
        }

        public void GetDescription()
        {
            Console.WriteLine("Nuisible: " + GetType() + " | etat: " + Etat + " | coordonnées: " + CurrentCoordonnees.X + ","+ CurrentCoordonnees.Y);
                    
        }
    }
}