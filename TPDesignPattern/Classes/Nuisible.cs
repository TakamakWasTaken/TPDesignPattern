using System;
using System.Net.NetworkInformation;

namespace TPDesignPattern
{
    public abstract class Nuisible
    {
        protected static readonly Random R = new Random();
        public Ecosysteme Ecosysteme { set; get; }
        public int Vitesse { set; get; }
        public Coordonnees CurrentCoordonnees { set; get; }
        protected Coordonnees LastCoordonnees { set; get;  }
        public string Etat { set; get; }
        public const string Dead = "dead";
        public const string Alive = "alive";
        public const string Zombified = "zombified";
        public string ShortName { get; set; }
        public bool IsMutant = false;
        private NonViolentStrategy.NonViolentStrategy _nonViolentStrategy;

        /// <summary>
        /// Méthode abstraite qui gère le comportement de chaque type nuisible lors de la rencontre avec un autre nuisible.
        /// </summary>
        /// <param name="nuisibleEncountered">Le Nuisible rencontré</param>
        public abstract void Contact(Nuisible nuisibleEncountered);

        /// <summary>
        /// Calcul des coordonnées d'apparition du Nuisible dans son écosystème.
        /// </summary>
        /// <param name="ecosysteme">L'écosystème dans lequel va évoluer le nuisible. Stocké dans dans chaque instance de la classe.</param>
        public void Spawn(Ecosysteme ecosysteme)
        {
            Ecosysteme = ecosysteme;
            int newX = R.Next(Ecosysteme.Min, Ecosysteme.Max+1);
            int newY = R.Next(Ecosysteme.Min, Ecosysteme.Max + 1);
            CurrentCoordonnees = new Coordonnees(newX, newY);
        }
        
        /// <summary>
        /// Calcule la position après déplacement total. Appelle la fonction de vérification de présence d'un autre nuisible et la fonction de contact si nécessaire.
        /// </summary>
        public void Deplacement()
        {
            if (_nonViolentStrategy == null)
            {
                for (var i = 0; i < Vitesse; i++)
                {
                    var direction = ChoixDirection();
                    MoveOne(direction);
                    Nuisible nuisibleEncountered = IsPositionEmpty(CurrentCoordonnees.X, CurrentCoordonnees.Y);
                    if (nuisibleEncountered != null && nuisibleEncountered.Etat != Dead)
                    {
                        Contact(nuisibleEncountered);
                    }
                }
            }
            else
            {
                _nonViolentStrategy.NonViolentDeplacement(this);
            }
        }
                
                

        /// <summary>
        /// Calcule la position du Nuisible après un déplacement d'une case. Si il est hors limites, inverse le déplacement.
        /// </summary>
        /// <param name="direction">Direction dans laquelle se dirige le nuisible, haut/bas/gauche/droite</param>
        public void MoveOne(string direction)
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
        /// Détermine si la nouvelle position contient déjà un nuisible (vivant ou zombifié)
        /// </summary>
        /// <param name="newX">Coordonnée en X</param>
        /// <param name="newY">Coordonnée en Y</param>
        /// <returns>renvoi le nuisible rencontré sur la nouvelle case</returns>
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
        /// <returns>Retourne la direction choisie sous la forme d'une string</returns>
        public string ChoixDirection()
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

        /// <summary>
        /// Fonction de zombification, présente au niveau de la classe Nuisible car un Rato u un Pigeon zombifié ne change pas de type mais obtient les propriétés d'un zombie.
        /// </summary>
        /// <param name="nuisibleEncountered">Le nuisible rencontré.</param>
        public void Zombify(Nuisible nuisibleEncountered)
        {
            if (nuisibleEncountered.Etat != Dead)
            {
                nuisibleEncountered.Etat = Zombified;
                ResetPosition();
            }
        }

        /// <summary>
        /// Retour à la case précédente.
        /// </summary>
        public void ResetPosition()
        {
            CurrentCoordonnees = LastCoordonnees;
            
        }

        /// <summary>
        /// renvoi une courte description des caractéristiques du Nuisible.
        /// </summary>
        public void GetDescription()
        {
            Console.WriteLine("Nuisible: " + GetType() + " | etat: " + Etat + " | coordonnées: " + CurrentCoordonnees.X + ","+ CurrentCoordonnees.Y);
                    
        }
        
        /// <summary>
        /// implémente une instance de la classe NonViolentStrategy dans la classe Nuisible
        /// </summary>
        /// <param name="nonViolentStrategy">L'instance en question. Son rôle est de modifier le comportement du déplacement du Nuisible.</param>
        public void SetNonViolentStrategy(NonViolentStrategy.NonViolentStrategy nonViolentStrategy)
        {
            _nonViolentStrategy = nonViolentStrategy;
        }
 
    }
}