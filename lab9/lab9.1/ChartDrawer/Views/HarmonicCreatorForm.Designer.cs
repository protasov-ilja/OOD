namespace lab9._1.ChartDrawer.Views
{
	partial class HarmonicCreatorForm
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
			this.Editor = new System.Windows.Forms.GroupBox();
			this.amplitudeText = new System.Windows.Forms.TextBox();
			this.phaseText = new System.Windows.Forms.TextBox();
			this.frequencyText = new System.Windows.Forms.TextBox();
			this.radioButtons = new System.Windows.Forms.GroupBox();
			this.cosButton = new System.Windows.Forms.RadioButton();
			this.sinButton = new System.Windows.Forms.RadioButton();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.resultHarmonicText = new System.Windows.Forms.Label();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.Editor.SuspendLayout();
			this.radioButtons.SuspendLayout();
			this.SuspendLayout();
			// 
			// Editor
			// 
			this.Editor.Controls.Add(this.amplitudeText);
			this.Editor.Controls.Add(this.phaseText);
			this.Editor.Controls.Add(this.frequencyText);
			this.Editor.Controls.Add(this.radioButtons);
			this.Editor.Controls.Add(this.label3);
			this.Editor.Controls.Add(this.label2);
			this.Editor.Controls.Add(this.label1);
			this.Editor.Location = new System.Drawing.Point(0, -2);
			this.Editor.Name = "Editor";
			this.Editor.Size = new System.Drawing.Size(385, 311);
			this.Editor.TabIndex = 4;
			this.Editor.TabStop = false;
			// 
			// amplitudeText
			// 
			this.amplitudeText.Location = new System.Drawing.Point(220, 43);
			this.amplitudeText.Name = "amplitudeText";
			this.amplitudeText.Size = new System.Drawing.Size(100, 22);
			this.amplitudeText.TabIndex = 10;
			this.amplitudeText.Leave += new System.EventHandler(this.amplitudeText_TextChanged);
			// 
			// phaseText
			// 
			this.phaseText.Location = new System.Drawing.Point(220, 237);
			this.phaseText.Name = "phaseText";
			this.phaseText.Size = new System.Drawing.Size(100, 22);
			this.phaseText.TabIndex = 9;
			this.phaseText.Leave += new System.EventHandler(this.phaseText_TextChanged);
			// 
			// frequencyText
			// 
			this.frequencyText.Location = new System.Drawing.Point(220, 169);
			this.frequencyText.Name = "frequencyText";
			this.frequencyText.Size = new System.Drawing.Size(100, 22);
			this.frequencyText.TabIndex = 8;
			this.frequencyText.Leave += new System.EventHandler(this.frequencyText_TextChanged);
			// 
			// radioButtons
			// 
			this.radioButtons.Controls.Add(this.cosButton);
			this.radioButtons.Controls.Add(this.sinButton);
			this.radioButtons.Location = new System.Drawing.Point(0, 82);
			this.radioButtons.Name = "radioButtons";
			this.radioButtons.Size = new System.Drawing.Size(387, 57);
			this.radioButtons.TabIndex = 7;
			this.radioButtons.TabStop = false;
			// 
			// cosButton
			// 
			this.cosButton.AutoSize = true;
			this.cosButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cosButton.Location = new System.Drawing.Point(248, 21);
			this.cosButton.Name = "cosButton";
			this.cosButton.Size = new System.Drawing.Size(54, 22);
			this.cosButton.TabIndex = 7;
			this.cosButton.TabStop = true;
			this.cosButton.Text = "cos";
			this.cosButton.UseVisualStyleBackColor = true;
			this.cosButton.CheckedChanged += new System.EventHandler(this.cosButton_CheckedChanged);
			// 
			// sinButton
			// 
			this.sinButton.AutoSize = true;
			this.sinButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.sinButton.Location = new System.Drawing.Point(53, 21);
			this.sinButton.Name = "sinButton";
			this.sinButton.Size = new System.Drawing.Size(48, 22);
			this.sinButton.TabIndex = 6;
			this.sinButton.TabStop = true;
			this.sinButton.Text = "sin";
			this.sinButton.UseVisualStyleBackColor = true;
			this.sinButton.CheckedChanged += new System.EventHandler(this.sinButton_CheckedChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(50, 241);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(54, 18);
			this.label3.TabIndex = 4;
			this.label3.Text = "Phase:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(50, 170);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(81, 18);
			this.label2.TabIndex = 2;
			this.label2.Text = "Frequency:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(50, 44);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "Amplitude:";
			// 
			// resultHarmonicText
			// 
			this.resultHarmonicText.AutoSize = true;
			this.resultHarmonicText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.resultHarmonicText.ForeColor = System.Drawing.SystemColors.ControlText;
			this.resultHarmonicText.Location = new System.Drawing.Point(48, 323);
			this.resultHarmonicText.Name = "resultHarmonicText";
			this.resultHarmonicText.Size = new System.Drawing.Size(71, 29);
			this.resultHarmonicText.TabIndex = 5;
			this.resultHarmonicText.Text = "1*Sin";
			// 
			// okButton
			// 
			this.okButton.Location = new System.Drawing.Point(53, 397);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(109, 44);
			this.okButton.TabIndex = 6;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(211, 397);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(109, 44);
			this.cancelButton.TabIndex = 7;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// HarmonicCreatorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(386, 453);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.resultHarmonicText);
			this.Controls.Add(this.Editor);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(404, 500);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(404, 500);
			this.Name = "HarmonicCreatorForm";
			this.Text = "Add new harmonic";
			this.Editor.ResumeLayout(false);
			this.Editor.PerformLayout();
			this.radioButtons.ResumeLayout(false);
			this.radioButtons.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox Editor;
		private System.Windows.Forms.GroupBox radioButtons;
		private System.Windows.Forms.RadioButton cosButton;
		private System.Windows.Forms.RadioButton sinButton;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label resultHarmonicText;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.TextBox amplitudeText;
		private System.Windows.Forms.TextBox phaseText;
		private System.Windows.Forms.TextBox frequencyText;
	}
}