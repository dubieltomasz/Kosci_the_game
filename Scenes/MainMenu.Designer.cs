namespace Kości__gra_.Scenes
{
    partial class MainMenu
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            flowLayoutPanel1 = new FlowLayoutPanel();
            btPlay = new Button();
            btSettings = new Button();
            btQuit = new Button();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btPlay);
            flowLayoutPanel1.Controls.Add(btSettings);
            flowLayoutPanel1.Controls.Add(btQuit);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(150, 150);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // btPlay
            // 
            btPlay.Location = new Point(3, 3);
            btPlay.Name = "btPlay";
            btPlay.Size = new Size(75, 23);
            btPlay.TabIndex = 0;
            btPlay.Text = "button1";
            btPlay.UseVisualStyleBackColor = true;
            btPlay.Click += btPlay_Click;
            // 
            // btSettings
            // 
            btSettings.Location = new Point(3, 32);
            btSettings.Name = "btSettings";
            btSettings.Size = new Size(75, 23);
            btSettings.TabIndex = 1;
            btSettings.Text = "button2";
            btSettings.UseVisualStyleBackColor = true;
            btSettings.Click += btSettings_Click;
            // 
            // btQuit
            // 
            btQuit.Location = new Point(3, 61);
            btQuit.Name = "btQuit";
            btQuit.Size = new Size(75, 23);
            btQuit.TabIndex = 2;
            btQuit.Text = "button3";
            btQuit.UseVisualStyleBackColor = true;
            btQuit.Click += btQuit_Click;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flowLayoutPanel1);
            Name = "MainMenu";
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Button btPlay;
        private Button btSettings;
        private Button btQuit;
    }
}
