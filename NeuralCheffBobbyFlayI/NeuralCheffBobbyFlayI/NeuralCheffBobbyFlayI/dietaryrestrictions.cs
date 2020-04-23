using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralCheffBobbyFlayI
{
    public partial class dietaryrestrictions : Form
    {
        public dietaryrestrictions()
        {
            InitializeComponent();
        }
        public object userchoice;
        public object gluttenfree = "Glutten Free";
        public object lowcarb = "Low Carb";
        public object vegan = "Vegan";
        public object vegetarian = "Vegetarian";

        private void button_gluttenfree_Click(object sender, EventArgs e)
        {
            button_vegetarian.Enabled = false;
            button_vegan.Enabled = false;
            button_lowcarb.Enabled = false;
            userchoice = gluttenfree;
        }

        private void button_lowcarb_Click(object sender, EventArgs e)
        {
            button_vegetarian.Enabled = false;
            button_vegan.Enabled = false;
            button_gluttenfree.Enabled = false;
            userchoice = lowcarb;
        }

        private void button_vegan_Click(object sender, EventArgs e)
        {
            button_vegetarian.Enabled = false;
            button_gluttenfree.Enabled = false;
            button_lowcarb.Enabled = false;
            userchoice = vegan;
        }

        private void button_vegetarian_Click(object sender, EventArgs e)
        {
            button_vegan.Enabled = false;
            button_gluttenfree.Enabled = false;
            button_lowcarb.Enabled = false;
            userchoice = vegetarian;
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button_vegan.Enabled = true;
            button_gluttenfree.Enabled = true;
            button_lowcarb.Enabled = true;
            button_vegetarian.Enabled = true;
            userchoice = null;
        }
    }
}
