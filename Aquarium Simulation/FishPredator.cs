using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium_Simulation
{
    class FishPredator:Fish
    {
        public FishPredator()
        {
            colour = Brushes.Gray;
            name = "Predator";
            health = 100.0f;
            attack = 12.0f;
            speed = 48.0f;
            hunger = 100.0f;
            isAlive = true;
            isCarnivore = true;
            random = new Random();
        }

        public override void Hunt(World world)
        {
            if (hunger <= 60.0f)
            {
                int closest = 0;
                for (int j = 0; j < world.fishes.Count; j++)
                {
                    int preyX = world.fishes[j].x;
                    int preyY = world.fishes[j].y;
                    if (world.fishes[j].name == "Prey")
                    {
                        if (Math.Pow(preyX - x, 2) + Math.Pow(preyY - y, 2) >= closest)
                        {

                            if (x > preyX)
                            {
                                if (x == 1) x = 1;
                                else x--;
                            }
                            else
                            {
                                if (x == world.sizeX) x = world.sizeX;
                                else x++;
                            }
                            if (y > preyY)
                            {
                                if (y == 1) y = 1;
                                else y--;
                            }
                            else
                            {
                                if (y == world.sizeY) y = world.sizeY;
                                else y++;
                            }
                            if (x == preyX && y == preyY)
                            {
                                Eat();
                                world.fishes.Remove(world.fishes[j]);
                            }
                        }
                    }
                }
            }
            else WalkAround();
        }

        override public void Eat()
        {
            hunger += 25;
        }

        override public void GetHungry()
        {
            hunger -= 0.3f;
        }
    }
}