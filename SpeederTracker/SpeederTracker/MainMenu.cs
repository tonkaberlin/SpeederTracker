using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
//using CustomUIControls;

namespace SpeederTracker
{
    public partial class MainMenu : Form
    {
        //TaskbarNotifier taskbarNotifier;
        Timer clocktimer;
        Timer closetimer;
        List<NotificationPanel> panels;
        Panel emptypanel;
        Label emptylabel;

        public MainMenu()
        {
            InitializeComponent();
            panels = new List<NotificationPanel>();
            initEmptyPanel();
            initTimers();

        }

        //Exits the program.
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        //Runs a simulation of a new notification.
        private void runSimulationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form configbox = new Config(this);
            configbox.Show();
        }

        //Runs a notification Test
        private void runNotificationTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setNotificationPanel("I-81 SB, Marker 109", 90, 65, 5);
            
            //taskbarNotifier.Show("TitleText", "ContentText", 500, 3000, 500);
        }

        //private void initNotification()
        //{
        //    taskbarNotifier = new TaskbarNotifier();
        //    taskbarNotifier.SetBackgroundBitmap("skin.bmp",
        //                        Color.FromArgb(255, 0, 255));
        //    taskbarNotifier.SetCloseBitmap("close.bmp",
        //            Color.FromArgb(255, 0, 255), new Point(127, 8));
        //    taskbarNotifier.TitleRectangle = new Rectangle(40, 9, 70, 25);
        //    taskbarNotifier.ContentRectangle = new Rectangle(8, 41, 133, 68);
        //    //taskbarNotifier.TitleClick += new EventHandler(TitleClick);
        //    //taskbarNotifier.ContentClick += new EventHandler(ContentClick);
        //    //taskbarNotifier.CloseClick += new EventHandler(CloseClick);
        //}

        //Initializes the timers for notifications to update.
        private void initTimers()
        {
            clocktimer = new Timer();
            clocktimer.Tick += new EventHandler(clocktimer_Tick);
            clocktimer.Interval = (1000) * (60);      //Timer ticks every 60 seconds
            clocktimer.Enabled = true;

            closetimer = new Timer();
            closetimer.Tick += new EventHandler(closetimer_Tick);
            closetimer.Interval = 10;
            closetimer.Enabled = true;
        }

        //Updates stored notification panels, removing them if they expire and
        //become invalid.
        void clocktimer_Tick(object sender, EventArgs e)
        {
            if (panels.Count > 0)
            {
                foreach (NotificationPanel p in panels)
                {
                    if (p.tickTimer())
                    {
                        removeNotificationPanel(p);
                        break;
                    }
                }
            }
        }

        //Updateds stored notification panels, removing them from the panels
        //list if they have been disposed of.
        void closetimer_Tick(object sender, EventArgs e)
        {
            if (panels.Count > 0)
            {
                foreach (NotificationPanel p in panels)
                {
                    if (p.closed)
                    {
                        removeNotificationPanel(p);
                        break;
                    }
                }
            }
        }

        //Inititializes a panel showing that there are currently no
        //valid notifications.
        private void initEmptyPanel()
        {
            this.emptypanel = new Panel();
            this.emptylabel = new Label();

            //EmptyPanel
            this.emptypanel.BackColor = System.Drawing.SystemColors.Window;
            this.emptypanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.emptypanel.Controls.Add(this.emptylabel);
            this.emptypanel.Location = new System.Drawing.Point(0, 0);
            this.emptypanel.Margin = new System.Windows.Forms.Padding(0);
            this.emptypanel.Name = "emptypanel";
            this.emptypanel.Size = new System.Drawing.Size(384, 75);
            this.emptypanel.TabIndex = 0;

            //EmptyLabel
            this.emptylabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.emptylabel.ForeColor = System.Drawing.Color.Maroon;
            this.emptylabel.Location = new System.Drawing.Point(0, 0);
            this.emptylabel.Name = "emptylabel";
            this.emptylabel.Size = new System.Drawing.Size(382, 74);
            this.emptylabel.TabIndex = 0;
            this.emptylabel.Text = "No Active Notifications";

            this.flowLayoutPanel1.Controls.Add(this.emptypanel);
        }

        //Show/Hide the "No Notifications" Panel.
        private void showEmptyPanel(bool show)
        {
            this.emptypanel.Visible = show;
            this.emptylabel.Visible = show;
        }

        //Set a new Notification panel.
        public void setNotificationPanel(string location, int speed, int speedlim, 
            int distance)
        {
            if (panels.Count == 0)
            {
                showEmptyPanel(false);
            }

            NotificationPanel newpanel = new NotificationPanel(panels.Count, location,
                distance, speedlim, speed);
            panels.Insert(0, newpanel);
            this.flowLayoutPanel1.Controls.Add(newpanel);
            reorderPanels();
        }

        //Remove a given Notification Panel from the panel pool.
        private void removeNotificationPanel(NotificationPanel panel)
        {
            panels.Remove(panel);
            this.flowLayoutPanel1.Controls.Remove(panel);
            reorderPanels();

            if (panels.Count == 0)
            {
                showEmptyPanel(true);
            }
        }

        //Reorders the panels graphically in a particular order.
        //New notifications are displayed @ the top of the window, older
        //at the bottom.
        private void reorderPanels()
        {
            for (int i = 0; i < panels.Count; i++)
            {
                flowLayoutPanel1.Controls.SetChildIndex(panels.ElementAt(i), i);
            }
        }

        private void sizeWindowStartup()
        {

        }

        //Displays an About...Dialog.
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form aboutbox = new AboutBox();
            aboutbox.Show();
        }

        //Clears all notifications from the window.
        private void clearNotificationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (NotificationPanel p in panels)
            {
                this.flowLayoutPanel1.Controls.Remove(p);
            }
            panels.Clear();
            showEmptyPanel(true);
        }

    }
}

