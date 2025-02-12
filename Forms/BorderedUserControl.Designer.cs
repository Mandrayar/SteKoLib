namespace SteKoLib
{
	partial class BorderedUserControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// toolTip
			// 
			this.toolTip.AutomaticDelay = 10;
			this.toolTip.AutoPopDelay = 10000;
			this.toolTip.InitialDelay = 10;
			this.toolTip.ReshowDelay = 100;
			this.toolTip.ShowAlways = true;
			// 
			// BorderedUserControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Name = "BorderedUserControl";
			this.ResumeLayout(false);

		}

		#endregion

		protected System.Windows.Forms.ToolTip toolTip;
	}
}
