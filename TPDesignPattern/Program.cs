using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace TPDesignPattern
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Bonjour Utilisateur!");
            
            Simulation simulation = new Simulation();
            Ecosysteme ecosysteme = new Ecosysteme();

            Zombie zombie = new Zombie();
            ecosysteme.addNuisible(zombie);
            
            simulation.addEcosysteme(ecosysteme);
        }
    }
}