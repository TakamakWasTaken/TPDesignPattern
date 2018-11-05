using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography;

namespace TPDesignPattern
{
    internal class Program
    {
        private static Timer aTimer;
        private static Simulation _simulation;
        public static void Main(string[] args)
        {
            _simulation = new Simulation();
            Ecosysteme ecosysteme = new Ecosysteme();

            Zombie zombie = new Zombie();
            Zombie zombie2 = new Zombie();
            Zombie zombie3 = new Zombie();
            Rat rat = new Rat();
            Rat rat1 = new Rat();
            Rat rat2 = new Rat();
            Rat rat3 = new Rat();
            Rat rat4 = new Rat();
            Pigeon pigeon = new Pigeon();
            Pigeon pigeon1 = new Pigeon();
            Pigeon pigeon2 = new Pigeon();
            Pigeon pigeon3 = new Pigeon();
            Pigeon pigeon4 = new Pigeon();
            
            ecosysteme.addNuisible(rat);
            ecosysteme.addNuisible(rat1);
            ecosysteme.addNuisible(rat2);
            ecosysteme.addNuisible(rat3);
            ecosysteme.addNuisible(rat4);
            ecosysteme.addNuisible(pigeon);
            ecosysteme.addNuisible(pigeon1);
            ecosysteme.addNuisible(pigeon2);
            ecosysteme.addNuisible(pigeon3);
            ecosysteme.addNuisible(pigeon4);
            ecosysteme.addNuisible(zombie);
            ecosysteme.addNuisible(zombie2);
            ecosysteme.addNuisible(zombie3);
            _simulation.addEcosysteme(ecosysteme);
            
             
            SetTimer();

            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            Console.ReadLine();
            aTimer.Stop();
            aTimer.Dispose();
      
            Console.WriteLine("Terminating the application...");
            
        }
        
        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new Timer(1000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Ecosysteme ecosysteme = _simulation.getEcosystemeList()[0];
            for (int x = ecosysteme.min; x <= ecosysteme.max; x++)
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
                
                for (var y = ecosysteme.min; y <= ecosysteme.max; y++)
                {
                    //nuisible ou case vide?
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
                    for (var i = 0; i < ecosysteme.getListNuisibles().Count; i++)
                    {
                        var nuisib = ecosysteme.getListNuisibles()[i];
                        Console.WriteLine(" etat: " + nuisib.etat + " coord: " + nuisib._currentCoordonnees.X + ","+ nuisib._currentCoordonnees.Y);
                    }
                    ecosysteme.UpdatePositions();
                    Console.WriteLine("en222d");
                }
            }
        }

        private static string getNextSquareContent(Ecosysteme ecosysteme, int x, int y)
        {
            string nextSquare = "-";
            for (var i = 0; i < ecosysteme.getListNuisibles().Count; i++)
            {
                Nuisible currentNuisible = ecosysteme.getListNuisibles()[i];

                if (x == currentNuisible._currentCoordonnees.X && y == currentNuisible._currentCoordonnees.Y)
                {
                    nextSquare = currentNuisible.shortName;
                }
            }
            return nextSquare;
        }
    }
}