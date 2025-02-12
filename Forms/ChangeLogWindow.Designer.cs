namespace SteKoLib
{
	partial class ChangeLogWindow
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
			this.rtbHistory = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// rtbHistory
			// 
			this.rtbHistory.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtbHistory.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtbHistory.Location = new System.Drawing.Point(0, 0);
			this.rtbHistory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.rtbHistory.Name = "rtbHistory";
			this.rtbHistory.ReadOnly = true;
			this.rtbHistory.Size = new System.Drawing.Size(1340, 603);
			this.rtbHistory.TabIndex = 0;
			this.rtbHistory.Text = "";
			// 
			// ChangeLogWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1340, 603);
			this.Controls.Add(this.rtbHistory);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "ChangeLogWindow";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Versionshistorie";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RichTextBox rtbHistory;
	}
}