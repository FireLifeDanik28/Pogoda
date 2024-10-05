namespace Pogoda
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            button1 = new Button();
            refreshTimer = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 20F);
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(128, 111);
            button1.TabIndex = 0;
            button1.Text = "Check Weather";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // refreshTimer
            // 
            refreshTimer.Enabled = true;
            refreshTimer.Interval = 900000;
            refreshTimer.Tick += refreshTimer_Tick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(146, 49);
            label1.Name = "label1";
            label1.Size = new Size(227, 37);
            label1.TabIndex = 2;
            label1.Text = "Temperature: __°C";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20F);
            label2.Location = new Point(146, 86);
            label2.Name = "label2";
            label2.Size = new Size(183, 37);
            label2.TabIndex = 3;
            label2.Text = "Humidity: __%";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 20F);
            label3.Location = new Point(12, 123);
            label3.Name = "label3";
            label3.Size = new Size(416, 37);
            label3.TabIndex = 4;
            label3.Text = "Summary: _________________________";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 20F);
            label4.Location = new Point(146, 12);
            label4.Name = "label4";
            label4.Size = new Size(263, 37);
            label4.TabIndex = 5;
            label4.Text = "Last api refresh: _____";
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(431, 172);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Weather Checker 2000";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private System.Windows.Forms.Timer refreshTimer;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
