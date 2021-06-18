using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium_Simulation
{
    public class Herb
    {
        public Herb() { }
        public Brush colour;
        public bool isAlive;
        public string name;
        public float nutrients;
        public float speedOfGrowth;
        public int x;
        public int y;
        public int age;
        public int hasSeed;

        virtual public void Grow(World world) { }
        virtual public void Age() { age++; }

        public bool CheckForSpace(World world, int directionX, int directionY) // правда -> можно посадить 
        {
            bool isFree = true;
            int i = 0;
            while (i < world.herbs.Count)
            {
                if (this != world.herbs[i])
                {
                    if ((x + directionX == world.herbs[i].x && y == world.herbs[i].y) ||
                        (y + directionY == world.herbs[i].y && x == world.herbs[i].x) ||
                        (x + directionX == world.herbs[i].x && y + directionY == world.herbs[i].y))
                    {
                        isFree = false; break;
                    }
                }
                i++;
            }
            if (!isFree) return false;
            else return true;
        }

        public void PaintHerb(Graphics graphics)
        {
            Rectangle rectangle = new Rectangle(x, y, 1, 1);
            graphics.DrawRectangle(Pens.Green, rectangle);
            graphics.FillRectangle(Brushes.Green, rectangle);
        }
    }
}
