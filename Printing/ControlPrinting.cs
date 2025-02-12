using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteKoLib
{
	/// <summary>
	/// Is able to recursively print a control and its content to a graphics object
	/// Control exclusion or scaling can be set either by setting the PrintContext or providing it in Print function
	/// </summary>
	public class ControlPrinting
	{
		public class PrintContext
		{
			public float FontScale = 1.0f;

			public bool ExcludeControl(Control c)
			{
				return ExclusionList != null ? ExclusionList.Contains(c.Name) : false;
			}

			public List<string> ExclusionList;
		}


		public PrintContext CurrentContext { get; } = new PrintContext();

		/// <summary>
		/// Prints all supported controls onto given graphics object
		/// </summary>
		/// <param name="control">Control to print all its child controls onto the graphics object</param>
		/// <param name="gr">Graphics object to print to</param>
		public void Print(Control control, Graphics gr)
		{
			Print(control, gr, CurrentContext);
		}

		/// <summary>
		/// Prints all supported controls onto given graphics object
		/// </summary>
		/// <param name="control">Control to print all its child controls onto the graphics object</param>
		/// <param name="gr">Graphics object to print to</param>
		/// <param name="Context">Context for this print, contains exlusion lists, font scale, ...</param>
		public void Print(Control control, Graphics gr, PrintContext Context)
		{
			StringFormat format = new StringFormat();
			format.LineAlignment = StringAlignment.Center;

			foreach (Control ctl in control.Controls)
			{
				if (Context.ExcludeControl(ctl))
					continue;

				if (ctl is ContainerControl)
				{
					ContainerControl container = (ContainerControl)ctl;
					gr.TranslateTransform(container.Location.X, container.Location.Y);
					Print(container, gr, Context);
					gr.TranslateTransform(-container.Location.X, -container.Location.Y);
				}
				else if (ctl is Label)
				{
					var lbl = ctl as Label;
					using (Font f = new Font(lbl.Font.FontFamily, lbl.Font.SizeInPoints * Context.FontScale))
					{
						gr.DrawString(lbl.Text, f, System.Drawing.Brushes.Black, lbl.Location.X, lbl.Location.Y);
					}
				}
				else if (ctl is TextBox)
				{
					var txt = ctl as TextBox;
					gr.DrawRectangle(System.Drawing.Pens.DarkGray, txt.Bounds);
					using (Font f = new Font(txt.Font.FontFamily, txt.Font.SizeInPoints * Context.FontScale))
					{
						gr.DrawString(txt.Text, f, System.Drawing.Brushes.Black, txt.Bounds, format);
					}
				}
				else if (ctl is RichTextBox)
				{
					var txt = ctl as RichTextBox;

					gr.DrawRectangle(System.Drawing.Pens.DarkGray, txt.Bounds);
					using (Font f = new Font(txt.Font.FontFamily, txt.Font.SizeInPoints * Context.FontScale))
					{
						gr.DrawString(RichTextStripper.StripRichTextFormat(txt.Rtf), f, System.Drawing.Brushes.Black, txt.Bounds, format);
					}
				}
				else if (ctl is System.Windows.Forms.CheckBox)
				{
					var cbx = ctl as System.Windows.Forms.CheckBox;
					gr.DrawRectangle(System.Drawing.Pens.DarkGray, cbx.Bounds);
					if (cbx.Checked)
					{
						gr.DrawLine(System.Drawing.Pens.Black, cbx.Left, cbx.Top, cbx.Right, cbx.Bottom);
						gr.DrawLine(System.Drawing.Pens.Black, cbx.Right, cbx.Top, cbx.Left, cbx.Bottom);
					}
				}
				else if (ctl is ComboBox)
				{
					ComboBox cbx = ctl as ComboBox;
					gr.DrawRectangle(System.Drawing.Pens.DarkGray, cbx.Bounds);
					using (Font f = new Font(cbx.Font.FontFamily, cbx.Font.SizeInPoints * Context.FontScale))
					{
						gr.DrawString(cbx.Text, f, System.Drawing.Brushes.Black, cbx.Bounds, format);
					}
				}
				else if (ctl is MaskedTextBox)
				{
					MaskedTextBox mtb = ctl as MaskedTextBox;
					gr.DrawRectangle(System.Drawing.Pens.DarkGray, mtb.Bounds);
					if (mtb.MaskCompleted)
					{
						using (Font f = new Font(mtb.Font.FontFamily, mtb.Font.SizeInPoints * Context.FontScale))
						{
							gr.DrawString(mtb.Text, f, System.Drawing.Brushes.Black, mtb.Bounds, format);
						}
					}
				}
				else if (ctl is ListBox)
				{
					ListBox lb = ctl as ListBox;
					gr.DrawRectangle(System.Drawing.Pens.DarkGray, lb.Bounds);
					int entryPositionY = lb.Location.Y;
					using (Font f = new Font(lb.Font.FontFamily, lb.Font.SizeInPoints * Context.FontScale))
					{
						foreach (object entry in lb.Items)
						{
							string entryString = entry.ToString();
							gr.DrawString(entryString, f, System.Drawing.Brushes.Black, lb.Location.X, entryPositionY);
							entryPositionY += lb.ItemHeight;
						}
					}
				}
				else if (ctl is PictureBox)
				{
					var pic = ctl as PictureBox;
					gr.DrawImageUnscaledAndClipped(pic.Image, new Rectangle(pic.Location.X, pic.Location.Y, pic.Width, pic.Height));
				}
			}
		}
	}
}
