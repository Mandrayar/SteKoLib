using System;
using System.Drawing;
using System.Windows.Forms;

namespace SteKoLib
{
    public partial class ColorPaletteChooser : Form
	{
		#region Construction

		public ColorPaletteChooser()
		{
			InitializeComponent();
		}

		#endregion

		#region Public Interface

		public Color SelectedColor
		{
			get { return chooser.SelectedColor; }
			set { chooser.SelectedColor = value; }
		}

		#endregion

		#region Inherited from Form

		protected override void OnDeactivate(EventArgs e)
		{
			base.OnDeactivate(e);
			Hide();
		}

		#endregion

		#region Control Callbacks

		void OnColorSelected(object sender, EventArgs e)
		{
			if (ColorSelected != null)
				ColorSelected(this, e);

			Hide();
		}

		#endregion

		#region Events

		public event EventHandler ColorSelected;

		#endregion
	}
}
