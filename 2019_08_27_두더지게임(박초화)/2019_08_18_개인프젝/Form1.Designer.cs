namespace _2019_08_18_개인프젝
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lbHit = new System.Windows.Forms.Label();
            this.lbMiss = new System.Windows.Forms.Label();
            this.btclose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbHit
            // 
            this.lbHit.AutoSize = true;
            this.lbHit.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHit.Image = ((System.Drawing.Image)(resources.GetObject("lbHit.Image")));
            this.lbHit.Location = new System.Drawing.Point(341, 17);
            this.lbHit.Name = "lbHit";
            this.lbHit.Size = new System.Drawing.Size(74, 30);
            this.lbHit.TabIndex = 1;
            this.lbHit.Text = "label1";
            // 
            // lbMiss
            // 
            this.lbMiss.AutoSize = true;
            this.lbMiss.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMiss.Image = ((System.Drawing.Image)(resources.GetObject("lbMiss.Image")));
            this.lbMiss.Location = new System.Drawing.Point(341, 47);
            this.lbMiss.Name = "lbMiss";
            this.lbMiss.Size = new System.Drawing.Size(74, 30);
            this.lbMiss.TabIndex = 1;
            this.lbMiss.Text = "label1";
            // 
            // btclose
            // 
            this.btclose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btclose.Font = new System.Drawing.Font("Indie Flower", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btclose.Location = new System.Drawing.Point(12, 12);
            this.btclose.Name = "btclose";
            this.btclose.Size = new System.Drawing.Size(81, 28);
            this.btclose.TabIndex = 2;
            this.btclose.Text = "End Game";
            this.btclose.UseVisualStyleBackColor = true;
            this.btclose.Click += new System.EventHandler(this.Btclose_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 549);
            this.Controls.Add(this.btclose);
            this.Controls.Add(this.lbMiss);
            this.Controls.Add(this.lbHit);
            this.Name = "Form1";
            this.Text = "두더지를 잡아라!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbHit;
        private System.Windows.Forms.Label lbMiss;
        private System.Windows.Forms.Button btclose;
    }
}

