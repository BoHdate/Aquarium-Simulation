using System;
using System.Drawing;
using System.Windows.Forms;

namespace Aquarium_Simulation
{
    public partial class Form1 : Form
    {
        private Timer timer = new Timer();
        Graphics dc;
        Creations creations = new Creations();
        public Form1()
        {
            InitializeComponent();
            timer.Interval = 10;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (!timer.Enabled) timer.Start();
            timer.Tick += new EventHandler(AnimateClick);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            Refresh();
            timer.Stop();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            Refresh();
            timer.Stop();
            creations.ecoStructure.Action();
            pictureBoxWorld.Paint += new PaintEventHandler(CreationsMethods);
        }

        private void AnimateClick(object sender, EventArgs e)
        {
            Refresh();
            creations.ecoStructure.Action();
            pictureBoxWorld.Paint += new PaintEventHandler(CreationsMethods);
        }

        private void CreationsMethods(object sender, PaintEventArgs e)
        {
            dc = e.Graphics;
            base.OnPaint(e);
            creations.PaintAllAnimals(dc);
            creations.PaintAllPlants(dc);
        }
    }
}
