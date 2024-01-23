namespace Cyclonian.GhBuddy
{
    partial class FrmMain
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
            btnMailSaveLocation = new Button();
            lblMailSaveLocation = new Label();
            tbMailSaveLocation = new TextBox();
            ofd = new OpenFileDialog();
            fbd = new FolderBrowserDialog();
            checkMailSaveLocationSubfolders = new CheckBox();
            btnReadMailSaveFiles = new Button();
            rtb = new RichTextBox();
            tbUsername = new TextBox();
            lblUsername = new Label();
            tbPassword = new TextBox();
            lblPassword = new Label();
            btnLogin = new Button();
            btnPost = new Button();
            lblConnection = new Label();
            dgv = new DataGridView();
            chGalaxy = new DataGridViewTextBoxColumn();
            chPlanet = new DataGridViewTextBoxColumn();
            chName = new DataGridViewTextBoxColumn();
            chClass = new DataGridViewTextBoxColumn();
            chER = new DataGridViewTextBoxColumn();
            chCR = new DataGridViewTextBoxColumn();
            chCD = new DataGridViewTextBoxColumn();
            chDR = new DataGridViewTextBoxColumn();
            chFL = new DataGridViewTextBoxColumn();
            chHR = new DataGridViewTextBoxColumn();
            chMA = new DataGridViewTextBoxColumn();
            chPE = new DataGridViewTextBoxColumn();
            chOQ = new DataGridViewTextBoxColumn();
            chSR = new DataGridViewTextBoxColumn();
            chUT = new DataGridViewTextBoxColumn();
            chExistsOnGh = new DataGridViewTextBoxColumn();
            btnClearData = new Button();
            btnAddNew = new Button();
            btnRemoveSelected = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // btnMailSaveLocation
            // 
            btnMailSaveLocation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMailSaveLocation.Location = new Point(1319, 71);
            btnMailSaveLocation.Name = "btnMailSaveLocation";
            btnMailSaveLocation.Size = new Size(75, 23);
            btnMailSaveLocation.TabIndex = 8;
            btnMailSaveLocation.Text = "Browse...";
            btnMailSaveLocation.UseVisualStyleBackColor = true;
            btnMailSaveLocation.Click += btnMailSaveLocation_Click;
            // 
            // lblMailSaveLocation
            // 
            lblMailSaveLocation.Location = new Point(12, 71);
            lblMailSaveLocation.Name = "lblMailSaveLocation";
            lblMailSaveLocation.Size = new Size(99, 23);
            lblMailSaveLocation.TabIndex = 6;
            lblMailSaveLocation.Text = "Mailsave location";
            lblMailSaveLocation.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbMailSaveLocation
            // 
            tbMailSaveLocation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbMailSaveLocation.Location = new Point(117, 71);
            tbMailSaveLocation.Name = "tbMailSaveLocation";
            tbMailSaveLocation.Size = new Size(1196, 23);
            tbMailSaveLocation.TabIndex = 7;
            tbMailSaveLocation.Leave += tbMailSaveLocation_Leave;
            // 
            // checkMailSaveLocationSubfolders
            // 
            checkMailSaveLocationSubfolders.AutoSize = true;
            checkMailSaveLocationSubfolders.Checked = true;
            checkMailSaveLocationSubfolders.CheckState = CheckState.Checked;
            checkMailSaveLocationSubfolders.Location = new Point(117, 100);
            checkMailSaveLocationSubfolders.Name = "checkMailSaveLocationSubfolders";
            checkMailSaveLocationSubfolders.Size = new Size(149, 19);
            checkMailSaveLocationSubfolders.TabIndex = 9;
            checkMailSaveLocationSubfolders.Text = "Look in subfolders too?";
            checkMailSaveLocationSubfolders.UseVisualStyleBackColor = true;
            checkMailSaveLocationSubfolders.CheckedChanged += checkMailSaveLocationSubfolders_CheckedChanged;
            checkMailSaveLocationSubfolders.Leave += checkMailSaveLocationSubfolders_Leave;
            // 
            // btnReadMailSaveFiles
            // 
            btnReadMailSaveFiles.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReadMailSaveFiles.Location = new Point(899, 310);
            btnReadMailSaveFiles.Name = "btnReadMailSaveFiles";
            btnReadMailSaveFiles.Size = new Size(118, 40);
            btnReadMailSaveFiles.TabIndex = 10;
            btnReadMailSaveFiles.Text = "Read Mailsave Files";
            btnReadMailSaveFiles.UseVisualStyleBackColor = true;
            btnReadMailSaveFiles.Click += btnReadMailSaveFiles_Click;
            // 
            // rtb
            // 
            rtb.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            rtb.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point);
            rtb.Location = new Point(117, 125);
            rtb.Name = "rtb";
            rtb.ReadOnly = true;
            rtb.Size = new Size(1277, 179);
            rtb.TabIndex = 13;
            rtb.Text = "";
            // 
            // tbUsername
            // 
            tbUsername.Location = new Point(117, 9);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(149, 23);
            tbUsername.TabIndex = 1;
            tbUsername.Leave += tbUsername_Leave;
            // 
            // lblUsername
            // 
            lblUsername.Location = new Point(12, 9);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(99, 23);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username";
            lblUsername.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(117, 38);
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '●';
            tbPassword.Size = new Size(149, 23);
            tbPassword.TabIndex = 3;
            // 
            // lblPassword
            // 
            lblPassword.Location = new Point(12, 38);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(99, 23);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password";
            lblPassword.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(272, 8);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(91, 53);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnPost
            // 
            btnPost.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPost.Enabled = false;
            btnPost.Location = new Point(1279, 630);
            btnPost.Name = "btnPost";
            btnPost.Size = new Size(115, 48);
            btnPost.TabIndex = 12;
            btnPost.Text = "Send Data";
            btnPost.UseVisualStyleBackColor = true;
            btnPost.Click += btnPost_Click;
            // 
            // lblConnection
            // 
            lblConnection.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblConnection.ForeColor = Color.Green;
            lblConnection.Location = new Point(369, 38);
            lblConnection.Name = "lblConnection";
            lblConnection.Size = new Size(99, 23);
            lblConnection.TabIndex = 5;
            lblConnection.Text = "Connected";
            lblConnection.TextAlign = ContentAlignment.MiddleLeft;
            lblConnection.Visible = false;
            // 
            // dgv
            // 
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Columns.AddRange(new DataGridViewColumn[] { chGalaxy, chPlanet, chName, chClass, chER, chCR, chCD, chDR, chFL, chHR, chMA, chPE, chOQ, chSR, chUT, chExistsOnGh });
            dgv.Location = new Point(117, 356);
            dgv.MultiSelect = false;
            dgv.Name = "dgv";
            dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv.RowTemplate.Height = 25;
            dgv.Size = new Size(1277, 268);
            dgv.TabIndex = 14;
            dgv.CellLeave += dgv_CellLeave;
            dgv.RowsAdded += dgv_RowsAdded;
            dgv.SelectionChanged += dgv_SelectionChanged;
            // 
            // chGalaxy
            // 
            chGalaxy.HeaderText = "Galaxy";
            chGalaxy.MinimumWidth = 100;
            chGalaxy.Name = "chGalaxy";
            chGalaxy.Resizable = DataGridViewTriState.False;
            // 
            // chPlanet
            // 
            chPlanet.HeaderText = "Planet";
            chPlanet.MinimumWidth = 120;
            chPlanet.Name = "chPlanet";
            chPlanet.Resizable = DataGridViewTriState.False;
            chPlanet.Width = 120;
            // 
            // chName
            // 
            chName.HeaderText = "Name";
            chName.MinimumWidth = 140;
            chName.Name = "chName";
            chName.Resizable = DataGridViewTriState.False;
            chName.Width = 140;
            // 
            // chClass
            // 
            chClass.HeaderText = "Class";
            chClass.MinimumWidth = 200;
            chClass.Name = "chClass";
            chClass.Resizable = DataGridViewTriState.False;
            chClass.Width = 200;
            // 
            // chER
            // 
            chER.HeaderText = "ER";
            chER.MinimumWidth = 40;
            chER.Name = "chER";
            chER.Resizable = DataGridViewTriState.False;
            chER.Width = 40;
            // 
            // chCR
            // 
            chCR.HeaderText = "CR";
            chCR.MinimumWidth = 40;
            chCR.Name = "chCR";
            chCR.Resizable = DataGridViewTriState.False;
            chCR.Width = 40;
            // 
            // chCD
            // 
            chCD.HeaderText = "CD";
            chCD.MinimumWidth = 40;
            chCD.Name = "chCD";
            chCD.Resizable = DataGridViewTriState.False;
            chCD.Width = 40;
            // 
            // chDR
            // 
            chDR.HeaderText = "DR";
            chDR.MinimumWidth = 40;
            chDR.Name = "chDR";
            chDR.Resizable = DataGridViewTriState.False;
            chDR.Width = 40;
            // 
            // chFL
            // 
            chFL.HeaderText = "FL";
            chFL.MinimumWidth = 40;
            chFL.Name = "chFL";
            chFL.Resizable = DataGridViewTriState.False;
            chFL.Width = 40;
            // 
            // chHR
            // 
            chHR.HeaderText = "HR";
            chHR.MinimumWidth = 40;
            chHR.Name = "chHR";
            chHR.Resizable = DataGridViewTriState.False;
            chHR.Width = 40;
            // 
            // chMA
            // 
            chMA.HeaderText = "MA";
            chMA.MinimumWidth = 40;
            chMA.Name = "chMA";
            chMA.Resizable = DataGridViewTriState.False;
            chMA.Width = 40;
            // 
            // chPE
            // 
            chPE.HeaderText = "PE";
            chPE.MinimumWidth = 40;
            chPE.Name = "chPE";
            chPE.Resizable = DataGridViewTriState.False;
            chPE.Width = 40;
            // 
            // chOQ
            // 
            chOQ.HeaderText = "OQ";
            chOQ.MinimumWidth = 40;
            chOQ.Name = "chOQ";
            chOQ.Resizable = DataGridViewTriState.False;
            chOQ.Width = 40;
            // 
            // chSR
            // 
            chSR.HeaderText = "SR";
            chSR.MinimumWidth = 40;
            chSR.Name = "chSR";
            chSR.Resizable = DataGridViewTriState.False;
            chSR.Width = 40;
            // 
            // chUT
            // 
            chUT.HeaderText = "UT";
            chUT.MinimumWidth = 40;
            chUT.Name = "chUT";
            chUT.Resizable = DataGridViewTriState.False;
            chUT.Width = 40;
            // 
            // chExistsOnGh
            // 
            chExistsOnGh.HeaderText = "On GH?";
            chExistsOnGh.MinimumWidth = 80;
            chExistsOnGh.Name = "chExistsOnGh";
            chExistsOnGh.Resizable = DataGridViewTriState.False;
            chExistsOnGh.Width = 80;
            // 
            // btnClearData
            // 
            btnClearData.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClearData.Location = new Point(1023, 310);
            btnClearData.Name = "btnClearData";
            btnClearData.Size = new Size(115, 40);
            btnClearData.TabIndex = 11;
            btnClearData.Text = "Clear Current Data";
            btnClearData.UseVisualStyleBackColor = true;
            btnClearData.Click += btnClearData_Click;
            // 
            // btnAddNew
            // 
            btnAddNew.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddNew.Location = new Point(1276, 310);
            btnAddNew.Name = "btnAddNew";
            btnAddNew.Size = new Size(118, 40);
            btnAddNew.TabIndex = 15;
            btnAddNew.Text = "Add New Resource";
            btnAddNew.UseVisualStyleBackColor = true;
            btnAddNew.Click += btnAddNew_Click;
            // 
            // btnRemoveSelected
            // 
            btnRemoveSelected.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRemoveSelected.Location = new Point(1144, 310);
            btnRemoveSelected.Name = "btnRemoveSelected";
            btnRemoveSelected.Size = new Size(126, 40);
            btnRemoveSelected.TabIndex = 16;
            btnRemoveSelected.Text = "Remove Local Entry";
            btnRemoveSelected.UseVisualStyleBackColor = true;
            btnRemoveSelected.Click += btnRemoveSelected_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1406, 690);
            Controls.Add(btnRemoveSelected);
            Controls.Add(btnAddNew);
            Controls.Add(btnClearData);
            Controls.Add(dgv);
            Controls.Add(lblConnection);
            Controls.Add(btnPost);
            Controls.Add(btnLogin);
            Controls.Add(tbPassword);
            Controls.Add(lblPassword);
            Controls.Add(tbUsername);
            Controls.Add(lblUsername);
            Controls.Add(rtb);
            Controls.Add(btnReadMailSaveFiles);
            Controls.Add(checkMailSaveLocationSubfolders);
            Controls.Add(tbMailSaveLocation);
            Controls.Add(lblMailSaveLocation);
            Controls.Add(btnMailSaveLocation);
            DoubleBuffered = true;
            Name = "FrmMain";
            Text = "Galaxy Harvester Buddy";
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnMailSaveLocation;
        private Label lblMailSaveLocation;
        private TextBox tbMailSaveLocation;
        private OpenFileDialog ofd;
        private FolderBrowserDialog fbd;
        private CheckBox checkMailSaveLocationSubfolders;
        private Button btnReadMailSaveFiles;
        private RichTextBox rtb;
        private TextBox tbUsername;
        private Label lblUsername;
        private TextBox tbPassword;
        private Label lblPassword;
        private Button btnLogin;
        private Button btnPost;
        private Label lblConnection;
        private DataGridView dgv;
        private DataGridViewTextBoxColumn chGalaxy;
        private DataGridViewTextBoxColumn chPlanet;
        private DataGridViewTextBoxColumn chName;
        private DataGridViewTextBoxColumn chClass;
        private DataGridViewTextBoxColumn chER;
        private DataGridViewTextBoxColumn chCR;
        private DataGridViewTextBoxColumn chCD;
        private DataGridViewTextBoxColumn chDR;
        private DataGridViewTextBoxColumn chFL;
        private DataGridViewTextBoxColumn chHR;
        private DataGridViewTextBoxColumn chMA;
        private DataGridViewTextBoxColumn chPE;
        private DataGridViewTextBoxColumn chOQ;
        private DataGridViewTextBoxColumn chSR;
        private DataGridViewTextBoxColumn chUT;
        private DataGridViewTextBoxColumn chExistsOnGh;
        private Button btnClearData;
        private Button btnAddNew;
        private Button btnRemoveSelected;
    }
}