using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr7_variant_16
{
	public class BrokenLine : Figure
	{
		public Color Color { get; set; } = Color.Black;
		public float Width { get; set; } = 2;
		public List<Segment> Segments { get; set; }
		public BrokenLine()
		{
			Segments = new List<Segment>();
		}
		public override void Draw(Graphics graphics)
		{
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			foreach(var segment in Segments)
			{
				segment.Draw(graphics);
			}
		}
	}

	public class Segment: Figure
	{
		public Color Color { get; set; }
		public float Width { get; set; }
		public Segment(PointF first, PointF second, Color color, float width = 2)
		{
			Width = width;
			Color = color;
			FirstPoint = first;
			SecondPoint = second;
		}
		public PointF FirstPoint { get; private set; }
		public PointF SecondPoint { get; private set; }

		public override void Draw(Graphics graphics)
		{
			graphics.DrawLine(new Pen(Color, Width), FirstPoint, SecondPoint);
		}
	}

	public abstract class Figure
	{
		public abstract void Draw(Graphics graphics);
	}
}
