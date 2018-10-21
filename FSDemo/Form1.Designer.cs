namespace FSDemo
{
    partial class Form1
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
            this.lvAgents = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.lvTasks = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvAgents
            // 
            this.lvAgents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader6});
            this.lvAgents.FullRowSelect = true;
            this.lvAgents.HideSelection = false;
            this.lvAgents.Location = new System.Drawing.Point(24, 23);
            this.lvAgents.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lvAgents.Name = "lvAgents";
            this.lvAgents.Size = new System.Drawing.Size(1214, 342);
            this.lvAgents.TabIndex = 0;
            this.lvAgents.UseCompatibleStateImageBehavior = false;
            this.lvAgents.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 259;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "State";
            this.columnHeader2.Width = 123;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Task";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1254, 23);
            this.button1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 44);
            this.button1.TabIndex = 2;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1254, 79);
            this.button2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 44);
            this.button2.TabIndex = 3;
            this.button2.Text = "Available";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1254, 135);
            this.button3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 44);
            this.button3.TabIndex = 4;
            this.button3.Text = "NotAvalable";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1254, 190);
            this.button4.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(150, 44);
            this.button4.TabIndex = 5;
            this.button4.Text = "Complete";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1254, 246);
            this.button5.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(150, 44);
            this.button5.TabIndex = 6;
            this.button5.Text = "Logout";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // lvTasks
            // 
            this.lvTasks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvTasks.FullRowSelect = true;
            this.lvTasks.HideSelection = false;
            this.lvTasks.Location = new System.Drawing.Point(24, 425);
            this.lvTasks.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lvTasks.Name = "lvTasks";
            this.lvTasks.Size = new System.Drawing.Size(1214, 342);
            this.lvTasks.TabIndex = 7;
            this.lvTasks.UseCompatibleStateImageBehavior = false;
            this.lvTasks.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ID";
            this.columnHeader3.Width = 259;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "State";
            this.columnHeader4.Width = 123;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Agent";
            this.columnHeader5.Width = 166;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1254, 425);
            this.button6.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(150, 44);
            this.button6.TabIndex = 8;
            this.button6.Text = "New Task";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(1254, 481);
            this.button7.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(150, 44);
            this.button7.TabIndex = 9;
            this.button7.Text = "Task Gone";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 865);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.lvTasks);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lvAgents);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvAgents;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ListView lvTasks;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}

