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
			string imagePath = "D:\\Work\\OOD\\lab5\\lab5\\sth\\sth.jpg";
			Document document = new Document();
			var img = document.InsertImage(imagePath, 1, 1, 0);
			document.Save(path);
			Assert.IsTrue(File.Exists(path + "\\index.html"));
			Assert.IsTrue(File.Exists(path + "\\image\\0.jpg"));
		}

		[TestMethod]
		public void CanSaveDocumentWithoutDeletedImage()
		{
			string path = Directory.GetCurrentDirectory() + "\\temp1";
			string imagePath = "D:\\Work\\OOD\\lab5\\lab5\\sth\\sth.jpg";
			Document document = new Document();
			var img = document.InsertImage(imagePath, 1, 1, 0);
			document.Undo();
			var img1 = document.InsertImage(imagePath, 1, 1, 0);
			Assert.AreEqual(document.GetItemsCount(), 1);
			document.Save(path);
			Assert.IsTrue(File.Exists(path + "\\index.html"));
			Assert.IsFalse(File.Exists(path + "\\image\\0.jpg"));
			Assert.IsTrue(File.Exists(path + "\\image\\1.jpg"));
		}
	}
}
