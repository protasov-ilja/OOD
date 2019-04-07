using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using task1.DocumentEditor.Documents;

namespace task1Tests.DocumentTests
{
	[TestClass]
    public class DocumentTests
    {
		[TestMethod]
		public void CanCreateDocumentAndSetTitle()
		{
			Document document = new Document();
			string title = "text";
			document.SetTitle(title);
			Assert.AreEqual(title, document.GetTitle());
		}

		[TestMethod]
		public void CanInsertPraragraphIfPosLessThanSizeAndPozitiveOrNull()
		{
			{
				Document document = new Document();
				document.InsertParagraph("text");
				Assert.AreEqual(document.GetItemsCount(), 1);
			}

			{
				Document document = new Document();
				document.InsertParagraph("text", 0);
				Assert.AreEqual(document.GetItemsCount(), 1);
			}

			{
				Document document = new Document();
				Assert.ThrowsException<IndexOutOfRangeException>(() => { document.InsertParagraph("text", 2); });
				Assert.ThrowsException<IndexOutOfRangeException>(() => { document.InsertParagraph("text", 1); });
			}
		}

		[TestMethod]
		public void CanInsertImageIfPosLessThanSizeAndPozitiveOrNull()
		{
			{
				Document document = new Document();
				document.InsertImage("text" , 1, 1);
				Assert.AreEqual(document.GetItemsCount(), 1);
			}

			{
				Document document = new Document();
				document.InsertImage("text", 1, 1, 0);
				Assert.AreEqual(document.GetItemsCount(), 1);
			}

			{
				Document document = new Document();
				Assert.ThrowsException<IndexOutOfRangeException>(() => { document.InsertImage("text", 1, 1, 1); });
				Assert.ThrowsException<IndexOutOfRangeException>(() => { document.InsertImage("text", 1, 1, 2); });
			}
		}

		[TestMethod]
		public void CanGetItemByIndexIfIndexInRangeOf0ToDocumentSize()
		{
			Document document = new Document();
			Assert.ThrowsException<IndexOutOfRangeException>(() => { document.GetItem(0); });
			document.InsertImage("text", 1, 1, 0);
			Assert.IsTrue(document.GetItem(0).Image != null);
			Assert.ThrowsException<IndexOutOfRangeException>(() => { document.GetItem(1); });
			Assert.ThrowsException<IndexOutOfRangeException>(() => { document.GetItem(-1); });
		}

		[TestMethod]
		public void CanRedo()
		{
			Document document = new Document();
			Assert.IsFalse(document.CanRedo());
			document.InsertImage("text", 1, 1, 0);
			document.Undo();
			Assert.IsTrue(document.CanRedo());
		}

		[TestMethod]
		public void CanUndo()
		{
			Document document = new Document();
			Assert.IsFalse(document.CanUndo());
			document.InsertImage("text", 1, 1, 0);
			Assert.IsTrue(document.CanUndo());
		}

		[TestMethod]
		public void CanSaveDocumentWithImage()
		{
			string path = Directory.GetCurrentDirectory() + "\\temp";
			string imagePath = Directory.GetCurrentDirectory() + "\\test_image\\t.jpg";
			Document document = new Document();
			var img = document.InsertImage(imagePath, 1, 1, 0);
			document.Save(path);
			Assert.IsTrue(File.Exists(path + "\\index.html"));
			Assert.IsTrue(File.Exists(path + "\\image\\0.jpg"));
			Directory.Delete(path, true);
			Directory.Delete(Directory.GetCurrentDirectory() + "\\image", true);
		}

		[TestMethod]
		public void CanSaveDocumentWithoutDeletedImage()
		{
			string path = Directory.GetCurrentDirectory() + "\\temp";
			string imagePath = Directory.GetCurrentDirectory() + "\\test_image\\t.jpg";
			Document document = new Document();
			var img = document.InsertImage(imagePath, 1, 1, 0);
			document.Undo();
			var img1 = document.InsertImage(imagePath, 1, 1, 0);
			Assert.AreEqual(document.GetItemsCount(), 1);
			document.Save(path);
			Assert.IsTrue(File.Exists(path + "\\index.html"));
			Assert.IsFalse(File.Exists(path + "\\image\\0.jpg"));
			Assert.IsTrue(File.Exists(path + "\\image\\1.jpg"));
			Directory.Delete(path, true);
			Directory.Delete(Directory.GetCurrentDirectory() + "\\image", true);
		}

		[TestMethod]
		public void CanDeleteMarkedImageAfter10Commands()
		{
			string path = Directory.GetCurrentDirectory() + "\\temp";
			string imagePath = Directory.GetCurrentDirectory() + "\\test_image\\t.jpg";
			Document document = new Document();
			var img = document.InsertImage(imagePath, 1, 1, 0);
			document.DeleteItem(0);
			var p3 = document.InsertParagraph("sth");
			var p4 = document.InsertParagraph("sth");
			var p5 = document.InsertParagraph("sth");
			var p6 = document.InsertParagraph("sth");
			var p7 = document.InsertParagraph("sth");
			var p8 = document.InsertParagraph("sth");
			var p9 = document.InsertParagraph("sth");
			var p10 = document.InsertParagraph("sth");
			var p11 = document.InsertParagraph("sth");
			document.Save(path);
			Assert.IsTrue(File.Exists(path + "\\index.html"));
			Assert.IsFalse(File.Exists(Directory.GetCurrentDirectory() + "\\image\\0.jpg"));
			Assert.IsFalse(File.Exists(path + "\\image\\0.jpg"));
			Directory.Delete(path, true);
			Directory.Delete(Directory.GetCurrentDirectory() + "\\image", true);
		}

		[TestMethod]
		public void CanChangeBackSlashesToForwardSlashesInImagePathInHtmlDoc()
		{
			string path = Directory.GetCurrentDirectory() + "\\temp";
			string imagePath = Directory.GetCurrentDirectory() + "\\test_image\\t.jpg";
			Document document = new Document();
			var img = document.InsertImage(imagePath, 1, 1, 0);
			document.Save(path);
			Assert.IsTrue(File.Exists(path + "\\index.html"));
			var testStr = $"<img src=\"{ "image/0.jpg" }\" width=\"{ 1 }\" height=\"{ 1 }\"/>";
			using (StreamReader sr = new StreamReader(path + "\\index.html"))
			{
				var isFound = false;
				var str = sr.ReadLine();
				while (str != null)
				{
					if (str == testStr)
					{
						isFound = true;
						break;
					}

					str = sr.ReadLine();
				}

				Assert.IsTrue(isFound);
				sr.Close();
			}

			Directory.Delete(path, true);
			Directory.Delete(Directory.GetCurrentDirectory() + "\\image", true);
		}

		[TestMethod]
		public void CanSetrelativePathToImageInHtmlDoc()
		{
			string path = Directory.GetCurrentDirectory() + "\\temp";
			string imagePath = Directory.GetCurrentDirectory() + "\\test_image\\t.jpg";
			Document document = new Document();
			var img = document.InsertImage(imagePath, 1, 1, 0);
			document.Save(path);
			Assert.IsTrue(File.Exists(path + "\\index.html"));
			var testStr = $"<img src=\"{ "image/0.jpg" }\" width=\"{ 1 }\" height=\"{ 1 }\"/>";
			using (StreamReader sr = new StreamReader(path + "\\index.html"))
			{
				var isFound = false;
				var str = sr.ReadLine();
				while (str != null)
				{
					if (str == testStr)
					{
						isFound = true;
						break;
					}

					str = sr.ReadLine();
				}

				Assert.IsTrue(isFound);
				sr.Close();
			}

			Directory.Delete(path, true);
			Directory.Delete(Directory.GetCurrentDirectory() + "\\image", true);
		}

		[TestMethod]
		public void CanEncodeSpecialSimbolsToHtmlFormatInTitle()
		{
			string path = Directory.GetCurrentDirectory() + "\\temp";
			string imagePath = Directory.GetCurrentDirectory() + "\\test_image\\t&.jpg";
			Document document = new Document();
			var img = document.InsertImage(imagePath, 1, 1, 0);
			var htmlStr = "<-- hello  world -->  &end";
			var stringTitle = $"  <title>&lt;-- hello  world --&gt;  &amp;end </title>";
			document.SetTitle(htmlStr);
			document.Save(path);
			Assert.IsTrue(File.Exists(path + "\\index.html"));
			using (StreamReader sr = new StreamReader(path + "\\index.html"))
			{
				var isFound = false;
				var str = sr.ReadLine();
				while (str != null)
				{
					Console.WriteLine(str);
					if (str == stringTitle)
					{
						isFound = true;
						break;
					}

					str = sr.ReadLine();
				}

				Assert.IsTrue(isFound);
				sr.Close();
			}

			Directory.Delete(path, true);
			Directory.Delete(Directory.GetCurrentDirectory() + "\\image", true);
		}

		[TestMethod]
		public void CanEncodeSpecialSimbolsToHtmlFormatInParagraph()
		{
			string path = Directory.GetCurrentDirectory() + "\\temp";
			Document document = new Document();
			var htmlStr = "<-- hello  world -->  &end";
			var p = document.InsertParagraph(htmlStr);
			var stringParagraph = $"<p>&lt;-- hello  world --&gt;  &amp;end</p>";
			document.Save(path);
			Assert.IsTrue(File.Exists(path + "\\index.html"));
			using (StreamReader sr = new StreamReader(path + "\\index.html"))
			{
				var isFound = false;
				var str = sr.ReadLine();
				while (str != null)
				{
					Console.WriteLine(str);
					if (str == stringParagraph)
					{
						isFound = true;
						break;
					}

					str = sr.ReadLine();
				}

				Assert.IsTrue(isFound);
				sr.Close();
			}

			Directory.Delete(path, true);
			Directory.Delete(Directory.GetCurrentDirectory() + "\\image", true);
		}
	}
}
