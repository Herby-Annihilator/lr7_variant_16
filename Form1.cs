using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lr7_variant_16
{
	public partial class Form1 : Form
	{
		private PointF currentFulcrum;
		private List<BrokenLine> brokenLines = new List<BrokenLine>();
		private BrokenLine currentBrokenLine;
		private bool isStartDraw = true;
		private Color currentColor = Color.Black;
		private float currentPenWidth = 2;
		
		public Form1()
		{
			InitializeComponent();
			SetDefaultSettingsToControls();
			currentBrokenLine = new BrokenLine();
			brokenLines.Add(currentBrokenLine);
		}

		private void SetDefaultSettingsToControls()
		{
			toolStripStatusLabelX.Text = "0";
			toolStripStatusLabelY.Text = "0";
		}

		private void button1_Click(object sender, EventArgs e)
		{

		}

		private void panelCanvas_MouseMove(object sender, MouseEventArgs e)
		{
			toolStripStatusLabelX.Text = e.X.ToString();
			toolStripStatusLabelY.Text = e.Y.ToString();
		}

		private void panelCanvas_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (isStartDraw)
				{
					AddEntryToDataGrid();
					currentFulcrum = e.Location;
					isStartDraw = false;
				}
				currentBrokenLine.Segments.Add(new Segment(currentFulcrum, e.Location, currentColor, currentPenWidth));
				currentFulcrum = e.Location;
			}
			else if (e.Button == MouseButtons.Right)
			{
				isStartDraw = true;
				currentBrokenLine = new BrokenLine();
				brokenLines.Add(currentBrokenLine);
				RandomColor();
			}
			panelCanvas.Invalidate();
		}

		private void AddEntryToDataGrid()
		{
			dataGridView1.Rows.Add();
			dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = brokenLines.Count;
			dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1].Style.BackColor = currentColor;
		}

		private void panelCanvas_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.Clear(Color.White);
			foreach(BrokenLine line in brokenLines)
			{
				line.Draw(e.Graphics);
			}
		}

		private void RandomColor()
		{
			Random random = new Random();
			currentColor = Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
		}

		private void buttonClearCanvas_Click(object sender, EventArgs e)
		{
			panelCanvas.CreateGraphics().Clear(Color.White);
		}
	}
}
