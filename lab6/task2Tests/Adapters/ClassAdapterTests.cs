using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.IO;
using task2.Adapters;

namespace task2Tests.Adapters
{
	[TestClass]
	public class ClassAdapterTests
    {
		[TestMethod]
		public void CanCreateClassAdapterForModernGraphicRendererAndDrawLineFromStartPositionWithDefaultColor()
		{
			var writer = new StringWriter();
			var adapter = new MGRendererClassAdapter(writer);

			var x = 10;
			var y = 20;

			adapter.BeginDraw();
			adapter.LineTo(x, y);
			adapter.EndDraw();
			var testColor = Color.Black;
			var testString = new StringWriter();
			testString.WriteLine("<draw>");
			testString.WriteLine($"<line fromX={0} fromY={0} toX={x} toY={y}>");
			testString.WriteLine($"<color r={testColor.R} g={testColor.G} b={testColor.B} a={testColor.A} />");
			testString.WriteLine($"</line>");
			testString.WriteLine("</draw>");
			Assert.AreEqual(testString.ToString(), writer.ToString());
		}

		[TestMethod]
		public void CanCreateClassAdapterForModernGraphicRendererAndDrawLineWithColor()
		{
			var writer = new StringWriter();
			var adapter = new MGRendererClassAdapter(writer);

			var startX = 1;
			var startY = 1;
			var endX = 10;
			var endY = 20;
			var testColor = Color.Coral;

			adapter.BeginDraw();
			adapter.SetColor((uint)testColor.ToArgb());
			adapter.MoveTo(startX, startY);
			adapter.LineTo(endX, endY);
			adapter.EndDraw();

			var testString = new StringWriter();
			testString.WriteLine("<draw>");
			testString.WriteLine($"<line fromX={startX} fromY={startY} toX={endX} toY={endY}>");
			testString.WriteLine($"<color r={testColor.R} g={testColor.G} b={testColor.B} a={testColor.A} />");
			testString.WriteLine($"</line>");
			testString.WriteLine("</draw>");
			Assert.AreEqual(testString.ToString(), writer.ToString());
		}
	}
}
