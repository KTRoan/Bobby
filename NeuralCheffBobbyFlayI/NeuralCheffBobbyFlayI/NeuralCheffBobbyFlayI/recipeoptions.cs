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
    public partial class recipeoptions : Form
    {

        public object userchoice_;
        public object drinks = "Drinks"; 
        public object italian = "Italian Food";
        public object mexican = "Mexican Food";
        public object chinese = "Chinese Food";

        public recipeoptions()
        {
            InitializeComponent();
        }

        private void button_drinks_Click(object sender, EventArgs e)
        {
            button_italian.Enabled = false;
            button_mexican.Enabled = false;
            button_chinese.Enabled = false;
            userchoice_ = drinks;
        }

        private void button_italian_Click(object sender, EventArgs e)
        {
            button_drinks.Enabled = false;
            button_mexican.Enabled = false;
            button_chinese.Enabled = false;
            userchoice_ = italian;
        }

        private void button_mexican_Click(object sender, EventArgs e)
        {
            button_italian.Enabled = false;
            button_drinks.Enabled = false;
            button_chinese.Enabled = false;
            userchoice_ = mexican;
        }

        private void button_chinese_Click(object sender, EventArgs e)
        {
            button_italian.Enabled = false;
            button_mexican.Enabled = false;
            button_drinks.Enabled = false;
            userchoice_ = chinese;
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Bobby b = new Bobby();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button_italian.Enabled = true;
            button_mexican.Enabled = true;
            button_drinks.Enabled = true;
            button_chinese.Enabled = true;
            userchoice_ = null;
        }
    }
}
