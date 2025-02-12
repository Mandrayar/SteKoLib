namespace SteKoLib
{
	partial class InputBox
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
			this.lblFieldName = new System.Windows.Forms.Label();
			this.txtFieldValue = new System.Windows.Forms.TextBox();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.cbOptions = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// lblFieldName
			// 
			this.lblFieldName.AutoSize = true;
			this.lblFieldName.Location = new System.Drawing.Point(12, 9);
			this.lblFieldName.Name = "lblFieldName";
			this.lblFieldName.Size = new System.Drawing.Size(62, 13);
			this.lblFieldName.TabIndex = 0;
			this.lblFieldName.Text = "Foldername";
			// 
			// txtFieldValue
			// 
			this.txtFieldValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtFieldValue.Location = new System.Drawing.Point(12, 25);
			this.txtFieldValue.Name = "txtFieldValue";
			this.txtFieldValue.Size = new System.Drawing.Size(268, 20);
			this.txtFieldValue.TabIndex = 1;
			// 
			// btnOk
			// 
			this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnOk.Location = new System.Drawing.Point(30, 60);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(114, 23);
			this.btnOk.TabIndex = 3;
			this.btnOk.Text = "&Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.OnConfirm);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(150, 60);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(114, 23);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.OnCancel);
			// 
			// cbOptions
			// 
			this.cbOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbOptions.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbOptions.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbOptions.FormattingEnabled = true;
			this.cbOptions.Location = new System.Drawing.Point(12, 25);
			this.cbOptions.Name = "cbOptions";
			this.cbOptions.Size = new System.Drawing.Size(268, 21);
			this.cbOptions.Sorted = true;
			this.cbOptions.TabIndex = 2;
			this.cbOptions.Visible = false;
			// 
			// InputBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(295, 95);
			this.Controls.Add(this.cbOptions);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.txtFieldValue);
			this.Controls.Add(this.lblFieldName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "InputBox";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Create Folder";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblFieldName;
		private System.Windows.Forms.TextBox txtFieldValue;
        private System.Windows.Forms.ComboBox cbOptions;
		protected internal System.Windows.Forms.Button btnOk;
		protected internal System.Windows.Forms.Button btnCancel;
	}
}