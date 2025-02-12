using System.Windows.Forms;

namespace SteKoLib
{
    public partial class ChangeLogWindow : Form
	{
		public ChangeLogWindow()
		{
			InitializeComponent();
		}

		public string History
		{
			get { return rtbHistory.Text; }
			set { rtbHistory.Text = value; }
		}
	}
}
