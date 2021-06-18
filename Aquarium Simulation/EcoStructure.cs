using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium_Simulation
{
    class EcoStructure
    {
        public World world = new World();
        Random randomizer = new Random();
        private int numberOfHerds = 20;
        public int CreateAnimal()
        {
            return randomizer.Next(0, 10);
        }

        public int GenerateX()
        {
            return randomizer.Next(1, world.sizeX);
        }

        public int GenerateY()
        {
            return randomizer.Next(1, world.sizeY);
        }

        public bool GenerateSex()
        {
            int which = randomizer.Next(0, 2);
            if (which == 0) return false;
            else return true;
        }

        public int GenerateAlpha()
        {
            return randomizer.Next(0, numberOfHerds);
        }

        public void CreateAlpha()
        {
            FishPrey doeAlpha = new FishPrey
            {
                x = GenerateX(),
                y = GenerateY(),
                sex = false,
                isAlpha = true,
                age = 7
            };
            world.AddAlphaFish(doeAlpha);
        }

        public void CreateHerd()
        {
            for (int i = 0; i < 10; i++)
            {
                bool sex = GenerateSex();
                FishPrey fishPrey = new FishPrey
                {
                    myAlpha = world.alphaFishes[GenerateAlpha()],
                    sex = sex,
                    isAlpha = false,
                };
                fishPrey.NearAlphaX();
                fishPrey.NearAlphaY();
                world.AddAnimal(fishPrey);
            }
        }

        public void CreateLife()
        {
            for (int i = 0; i < numberOfHerds; i++)
            {
                CreateAlpha();
            }
            CreateHerd();
        }

        public void CreatePlants()
        {
            for (int i = 0; i < 100; i++)
            {
                Grass grass = new Grass();

                int x = GenerateX();
                int y = GenerateY();

                grass.x = x;
                grass.y = y;
                world.herbs.Add(grass);
            }
        }
        public void Action()
        {
            for (int i = 0; i < world.fishes.Count; i++)
            {
                if (world.fishes[i].isAlive)
                {
                    world.fishes[i].StayWithAlpha();
                    world.fishes[i].GetHungry();
                    world.fishes[i].SearchForEnemies(world);
                    world.fishes[i].Hunt(world);
                    world.fishes[i].Age();
                }
            }

            for (int i = 0; i < world.alphaFishes.Count; i++)
            {
                world.alphaFishes[i].WalkAround();
                world.alphaFishes[i].GetHungry();
                world.alphaFishes[i].SearchForEnemies(world);
                world.alphaFishes[i].Hunt(world);
                world.alphaFishes[i].Age();
            }

            for (int i = 0; i < world.herbs.Count; i++)
            {
                world.herbs[i].Grow(world);
                world.herbs[i].Age();
            }
        }
    }
}