using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SteKoLib
{
	public partial class InputBox : Form
	{
		#region Member

		bool isComboboxVisible = false;
		protected bool CloseWindowOnConfirm { get; set; }


		#endregion

		#region Construction

		public InputBox()
		{
			CloseWindowOnConfirm = true;
			InitializeComponent();
			DialogResult = DialogResult.Cancel;
			ActiveControl = txtFieldValue;
		}

		public InputBox(IEnumerable<string> options) : base()
		{
			isComboboxVisible = true;
			txtFieldValue.Visible = !isComboboxVisible;
			cbOptions.Visible = isComboboxVisible;
			foreach (string str in options)
				cbOptions.Items.Add(str);

			cbOptions.KeyDown += new KeyEventHandler(cbOptions_KeyPress);
			ActiveControl = cbOptions;
		}

		#endregion

		#region Public Properties

		/// <summary>
		/// Sets or gets the label text next to the value TextBox
		/// </summary>
		public string FieldTitle
		{
			get { return lblFieldName.Text; }
			set { lblFieldName.Text = value; }
		}

		public bool ShowPasswordChar
		{
			set
			{
				if (value)
					txtFieldValue.PasswordChar = '*';
				else
					txtFieldValue.PasswordChar = '\0';
			}
		}

		/// <summary>
		/// Sets or gets the string for the InputBox value
		/// </summary>
		public string InputValue
		{
			get
			{
				if (isComboboxVisible)
					return cbOptions.Text;
				else
					return txtFieldValue.Text;
			}
			set
			{
				if (isComboboxVisible)
					cbOptions.Text = value;
				else
					txtFieldValue.Text = value;
			}
		}

		public bool MultiLine
		{
			get { return txtFieldValue.Multiline; }
			set { txtFieldValue.Multiline = value; }
		}

		#endregion

		#region Static Show Methods

		/// <summary>
		/// Show a customizable input box to get a input value for eg a folder name
		/// </summary>
		/// <param name="title">Title for the InputBox</param>
		/// <param name="fieldTitle">Label description next to the field value</param>
		/// <returns>Input string if user presses okay or empty if user close the window or use the cancel button</returns>
		public static string Show(string title, string fieldTitle, Form owner = null)
		{
			InputBox input = CreateInputBox(null, title, fieldTitle, false, false);

			DialogResult result = input.ShowDialog(owner);
			if (result == DialogResult.OK)
				return input.InputValue;
			
			return string.Empty;
		}

		public static DialogResult Show(string title, string fieldTitle, ref string value, Form owner = null)
		{
			return Show(title, fieldTitle, false, false, ref value, owner);
		}


		public static DialogResult ShowCentered(string title, string fieldTitle, ref string value, Form owner = null)
		{
			return Show(title, fieldTitle, true, false, ref value, owner);
		}

		public static DialogResult ShowPasswordCentered(string title, string fieldTitle, ref string value, Form owner = null)
		{
			return Show(title, fieldTitle, true, true, ref value, owner);
		}

		public static DialogResult Show(IEnumerable<string> options, string title, string fieldTitle, ref string value, Form owner = null)
		{
			return Show(options, title, fieldTitle, false, ref value, owner);
		}

		public static string Show(string title, string fieldTitle, string defaultValue, Form owner = null)
		{
			string value = defaultValue;
			if (Show(title, fieldTitle, false, false, ref value, owner) == DialogResult.OK)
				return value;

			return defaultValue;
		}

		public static string Show(string title, string fieldTitle, string defaultValue, bool multiLine, Form owner = null)
		{
			InputBox input = CreateInputBox(null, title, fieldTitle, false, false);
			input.InputValue = defaultValue;
			input.MultiLine = multiLine;
			if (multiLine)
				input.Size = new System.Drawing.Size(input.Width, input.Height + 100);

			string resultValue = defaultValue;

			DialogResult result = input.ShowDialog(owner);
			if (result == DialogResult.OK)
				resultValue = input.InputValue;

			return resultValue;
		}

		#endregion

		#region Helper Methods

		static InputBox CreateInputBox(IEnumerable<string> options, string title, string fieldTitle, bool showCentered, bool showPasswordChar)
		{
			InputBox input = null;
			if (options == null)
				input = new InputBox();
			else
				input = new InputBox(options);

			input.Text = title;
			input.FieldTitle = fieldTitle;
			input.ShowInTaskbar = false;
			input.ShowPasswordChar = showPasswordChar;
			return input;
		}

		static DialogResult Show(string title, string fieldTitle, bool showCentered, bool showPasswordChar, ref string value, Form owner = null)
		{
			InputBox input = CreateInputBox(null, title, fieldTitle, showCentered, showPasswordChar);
			input.InputValue = value;
			DialogResult result = input.ShowDialog(owner);
			if (result == DialogResult.OK)
				value = input.InputValue;
			return result;
		}

		static DialogResult Show(IEnumerable<string> options, string title, string fieldTitle, bool showCentered, ref string value, Form owner = null)
		{
			InputBox input = CreateInputBox(options, title, fieldTitle, showCentered, false);
			input.InputValue = value;
			DialogResult result = input.ShowDialog(owner);
			value = input.InputValue;
			return result;
		}

		#endregion

		#region Control Callbacks

		protected virtual void OnConfirm(object sender, EventArgs e)
		{
			if (isComboboxVisible)
			{
				const int INVALID_INDEX = -1;
				string input = cbOptions.Text;
				if (cbOptions.FindStringExact(input) == INVALID_INDEX)
				{
					MessageBox.Show("The input you have typed in isn't a valid option!");
					cbOptions.Focus();
					return;
				}
			}

			DialogResult = DialogResult.OK;
			if (CloseWindowOnConfirm)
				Close();
		}

		void OnCancel(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		public void cbOptions_KeyPress(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				OnConfirm(this, EventArgs.Empty);
				e.Handled = true;
			}
			else if (e.KeyCode == Keys.Escape)
			{
				OnCancel(this, EventArgs.Empty);
				e.Handled = true;
			}
		}

		#endregion

		#region Inherited Form Methods

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			if (isComboboxVisible)
				cbOptions.Focus();
			else
				txtFieldValue.Focus();
		}

		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				OnConfirm(this, EventArgs.Empty);
				e.Handled = true;
			}
			else if (e.KeyChar == (char)Keys.Escape)
			{
				OnCancel(this, EventArgs.Empty);
				e.Handled = true;
			}
			base.OnKeyPress(e);
		}

		#endregion
	}
}
