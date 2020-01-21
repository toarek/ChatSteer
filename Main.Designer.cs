namespace ChatSteer {
    partial class Main {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.Chat = new System.Windows.Forms.Panel();
            this.Timer0 = new System.Windows.Forms.Timer(this.components);
            this.Start = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.ProcessList = new System.Windows.Forms.CheckedListBox();
            this.KeyList = new System.Windows.Forms.ListBox();
            this.Messages = new System.Windows.Forms.ListBox();
            this.MessagesTitle = new System.Windows.Forms.Label();
            this.KeyListTitle = new System.Windows.Forms.Label();
            this.ProcessListTitle = new System.Windows.Forms.Label();
            this.SteeringAppText = new System.Windows.Forms.Label();
            this.WelcomeText = new System.Windows.Forms.Label();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.Timer2 = new System.Windows.Forms.Timer(this.components);
            this.AuthorLabel = new System.Windows.Forms.Label();
            this.AuthorButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Chat
            // 
            this.Chat.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Chat.Location = new System.Drawing.Point(600, 12);
            this.Chat.Name = "Chat";
            this.Chat.Size = new System.Drawing.Size(340, 317);
            this.Chat.TabIndex = 1;
            // 
            // Timer0
            // 
            this.Timer0.Enabled = true;
            this.Timer0.Interval = 50;
            this.Timer0.Tick += new System.EventHandler(this.Timer0_Tick);
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(12, 313);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 2;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Stop
            // 
            this.Stop.Location = new System.Drawing.Point(93, 313);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(75, 23);
            this.Stop.TabIndex = 3;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(312, 313);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(240, 23);
            this.RefreshButton.TabIndex = 4;
            this.RefreshButton.Text = "Odśwież";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // ProcessList
            // 
            this.ProcessList.FormattingEnabled = true;
            this.ProcessList.Location = new System.Drawing.Point(312, 28);
            this.ProcessList.Name = "ProcessList";
            this.ProcessList.Size = new System.Drawing.Size(240, 274);
            this.ProcessList.TabIndex = 5;
            this.ProcessList.Visible = false;
            this.ProcessList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ProcessList_ItemCheck);
            // 
            // KeyList
            // 
            this.KeyList.FormattingEnabled = true;
            this.KeyList.Location = new System.Drawing.Point(359, 25);
            this.KeyList.Name = "KeyList";
            this.KeyList.Size = new System.Drawing.Size(193, 277);
            this.KeyList.TabIndex = 6;
            // 
            // Messages
            // 
            this.Messages.FormattingEnabled = true;
            this.Messages.Location = new System.Drawing.Point(12, 25);
            this.Messages.Name = "Messages";
            this.Messages.Size = new System.Drawing.Size(341, 277);
            this.Messages.TabIndex = 7;
            // 
            // MessagesTitle
            // 
            this.MessagesTitle.AutoSize = true;
            this.MessagesTitle.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MessagesTitle.Location = new System.Drawing.Point(13, 6);
            this.MessagesTitle.Name = "MessagesTitle";
            this.MessagesTitle.Size = new System.Drawing.Size(79, 14);
            this.MessagesTitle.TabIndex = 8;
            this.MessagesTitle.Text = "Czat na żywo";
            // 
            // KeyListTitle
            // 
            this.KeyListTitle.AutoSize = true;
            this.KeyListTitle.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.KeyListTitle.Location = new System.Drawing.Point(356, 6);
            this.KeyListTitle.Name = "KeyListTitle";
            this.KeyListTitle.Size = new System.Drawing.Size(75, 14);
            this.KeyListTitle.TabIndex = 9;
            this.KeyListTitle.Text = "Kolejka akcji";
            // 
            // ProcessListTitle
            // 
            this.ProcessListTitle.AutoSize = true;
            this.ProcessListTitle.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ProcessListTitle.Location = new System.Drawing.Point(309, 6);
            this.ProcessListTitle.Name = "ProcessListTitle";
            this.ProcessListTitle.Size = new System.Drawing.Size(132, 14);
            this.ProcessListTitle.TabIndex = 10;
            this.ProcessListTitle.Text = "Uruchomione aplikacje";
            this.ProcessListTitle.Visible = false;
            // 
            // SteeringAppText
            // 
            this.SteeringAppText.AutoSize = true;
            this.SteeringAppText.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SteeringAppText.Location = new System.Drawing.Point(174, 318);
            this.SteeringAppText.Name = "SteeringAppText";
            this.SteeringAppText.Size = new System.Drawing.Size(123, 14);
            this.SteeringAppText.TabIndex = 11;
            this.SteeringAppText.Text = "Sterowany program: \r\n";
            this.SteeringAppText.Visible = false;
            // 
            // WelcomeText
            // 
            this.WelcomeText.AutoSize = true;
            this.WelcomeText.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WelcomeText.Location = new System.Drawing.Point(13, 6);
            this.WelcomeText.MaximumSize = new System.Drawing.Size(290, 0);
            this.WelcomeText.Name = "WelcomeText";
            this.WelcomeText.Size = new System.Drawing.Size(267, 140);
            this.WelcomeText.TabIndex = 12;
            this.WelcomeText.Text = resources.GetString("WelcomeText.Text");
            // 
            // Timer1
            // 
            this.Timer1.Enabled = true;
            this.Timer1.Interval = 1;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Timer2
            // 
            this.Timer2.Enabled = true;
            this.Timer2.Interval = 8000;
            this.Timer2.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // AuthorLabel
            // 
            this.AuthorLabel.AutoSize = true;
            this.AuthorLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AuthorLabel.Location = new System.Drawing.Point(49, 132);
            this.AuthorLabel.MaximumSize = new System.Drawing.Size(290, 0);
            this.AuthorLabel.Name = "AuthorLabel";
            this.AuthorLabel.Size = new System.Drawing.Size(119, 14);
            this.AuthorLabel.TabIndex = 14;
            this.AuthorLabel.Text = "Arkadiusz Tołwiński";
            // 
            // AuthorButton
            // 
            this.AuthorButton.Location = new System.Drawing.Point(52, 127);
            this.AuthorButton.Name = "AuthorButton";
            this.AuthorButton.Size = new System.Drawing.Size(66, 23);
            this.AuthorButton.TabIndex = 15;
            this.AuthorButton.Text = "Pokaż";
            this.AuthorButton.UseVisualStyleBackColor = true;
            this.AuthorButton.Click += new System.EventHandler(this.AuthorButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 341);
            this.Controls.Add(this.AuthorButton);
            this.Controls.Add(this.AuthorLabel);
            this.Controls.Add(this.WelcomeText);
            this.Controls.Add(this.SteeringAppText);
            this.Controls.Add(this.ProcessListTitle);
            this.Controls.Add(this.KeyListTitle);
            this.Controls.Add(this.MessagesTitle);
            this.Controls.Add(this.Messages);
            this.Controls.Add(this.KeyList);
            this.Controls.Add(this.ProcessList);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.Chat);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(580, 380);
            this.MinimumSize = new System.Drawing.Size(580, 380);
            this.Name = "Main";
            this.Text = "ChatSteer";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel Chat;
        private System.Windows.Forms.Timer Timer0;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.CheckedListBox ProcessList;
        private System.Windows.Forms.ListBox KeyList;
        private System.Windows.Forms.ListBox Messages;
        private System.Windows.Forms.Label MessagesTitle;
        private System.Windows.Forms.Label KeyListTitle;
        private System.Windows.Forms.Label ProcessListTitle;
        private System.Windows.Forms.Label SteeringAppText;
        private System.Windows.Forms.Label WelcomeText;
        private System.Windows.Forms.Timer Timer1;
        private System.Windows.Forms.Timer Timer2;
        private System.Windows.Forms.Label AuthorLabel;
        private System.Windows.Forms.Button AuthorButton;
    }
}

