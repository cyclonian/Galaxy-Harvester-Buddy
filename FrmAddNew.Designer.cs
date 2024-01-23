namespace Cyclonian.GhBuddy
{
    partial class FrmAddNew
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
            components = new System.ComponentModel.Container();
            btnOk = new Button();
            btnCancel = new Button();
            cbResourceClass = new ComboBox();
            lblUsername = new Label();
            lblPlanet = new Label();
            cbPlanet = new ComboBox();
            tbER = new TextBox();
            lblER = new Label();
            lblCR = new Label();
            tbCR = new TextBox();
            lblCD = new Label();
            tbCD = new TextBox();
            lblDR = new Label();
            tbDR = new TextBox();
            lblFL = new Label();
            tbFL = new TextBox();
            lblHR = new Label();
            tbHR = new TextBox();
            lblMA = new Label();
            tbMA = new TextBox();
            lblPE = new Label();
            tbPE = new TextBox();
            lblOQ = new Label();
            tbOQ = new TextBox();
            lblSR = new Label();
            tbSR = new TextBox();
            lblUT = new Label();
            tbUT = new TextBox();
            lblName = new Label();
            tbName = new TextBox();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(464, 224);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 28;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(383, 224);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 29;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // cbResourceClass
            // 
            cbResourceClass.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbResourceClass.FormattingEnabled = true;
            cbResourceClass.Location = new Point(117, 38);
            cbResourceClass.Name = "cbResourceClass";
            cbResourceClass.Size = new Size(231, 23);
            cbResourceClass.TabIndex = 3;
            cbResourceClass.SelectedIndexChanged += cbResourceClass_SelectedIndexChanged;
            // 
            // lblUsername
            // 
            lblUsername.Location = new Point(12, 38);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(99, 23);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Resource Class";
            lblUsername.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPlanet
            // 
            lblPlanet.Location = new Point(12, 9);
            lblPlanet.Name = "lblPlanet";
            lblPlanet.Size = new Size(99, 23);
            lblPlanet.TabIndex = 0;
            lblPlanet.Text = "Planet";
            lblPlanet.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cbPlanet
            // 
            cbPlanet.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbPlanet.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbPlanet.FormattingEnabled = true;
            cbPlanet.Location = new Point(117, 9);
            cbPlanet.Name = "cbPlanet";
            cbPlanet.Size = new Size(231, 23);
            cbPlanet.TabIndex = 1;
            cbPlanet.SelectedIndexChanged += cbPlanet_SelectedIndexChanged;
            // 
            // tbER
            // 
            tbER.Enabled = false;
            tbER.Location = new Point(12, 153);
            tbER.Name = "tbER";
            tbER.Size = new Size(42, 23);
            tbER.TabIndex = 7;
            tbER.Text = "0";
            tbER.TextAlign = HorizontalAlignment.Center;
            tbER.TextChanged += tbStat_TextChanged;
            tbER.Enter += tbStat_Enter;
            // 
            // lblER
            // 
            lblER.Location = new Point(12, 127);
            lblER.Name = "lblER";
            lblER.Size = new Size(42, 23);
            lblER.TabIndex = 6;
            lblER.Text = "ER";
            lblER.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCR
            // 
            lblCR.Location = new Point(60, 127);
            lblCR.Name = "lblCR";
            lblCR.Size = new Size(42, 23);
            lblCR.TabIndex = 8;
            lblCR.Text = "CR";
            lblCR.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tbCR
            // 
            tbCR.Enabled = false;
            tbCR.Location = new Point(60, 153);
            tbCR.Name = "tbCR";
            tbCR.Size = new Size(42, 23);
            tbCR.TabIndex = 9;
            tbCR.Text = "0";
            tbCR.TextAlign = HorizontalAlignment.Center;
            tbCR.TextChanged += tbStat_TextChanged;
            tbCR.Enter += tbStat_Enter;
            // 
            // lblCD
            // 
            lblCD.Location = new Point(108, 127);
            lblCD.Name = "lblCD";
            lblCD.Size = new Size(42, 23);
            lblCD.TabIndex = 10;
            lblCD.Text = "CD";
            lblCD.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tbCD
            // 
            tbCD.Enabled = false;
            tbCD.Location = new Point(108, 153);
            tbCD.Name = "tbCD";
            tbCD.Size = new Size(42, 23);
            tbCD.TabIndex = 11;
            tbCD.Text = "0";
            tbCD.TextAlign = HorizontalAlignment.Center;
            tbCD.TextChanged += tbStat_TextChanged;
            tbCD.Enter += tbStat_Enter;
            // 
            // lblDR
            // 
            lblDR.Location = new Point(156, 127);
            lblDR.Name = "lblDR";
            lblDR.Size = new Size(42, 23);
            lblDR.TabIndex = 12;
            lblDR.Text = "DR";
            lblDR.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tbDR
            // 
            tbDR.Enabled = false;
            tbDR.Location = new Point(156, 153);
            tbDR.Name = "tbDR";
            tbDR.Size = new Size(42, 23);
            tbDR.TabIndex = 13;
            tbDR.Text = "0";
            tbDR.TextAlign = HorizontalAlignment.Center;
            tbDR.TextChanged += tbStat_TextChanged;
            tbDR.Enter += tbStat_Enter;
            // 
            // lblFL
            // 
            lblFL.Location = new Point(204, 127);
            lblFL.Name = "lblFL";
            lblFL.Size = new Size(42, 23);
            lblFL.TabIndex = 14;
            lblFL.Text = "FL";
            lblFL.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tbFL
            // 
            tbFL.Enabled = false;
            tbFL.Location = new Point(204, 153);
            tbFL.Name = "tbFL";
            tbFL.Size = new Size(42, 23);
            tbFL.TabIndex = 15;
            tbFL.Text = "0";
            tbFL.TextAlign = HorizontalAlignment.Center;
            tbFL.TextChanged += tbStat_TextChanged;
            tbFL.Enter += tbStat_Enter;
            // 
            // lblHR
            // 
            lblHR.Location = new Point(252, 127);
            lblHR.Name = "lblHR";
            lblHR.Size = new Size(42, 23);
            lblHR.TabIndex = 16;
            lblHR.Text = "HR";
            lblHR.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tbHR
            // 
            tbHR.Enabled = false;
            tbHR.Location = new Point(252, 153);
            tbHR.Name = "tbHR";
            tbHR.Size = new Size(42, 23);
            tbHR.TabIndex = 17;
            tbHR.Text = "0";
            tbHR.TextAlign = HorizontalAlignment.Center;
            tbHR.TextChanged += tbStat_TextChanged;
            tbHR.Enter += tbStat_Enter;
            // 
            // lblMA
            // 
            lblMA.Location = new Point(300, 127);
            lblMA.Name = "lblMA";
            lblMA.Size = new Size(42, 23);
            lblMA.TabIndex = 18;
            lblMA.Text = "MA";
            lblMA.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tbMA
            // 
            tbMA.Enabled = false;
            tbMA.Location = new Point(300, 153);
            tbMA.Name = "tbMA";
            tbMA.Size = new Size(42, 23);
            tbMA.TabIndex = 19;
            tbMA.Text = "0";
            tbMA.TextAlign = HorizontalAlignment.Center;
            tbMA.TextChanged += tbStat_TextChanged;
            tbMA.Enter += tbStat_Enter;
            // 
            // lblPE
            // 
            lblPE.Location = new Point(348, 127);
            lblPE.Name = "lblPE";
            lblPE.Size = new Size(42, 23);
            lblPE.TabIndex = 20;
            lblPE.Text = "PE";
            lblPE.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tbPE
            // 
            tbPE.Enabled = false;
            tbPE.Location = new Point(348, 153);
            tbPE.Name = "tbPE";
            tbPE.Size = new Size(42, 23);
            tbPE.TabIndex = 21;
            tbPE.Text = "0";
            tbPE.TextAlign = HorizontalAlignment.Center;
            tbPE.TextChanged += tbStat_TextChanged;
            tbPE.Enter += tbStat_Enter;
            // 
            // lblOQ
            // 
            lblOQ.Location = new Point(396, 127);
            lblOQ.Name = "lblOQ";
            lblOQ.Size = new Size(42, 23);
            lblOQ.TabIndex = 22;
            lblOQ.Text = "OQ";
            lblOQ.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tbOQ
            // 
            tbOQ.Enabled = false;
            tbOQ.Location = new Point(396, 153);
            tbOQ.Name = "tbOQ";
            tbOQ.Size = new Size(42, 23);
            tbOQ.TabIndex = 23;
            tbOQ.Text = "0";
            tbOQ.TextAlign = HorizontalAlignment.Center;
            tbOQ.TextChanged += tbStat_TextChanged;
            tbOQ.Enter += tbStat_Enter;
            // 
            // lblSR
            // 
            lblSR.Location = new Point(444, 127);
            lblSR.Name = "lblSR";
            lblSR.Size = new Size(42, 23);
            lblSR.TabIndex = 24;
            lblSR.Text = "SR";
            lblSR.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tbSR
            // 
            tbSR.Enabled = false;
            tbSR.Location = new Point(444, 153);
            tbSR.Name = "tbSR";
            tbSR.Size = new Size(42, 23);
            tbSR.TabIndex = 25;
            tbSR.Text = "0";
            tbSR.TextAlign = HorizontalAlignment.Center;
            tbSR.TextChanged += tbStat_TextChanged;
            tbSR.Enter += tbStat_Enter;
            // 
            // lblUT
            // 
            lblUT.Location = new Point(492, 127);
            lblUT.Name = "lblUT";
            lblUT.Size = new Size(42, 23);
            lblUT.TabIndex = 26;
            lblUT.Text = "UT";
            lblUT.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tbUT
            // 
            tbUT.Enabled = false;
            tbUT.Location = new Point(492, 153);
            tbUT.Name = "tbUT";
            tbUT.Size = new Size(42, 23);
            tbUT.TabIndex = 27;
            tbUT.Text = "0";
            tbUT.TextAlign = HorizontalAlignment.Center;
            tbUT.TextChanged += tbStat_TextChanged;
            tbUT.Enter += tbStat_Enter;
            // 
            // lblName
            // 
            lblName.Location = new Point(12, 67);
            lblName.Name = "lblName";
            lblName.Size = new Size(99, 23);
            lblName.TabIndex = 4;
            lblName.Text = "Name";
            lblName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbName
            // 
            tbName.Location = new Point(117, 67);
            tbName.Name = "tbName";
            tbName.Size = new Size(231, 23);
            tbName.TabIndex = 5;
            tbName.TextChanged += tbName_TextChanged;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // FrmAddNew
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(551, 259);
            Controls.Add(tbName);
            Controls.Add(lblName);
            Controls.Add(lblUT);
            Controls.Add(tbUT);
            Controls.Add(lblSR);
            Controls.Add(tbSR);
            Controls.Add(lblOQ);
            Controls.Add(tbOQ);
            Controls.Add(lblPE);
            Controls.Add(tbPE);
            Controls.Add(lblMA);
            Controls.Add(tbMA);
            Controls.Add(lblHR);
            Controls.Add(tbHR);
            Controls.Add(lblFL);
            Controls.Add(tbFL);
            Controls.Add(lblDR);
            Controls.Add(tbDR);
            Controls.Add(lblCD);
            Controls.Add(tbCD);
            Controls.Add(lblCR);
            Controls.Add(tbCR);
            Controls.Add(lblER);
            Controls.Add(tbER);
            Controls.Add(lblPlanet);
            Controls.Add(cbPlanet);
            Controls.Add(lblUsername);
            Controls.Add(cbResourceClass);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAddNew";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add New Resource";
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOk;
        private Button btnCancel;
        private ComboBox cbResourceClass;
        private Label lblUsername;
        private Label lblPlanet;
        private ComboBox cbPlanet;
        private TextBox tbER;
        private Label lblER;
        private Label lblCR;
        private TextBox tbCR;
        private Label lblCD;
        private TextBox tbCD;
        private Label lblDR;
        private TextBox tbDR;
        private Label lblFL;
        private TextBox tbFL;
        private Label lblHR;
        private TextBox tbHR;
        private Label lblMA;
        private TextBox tbMA;
        private Label lblPE;
        private TextBox tbPE;
        private Label lblOQ;
        private TextBox tbOQ;
        private Label lblSR;
        private TextBox tbSR;
        private Label lblUT;
        private TextBox tbUT;
        private Label lblName;
        private TextBox tbName;
        private ErrorProvider errorProvider;
    }
}