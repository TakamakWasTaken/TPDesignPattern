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
            Pigeon pigeon = new Pigeon();
            
            ecosysteme.addNuisible(zombie);
            ecosysteme.addNuisible(zombie2);
            ecosysteme.addNuisible(zombie3);
            ecosysteme.addNuisible(rat);
            ecosysteme.addNuisible(pigeon);
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
            aTimer = new Timer(2000);
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
                    ecosysteme.UpdatePositions();
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