using System;
using System.Collections.Generic;

namespace TPDesignPattern
{
    public class Ecosysteme
    {
        public int Min { get; }
        public int Max { get; }
        public string Type { get; set; }
        public int MaxNuisibles { get; set; }
        
        private readonly List<Nuisible> _listNuisibles = new List<Nuisible>();

        /// <summary>
        /// Appel de la méthode spawn du nouveau nuisible et l'ajoute à la liste des nuisibles présents dans l'environnement.
        /// </summary>
        /// <param name="nuisible"> le Nuisible à ajouter à l'écosystème.</param>
        public void AddNuisible(Nuisible nuisible)
        {
            nuisible.Spawn(this);
            _listNuisibles.Add(nuisible);
        }

        public List<Nuisible> GetListNuisibles()
        {
            return _listNuisibles;
        }

        /// <summary>
        /// Le constructeur d'écosystème. instancie l'écosystème selon le type sélectionné par l'utilisateur.
        /// </summary>
        /// <param name="type"> entier qui permet de lier le choix de l'utilisateur à l'écosystème qui lui correspond.</param>
        public Ecosysteme(int type)
        {
            Min = 1;
            Max = 10;
            MaxNuisibles = 20;
            var R = new Random();
            var nbrRats = R.Next(1, MaxNuisibles - 1); //ce random permet à chaque type de nuisible de spanw au moins une fois.
            var nbrPigeons = R.Next(1, MaxNuisibles - nbrRats);
            var nbrZombies = MaxNuisibles - (nbrPigeons + nbrRats);
            switch (type)
            {
                case 1:
                    Type = "Aléatoire";
                    break;
                    
                case 2:
                    Type = "UmbrellaCorp";
                    nbrZombies = R.Next(MaxNuisibles/2, MaxNuisibles-1);
                    nbrRats = R.Next(1, MaxNuisibles-nbrZombies);
                    nbrPigeons = MaxNuisibles - (nbrRats + nbrZombies);
                    break;
                 
                case 3:
                    Type = "Citadin";
                    nbrRats = R.Next(1, MaxNuisibles);
                    nbrPigeons = MaxNuisibles - nbrRats;
                    nbrZombies = 0;
                    break;
                    
                default:
                    Type = "Aléatoire";
                    break;
            }
            for (var i = 0; i < nbrRats; i++)
            {
                var rat = new Rat();
                AddNuisible(rat);
            }
            for (var i = 0; i < nbrPigeons; i++)
            {
                var pigeon = new Pigeon();
                AddNuisible(pigeon);
            }
            for (var i = 0; i < nbrZombies; i++)
            {
                var zombie = new Zombie();
                AddNuisible(zombie);
            }
        }

        /// <summary>
        /// Invoque la méthode de déplacement de tous les nuisibles de l'écosystème, si ils sont vivants.
        /// </summary>
        public void UpdatePositions()
        {
            for (var i = 0; i < GetListNuisibles().Count; i++)
            {
                var currentNuisible = GetListNuisibles()[i];
                if (currentNuisible.Etat != Nuisible.Dead)
                {
                    currentNuisible.Deplacement();
                }
            }
        }
    }
}