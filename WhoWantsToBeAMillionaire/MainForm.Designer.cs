namespace WhoWantsToBeAMillionaire
{
    partial class MainForm
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
            this.btnAnswerA = new System.Windows.Forms.Button();
            this.btnAnswerB = new System.Windows.Forms.Button();
            this.btnAnswerC = new System.Windows.Forms.Button();
            this.btnAnswerD = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.lstLevel = new System.Windows.Forms.ListBox();
            this.btn50 = new System.Windows.Forms.Button();
            this.btnFriendsHelp = new System.Windows.Forms.Button();
            this.btnChangeQuestion = new System.Windows.Forms.Button();
            this.btnHallHelp = new System.Windows.Forms.Button();
            this.btnRightToFail = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAnswerA
            // 
            this.btnAnswerA.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAnswerA.Location = new System.Drawing.Point(28, 410);
            this.btnAnswerA.Name = "btnAnswerA";
            this.btnAnswerA.Size = new System.Drawing.Size(221, 59);
            this.btnAnswerA.TabIndex = 0;
            this.btnAnswerA.Tag = "1";
            this.btnAnswerA.Text = "A";
            this.btnAnswerA.UseVisualStyleBackColor = true;
            this.btnAnswerA.Click += new System.EventHandler(this.btnAnswerA_Click);
            // 
            // btnAnswerB
            // 
            this.btnAnswerB.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAnswerB.Location = new System.Drawing.Point(28, 482);
            this.btnAnswerB.Name = "btnAnswerB";
            this.btnAnswerB.Size = new System.Drawing.Size(221, 59);
            this.btnAnswerB.TabIndex = 1;
            this.btnAnswerB.Tag = "2";
            this.btnAnswerB.Text = "B";
            this.btnAnswerB.UseVisualStyleBackColor = true;
            this.btnAnswerB.Click += new System.EventHandler(this.btnAnswerB_Click);
            // 
            // btnAnswerC
            // 
            this.btnAnswerC.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAnswerC.Location = new System.Drawing.Point(255, 410);
            this.btnAnswerC.Name = "btnAnswerC";
            this.btnAnswerC.Size = new System.Drawing.Size(221, 59);
            this.btnAnswerC.TabIndex = 2;
            this.btnAnswerC.Tag = "3";
            this.btnAnswerC.Text = "C";
            this.btnAnswerC.UseVisualStyleBackColor = true;
            this.btnAnswerC.Click += new System.EventHandler(this.btnAnswerC_Click);
            // 
            // btnAnswerD
            // 
            this.btnAnswerD.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAnswerD.Location = new System.Drawing.Point(255, 482);
            this.btnAnswerD.Name = "btnAnswerD";
            this.btnAnswerD.Size = new System.Drawing.Size(221, 59);
            this.btnAnswerD.TabIndex = 3;
            this.btnAnswerD.Tag = "4";
            this.btnAnswerD.Text = "D";
            this.btnAnswerD.UseVisualStyleBackColor = true;
            this.btnAnswerD.Click += new System.EventHandler(this.btnAnswerD_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WhoWantsToBeAMillionaire.Properties.Resources.maxresdefault;
            this.pictureBox1.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(513, 319);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // lblQuestion
            // 
            this.lblQuestion.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblQuestion.Location = new System.Drawing.Point(28, 335);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(448, 62);
            this.lblQuestion.TabIndex = 5;
            this.lblQuestion.Text = "label1";
            // 
            // lstLevel
            // 
            this.lstLevel.Enabled = false;
            this.lstLevel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lstLevel.FormattingEnabled = true;
            this.lstLevel.ItemHeight = 21;
            this.lstLevel.Items.AddRange(new object[] {
            "3 000 000",
            "1 500 000",
            "800 000",
            "400 000",
            "200 000",
            "100 000",
            "50 000",
            "25 000",
            "15 000",
            "10 000",
            "5 000",
            "3 000",
            "2 000",
            "1 000",
            "500"});
            this.lstLevel.Location = new System.Drawing.Point(509, 0);
            this.lstLevel.Name = "lstLevel";
            this.lstLevel.Size = new System.Drawing.Size(161, 319);
            this.lstLevel.TabIndex = 6;
            // 
            // btn50
            // 
            this.btn50.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn50.Location = new System.Drawing.Point(513, 372);
            this.btn50.Name = "btn50";
            this.btn50.Size = new System.Drawing.Size(152, 41);
            this.btn50.TabIndex = 7;
            this.btn50.Text = "50/50";
            this.btn50.UseVisualStyleBackColor = true;
            this.btn50.Click += new System.EventHandler(this.btn50_Click);
            // 
            // btnFriendsHelp
            // 
            this.btnFriendsHelp.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFriendsHelp.Location = new System.Drawing.Point(513, 511);
            this.btnFriendsHelp.Name = "btnFriendsHelp";
            this.btnFriendsHelp.Size = new System.Drawing.Size(152, 41);
            this.btnFriendsHelp.TabIndex = 8;
            this.btnFriendsHelp.Text = "Звонок другу";
            this.btnFriendsHelp.UseVisualStyleBackColor = true;
            this.btnFriendsHelp.Click += new System.EventHandler(this.btnFriendsHelp_Click);
            // 
            // btnChangeQuestion
            // 
            this.btnChangeQuestion.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnChangeQuestion.Location = new System.Drawing.Point(513, 325);
            this.btnChangeQuestion.Name = "btnChangeQuestion";
            this.btnChangeQuestion.Size = new System.Drawing.Size(152, 41);
            this.btnChangeQuestion.TabIndex = 9;
            this.btnChangeQuestion.Text = "Смена вопроса";
            this.btnChangeQuestion.UseVisualStyleBackColor = true;
            this.btnChangeQuestion.Click += new System.EventHandler(this.btnChangeQuestion_Click);
            // 
            // btnHallHelp
            // 
            this.btnHallHelp.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnHallHelp.Location = new System.Drawing.Point(513, 466);
            this.btnHallHelp.Name = "btnHallHelp";
            this.btnHallHelp.Size = new System.Drawing.Size(152, 39);
            this.btnHallHelp.TabIndex = 10;
            this.btnHallHelp.Text = "Помощь зала";
            this.btnHallHelp.UseVisualStyleBackColor = true;
            this.btnHallHelp.Click += new System.EventHandler(this.btnHallHelp_Click);
            // 
            // btnRightToFail
            // 
            this.btnRightToFail.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRightToFail.Location = new System.Drawing.Point(513, 420);
            this.btnRightToFail.Name = "btnRightToFail";
            this.btnRightToFail.Size = new System.Drawing.Size(152, 39);
            this.btnRightToFail.TabIndex = 11;
            this.btnRightToFail.Text = "Право на ошибку";
            this.btnRightToFail.UseVisualStyleBackColor = true;
            this.btnRightToFail.Click += new System.EventHandler(this.btnRightToFail_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 557);
            this.Controls.Add(this.btnRightToFail);
            this.Controls.Add(this.btnHallHelp);
            this.Controls.Add(this.btnChangeQuestion);
            this.Controls.Add(this.btnFriendsHelp);
            this.Controls.Add(this.btn50);
            this.Controls.Add(this.lstLevel);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnAnswerD);
            this.Controls.Add(this.btnAnswerC);
            this.Controls.Add(this.btnAnswerB);
            this.Controls.Add(this.btnAnswerA);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Игра \"Кто хочет стать миллионером\"";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnAnswerA;
        private Button btnAnswerB;
        private Button btnAnswerC;
        private Button btnAnswerD;
        private PictureBox pictureBox1;
        private Label lblQuestion;
        private ListBox lstLevel;
        private Button btn50;
        private Button btnFriendsHelp;
        private Button btnChangeQuestion;
        private Button btnHallHelp;
        private Button btnRightToFail;
    }
}