using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace TPDesignPattern
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Bonjour Utilisateur!");
            
            Simulation simulation = new Simulation();
            Ecosysteme ecosysteme = new Ecosysteme();

            Zombie zombie = new Zombie();
            Rat rat = new Rat();
            //Pigeon pigeon = new Pigeon();
            
            ecosysteme.addNuisible(zombie);
            
            //simulation.addEcosysteme(ecosysteme);
            
            //simulation.start();

            for (int x = 0; x <= 10; x++)
            {
                if (x == 0)
                {
                    Console.WriteLine("╔══════════╗");
                    
                    Console.Write("║");
                }
                else if (x == 10)
                {
                    Console.WriteLine("╚══════════╝");
                }
                else
                {
                    Console.Write("║");
                }
                for (int y = 1; y <= 10; y++)
                {
                    if (x != 10)
                    {
                        //Console.Write();
                    }


                    if (y == 10 && x < 10)
                    {
                        Console.WriteLine("║");
                    }
                }
            }
        }
    }
}