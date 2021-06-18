using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium_Simulation
{
    public class World
    {
        public int sizeX = 1478;
        public int sizeY = 650;
        public List<Fish> fishes = new List<Fish>();
        public List<Herb> herbs = new List<Herb>();
        public List<Fish> alphaFishes = new List<Fish>();

        public void AddAnimal(Fish fish)
        {
            fishes.Add(fish);
        }

        public void AddPlant(Herb herb)
        {
            herbs.Add(herb);
        }

        public void AddAlphaFish(Fish fish)
        {
            alphaFishes.Add(fish);
        }
    }
}
