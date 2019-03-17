using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Task1.Painter;
using Task1.Painter.Enums;

namespace Task1Tests.Shapes
{
	class TestCanvas : ICanvas
	{
		public Color Color { get; set; }

		public List<string> ExpectedData { get; set; } = new List<string>();

		public int Counter { get; set; } = 0;

		public void DrawEllipse(double l, double t, double width, double height)
		{
			Assert.AreEqual($"{l} {t} {width} {height}", ExpectedData[Counter]);
			Counter++;
		}

		public void DrawLine(Point from, Point to)
		{
			Assert.AreEqual($"{from} {to}", ExpectedData[Counter]);
			Counter++;
		}
	}
}
