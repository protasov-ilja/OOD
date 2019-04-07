using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using task1.DocumentEditor;

namespace task1Tests.EditorTests
{
	[TestClass]
	public class EditorTests
    {
		[TestMethod]
		public void CanInsertParagraph()
		{
			var testCommand = "i-p end text\nexit";
			var strmIn = new StringReader(testCommand);
			var strmOut = new StringWriter();
			Editor e = new Editor();
			e.Run(strmIn, strmOut);
			var testStr = "";
			Assert.AreEqual(testStr, strmOut.ToString());
		}

		[TestMethod]
		public void CantInsertParagraphWithFueArgument1()
		{
			var testCommand = "i-p\nexit";
			var strmIn = new StringReader(testCommand);
			var strmOut = new StringWriter();
			Editor e = new Editor();
			e.Run(strmIn, strmOut);
			var testStr = "Not Enougth arguments 0";
			Assert.IsTrue(strmOut.ToString().Contains(testStr));
		}

		[TestMethod]
		public void CantInsertParagraphWithFueArgument0()
		{
			var testCommand = "i-p 0\nexit";
			var strmIn = new StringReader(testCommand);
			var strmOut = new StringWriter();
			Editor e = new Editor();
			e.Run(strmIn, strmOut);
			var testStr = "Not Enougth arguments 1";
			Assert.IsTrue(strmOut.ToString().Contains(testStr));
		}

		[TestMethod]
		public void CantInsertParagraphWith1ArgumentInZeroPlace()
		{
			var testCommand = "i-p end 1\nexit";
			var strmIn = new StringReader(testCommand);
			var strmOut = new StringWriter();
			Editor e = new Editor();
			e.Run(strmIn, strmOut);
			var testStr = "";
			Assert.AreEqual(strmOut.ToString(), testStr);
		}

		[TestMethod]
		public void CanInsertImage()
		{
			var testCommand = $"i-i end 1 1 {Directory.GetCurrentDirectory()}\\image_test\\t.jpg\nexit";
			var strmIn = new StringReader(testCommand);
			var strmOut = new StringWriter();
			Editor e = new Editor();
			e.Run(strmIn, strmOut);
			Directory.Delete(Directory.GetCurrentDirectory() + "\\image", true);
			var testStr = "";
			Assert.AreEqual(testStr, strmOut.ToString());
		}

		[TestMethod]
		public void CantInsertImageWithFueArguments3()
		{
			var testCommand = $"i-i end 1 1\nexit";
			var strmIn = new StringReader(testCommand);
			var strmOut = new StringWriter();
			Editor e = new Editor();
			e.Run(strmIn, strmOut);
			Directory.Delete(Directory.GetCurrentDirectory() + "\\image", true);
			var testStr = "Not Enougth arguments 3";
			Assert.IsTrue(strmOut.ToString().Contains(testStr));
		}

		[TestMethod]
		public void CantInsertImageWithFueArguments2()
		{
			var testCommand = $"i-i end 1\nexit";
			var strmIn = new StringReader(testCommand);
			var strmOut = new StringWriter();
			Editor e = new Editor();
			e.Run(strmIn, strmOut);
			Directory.Delete(Directory.GetCurrentDirectory() + "\\image", true);
			var testStr = "Not Enougth arguments 2";
			Assert.IsTrue(strmOut.ToString().Contains(testStr));
		}

		[TestMethod]
		public void CantInsertImageWithFueArguments1()
		{
			var testCommand = $"i-i end\nexit";
			var strmIn = new StringReader(testCommand);
			var strmOut = new StringWriter();
			Editor e = new Editor();
			e.Run(strmIn, strmOut);
			Directory.Delete(Directory.GetCurrentDirectory() + "\\image", true);
			var testStr = "Not Enougth arguments 1";
			Assert.IsTrue(strmOut.ToString().Contains(testStr));
		}

		[TestMethod]
		public void CantInsertImageWithFueArguments0()
		{
			var testCommand = $"i-i\nexit";
			var strmIn = new StringReader(testCommand);
			var strmOut = new StringWriter();
			Editor e = new Editor();
			e.Run(strmIn, strmOut);
			Directory.Delete(Directory.GetCurrentDirectory() + "\\image", true);
			var testStr = "Not Enougth arguments 0";
			Assert.IsTrue(strmOut.ToString().Contains(testStr));
		}

		[TestMethod]
		public void CantResizeImageIfNotCorrectIndex()
		{
			var testCommand = $"resize 1 100 100\nexit";
			var strmIn = new StringReader(testCommand);
			var strmOut = new StringWriter();
			Editor e = new Editor();
			e.Run(strmIn, strmOut);
			var testStr = "Specified argument was out of the range of valid values.";
			Console.WriteLine(strmOut.ToString());
			Assert.IsTrue(strmOut.ToString().Contains(testStr));
		}

		[TestMethod]
		public void CantReplaceParagraphIfNotCorrectIndex()
		{
			var testCommand = $"replace 1 100 100\nexit";
			var strmIn = new StringReader(testCommand);
			var strmOut = new StringWriter();
			Editor e = new Editor();
			e.Run(strmIn, strmOut);
			var testStr = "Specified argument was out of the range of valid values.";
			Console.WriteLine(strmOut.ToString());
			Assert.IsTrue(strmOut.ToString().Contains(testStr));
		}

		[TestMethod]
		public void CantRedoCommand()
		{
			var testCommand = $"redo\nexit";
			var strmIn = new StringReader(testCommand);
			var strmOut = new StringWriter();
			Editor e = new Editor();
			e.Run(strmIn, strmOut);
			var testStr = "Can't Redo";
			Console.WriteLine(strmOut.ToString());
			Assert.IsTrue(strmOut.ToString().Contains(testStr));
		}

		[TestMethod]
		public void CantUndoCommand()
		{
			var testCommand = $"undo\nexit";
			var strmIn = new StringReader(testCommand);
			var strmOut = new StringWriter();
			Editor e = new Editor();
			e.Run(strmIn, strmOut);
			var testStr = "Can't Undo";
			Console.WriteLine(strmOut.ToString());
			Assert.IsTrue(strmOut.ToString().Contains(testStr));
		}
	}
}
