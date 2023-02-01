namespace iw4x_launcher.UI
{
    partial class ServerItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblServerTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblmapName = new System.Windows.Forms.Label();
            this.lblPlayers = new System.Windows.Forms.Label();
            this.lblGM = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblServerTitle
            // 
            this.lblServerTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblServerTitle.AutoEllipsis = true;
            this.lblServerTitle.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerTitle.ForeColor = System.Drawing.Color.CadetBlue;
            this.lblServerTitle.Location = new System.Drawing.Point(43, 4);
            this.lblServerTitle.Name = "lblServerTitle";
            this.lblServerTitle.Size = new System.Drawing.Size(414, 29);
            this.lblServerTitle.TabIndex = 0;
            this.lblServerTitle.Text = "serverTitle";
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.CadetBlue;
            this.label2.Location = new System.Drawing.Point(186, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Map:";
            // 
            // label3
            // 
            this.label3.AutoEllipsis = true;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.CadetBlue;
            this.label3.Location = new System.Drawing.Point(5, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Players:";
            // 
            // lblmapName
            // 
            this.lblmapName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblmapName.AutoEllipsis = true;
            this.lblmapName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmapName.ForeColor = System.Drawing.Color.Wheat;
            this.lblmapName.Location = new System.Drawing.Point(249, 45);
            this.lblmapName.Name = "lblmapName";
            this.lblmapName.Size = new System.Drawing.Size(208, 29);
            this.lblmapName.TabIndex = 3;
            this.lblmapName.Text = "mapName";
            // 
            // lblPlayers
            // 
            this.lblPlayers.AutoEllipsis = true;
            this.lblPlayers.AutoSize = true;
            this.lblPlayers.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayers.ForeColor = System.Drawing.Color.Wheat;
            this.lblPlayers.Location = new System.Drawing.Point(94, 45);
            this.lblPlayers.Name = "lblPlayers";
            this.lblPlayers.Size = new System.Drawing.Size(47, 29);
            this.lblPlayers.TabIndex = 4;
            this.lblPlayers.Text = "0/0";
            // 
            // lblGM
            // 
            this.lblGM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGM.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGM.ForeColor = System.Drawing.Color.CadetBlue;
            this.lblGM.Location = new System.Drawing.Point(304, 77);
            this.lblGM.Name = "lblGM";
            this.lblGM.Size = new System.Drawing.Size(153, 29);
            this.lblGM.TabIndex = 5;
            this.lblGM.Text = "S&&D/HC";
            this.lblGM.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblID
            // 
            this.lblID.AutoEllipsis = true;
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Calibri", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.Color.Wheat;
            this.lblID.Location = new System.Drawing.Point(3, 4);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(41, 26);
            this.lblID.TabIndex = 6;
            this.lblID.Text = "00)";
            // 
            // ServerItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(50)))), ((int)(((byte)(7)))));
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblGM);
            this.Controls.Add(this.lblPlayers);
            this.Controls.Add(this.lblmapName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblServerTitle);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 3, 30, 20);
            this.Name = "ServerItem";
            this.Size = new System.Drawing.Size(460, 106);
            this.Load += new System.EventHandler(this.ServerItem_Load);
            this.Resize += new System.EventHandler(this.ServerItem_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblServerTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblmapName;
        private System.Windows.Forms.Label lblPlayers;
        private System.Windows.Forms.Label lblGM;
        private System.Windows.Forms.Label lblID;
    }
}
