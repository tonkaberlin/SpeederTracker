namespace SpeederTracker
{
    partial class Config
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.locationBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.genNotificationButton = new System.Windows.Forms.Button();
            this.distanceBox = new System.Windows.Forms.NumericUpDown();
            this.speedBox = new System.Windows.Forms.NumericUpDown();
            this.speedLimBox = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.distanceBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedLimBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Camera Location";
            // 
            // locationBox
            // 
            this.locationBox.Location = new System.Drawing.Point(16, 29);
            this.locationBox.Name = "locationBox";
            this.locationBox.Size = new System.Drawing.Size(256, 20);
            this.locationBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "This Car\'s Distance from Camera (in Miles)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Target Car\'s Current Speed (MPH)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Speed Limit for Camera\'s Area";
            // 
            // genNotificationButton
            // 
            this.genNotificationButton.Location = new System.Drawing.Point(73, 227);
            this.genNotificationButton.Name = "genNotificationButton";
            this.genNotificationButton.Size = new System.Drawing.Size(135, 23);
            this.genNotificationButton.TabIndex = 8;
            this.genNotificationButton.Text = "Generate Notification";
            this.genNotificationButton.UseVisualStyleBackColor = true;
            this.genNotificationButton.Click += new System.EventHandler(this.genNotificationButton_Click);
            // 
            // distanceBox
            // 
            this.distanceBox.Location = new System.Drawing.Point(19, 73);
            this.distanceBox.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.distanceBox.Name = "distanceBox";
            this.distanceBox.Size = new System.Drawing.Size(52, 20);
            this.distanceBox.TabIndex = 9;
            // 
            // speedBox
            // 
            this.speedBox.Location = new System.Drawing.Point(19, 121);
            this.speedBox.Name = "speedBox";
            this.speedBox.Size = new System.Drawing.Size(52, 20);
            this.speedBox.TabIndex = 10;
            // 
            // speedLimBox
            // 
            this.speedLimBox.Location = new System.Drawing.Point(19, 172);
            this.speedLimBox.Name = "speedLimBox";
            this.speedLimBox.Size = new System.Drawing.Size(52, 20);
            this.speedLimBox.TabIndex = 11;
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.speedLimBox);
            this.Controls.Add(this.speedBox);
            this.Controls.Add(this.distanceBox);
            this.Controls.Add(this.genNotificationButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.locationBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Config";
            this.Text = "Config";
            ((System.ComponentModel.ISupportInitialize)(this.distanceBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedLimBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox locationBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button genNotificationButton;
        private System.Windows.Forms.NumericUpDown distanceBox;
        private System.Windows.Forms.NumericUpDown speedBox;
        private System.Windows.Forms.NumericUpDown speedLimBox;
    }
}