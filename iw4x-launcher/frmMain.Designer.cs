namespace iw4x_launcher
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.labelVersion = new System.Windows.Forms.Label();
            this.gameRunning = new System.Windows.Forms.Timer(this.components);
            this.header4 = new System.Windows.Forms.GroupBox();
            this.reload = new System.Windows.Forms.PictureBox();
            this.labelRefreshtime = new System.Windows.Forms.Label();
            this.cbSort = new System.Windows.Forms.CheckBox();
            this.cbComp = new System.Windows.Forms.CheckBox();
            this.headerVersion = new System.Windows.Forms.GroupBox();
            this.cbGameVersions = new System.Windows.Forms.CheckBox();
            this.labelLoading = new System.Windows.Forms.Label();
            this.headerOptions = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.set06xGUIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.set07xGUIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboLang = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbMenuFix = new System.Windows.Forms.CheckBox();
            this.ll2 = new System.Windows.Forms.LinkLabel();
            this.labelRawfiles = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ll1 = new System.Windows.Forms.LinkLabel();
            this.labelDLCFiles = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labelDownload = new System.Windows.Forms.Label();
            this.TextDebugger = new System.Windows.Forms.RichTextBox();
            this.lblDirectory = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cbGUID = new System.Windows.Forms.CheckBox();
            this.btnLaunch = new iw4x_launcher.UI.RButton();
            this.rButton1 = new iw4x_launcher.UI.RButton();
            this.btnDirectory = new iw4x_launcher.UI.RButton();
            this.listVersions = new iw4x_launcher.UI.RadioButtonList();
            this.rPanel2 = new iw4x_launcher.UI.RPanel();
            this.labelServers = new System.Windows.Forms.Label();
            this.rPanel1 = new iw4x_launcher.UI.RPanel();
            this.serverItemWide1 = new iw4x_launcher.UI.ServerItemWide();
            this.PanelServersList = new System.Windows.Forms.FlowLayoutPanel();
            this.header4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reload)).BeginInit();
            this.headerVersion.SuspendLayout();
            this.headerOptions.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.rPanel2.SuspendLayout();
            this.rPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelVersion
            // 
            this.labelVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelVersion.AutoEllipsis = true;
            this.labelVersion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelVersion.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersion.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelVersion.Location = new System.Drawing.Point(675, 516);
            this.labelVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(343, 28);
            this.labelVersion.TabIndex = 7;
            this.labelVersion.Text = "Currently running version: {0}\r\nSelected Server: {1}";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gameRunning
            // 
            this.gameRunning.Enabled = true;
            this.gameRunning.Interval = 1000;
            this.gameRunning.Tick += new System.EventHandler(this.gameRunning_Tick);
            // 
            // header4
            // 
            this.header4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.header4.Controls.Add(this.reload);
            this.header4.Controls.Add(this.labelRefreshtime);
            this.header4.Controls.Add(this.cbSort);
            this.header4.Controls.Add(this.cbComp);
            this.header4.Controls.Add(this.rPanel2);
            this.header4.Controls.Add(this.rPanel1);
            this.header4.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header4.ForeColor = System.Drawing.Color.Wheat;
            this.header4.Location = new System.Drawing.Point(8, 6);
            this.header4.Margin = new System.Windows.Forms.Padding(2);
            this.header4.Name = "header4";
            this.header4.Padding = new System.Windows.Forms.Padding(2);
            this.header4.Size = new System.Drawing.Size(1012, 239);
            this.header4.TabIndex = 19;
            this.header4.TabStop = false;
            this.header4.Text = "  Select a Server  ";
            // 
            // reload
            // 
            this.reload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reload.Image = ((System.Drawing.Image)(resources.GetObject("reload.Image")));
            this.reload.Location = new System.Drawing.Point(121, 32);
            this.reload.Name = "reload";
            this.reload.Size = new System.Drawing.Size(17, 18);
            this.reload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.reload.TabIndex = 26;
            this.reload.TabStop = false;
            this.reload.Click += new System.EventHandler(this.reload_Click);
            // 
            // labelRefreshtime
            // 
            this.labelRefreshtime.AutoSize = true;
            this.labelRefreshtime.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.labelRefreshtime.Location = new System.Drawing.Point(158, 31);
            this.labelRefreshtime.Name = "labelRefreshtime";
            this.labelRefreshtime.Size = new System.Drawing.Size(65, 19);
            this.labelRefreshtime.TabIndex = 23;
            this.labelRefreshtime.Text = "00:00:00";
            this.labelRefreshtime.Visible = false;
            // 
            // cbSort
            // 
            this.cbSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSort.AutoSize = true;
            this.cbSort.Checked = true;
            this.cbSort.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbSort.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSort.ForeColor = System.Drawing.Color.CadetBlue;
            this.cbSort.Location = new System.Drawing.Point(860, 34);
            this.cbSort.Margin = new System.Windows.Forms.Padding(2);
            this.cbSort.Name = "cbSort";
            this.cbSort.Size = new System.Drawing.Size(142, 20);
            this.cbSort.TabIndex = 22;
            this.cbSort.Text = "Sort by Player Count";
            this.cbSort.UseVisualStyleBackColor = true;
            this.cbSort.CheckedChanged += new System.EventHandler(this.cbSort_CheckedChanged);
            // 
            // cbComp
            // 
            this.cbComp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbComp.AutoSize = true;
            this.cbComp.Checked = true;
            this.cbComp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbComp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbComp.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbComp.ForeColor = System.Drawing.Color.CadetBlue;
            this.cbComp.Location = new System.Drawing.Point(800, 14);
            this.cbComp.Margin = new System.Windows.Forms.Padding(2);
            this.cbComp.Name = "cbComp";
            this.cbComp.Size = new System.Drawing.Size(202, 20);
            this.cbComp.TabIndex = 21;
            this.cbComp.Text = "Show only Compatible Servers";
            this.cbComp.UseVisualStyleBackColor = true;
            this.cbComp.CheckedChanged += new System.EventHandler(this.cbComp_CheckedChanged);
            // 
            // headerVersion
            // 
            this.headerVersion.Controls.Add(this.cbGameVersions);
            this.headerVersion.Controls.Add(this.labelLoading);
            this.headerVersion.Controls.Add(this.listVersions);
            this.headerVersion.Font = new System.Drawing.Font("Century Gothic", 10.125F);
            this.headerVersion.ForeColor = System.Drawing.Color.Wheat;
            this.headerVersion.Location = new System.Drawing.Point(8, 258);
            this.headerVersion.Margin = new System.Windows.Forms.Padding(2);
            this.headerVersion.Name = "headerVersion";
            this.headerVersion.Padding = new System.Windows.Forms.Padding(2);
            this.headerVersion.Size = new System.Drawing.Size(254, 287);
            this.headerVersion.TabIndex = 20;
            this.headerVersion.TabStop = false;
            this.headerVersion.Text = "  Select Game Version  ";
            // 
            // cbGameVersions
            // 
            this.cbGameVersions.AutoSize = true;
            this.cbGameVersions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbGameVersions.ForeColor = System.Drawing.Color.CadetBlue;
            this.cbGameVersions.Location = new System.Drawing.Point(9, 22);
            this.cbGameVersions.Margin = new System.Windows.Forms.Padding(2);
            this.cbGameVersions.Name = "cbGameVersions";
            this.cbGameVersions.Size = new System.Drawing.Size(206, 23);
            this.cbGameVersions.TabIndex = 11;
            this.cbGameVersions.Text = "Only Local Game Versions";
            this.cbGameVersions.UseVisualStyleBackColor = true;
            this.cbGameVersions.CheckedChanged += new System.EventHandler(this.cbGameVersions_CheckedChanged);
            // 
            // labelLoading
            // 
            this.labelLoading.AutoSize = true;
            this.labelLoading.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoading.ForeColor = System.Drawing.Color.Gold;
            this.labelLoading.Location = new System.Drawing.Point(92, 132);
            this.labelLoading.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLoading.Name = "labelLoading";
            this.labelLoading.Size = new System.Drawing.Size(70, 12);
            this.labelLoading.TabIndex = 1;
            this.labelLoading.Text = "⌛ Loading";
            // 
            // headerOptions
            // 
            this.headerOptions.Controls.Add(this.rButton1);
            this.headerOptions.Controls.Add(this.cbGUID);
            this.headerOptions.Controls.Add(this.linkLabel1);
            this.headerOptions.Controls.Add(this.btnDirectory);
            this.headerOptions.Controls.Add(this.comboLang);
            this.headerOptions.Controls.Add(this.label10);
            this.headerOptions.Controls.Add(this.cbMenuFix);
            this.headerOptions.Controls.Add(this.ll2);
            this.headerOptions.Controls.Add(this.labelRawfiles);
            this.headerOptions.Controls.Add(this.label8);
            this.headerOptions.Controls.Add(this.ll1);
            this.headerOptions.Controls.Add(this.labelDLCFiles);
            this.headerOptions.Font = new System.Drawing.Font("Century Gothic", 10.125F);
            this.headerOptions.ForeColor = System.Drawing.Color.Wheat;
            this.headerOptions.Location = new System.Drawing.Point(278, 258);
            this.headerOptions.Margin = new System.Windows.Forms.Padding(2);
            this.headerOptions.Name = "headerOptions";
            this.headerOptions.Padding = new System.Windows.Forms.Padding(2);
            this.headerOptions.Size = new System.Drawing.Size(254, 287);
            this.headerOptions.TabIndex = 21;
            this.headerOptions.TabStop = false;
            this.headerOptions.Text = "  Launcher Options  ";
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.Olive;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.ForeColor = System.Drawing.Color.CadetBlue;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.CadetBlue;
            this.linkLabel1.Location = new System.Drawing.Point(57, 24);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(85, 16);
            this.linkLabel1.TabIndex = 31;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "GUID Backup";
            this.linkLabel1.Visible = false;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.set06xGUIDToolStripMenuItem,
            this.set07xGUIDToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(148, 48);
            // 
            // set06xGUIDToolStripMenuItem
            // 
            this.set06xGUIDToolStripMenuItem.Name = "set06xGUIDToolStripMenuItem";
            this.set06xGUIDToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.set06xGUIDToolStripMenuItem.Text = "Set 0.6.x GUID";
            this.set06xGUIDToolStripMenuItem.Click += new System.EventHandler(this.set06xGUIDToolStripMenuItem_Click);
            // 
            // set07xGUIDToolStripMenuItem
            // 
            this.set07xGUIDToolStripMenuItem.Name = "set07xGUIDToolStripMenuItem";
            this.set07xGUIDToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.set07xGUIDToolStripMenuItem.Text = "Set 0.7.x GUID";
            this.set07xGUIDToolStripMenuItem.Click += new System.EventHandler(this.set07xGUIDToolStripMenuItem_Click);
            // 
            // comboLang
            // 
            this.comboLang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboLang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.comboLang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboLang.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboLang.ForeColor = System.Drawing.Color.Wheat;
            this.comboLang.FormattingEnabled = true;
            this.comboLang.Items.AddRange(new object[] {
            "English",
            "Russian"});
            this.comboLang.Location = new System.Drawing.Point(166, 12);
            this.comboLang.Margin = new System.Windows.Forms.Padding(2);
            this.comboLang.Name = "comboLang";
            this.comboLang.Size = new System.Drawing.Size(83, 25);
            this.comboLang.TabIndex = 10;
            this.comboLang.SelectedIndexChanged += new System.EventHandler(this.comboLang_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label10.Font = new System.Drawing.Font("Lucida Console", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Wheat;
            this.label10.Location = new System.Drawing.Point(14, 172);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 22);
            this.label10.TabIndex = 29;
            this.label10.Text = "⟳";
            this.label10.Visible = false;
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // cbMenuFix
            // 
            this.cbMenuFix.AutoSize = true;
            this.cbMenuFix.Checked = true;
            this.cbMenuFix.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMenuFix.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbMenuFix.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.cbMenuFix.ForeColor = System.Drawing.Color.CadetBlue;
            this.cbMenuFix.Location = new System.Drawing.Point(13, 211);
            this.cbMenuFix.Margin = new System.Windows.Forms.Padding(2);
            this.cbMenuFix.Name = "cbMenuFix";
            this.cbMenuFix.Size = new System.Drawing.Size(116, 21);
            this.cbMenuFix.TabIndex = 28;
            this.cbMenuFix.Text = "v0.7.5 Menu Fix";
            this.cbMenuFix.UseVisualStyleBackColor = true;
            this.cbMenuFix.CheckedChanged += new System.EventHandler(this.cbMenuFix_CheckedChanged);
            // 
            // ll2
            // 
            this.ll2.ActiveLinkColor = System.Drawing.Color.Olive;
            this.ll2.AutoSize = true;
            this.ll2.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.ll2.ForeColor = System.Drawing.Color.CadetBlue;
            this.ll2.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.ll2.LinkColor = System.Drawing.Color.CadetBlue;
            this.ll2.Location = new System.Drawing.Point(36, 176);
            this.ll2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ll2.Name = "ll2";
            this.ll2.Size = new System.Drawing.Size(147, 17);
            this.ll2.TabIndex = 26;
            this.ll2.TabStop = true;
            this.ll2.Text = "🡇 Download and Patch";
            this.ll2.Visible = false;
            this.ll2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ll2_LinkClicked);
            // 
            // labelRawfiles
            // 
            this.labelRawfiles.AutoSize = true;
            this.labelRawfiles.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRawfiles.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelRawfiles.Location = new System.Drawing.Point(10, 158);
            this.labelRawfiles.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRawfiles.Name = "labelRawfiles";
            this.labelRawfiles.Size = new System.Drawing.Size(156, 17);
            this.labelRawfiles.TabIndex = 25;
            this.labelRawfiles.Text = "✓ v0.0.9 Rawfiles Verified";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label8.Font = new System.Drawing.Font("Lucida Console", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Wheat;
            this.label8.Location = new System.Drawing.Point(14, 118);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 22);
            this.label8.TabIndex = 24;
            this.label8.Text = "⟳";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label8.Visible = false;
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // ll1
            // 
            this.ll1.ActiveLinkColor = System.Drawing.Color.Olive;
            this.ll1.AutoSize = true;
            this.ll1.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.ll1.ForeColor = System.Drawing.Color.CadetBlue;
            this.ll1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.ll1.LinkColor = System.Drawing.Color.CadetBlue;
            this.ll1.Location = new System.Drawing.Point(36, 118);
            this.ll1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ll1.Name = "ll1";
            this.ll1.Size = new System.Drawing.Size(147, 17);
            this.ll1.TabIndex = 23;
            this.ll1.TabStop = true;
            this.ll1.Text = "🡇 Download and Patch";
            this.ll1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ll1_LinkClicked);
            // 
            // labelDLCFiles
            // 
            this.labelDLCFiles.AutoSize = true;
            this.labelDLCFiles.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.labelDLCFiles.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelDLCFiles.Location = new System.Drawing.Point(10, 101);
            this.labelDLCFiles.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDLCFiles.Name = "labelDLCFiles";
            this.labelDLCFiles.Size = new System.Drawing.Size(132, 17);
            this.labelDLCFiles.TabIndex = 22;
            this.labelDLCFiles.Text = "✓ DLC 9 Files Verified";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.labelDownload);
            this.groupBox4.Controls.Add(this.TextDebugger);
            this.groupBox4.Font = new System.Drawing.Font("Century Gothic", 10.125F);
            this.groupBox4.ForeColor = System.Drawing.Color.Wheat;
            this.groupBox4.Location = new System.Drawing.Point(550, 258);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(468, 250);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "  Logger  ";
            // 
            // labelDownload
            // 
            this.labelDownload.AutoEllipsis = true;
            this.labelDownload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(42)))));
            this.labelDownload.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDownload.ForeColor = System.Drawing.Color.CadetBlue;
            this.labelDownload.Location = new System.Drawing.Point(8, 227);
            this.labelDownload.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDownload.Name = "labelDownload";
            this.labelDownload.Size = new System.Drawing.Size(452, 14);
            this.labelDownload.TabIndex = 22;
            this.labelDownload.Text = "downloadProgress";
            this.labelDownload.Visible = false;
            // 
            // TextDebugger
            // 
            this.TextDebugger.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextDebugger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(42)))));
            this.TextDebugger.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextDebugger.Font = new System.Drawing.Font("Lucida Console", 9F);
            this.TextDebugger.ForeColor = System.Drawing.Color.CadetBlue;
            this.TextDebugger.Location = new System.Drawing.Point(8, 28);
            this.TextDebugger.Margin = new System.Windows.Forms.Padding(2);
            this.TextDebugger.Name = "TextDebugger";
            this.TextDebugger.ReadOnly = true;
            this.TextDebugger.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.TextDebugger.Size = new System.Drawing.Size(453, 215);
            this.TextDebugger.TabIndex = 0;
            this.TextDebugger.Text = "";
            // 
            // lblDirectory
            // 
            this.lblDirectory.AutoEllipsis = true;
            this.lblDirectory.ForeColor = System.Drawing.Color.Wheat;
            this.lblDirectory.Location = new System.Drawing.Point(208, 1);
            this.lblDirectory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDirectory.Name = "lblDirectory";
            this.lblDirectory.Size = new System.Drawing.Size(609, 16);
            this.lblDirectory.TabIndex = 13;
            this.lblDirectory.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblDirectory.Click += new System.EventHandler(this.label5_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(857, 2);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mayion @COD Alliance";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(14, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "ver. 1.4.1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(42)))));
            this.panel1.Controls.Add(this.lblDirectory);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.panel1.Location = new System.Drawing.Point(0, 552);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1021, 20);
            this.panel1.TabIndex = 32;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 120000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cbGUID
            // 
            this.cbGUID.AutoSize = true;
            this.cbGUID.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbGUID.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGUID.Location = new System.Drawing.Point(116, 49);
            this.cbGUID.Name = "cbGUID";
            this.cbGUID.Size = new System.Drawing.Size(98, 20);
            this.cbGUID.TabIndex = 32;
            this.cbGUID.Text = "Switch GUIDs";
            this.cbGUID.UseVisualStyleBackColor = true;
            // 
            // btnLaunch
            // 
            this.btnLaunch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(42)))));
            this.btnLaunch.CornerRadius = 3;
            this.btnLaunch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLaunch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLaunch.FlatAppearance.BorderSize = 0;
            this.btnLaunch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLaunch.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaunch.ForeColor = System.Drawing.Color.Wheat;
            this.btnLaunch.Location = new System.Drawing.Point(550, 517);
            this.btnLaunch.Margin = new System.Windows.Forms.Padding(2);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(122, 28);
            this.btnLaunch.TabIndex = 31;
            this.btnLaunch.TabStop = false;
            this.btnLaunch.Text = "Launch Game";
            this.btnLaunch.UseVisualStyleBackColor = false;
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // rButton1
            // 
            this.rButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(42)))));
            this.rButton1.CornerRadius = 3;
            this.rButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rButton1.FlatAppearance.BorderSize = 0;
            this.rButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rButton1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rButton1.ForeColor = System.Drawing.Color.Wheat;
            this.rButton1.Location = new System.Drawing.Point(12, 45);
            this.rButton1.Margin = new System.Windows.Forms.Padding(2);
            this.rButton1.Name = "rButton1";
            this.rButton1.Size = new System.Drawing.Size(94, 26);
            this.rButton1.TabIndex = 33;
            this.rButton1.TabStop = false;
            this.rButton1.Text = "GUID Backup";
            this.rButton1.UseVisualStyleBackColor = false;
            this.rButton1.Click += new System.EventHandler(this.rButton1_Click_1);
            // 
            // btnDirectory
            // 
            this.btnDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(42)))));
            this.btnDirectory.CornerRadius = 3;
            this.btnDirectory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDirectory.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDirectory.FlatAppearance.BorderSize = 0;
            this.btnDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDirectory.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDirectory.ForeColor = System.Drawing.Color.Wheat;
            this.btnDirectory.Location = new System.Drawing.Point(42, 243);
            this.btnDirectory.Margin = new System.Windows.Forms.Padding(2);
            this.btnDirectory.Name = "btnDirectory";
            this.btnDirectory.Size = new System.Drawing.Size(172, 25);
            this.btnDirectory.TabIndex = 30;
            this.btnDirectory.TabStop = false;
            this.btnDirectory.Text = "Select Game Directory";
            this.btnDirectory.UseVisualStyleBackColor = false;
            this.btnDirectory.Click += new System.EventHandler(this.btnDirectory_Click);
            // 
            // listVersions
            // 
            this.listVersions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.listVersions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listVersions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listVersions.ForeColor = System.Drawing.Color.Wheat;
            this.listVersions.FormattingEnabled = true;
            this.listVersions.Location = new System.Drawing.Point(9, 48);
            this.listVersions.Margin = new System.Windows.Forms.Padding(2);
            this.listVersions.Name = "listVersions";
            this.listVersions.Size = new System.Drawing.Size(236, 220);
            this.listVersions.TabIndex = 0;
            this.listVersions.Visible = false;
            this.listVersions.SelectedIndexChanged += new System.EventHandler(this.listVersions_SelectedIndexChanged);
            // 
            // rPanel2
            // 
            this.rPanel2.BorderColor = System.Drawing.Color.DimGray;
            this.rPanel2.BorderSize = 1;
            this.rPanel2.Controls.Add(this.labelServers);
            this.rPanel2.CornerRadius = 3;
            this.rPanel2.HoverColor = System.Drawing.Color.Empty;
            this.rPanel2.Location = new System.Drawing.Point(9, 29);
            this.rPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.rPanel2.Name = "rPanel2";
            this.rPanel2.ShowHeader = false;
            this.rPanel2.Size = new System.Drawing.Size(102, 27);
            this.rPanel2.TabIndex = 18;
            // 
            // labelServers
            // 
            this.labelServers.AutoEllipsis = true;
            this.labelServers.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelServers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelServers.Location = new System.Drawing.Point(3, 4);
            this.labelServers.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelServers.Name = "labelServers";
            this.labelServers.Size = new System.Drawing.Size(96, 16);
            this.labelServers.TabIndex = 19;
            this.labelServers.Text = "000 Servers";
            this.labelServers.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // rPanel1
            // 
            this.rPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rPanel1.BorderColor = System.Drawing.Color.DimGray;
            this.rPanel1.BorderSize = 1;
            this.rPanel1.Controls.Add(this.serverItemWide1);
            this.rPanel1.Controls.Add(this.PanelServersList);
            this.rPanel1.CornerRadius = 3;
            this.rPanel1.HoverColor = System.Drawing.Color.Empty;
            this.rPanel1.Location = new System.Drawing.Point(9, 59);
            this.rPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.rPanel1.Name = "rPanel1";
            this.rPanel1.ShowHeader = false;
            this.rPanel1.Size = new System.Drawing.Size(993, 172);
            this.rPanel1.TabIndex = 17;
            // 
            // serverItemWide1
            // 
            this.serverItemWide1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.serverItemWide1.ForeColor = System.Drawing.Color.Wheat;
            this.serverItemWide1.IsSelected = false;
            this.serverItemWide1.Location = new System.Drawing.Point(5, 3);
            this.serverItemWide1.Margin = new System.Windows.Forms.Padding(6);
            this.serverItemWide1.MinimumSize = new System.Drawing.Size(0, 26);
            this.serverItemWide1.Name = "serverItemWide1";
            this.serverItemWide1.Size = new System.Drawing.Size(973, 26);
            this.serverItemWide1.TabIndex = 2;
            // 
            // PanelServersList
            // 
            this.PanelServersList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelServersList.Location = new System.Drawing.Point(2, 28);
            this.PanelServersList.Margin = new System.Windows.Forms.Padding(2);
            this.PanelServersList.Name = "PanelServersList";
            this.PanelServersList.Size = new System.Drawing.Size(977, 134);
            this.PanelServersList.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.ClientSize = new System.Drawing.Size(1021, 572);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnLaunch);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.headerOptions);
            this.Controls.Add(this.headerVersion);
            this.Controls.Add(this.header4);
            this.Controls.Add(this.labelVersion);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Lucida Console", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(1037, 611);
            this.MinimumSize = new System.Drawing.Size(1037, 611);
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IW4X Launcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.header4.ResumeLayout(false);
            this.header4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reload)).EndInit();
            this.headerVersion.ResumeLayout(false);
            this.headerVersion.PerformLayout();
            this.headerOptions.ResumeLayout(false);
            this.headerOptions.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.rPanel2.ResumeLayout(false);
            this.rPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private UI.RadioButtonList listVersions;
        private System.Windows.Forms.ComboBox comboLang;
        private System.Windows.Forms.Label labelLoading;
        private System.Windows.Forms.CheckBox cbGameVersions;
        private System.Windows.Forms.Timer gameRunning;
        public System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label lblDirectory;
        private UI.RPanel rPanel1;
        private UI.RPanel rPanel2;
        private System.Windows.Forms.Label labelServers;
        private System.Windows.Forms.FlowLayoutPanel PanelServersList;
        private System.Windows.Forms.GroupBox header4;
        private System.Windows.Forms.CheckBox cbComp;
        private System.Windows.Forms.GroupBox headerVersion;
        private System.Windows.Forms.GroupBox headerOptions;
        private UI.RButton btnDirectory;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox cbMenuFix;
        private System.Windows.Forms.LinkLabel ll2;
        private System.Windows.Forms.Label labelRawfiles;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.LinkLabel ll1;
        private System.Windows.Forms.Label labelDLCFiles;
        private System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.RichTextBox TextDebugger;
        public UI.RButton btnLaunch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelDownload;
        private UI.ServerItemWide serverItemWide1;
        private System.Windows.Forms.CheckBox cbSort;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem set06xGUIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem set07xGUIDToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelRefreshtime;
        private System.Windows.Forms.PictureBox reload;
        public UI.RButton rButton1;
        private System.Windows.Forms.CheckBox cbGUID;
    }
}

