using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpeederTracker
{
    public partial class Config : Form
    {
        MainMenu menu;

        public string location;
        public int distance;
        public int speed;
        public int speedlim;

        public Config(MainMenu menu)
        {
            this.menu = menu;
            InitializeComponent();
            location = "";
            distance = 0;
            speed = 0;
            speedlim = 0;
        }

        private void saveConfig()
        {
            location = locationBox.Text;
            distance = (int)distanceBox.Value;
            speed = (int)speedBox.Value;
            speedlim = (int)speedLimBox.Value;
        }

        private void genNotificationButton_Click(object sender, EventArgs e)
        {
            saveConfig();
            menu.setNotificationPanel(location, speed, speedlim, distance);
        }
    }
}
