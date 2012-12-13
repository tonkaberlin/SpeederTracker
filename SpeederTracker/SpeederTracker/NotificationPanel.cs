using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class NotificationPanel : Panel
{
    
    int position;
    int eta;
    public bool closed;

    Label loclabel;
    Label distlabel;
    Label speedlabel;
    Label overspeedlabel;
    Label mphlabel;
    Label etalabel;
    Label closelabel;

	public NotificationPanel(int position, String location, int distance, 
        int speedlim, int speed)
        : base()
	{
        this.position = position;
        this.closed = false;

        loclabel = new Label();
        distlabel = new Label();
        speedlabel = new Label();
        mphlabel = new Label();
        overspeedlabel = new Label();
        etalabel = new Label();
        closelabel = new Label();

        //Add labels to panel
        this.Controls.Add(loclabel);
        this.Controls.Add(distlabel);
        this.Controls.Add(speedlabel);
        this.Controls.Add(overspeedlabel);
        this.Controls.Add(mphlabel);
        this.Controls.Add(etalabel);
        this.Controls.Add(closelabel);

        //initialize panel settings
        this.BackColor = System.Drawing.SystemColors.Window;
        this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.Location = new System.Drawing.Point(0, 75 * 0);
        this.Margin = new System.Windows.Forms.Padding(0);
        this.Size = new System.Drawing.Size(384, 75);
        this.TabIndex = 0;

        //initialize labels
        initLocLabel(location);
        initDistLabel(distance);
        initSpeedLabel(speed, speedlim);
        //initEtaLabel(eta);
        this.eta = initEtaLabelSpeed(speed, speedlim, distance);
        initCloseLabel();
    }

    private void closelabel_Click(object sender, EventArgs e)
    {
        //string parent_name = ((Label)sender).Parent.Name;
        //Console.WriteLine(parent_name);
        this.closed = true;
    }

    private void initLocLabel(String location)
    {
        this.loclabel.AutoSize = true;
        this.loclabel.Location = new System.Drawing.Point(26, 9);
        this.loclabel.Size = new System.Drawing.Size(102, 13);
        this.loclabel.TabIndex = 1;
        this.loclabel.Text = location;
    }

    private void initDistLabel(int distance)
    {
        this.distlabel.AutoSize = true;
        this.distlabel.Location = new System.Drawing.Point(29, 45);
        this.distlabel.Size = new System.Drawing.Size(80, 13);
        this.distlabel.TabIndex = 2;
        this.distlabel.Text = "Distance: " + distance + " mi";
    }

    private void initSpeedLabel(int speed, int speedlim)
    {
        this.speedlabel.AutoSize = true;
        this.speedlabel.Location = new System.Drawing.Point(182, 9);
        this.speedlabel.Size = new System.Drawing.Size(19, 13);
        this.speedlabel.TabIndex = 3;
        this.speedlabel.Text = speed.ToString();

        this.overspeedlabel.AutoSize = true;
        this.overspeedlabel.ForeColor = System.Drawing.Color.Red;
        this.overspeedlabel.Location = new System.Drawing.Point(198, 9);
        this.overspeedlabel.Size = new System.Drawing.Size(31, 13);
        this.overspeedlabel.TabIndex = 4;
        this.overspeedlabel.Text = "(+"
            + (speed - speedlim > 0 ? speed - speedlim : 0) + ")";

        this.mphlabel.AutoSize = true;
        this.mphlabel.Location = new System.Drawing.Point(235, 9);
        this.mphlabel.Size = new System.Drawing.Size(31, 13);
        this.mphlabel.TabIndex = 5;
        this.mphlabel.Text = "MPH";
    }

    private void initEtaLabel(int minutes)
    {
        this.etalabel.AutoSize = true;
        this.etalabel.Location = new System.Drawing.Point(182, 44);
        this.etalabel.Size = new System.Drawing.Size(65, 13);
        this.etalabel.TabIndex = 6;
        this.etalabel.Text = "ETA: " + minutes + " min";
    }

    private int initEtaLabelSpeed(int speed, int speedlim, int distance)
    {
        this.etalabel.AutoSize = true;
        this.etalabel.Location = new System.Drawing.Point(182, 44);
        this.etalabel.Size = new System.Drawing.Size(65, 13);
        this.etalabel.TabIndex = 7;
        decimal eta = ((speed + speedlim) / 2) / 60 * distance;
        Math.Round(eta);
        this.etalabel.Text = "ETA: " + eta + " min";
        return (int)eta;
    }

    private void initCloseLabel()
    {
        this.closelabel.AutoSize = true;
        this.closelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.closelabel.Location = new System.Drawing.Point(334, 24);
        this.closelabel.Size = new System.Drawing.Size(25, 24);
        this.closelabel.TabIndex = 8;
        this.closelabel.Text = "X";
        this.closelabel.Click += new System.EventHandler(this.closelabel_Click);
    }

    //Updates when a timer Tick occurs. Either updates the Estimated Time of Arrival,
    //Or returns that the notification has expired and should be removed.
    public bool tickTimer()
    {
        eta = eta - 1;
        if (eta > 0)
        {
            this.etalabel.Text = "ETA: " + eta + " min";
            this.etalabel.Update();
            return false;
        }
        else
        {
            this.closed = true;
            return true;
        }
    }

    ////Dispose of this panel and all resources utilizied within it.
    //public override void Dispose()
    //{
    //    loclabel.Dispose();
    //    distlabel.Dispose();
    //    speedlabel.Dispose();
    //    mphlabel.Dispose();
    //    overspeedlabel.Dispose();
    //    etalabel.Dispose();
    //    closelabel.Dispose();
    //    base.Dispose();
    //}
        
}
