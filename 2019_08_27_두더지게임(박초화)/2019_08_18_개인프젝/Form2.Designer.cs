namespace _2019_08_18_개인프젝
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.btstart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btEnd = new System.Windows.Forms.Button();
            this.msHelp = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.게임설명ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msHelp.SuspendLayout();
            this.SuspendLayout();
            // 
            // btstart
            // 
            this.btstart.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btstart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btstart.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btstart.Location = new System.Drawing.Point(50, 441);
            this.btstart.Name = "btstart";
            this.btstart.Size = new System.Drawing.Size(223, 52);
            this.btstart.TabIndex = 0;
            this.btstart.Text = "GAME START";
            this.btstart.UseVisualStyleBackColor = false;
            this.btstart.Click += new System.EventHandler(this.Btstart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(181, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 50);
            this.label1.TabIndex = 1;
            this.label1.Text = "두더지를 잡아라";
            // 
            // btEnd
            // 
            this.btEnd.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btEnd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btEnd.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEnd.Location = new System.Drawing.Point(367, 443);
            this.btEnd.Name = "btEnd";
            this.btEnd.Size = new System.Drawing.Size(225, 50);
            this.btEnd.TabIndex = 0;
            this.btEnd.Text = "CLOSE";
            this.btEnd.UseVisualStyleBackColor = false;
            this.btEnd.Click += new System.EventHandler(this.BtEnd_Click);
            // 
            // msHelp
            // 
            this.msHelp.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.msHelp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.msHelp.Location = new System.Drawing.Point(0, 0);
            this.msHelp.Name = "msHelp";
            this.msHelp.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.msHelp.ShowItemToolTips = true;
            this.msHelp.Size = new System.Drawing.Size(644, 24);
            this.msHelp.TabIndex = 2;
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.게임설명ToolStripMenuItem});
            this.helpToolStripMenuItem.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // 게임설명ToolStripMenuItem
            // 
            this.게임설명ToolStripMenuItem.Name = "게임설명ToolStripMenuItem";
            this.게임설명ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.게임설명ToolStripMenuItem.Text = "게임설명";
            this.게임설명ToolStripMenuItem.Click += new System.EventHandler(this.게임설명ToolStripMenuItem_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(644, 507);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btEnd);
            this.Controls.Add(this.btstart);
            this.Controls.Add(this.msHelp);
            this.MainMenuStrip = this.msHelp;
            this.Name = "Form2";
            this.Text = "두더지를 잡아라";
            this.msHelp.ResumeLayout(false);
            this.msHelp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btstart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btEnd;
        private System.Windows.Forms.MenuStrip msHelp;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 게임설명ToolStripMenuItem;
    }
}