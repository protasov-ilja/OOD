using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using task1.DocumentEditor.Documents.Items;

namespace task1Tests.Items.ImageTests
{
	[TestClass]
	public class ImageTests
    {
		[TestMethod]
		public void CanCreateImageWothCorrectSize()
		{
			var h = new TestHandler();
			TestExecutor executor = new TestExecutor();
			string path = "image.jpg";
			int width1 = 1;
			int height1 = 1;
			Image image1 = new Image(width1, height1, path, executor, h);
			Assert.AreEqual(image1.Width, width1);
			Assert.AreEqual(image1.Height, height1);
			Assert.AreEqual(image1.Path, path);

			int width2 = 10000;
			int height2 = 10000;
			Image image2 = new Image(width2, height2, path, executor, h);
			Assert.AreEqual(image2.Width, width2);
			Assert.AreEqual(image2.Height, height2);
			Assert.AreEqual(image2.Path, path);
		}

		[TestMethod]
		public void CantCreateImageWithWidthMoreThan10000AndLessThan1()
		{
			var h = new TestHandler();
			TestExecutor executor = new TestExecutor();
			string path = "image.jpg";
			int maxWidth = 10000;
			int minWidth = 1;
			int height = 1;
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Image image = new Image(maxWidth + 1, height, path, executor, h); });
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Image image = new Image(minWidth - 1, height, path, executor, h); });
		}

		[TestMethod]
		public void CantCreateImageWithHeightMoreThan10000AndLessThan1()
		{
			var h = new TestHandler();
			TestExecutor executor = new TestExecutor();
			string path = "image.jpg";
			int maxHeight = 10000;
			int minHeight = 1;
			int width = 1;
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Image image = new Image(width, maxHeight + 1, path, executor, h); });
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Image image = new Image(width, minHeight - 1, path, executor, h); });
		}

		[TestMethod]
		public void CantResizeImageIfWidhtOrHeigthNotCorrect()
		{
			var h = new TestHandler();
			TestExecutor executor = new TestExecutor();
			string path = "image.jpg";
			int maxSize = 10000;
			int minSize = 1;
			Image image = new Image(maxSize, minSize, path, executor, h);
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => { image.Resize(maxSize + 1, minSize); });
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => { image.Resize(maxSize, minSize - 1); });
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => { image.Resize(minSize, maxSize + 1); });
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => { image.Resize(minSize - 1, maxSize); });
		}

		[TestMethod]
		public void CanResizeImage()
		{
			var h = new TestHandler();
			TestExecutor executor = new TestExecutor();
			string path = "image.jpg";
			int maxSize = 10000;
			int minSize = 1;
			Image image = new Image(maxSize, minSize, path, executor, h);
			image.Resize(maxSize, minSize);
			image.Resize(minSize, maxSize);
			image.Resize(2, 4);
		}
	}
}
