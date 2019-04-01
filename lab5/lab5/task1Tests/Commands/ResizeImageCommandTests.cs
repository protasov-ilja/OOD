using Microsoft.VisualStudio.TestTools.UnitTesting;
using task1.DocumentEditor.Commands;

namespace task1Tests.Commands
{
	[TestClass]
	public class ResizeImageCommandTests
    {
		[TestMethod]
		public void CanCreateCommandAndReplaceItemText()
		{
			var i = new TestImage();
			int width = 2;
			int height = 2;
			i.Width = width;
			i.Height = height;
			Assert.AreEqual(i.Width, width);
			Assert.AreEqual(i.Height, height);

			int newWidth = 3;
			int newHeight = 10;
			var c = new ResizeImageCommand(i, newWidth, newHeight);
			c.Execute();
			Assert.AreEqual(i.Width, newWidth);
			Assert.AreEqual(i.Height, newHeight);
		}

		[TestMethod]
		public void CanUndoResizeOfImage()
		{
			var i = new TestImage();
			int width = 2;
			int height = 2;
			i.Width = width;
			i.Height = height;
			Assert.AreEqual(i.Width, width);
			Assert.AreEqual(i.Height, height);

			int newWidth = 3;
			int newHeight = 10;
			var c = new ResizeImageCommand(i, newWidth, newHeight);
			c.Execute();
			Assert.AreEqual(i.Width, newWidth);
			Assert.AreEqual(i.Height, newHeight);

			c.Unexecute();
			Assert.AreEqual(i.Width, width);
			Assert.AreEqual(i.Height, height);
		}
	}
}
