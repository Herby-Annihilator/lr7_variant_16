using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lr7_variant_16
{
	public class Reshala
	{
		public BrokenLine First { get; set; }
		public BrokenLine Second { get; set; }
		public Reshala(BrokenLine first, BrokenLine second)
		{
			First = first;
			Second = second;
		}
		//public bool Poreshat()
		//{

		//}

		private float Area(PointF a, PointF b, PointF c)
		{
			return (b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X);
		}
		private bool Intersect_1(float a, float b, float c, float d)
		{
			if (a > b) Swap(ref a, ref b);
			if (c > d) Swap(ref c, ref d);
			return Math.Max(a, c) <= Math.Min(b, d);
		}

		private bool Intersect(PointF a, PointF b, PointF c, PointF d)
		{
			return Intersect_1(a.X, b.X, c.X, d.X)
				&& Intersect_1(a.Y, b.Y, c.Y, d.Y)
				&& Area(a, b, c) * Area(a, b, d) <= 0
				&& Area(c, d, a) * Area(c, d, b) <= 0;
		}

		private void Swap(ref float x, ref float y)
		{
			float z = x;
			x = y;
			y = z;
		}
	}


	public class ScanLine
	{
		private List<Segment> IntersectingSegments { get; set; }
		private PointF ScaningPoint { get; set; }

		private Segment[] firstBrokenLine;
		private Segment[] secondBrokenLine;

		public ScanLine(BrokenLine first, BrokenLine second)
		{
			firstBrokenLine = first.Segments.ToArray();
			firstBrokenLine.OrderByDescending((segment) => { return Math.Min(segment.FirstPoint.X, segment.SecondPoint.X); });
			secondBrokenLine = second.Segments.ToArray();
			secondBrokenLine.OrderByDescending((segment) => { return Math.Min(segment.FirstPoint.X, segment.SecondPoint.X); });
			ScaningPoint = new PointF();
			IntersectingSegments = new List<Segment>();
		}

		public bool Scan(Func<Segment, Segment, bool> IsIntersect)
		{
			int firstBrokenLineSegmentIndex = 0;
			int secondBrokenLineSegmentIndex = 0;
			do
			{
				if (firstBrokenLine[firstBrokenLineSegmentIndex].)
			} while (!IsIntersect());
		}
	}
}
