using System;

namespace SteKoLib
{
    public class SearchBox : InputBox
	{
		#region Events

		public event EventHandler SearchTriggered;

		#endregion

		#region Construction

		public SearchBox()
		{
			btnOk.Text = "Weitersuchen";
			btnCancel.Text = "Abbrechen";
			Text = "Suchen";
			FieldTitle = "Suchen nach:";
			CloseWindowOnConfirm = false;
		}

		#endregion

		protected override void OnConfirm(object sender, EventArgs e)
		{
			base.OnConfirm(sender, e);
			SearchTriggered?.Invoke(this, e);
		}
	}
}
