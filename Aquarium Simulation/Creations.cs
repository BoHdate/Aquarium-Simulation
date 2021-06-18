using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium_Simulation
{
    class Creations
    {
        public EcoStructure ecoStructure = new EcoStructure();
        public Creations()
        {
            ecoStructure.CreateLife();
            ecoStructure.CreatePlants();
        }

        public void WriteLogsInConsole()
        {
            for (int i = 0; i < ecoStructure.world.fishes.Count(); i++)
            {
                Console.WriteLine("Fish " + i + ".: " +
                        ecoStructure.world.fishes[i].name + " at: x = " +
                        ecoStructure.world.fishes[i].x + ", y = " +
                        ecoStructure.world.fishes[i].y + ", sex: " +
                        ecoStructure.world.fishes[i].sex + ", hunger: " +
                        ecoStructure.world.fishes[i].hunger);
            }

            for (int i = 0; i < ecoStructure.world.herbs.Count(); i++)
            {
                Console.WriteLine("Herb " + i + ".: " +
                        ecoStructure.world.herbs[i].name + " at: x = " +
                        ecoStructure.world.herbs[i].x + ", y = " +
                        ecoStructure.world.herbs[i].y + ", age = " +
                        ecoStructure.world.herbs[i].age);
            }
            Console.WriteLine("-----------------------------------------");
        }

        public void PaintAllAnimals(Graphics g)
        {
            foreach (var fish in ecoStructure.world.fishes)
            {
                fish.PaintAnimal(g);
            }
            foreach (var fish in ecoStructure.world.alphaFishes)
            {
                fish.PaintAnimal(g);
            }
        }

        public void PaintAllPlants(Graphics g)
        {
            foreach (var herb in ecoStructure.world.herbs)
            {
                herb.PaintHerb(g);
            }
        }
    }
}
