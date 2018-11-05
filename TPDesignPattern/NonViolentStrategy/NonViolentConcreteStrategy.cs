using System.Collections.Generic;

namespace TPDesignPattern.NonViolentStrategy
{
    public class NonViolentConcreteStrategy : NonViolentStrategy
    {
        /// <summary>
        /// Modification de la méthode Déplacement() des Nuisibles. Cette méthode permet aux nuisibles de
        ///  relancer leur tentative de déplacement si celle-ci les fait rencontrer un autre nuisible.
        /// </summary>
        /// <param name="nuisible">Le nuisible courant, qui effectue le déplacement.</param>
        public override void NonViolentDeplacement(Nuisible nuisible)
        {
            for (var i = 0; i < nuisible.Vitesse; i++)
            {
                var directionPicked = new List<string>();
                var direction = nuisible.ChoixDirection();
                nuisible.MoveOne(direction);
                Nuisible nuisibleEncountered = nuisible.IsPositionEmpty(nuisible.CurrentCoordonnees.X, nuisible.CurrentCoordonnees.Y);
                
                for (var j = 0; j < 10; j++) //only 10 iterations to prevent infity loop with a while statement.
                {
                    if (nuisibleEncountered != null && nuisibleEncountered.Etat != Nuisible.Dead)
                    {
                        directionPicked.Add(direction);

                        if (4 - directionPicked.Count == 0)
                        {
                            nuisible.Contact(nuisibleEncountered);
                        }
                        else
                        {
                            nuisible.ResetPosition();
                            direction = nuisible.ChoixDirection();
                            nuisible.MoveOne(direction);
                            nuisibleEncountered = nuisible.IsPositionEmpty(nuisible.CurrentCoordonnees.X,
                                nuisible.CurrentCoordonnees.Y);
                        }
                    }
                    else
                    {
                        j = 9;
                    }
                }
            }
        }
    }
}