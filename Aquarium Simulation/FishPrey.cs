using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium_Simulation
{
    public class FishPrey:Fish
    {
        public FishPrey()
        {
            colour = Brushes.DarkBlue;
            name = "Prey";
            health = 100.0f;
            attack = 12.0f;
            speed = 150.0f;
            hunger = 120.0f;
            isAlive = true;
            isCarnivore = false;
            random = new Random();
        }

        override public void SearchForEnemies(World world)
        {
            int size = world.fishes.Count();
            for (int j = 0; j < size; j++)
            {
                if (world.fishes[j].name == "Predator")
                {
                    if (Math.Abs(world.fishes[j].x - x) <= 10)
                    {
                        x++;
                    }
                    if (Math.Abs(world.fishes[j].y - y) <= 10)
                    {
                        y++;
                    }
                }
            }
        }

        public override void Hunt(World world)
        {
            if (hunger <= 80.0f)
            {
                // Find closest herb
                Herb closestPrey = FindClosestHerb(world);
                if (closestPrey != null)
                {
                    // Follow horizontally
                    if (x > closestPrey.x)
                    {
                        if (x != 1) x--;
                    }
                    else
                    {
                        if (x != world.sizeX) x++;
                    }

                    // Follow vertically
                    if (y > closestPrey.y)
                    {
                        if (y != 1) y--;
                    }
                    else
                    {
                        if (y != world.sizeY) y++;
                    }

                    // Eat
                    if (x == closestPrey.x && y == closestPrey.y)
                    {
                        Eat();
                        world.herbs.Remove(closestPrey);
                    }
                }
            }
        }

        override public void Eat()
        {
            hunger += 10;
        }

        override public void GetHungry()
        {
            hunger -= 0.5f;
        }
    }
}