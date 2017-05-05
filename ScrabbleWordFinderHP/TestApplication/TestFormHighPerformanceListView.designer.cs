namespace TestApplication
{
    partial class TestFormHighPerformanceListView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.highPerformanceListView = new HarpyEagle.HighPerformanceControls.HighPerformanceListView();
            this.label11 = new System.Windows.Forms.Label();
            this.patternBox = new System.Windows.Forms.TextBox();
            this.tilesBox = new System.Windows.Forms.TextBox();
            this.searchButton1 = new System.Windows.Forms.Button();
            this.searchButton2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.wordsfound = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(346, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "High Performance";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.highPerformanceListView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(322, 384);
            this.panel1.TabIndex = 2;
            // 
            // highPerformanceListView
            // 
            this.highPerformanceListView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.highPerformanceListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.highPerformanceListView.ListViewProvider = null;
            this.highPerformanceListView.Location = new System.Drawing.Point(0, 0);
            this.highPerformanceListView.Name = "highPerformanceListView";
            this.highPerformanceListView.Size = new System.Drawing.Size(322, 384);
            this.highPerformanceListView.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(364, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 17);
            this.label11.TabIndex = 16;
            this.label11.Text = "Word Finder";
            // 
            // patternBox
            // 
            this.patternBox.Location = new System.Drawing.Point(344, 182);
            this.patternBox.Name = "patternBox";
            this.patternBox.Size = new System.Drawing.Size(140, 20);
            this.patternBox.TabIndex = 3;
            // 
            // tilesBox
            // 
            this.tilesBox.Location = new System.Drawing.Point(344, 88);
            this.tilesBox.Name = "tilesBox";
            this.tilesBox.Size = new System.Drawing.Size(140, 20);
            this.tilesBox.TabIndex = 1;
            // 
            // searchButton1
            // 
            this.searchButton1.Location = new System.Drawing.Point(344, 126);
            this.searchButton1.Name = "searchButton1";
            this.searchButton1.Size = new System.Drawing.Size(140, 23);
            this.searchButton1.TabIndex = 2;
            this.searchButton1.Text = "Find Words";
            this.searchButton1.UseVisualStyleBackColor = true;
            this.searchButton1.Click += new System.EventHandler(this.searchButton1_Click);
            // 
            // searchButton2
            // 
            this.searchButton2.Location = new System.Drawing.Point(344, 218);
            this.searchButton2.Name = "searchButton2";
            this.searchButton2.Size = new System.Drawing.Size(140, 23);
            this.searchButton2.TabIndex = 4;
            this.searchButton2.Text = "Find Matches";
            this.searchButton2.UseVisualStyleBackColor = true;
            this.searchButton2.Click += new System.EventHandler(this.searchButton2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(341, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Enter a pattern to match:";
            // 
            // wordsfound
            // 
            this.wordsfound.AutoSize = true;
            this.wordsfound.Location = new System.Drawing.Point(341, 362);
            this.wordsfound.Name = "wordsfound";
            this.wordsfound.Size = new System.Drawing.Size(77, 13);
            this.wordsfound.TabIndex = 21;
            this.wordsfound.Text = "Words Found: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(344, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Enter your tiles:";
            // 
            // TestFormHighPerformanceListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 384);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.wordsfound);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.searchButton2);
            this.Controls.Add(this.searchButton1);
            this.Controls.Add(this.tilesBox);
            this.Controls.Add(this.patternBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "TestFormHighPerformanceListView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scrabble Word Finder";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HarpyEagle.HighPerformanceControls.HighPerformanceListView highPerformanceListView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox patternBox;
        private System.Windows.Forms.TextBox tilesBox;
        private System.Windows.Forms.Button searchButton1;
        private System.Windows.Forms.Button searchButton2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label wordsfound;
        private System.Windows.Forms.Label label4;
    }
}