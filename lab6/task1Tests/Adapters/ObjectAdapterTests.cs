using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using task1.Adapters;
using task1.ModernGraphicsLib;

namespace task1Tests.Adapters
{
	[TestClass]
	public class ObjectAdapterTests
    {
		[TestMethod]
		public void CanCreateObjectAdapterForModernGraphicRendererAndDrawLineFromStartPosition()
		{
			var writer = new StringWriter();
			var renderer = new ModernGraphicsRenderer(writer);
			var adapter = new MGRendererObjectAdapter(renderer);

			var x = 10;
			var y = 20;

			adapter.Renderer.BeginDraw();
			adapter.LineTo(x, y);
			adapter.Renderer.EndDraw();

			var testString = new StringWriter();
			testString.WriteLine("<draw>");
			testString.WriteLine($"<line fromX={0} fromY={0} toX={x} toY={y}/>");
			testString.WriteLine("</draw>");
			Assert.AreEqual(testString.ToString(), writer.ToString());
		}

		[TestMethod]
		public void CanCreateObjectAdapterForModernGraphicRendererAndDrawLine()
		{
			var writer = new StringWriter();
			var renderer = new ModernGraphicsRenderer(writer);
			var adapter = new MGRendererObjectAdapter(renderer);

			var startX = 1;
			var startY = 1;
			var endX = 10;
			var endY = 20;

			adapter.Renderer.BeginDraw();
			adapter.MoveTo(startX, startY);
			adapter.LineTo(endX, endY);
			adapter.Renderer.EndDraw();

			var testString = new StringWriter();
			testString.WriteLine("<draw>");
			testString.WriteLine($"<line fromX={startX} fromY={startY} toX={endX} toY={endY}/>");
			testString.WriteLine("</draw>");
			Assert.AreEqual(testString.ToString(), writer.ToString());
		}
	}
}
