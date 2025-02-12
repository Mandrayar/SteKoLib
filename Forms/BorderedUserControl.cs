using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SteKoLib
{
	public partial class BorderedUserControl : UserControl
	{
		public BorderedUserControl()
		{
			InitializeComponent();
		}

		public Color BorderColor { get; set; }
		public int BorderWidth { get; set; }

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			base.OnPaintBackground(e);
			ButtonBorderStyle BorderStyle = ButtonBorderStyle.Solid;
			ControlPaint.DrawBorder(e.Graphics, ClientRectangle, BorderColor, BorderWidth, BorderStyle, BorderColor, BorderWidth, BorderStyle, BorderColor, BorderWidth, BorderStyle, BorderColor, BorderWidth, BorderStyle);
		}
	}
}
