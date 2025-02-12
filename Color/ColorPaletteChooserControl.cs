using System;
using System.Drawing;
using System.Windows.Forms;

namespace SteKoLib
{
    public partial class ColorPaletteChooserControl : UserControl
	{
		#region Defines

		#region Colors

		static readonly Color[] colorGrid = new Color[]
		{
			// Row 1
			Color.FromArgb(0, 0, 0),
			Color.FromArgb(67, 67, 67),
			Color.FromArgb(102, 102, 102),
			Color.FromArgb(153, 153, 153),
			Color.FromArgb(183, 183, 183),
			Color.FromArgb(204, 204, 204),
			Color.FromArgb(217, 217, 217),
			Color.FromArgb(239, 239, 239),
			Color.FromArgb(243, 243, 243),
			Color.FromArgb(255, 255, 255),

			// Row 2
			Color.FromArgb(152, 0, 0),
			Color.FromArgb(255, 0, 0),
			Color.FromArgb(255, 153, 0),
			Color.FromArgb(255, 255, 0),
			Color.FromArgb(0, 255, 0),
			Color.FromArgb(0, 255, 255),
			Color.FromArgb(74, 134, 232),
			Color.FromArgb(0, 0, 255),
			Color.FromArgb(153, 0, 255),
			Color.FromArgb(255, 0, 255),

			// Row 3
			Color.FromArgb(230, 184, 175),
			Color.FromArgb(244, 204, 204),
			Color.FromArgb(252, 229, 205),
			Color.FromArgb(255, 242, 204),
			Color.FromArgb(217, 234, 211),
			Color.FromArgb(208, 224, 227),
			Color.FromArgb(201, 218, 248),
			Color.FromArgb(207, 226, 243),
			Color.FromArgb(217, 210, 233),
			Color.FromArgb(234, 209, 220),
			
			// Row 4
			Color.FromArgb(221, 126, 107),
			Color.FromArgb(234, 153, 153),
			Color.FromArgb(249, 203, 156),
			Color.FromArgb(255, 229, 153),
			Color.FromArgb(182, 215, 168),
			Color.FromArgb(162, 196, 201),
			Color.FromArgb(164, 194, 244),
			Color.FromArgb(159, 197, 232),
			Color.FromArgb(180, 167, 214),
			Color.FromArgb(213, 166, 189),

			// Row 5
			Color.FromArgb(204, 65, 34),
			Color.FromArgb(224, 102, 102),
			Color.FromArgb(246, 178, 107),
			Color.FromArgb(255, 217, 102),
			Color.FromArgb(147, 196, 125),
			Color.FromArgb(118, 165, 175),
			Color.FromArgb(109, 158, 235),
			Color.FromArgb(111, 168, 220),
			Color.FromArgb(142, 124, 195),
			Color.FromArgb(194, 123, 160),

			// Row 6
			Color.FromArgb(166, 28, 0),
			Color.FromArgb(204, 0, 0),
			Color.FromArgb(230, 145, 56),
			Color.FromArgb(241, 194, 50),
			Color.FromArgb(106, 168, 79),
			Color.FromArgb(69, 129, 142),
			Color.FromArgb(60, 120, 216),
			Color.FromArgb(61, 133, 198),
			Color.FromArgb(103, 78, 167),
			Color.FromArgb(166, 77, 121),

			// Row 7
			Color.FromArgb(133, 32, 12),
			Color.FromArgb(153, 0, 0),
			Color.FromArgb(180, 95, 6),
			Color.FromArgb(191, 144, 0),
			Color.FromArgb(56, 118, 29),
			Color.FromArgb(19, 79, 92),
			Color.FromArgb(17, 85, 204),
			Color.FromArgb(11, 83, 148),
			Color.FromArgb(53, 28, 117),
			Color.FromArgb(116, 27, 71),

			// Row 8
			Color.FromArgb(91, 15, 0),
			Color.FromArgb(102, 0, 0),
			Color.FromArgb(120, 63, 4),
			Color.FromArgb(127, 96, 0),
			Color.FromArgb(39, 78, 19),
			Color.FromArgb(12, 52, 61),
			Color.FromArgb(28, 69, 135),
			Color.FromArgb(7, 55, 99),
			Color.FromArgb(32, 18, 77),
			Color.FromArgb(76, 17, 48)
		};

		#endregion

		const int BORDER = 2;
		const int QUAD_SIZE = 21;
		const int SMALL_GAP = 2;
		const int BIG_GAP = 10;
		const int GRID_ROW_COUNT = 8;
		const int MIN_WIDTH = 232;
		const int MIN_HEIGHT = 202;
		const int INVALID_INDEX = -1;

		#endregion

		#region Construction

		public ColorPaletteChooserControl()
		{
			InitializeComponent();
			DoubleBuffered = true;
		}

		#endregion

		#region Public Properties

		public Color SelectedColor
		{
			get
			{
				return GetSelectedColor();
			}
			set
			{
				SelectedIndex = GetColorIndex(value);
			}
		}

		#endregion

		#region Inherited from UserControl

		#region Control Size

		protected override Size DefaultMinimumSize
		{
			get { return new Size(MIN_WIDTH, MIN_HEIGHT); }
		}

		protected override Size DefaultSize
		{
			get { return new Size(MIN_WIDTH, MIN_HEIGHT); }
		}

		public override Size MinimumSize
		{
			get { return base.MinimumSize; }
			set
			{
				if (value.Width < MIN_WIDTH)
					value.Width = MIN_WIDTH;

				if (value.Height < MIN_HEIGHT)
					value.Height = MIN_HEIGHT;

				base.MinimumSize = value;
			}
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			if (Width < MIN_WIDTH)
				Width = MIN_WIDTH;

			if (Height < MIN_HEIGHT)
				Height = MIN_HEIGHT;

			base.OnSizeChanged(e);
		}

		#endregion

		#region Rendering

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			base.OnPaintBackground(e);

			Rectangle rect = new Rectangle(BORDER, BORDER, QUAD_SIZE, QUAD_SIZE);
			int stride = colorGrid.Length / GRID_ROW_COUNT;
			for (int y = 0; y < GRID_ROW_COUNT; ++y)
			{
				rect.X = BORDER;
				for (int x = 0; x < stride; ++x)
				{
					int index = y * stride + x;

					brush.Color = colorGrid[index];
					if (index == hoverIndex || index == selectedIndex)
					{
						e.Graphics.DrawRectangle(Pens.White, rect.X - 1, rect.Y - 1, rect.Width + 2, rect.Height + 2);
						e.Graphics.DrawRectangle(Pens.Black, rect.X - 2, rect.Y - 2, rect.Width + 3, rect.Height + 3);
					}

					e.Graphics.FillRectangle(brush, rect);
					rect.Offset(QUAD_SIZE + SMALL_GAP, 0);
				}

				rect.Y = rect.Y + QUAD_SIZE + GetVerticalGap(y);
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
		}

		int GetVerticalGap(int row)
		{
			if (row == 0 || row == 1)
				return BIG_GAP;

			return SMALL_GAP;
		}

		#endregion

		#region Input

		protected override void OnMouseClick(MouseEventArgs e)
		{
			base.OnMouseClick(e);
			int temp = GetColorIndex(e.Location);
			if (temp != INVALID_INDEX)
				SelectedIndex = temp;

		}

		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			HoverIndex = GetColorIndex(PointToClient(Cursor.Position));
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			HoverIndex = GetColorIndex(PointToClient(Cursor.Position));
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			HoverIndex = GetColorIndex(e.Location);
		}

		#endregion

		#endregion

		#region Index Properties

		private int HoverIndex
		{
			set
			{
				if (value != hoverIndex)
				{
					hoverIndex = value;
					Invalidate();
				}
			}
		}

		private int SelectedIndex
		{
			set
			{
				if (value != selectedIndex)
				{
					selectedIndex = value;
					FireColorSelected();
					Invalidate();
				}
			}
		}

		#endregion

		#region Color Functions

		/// <summary>
		/// Returns a valid index in color grid array or INVALID_INDEX
		/// </summary>
		int GetColorIndex(Point mousePosition)
		{
			Rectangle rect = new Rectangle(BORDER, BORDER, QUAD_SIZE, QUAD_SIZE);
			int stride = colorGrid.Length / GRID_ROW_COUNT;
			for (int y = 0; y < GRID_ROW_COUNT; ++y)
			{
				rect.X = BORDER;
				for (int x = 0; x < stride; ++x)
				{
					if (rect.Contains(mousePosition))
						return y * stride + x;

					rect.Offset(QUAD_SIZE + SMALL_GAP, 0);
				}

				rect.Y = rect.Y + QUAD_SIZE + GetVerticalGap(y);
			}

			return INVALID_INDEX;
		}

		/// <summary>
		/// Returns a valid index if color exists in color grid otherwise returns INVALID_INDEX
		/// </summary>
		int GetColorIndex(Color color)
		{
			for (int i = 0; i < colorGrid.Length; ++i)
			{
				Color c = colorGrid[i];
				if ((color.R == c.R) && (color.G == c.G) && (color.B == c.B))
					return i;
			}

			return INVALID_INDEX;
		}

		Color GetSelectedColor()
		{
			if (selectedIndex != INVALID_INDEX)
			{
				return colorGrid[selectedIndex];
			}

			return Color.Empty;
		}

		#endregion

		#region Events

		void FireColorSelected()
		{
			if (ColorSelected != null)
				ColorSelected(this, EventArgs.Empty);
		}

		#endregion

		#region Events

		public event EventHandler ColorSelected;

		#endregion

		#region Member

		SolidBrush brush = new SolidBrush(Color.Black);
		int selectedIndex = INVALID_INDEX;
		int hoverIndex = INVALID_INDEX;

		#endregion
	}
}
