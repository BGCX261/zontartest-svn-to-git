namespace SchiffeVersenken.Klassen
{
    partial class NeuesSchiff
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.rbVertikal = new System.Windows.Forms.RadioButton();
            this.rbWaagerecht = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btCancel = new System.Windows.Forms.Button();
            this.spielfeld = new SchiffeVersenken.Klassen.SpielGUI();
            this.btOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rbVertikal
            // 
            this.rbVertikal.AutoSize = true;
            this.rbVertikal.Location = new System.Drawing.Point(12, 12);
            this.rbVertikal.Name = "rbVertikal";
            this.rbVertikal.Size = new System.Drawing.Size(60, 17);
            this.rbVertikal.TabIndex = 0;
            this.rbVertikal.TabStop = true;
            this.rbVertikal.Text = "Vertikal";
            this.rbVertikal.UseVisualStyleBackColor = true;
            // 
            // rbWaagerecht
            // 
            this.rbWaagerecht.AutoSize = true;
            this.rbWaagerecht.Location = new System.Drawing.Point(12, 35);
            this.rbWaagerecht.Name = "rbWaagerecht";
            this.rbWaagerecht.Size = new System.Drawing.Size(84, 17);
            this.rbWaagerecht.TabIndex = 1;
            this.rbWaagerecht.TabStop = true;
            this.rbWaagerecht.Text = "Waagerecht";
            this.rbWaagerecht.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(119, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Zerstörer";
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(272, 343);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 4;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // spielfeld
            // 
            this.spielfeld.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.spielfeld.Location = new System.Drawing.Point(12, 58);
            this.spielfeld.Name = "spielfeld";
            this.spielfeld.Size = new System.Drawing.Size(335, 279);
            this.spielfeld.TabIndex = 5;
            // 
            // btOK
            // 
            this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOK.Location = new System.Drawing.Point(191, 343);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.TabIndex = 6;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            // 
            // NeuesSchiff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 378);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.spielfeld);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbWaagerecht);
            this.Controls.Add(this.rbVertikal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NeuesSchiff";
            this.Text = "NeuesSchiff";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbVertikal;
        private System.Windows.Forms.RadioButton rbWaagerecht;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btCancel;
        private SpielGUI spielfeld;
        private System.Windows.Forms.Button btOK;
    }
}