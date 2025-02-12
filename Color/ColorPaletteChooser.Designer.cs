namespace SteKoLib
{
	partial class ColorPaletteChooser
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
			this.chooser = new SteKoLib.ColorPaletteChooserControl();
			this.SuspendLayout();
			// 
			// chooser
			// 
			this.chooser.BackColor = System.Drawing.Color.Transparent;
			this.chooser.Location = new System.Drawing.Point(0, 0);
			this.chooser.Name = "chooser";
			this.chooser.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.chooser.Size = new System.Drawing.Size(232, 202);
			this.chooser.TabIndex = 0;
			this.chooser.ColorSelected += new System.EventHandler(this.OnColorSelected);
			// 
			// ColorPaletteChooser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(232, 202);
			this.Controls.Add(this.chooser);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "ColorPaletteChooser";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "ColorPaletteChooser";
			this.ResumeLayout(false);

		}

		#endregion

		private ColorPaletteChooserControl chooser;
	}
}