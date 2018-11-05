using System;
using System.Timers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Security.Cryptography;
using TPDesignPattern.NonViolentStrategy;

namespace TPDesignPattern
{
    internal class Program
    {
        private static Timer aTimer;
        private static Simulation _simulation;
        public static void Main(string[] args)
        {
            
            _simulation = new Simulation();
            var choice = 0;
            var userChoiceMutants = 0;
            var userChoiceNonViolent = 0;
            var enableMutant = false;
            var enableStrategy = false;
            while (choice > 3 || choice < 1)
            {
                Console.WriteLine("Bienvenu, veuillez entrer le chiffre correspondant à l'écosystème à simuler et appuyer sur Entrée:\n");
                Console.WriteLine("1: Aléatoire");
                Console.WriteLine("2: UmbrellaCorp");
                Console.WriteLine("3: Citadin\n");
                var x = Console.ReadLine();
                if (x == "1" || x == "2" || x == "3")
                {
                    choice = Convert.ToInt16(x);
                }
            }
            
            while (userChoiceMutants < 1 || userChoiceMutants > 2)
            {
                Console.WriteLine("1: Mutants activés (Les pigeons tueront tous les rats rencontrés!)\n");
                Console.WriteLine("2: Mutants désactivés\n");
                var x = Console.ReadLine();
                userChoiceMutants = Convert.ToInt16(x);
                if (x == "1")
                {
                    enableMutant = true;
                }
            }
            
            while (userChoiceNonViolent < 1 || userChoiceNonViolent > 2)
            {
                Console.WriteLine("1: Nuisibles fuyards (Les nuisibles éviteront à tout prix les rencontres!)\n");
                Console.WriteLine("2: Nuisibles standards\n");
                var x = Console.ReadLine();
                userChoiceNonViolent = Convert.ToInt16(x);
                if (x == "1")
                {
                    enableStrategy = true;
                }
            }
            Ecosysteme ecosysteme = new Ecosysteme(choice);

            
            for (var i = 0; i < ecosysteme.GetListNuisibles().Count; i++)
            {
                var currentNuisible = ecosysteme.GetListNuisibles()[i];
                if (enableMutant && currentNuisible.GetType() == typeof(Pigeon))
                {
                    currentNuisible.IsMutant = true;
                }
                
                if (enableStrategy)
                {
                    currentNuisible.SetNonViolentStrategy(new NonViolentConcreteStrategy());
                }
                Console.WriteLine("Nuisible: " + currentNuisible.GetType() + " | etat: " + currentNuisible.Etat + " | coordonnées: " + currentNuisible.CurrentCoordonnees.X + ","+ currentNuisible.CurrentCoordonnees.Y);
            }
            
            _simulation.AddEcosysteme(ecosysteme);
            
            SetTimer();

            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.ReadLine();
            Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            aTimer.Stop();
            aTimer.Dispose();
            Console.WriteLine("Terminating the application...");
        }
        
        private static void SetTimer()
        {
            aTimer = new Timer(1000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Ecosysteme ecosysteme = _simulation.GetEcosystemeList()[0];
            for (int x = ecosysteme.Min; x <= ecosysteme.Max; x++)
            {
                if (x == 1)
                {
                    Console.WriteLine("╔══════════╗");
                    Console.Write("║");
                }
                else
                {
                    Console.Write("║");
                }
                
                for (var y = ecosysteme.Min; y <= ecosysteme.Max; y++)
                {
                    var nextSquare = getNextSquareContent(ecosysteme, x, y );
                    
                    Console.Write(nextSquare);
                    
                    
                    if (y == 10)
                    {
                        Console.WriteLine("║");
                    }
                }
                if (x == 10)
                {
                    Console.WriteLine("╚══════════╝");
                    for (var i = 0; i < ecosysteme.GetListNuisibles().Count; i++)
                    {
                        var nuisib = ecosysteme.GetListNuisibles()[i];
                        nuisib.GetDescription();
                    }
                    ecosysteme.UpdatePositions();
                }
            }
        }

        
        private static string getNextSquareContent(Ecosysteme ecosysteme, int x, int y)
        {
            string nextSquare = "-";
            for (var i = 0; i < ecosysteme.GetListNuisibles().Count; i++)
            {
                var currentNuisible = ecosysteme.GetListNuisibles()[i];

                if (currentNuisible.Etat != Nuisible.Dead)
                {
                    if (x == currentNuisible.CurrentCoordonnees.X && y == currentNuisible.CurrentCoordonnees.Y)
                    {
                        nextSquare = currentNuisible.ShortName;
                    }
                }
            }
            return nextSquare;
        }
    }
}