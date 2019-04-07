using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using task1.Adapters;

namespace task1Tests.Adapters
{
	[TestClass]
	public class ClassAdapterTests
    {
		[TestMethod]
		public void CanCreateClassAdapterForModernGraphicRendererAndDrawLineFromStartPosition()
		{
			var writer = new StringWriter();
			var adapter = new MGRendererClassAdapter(writer);

			var x = 10;
			var y = 20;

			adapter.BeginDraw();
			adapter.LineTo(x, y);
			adapter.EndDraw();

			var testString = new StringWriter();
			testString.WriteLine("<draw>");
			testString.WriteLine($"<line fromX={0} fromY={0} toX={x} toY={y}/>");
			testString.WriteLine("</draw>");
			Assert.AreEqual(testString.ToString(), writer.ToString());
		}

		[TestMethod]
		public void CanCreateClassAdapterForModernGraphicRendererAndDrawLine()
		{
			var writer = new StringWriter();
			var adapter = new MGRendererClassAdapter(writer);

			var startX = 1;
			var startY = 1;
			var endX = 10;
			var endY = 20;

			adapter.BeginDraw();
			adapter.MoveTo(startX, startY);
			adapter.LineTo(endX, endY);
			adapter.EndDraw();

			var testString = new StringWriter();
			testString.WriteLine("<draw>");
			testString.WriteLine($"<line fromX={startX} fromY={startY} toX={endX} toY={endY}/>");
			testString.WriteLine("</draw>");
			Assert.AreEqual(testString.ToString(), writer.ToString());
		}
	}
}
